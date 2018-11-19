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
    public partial class SendPublicMessage : Web.UI.ManagePage
    {
        private string access_token;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取公众号getAccessToken
            if (!Page.IsPostBack) {
                string result = HttpHelper.Send("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid="
                + ConfigHelper.GetConfigAppSettings("appid") + "&secret=" + ConfigHelper.GetConfigAppSettings("secret"), "get", "", null);
                HTTPModel.getAccessToken token = new HTTPModel.getAccessToken();
                token = (HTTPModel.getAccessToken)JosnHelper.JsonToObject(result, token);
                access_token = token.access_token;
            }                
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            //if (txt_template_id.Text.Trim() == "")
            //{
            //    JscriptMsg("无效的接收人，请填写接收人！", "SendPublicMessage.aspx?#");
            //}
            //var data = new SendMessageToUser
            //{
            //    touser = txt_template_id.Text,
            //    msgtype = "text",
            //    text = new MessageText
            //    {
            //        content = txt_MessageText.InnerText
            //    }
            //    //weapp_template_msg = new weapp_template_msg() {
            //    //    template_id = txt_template_id.Text,
            //    //    page = txt_page.Text,
            //    //    form_id = txt_form_id.Text,
            //    //    data = txt_data.Text,
            //    //    emphasis_keyword = txt_emphasis_keyword.Text,
            //    //},
            //    //mp_template_msg = new mp_template_msg() {
            //    //    appid = ConfigHelper.GetConfigAppSettings("appid"),
            //    //    template_id = txt_template_id.Text,
            //    //    url = txt_url.Text,
            //    //    miniprogram = txt_miniprogram.Text,
            //    //    data = txt_data.Text,
            //    //}
            //};

            //string result = HttpHelper.Send("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + access_token, "post", JosnHelper.ObjectToJson(data), null);
            //HTTPModel.result_template_msg msg = new HTTPModel.result_template_msg();
            //msg = (HTTPModel.result_template_msg)JosnHelper.JsonToObject(result, msg);
            //if (msg.errcode != 0)
            //{
            //    JscriptMsg("发送成功！", "SendPublicMessage.aspx?#");
            //}
            //else
            //{
            //    JscriptMsg("发送失败！", "SendPublicMessage.aspx?#");
            //}
        }

        public class MessageText
        {
            public string content { set; get; }
        }

        public class SendMessageToUser
        {
            public string touser { set; get; }

            public string msgtype { set; get; }

            public MessageText text { set; get; }
        }
    }
}