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
            if (!Page.IsPostBack)
            {
                //string result = HttpHelper.Send("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid="
                //+ ConfigHelper.GetConfigAppSettings("appid") + "&secret=" + ConfigHelper.GetConfigAppSettings("secret"), "get", "", null);
                //HTTPModel.getAccessToken token = new HTTPModel.getAccessToken();
                //token = (HTTPModel.getAccessToken)JosnHelper.JsonToObject(result, token);
                //access_token = token.access_token;
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() == "")
            {
                JscriptMsg("消息内容不能为空！", "SendPublicMessage.aspx?#");
            }

            if (rbt_type1.Checked && txtOpenId.Text.Trim() == "")
            {
                JscriptMsg("无效的接收人，请填写接收人！", "SendPublicMessage.aspx?#");
            }

            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "");
                return;
            }
            JscriptMsg("添加信息成功！", "SendPublicMessage.aspx");
        }

        private bool DoAdd()
        {
            Model.t_templatemessage model = new Model.t_templatemessage();
            BLL.t_templatemessage bll = new BLL.t_templatemessage();

            var type = 0;
            if (rbt_type1.Checked)
            {
                type = 1;
            }
            if (rbt_type2.Checked)
            {
                if (drp_SelectPe.SelectedItem.Text == "客户")
                {
                    type = 2;
                }
                else
                {
                    type = 3;
                }
            }
            model.Type = type;
            model.OpenId = txtOpenId.Text;
            model.Message = txtMessage.Text;
            model.IsDeleted = 0;
            model.CreationTime = DateTime.Now;

            if (bll.Add(model))
            {
                return true;
            }
            return false;
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

        protected void rbt_type1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_type1.Checked)
            {
                dl_df.Visible = true;
                dl_qf.Visible = false;
            }
        }

        protected void rbt_type2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_type2.Checked)
            {
                dl_df.Visible = false;
                dl_qf.Visible = true;
            }
        }
    }
}