using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingLong.Admin.Model
{
    public class HTTPModel
    {

        public class getAccessToken
        {
            public string access_token { set; get; }

            public int expires_in { set; get; }
            public int errcode { set; get; }
            public string errmsg { set; get; }
        }


        public class weapp_template_msg
        {
            public string template_id { set; get; }
            public string page { set; get; }
            public string form_id { set; get; }

            public string data { set; get; }
            public string emphasis_keyword { set; get; }
        }

        public class mp_template_msg
        {
            public string appid { set; get; }
            public string template_id { set; get; }
            public string url { set; get; }

            public string miniprogram { set; get; }
            public string data { set; get; }
        }

        public class result_template_msg
        {
            public int errcode { set; get; }
            public string errmsg { set; get; }
        }
    }
}
