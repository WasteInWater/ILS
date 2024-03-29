﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wms.Core.Service
{
    public interface ISysCacheService
    {
        Task<bool> DelAsync(string key);
        Task<bool> DelByPatternAsync(string key);
        List<string> GetAllCacheKeys();
        Task<List<long>> GetDataScope(long userId);
        Task<List<LayuiMenu>> GetMenu(long userId, string appCode);
        Task<List<string>> GetPermission(long userId);
        Task SetDataScope(long userId, List<long> dataScopes);
        Task SetMenu(long userId, string appCode, List<LayuiMenu> menus);
        Task SetPermission(long userId, List<string> permissions);
        Task<bool> SetAsync(string key, object value);
        Task<string> GetAsync(string key);
        Task<T> GetAsync<T>(string key);
    }
}