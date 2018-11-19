using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LingLong.Admin.Web.admin.reward
{
    /// <summary>
    /// t_reward_distribution_handle 的摘要说明
    /// </summary>
    public class t_reward_distribution_handle : System.Web.UI.Page, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            BLL.t_reward_distribution bll = new BLL.t_reward_distribution();
            Model.t_reward_distribution model = bll.GetModel(id);
            string _action = context.Request.QueryString["action"];
            if (_action == DTEnums.ActionEnum.Confirm.ToString())
            {
                bll.SetStatus();
                model.IsDefault = 1;
                bll.Update(model);
                //JscriptMsg("启用成功！", "reward_distribution_list.aspx");
                context.Response.Write("parent.jsprint(\"启用成功！\", \"reward_distribution_list.aspx\")");
                context.Response.Redirect("reward_distribution_list.aspx");
            }
            else if (_action == DTEnums.ActionEnum.Invalid.ToString())
            {
                model.IsDefault = 0;
                bll.Update(model);
                //JscriptMsg("禁用成功！", "reward_distribution_list.aspx");
                //context.Response.Write("parent.jsprint(\"启用成功！\", \"reward_distribution_list.aspx\")");
                context.Response.Redirect("reward_distribution_list.aspx");
            }
        }

        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        protected void JscriptMsg(string msgtitle, string url)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}