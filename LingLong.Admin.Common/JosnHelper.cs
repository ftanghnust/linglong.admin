using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LingLong.Admin.Common
{
    public static class JosnHelper
    {
        // 从一个对象信息生成Json串
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }

        // 从一个Json串生成对象信息
        public static object JsonToObject(string jsonString, object obj)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                return serializer.ReadObject(mStream);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 转化为JSON格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonString<T>(this T obj) where T : class
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            //解决json对象过长时无法序列化问题
            jsonSerializer.MaxJsonLength = int.MaxValue;
            var str = jsonSerializer.Serialize(obj);
            return ReplaceDatetimeString(str); ;
        }

        /// <summary>
        /// 将时间由"\/Date(1228372204484)\/" 格式转换成 "yyyy-MM-dd HH:mm:ss" 格式的字符串
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static string GetDatetimeString(Match m)
        {
            string sRet = "";
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime(); // dt是UniversalTime
            sRet = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return sRet;
        }

        /// <summary>
        /// 将时间由"\/Date(1228372204484)\/" 格式转换成 "yyyy-MM-dd HH:mm:ss" 格式的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string ReplaceDatetimeString(string str)
        {
            //将时间由"\/Date(1228372204484)\/" 格式转换成 "yyyy-MM-dd HH:mm:ss" 格式的字符串
            string sPattern = @"\\/Date\((\d+)\)\\/";
            MatchEvaluator myMatchEvaluator = new MatchEvaluator(GetDatetimeString);
            Regex reg = new Regex(sPattern);
            return reg.Replace(str, myMatchEvaluator);
        }
    }
}
