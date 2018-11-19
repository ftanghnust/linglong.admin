using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingLong.Admin.Common
{
    public static class ConfigHelper
    {
        /// <summary>
        /// 获取配置文件中的字符串
        /// </summary>
        /// <param name="namaStr">字符串名称</param>
        /// <returns></returns>
        public static string GetConfigConnectionStrings(string namaStr)
        {
            string result = string.Empty;
            try
            {
                result = System.Configuration.ConfigurationManager.ConnectionStrings[namaStr].ConnectionString;
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 获取配置文件中的参数
        /// </summary>
        /// <param name="nameStr"></param>
        /// <returns></returns>
        public static string GetConfigAppSettings(string nameStr)
        {
            string result = string.Empty;
            try
            {
                result = System.Configuration.ConfigurationManager.AppSettings[nameStr];
            }
            catch { }
            return result;
        }

        /// <summary>
        /// 设置配置文件
        /// </summary>
        public static void SetConfigConnectionStrings()
        {

        }
    }
}
