﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core
{
    public class ToolVcode
    {
        public static  MemoryStream GetValidateImg(out string code, string bgImg)
        {
            code = GetRandomString(4);
            Random rnd = new Random();
            System.Drawing.Bitmap img = new System.Drawing.Bitmap((int)Math.Ceiling((code.Length * 17.2)), 28);
            System.Drawing.Image bg = System.Drawing.Bitmap.FromFile(bgImg);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);
            System.Drawing.Font font = new System.Drawing.Font("Arial", 16, (System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Italic));
            System.Drawing.Font fontbg = new System.Drawing.Font("Arial", 16, (System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), System.Drawing.Color.Blue, System.Drawing.Color.DarkRed, 1.2f, true);
            g.DrawImage(bg, 0, 0, new System.Drawing.Rectangle(rnd.Next(bg.Width - img.Width), rnd.Next(bg.Height - img.Height), img.Width, img.Height), System.Drawing.GraphicsUnit.Pixel);
            g.DrawString(code, fontbg, System.Drawing.Brushes.White, 0, 1);
            g.DrawString(code, font, System.Drawing.Brushes.ForestGreen, 0, 1);//字颜色

            //画图片的背景噪音线 
            int x = img.Width;
            int y1 = rnd.Next(5, img.Height);
            int y2 = rnd.Next(5, img.Height);
            g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Green, 2), 1, y1, x - 2, y2);
            g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Transparent), 0, 10, img.Width - 1, img.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms;
        }

        private static string GetRandomString(int length)
        {
            int number;
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random(Math.Abs(Guid.NewGuid().GetHashCode()));
            for (int i = 0; i < length; i++)
            {
                char code;
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                if (code.Equals('o') || code.Equals('0'))//去除O或者0
                {
                    length += 1;
                    continue;
                }
                stringBuilder.Append(code);
            }
            return stringBuilder.ToString();
        }
    }
}
