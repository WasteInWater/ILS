using Furion;
using Furion.DataEncryption;
using Microsoft.AspNetCore.SignalR;
using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wms.Core.Service;

namespace Wms.Core
{
    public class SignalRHub:Hub
    {
        private readonly ISysCacheService _sysCache;
        public SignalRHub(ISysCacheService sysCache)
        {
            _sysCache = sysCache;
        }

        // 定义一个方法供客户端调用
        public  Task SendMessage(string message, List<string> userIds, string userName = "")
        {
            // 触发客户端定义监听的方法
            return  Clients.Groups(userIds).SendAsync("ReceiveMessage", userName.IsNullOrWhiteSpace() ? "系统" : userName, message);
        }
        public override async Task OnConnectedAsync()
        {
            
            var token = Context.GetHttpContext().Request.Query["access_token"];
            var claims = JWTEncryption.ReadJwtToken(token)?.Claims;
            
            var userId = claims.FirstOrDefault(e => e.Type == ClaimConst.Claim_UserId)?.Value;
            if (string.IsNullOrEmpty(userId)) return;
            
            var onlineUsers = await _sysCache.GetAsync<List<OnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER);
            if (onlineUsers == null) onlineUsers = new List<OnlineUser>();

            await Groups.AddToGroupAsync(Context.ConnectionId, userId);

            onlineUsers.Add(new OnlineUser
            {
                ConnectionId = Context.ConnectionId,
                UserId = long.Parse(userId),
                LastTime = DateTime.Now
            });
            await _sysCache.SetAsync(CommonConst.CACHE_KEY_ONLINE_USER, onlineUsers);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (!string.IsNullOrEmpty(Context.ConnectionId))
            {
                var onlineUsers = await _sysCache.GetAsync<List<OnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER);
                if (onlineUsers == null) return;

                long remuserId = onlineUsers.Find(u => u.ConnectionId == Context.ConnectionId).UserId;
                await Groups.RemoveFromGroupAsync(Context.ConnectionId,remuserId.ToString());

                onlineUsers.RemoveAll(u => u.ConnectionId == Context.ConnectionId);
                await _sysCache.SetAsync(CommonConst.CACHE_KEY_ONLINE_USER, onlineUsers);
            }
        }
    }
}
