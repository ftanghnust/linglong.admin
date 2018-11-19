using LingLong.Admin.Common;
using LingLong.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LingLong.Admin.Model.HTTPModel;

namespace LingLong.Admin.Web.admin.message
{
    public partial class EditParticulars : Web.UI.ManagePage
    {
        private string access_token;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取公众号getAccessToken
            string result = HttpHelper.Send("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid="
                + ConfigHelper.GetConfigAppSettings("appid") + "&secret=" + ConfigHelper.GetConfigAppSettings("secret"), "get", "", null);
            HTTPModel.getAccessToken token = new HTTPModel.getAccessToken();
            token = (HTTPModel.getAccessToken)JosnHelper.JsonToObject(result, token);
            access_token = token.access_token;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            //var data = new {
            //    touser = ConfigHelper.GetConfigAppSettings("appid"),
            //    weapp_template_msg = new weapp_template_msg() {
            //        template_id = txt_template_id.Text,
            //        page = txt_page.Text,
            //        form_id = txt_form_id.Text,
            //        data = txt_data.Text,
            //        emphasis_keyword = txt_emphasis_keyword.Text,
            //    },
            //    mp_template_msg = new mp_template_msg() {
            //        appid = ConfigHelper.GetConfigAppSettings("appid"),
            //        template_id = txt_template_id.Text,
            //        url = txt_url.Text,
            //        miniprogram = txt_miniprogram.Text,
            //        data = txt_data.Text,
            //    }
            //};

            string result = HttpHelper.Send("https://api.weixin.qq.com/cgi-bin/message/wxopen/template/uniform_send?access_token=ACCESS_TOKEN", "post", JosnHelper.ObjectToJson(""), null);
            HTTPModel.result_template_msg msg = new HTTPModel.result_template_msg();
            msg = (HTTPModel.result_template_msg)JosnHelper.JsonToObject(result, msg);

        }
    }
}