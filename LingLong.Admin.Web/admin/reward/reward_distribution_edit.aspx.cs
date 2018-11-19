using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.reward
{
    public partial class sys_rewardmoney_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private static Model.manager managermodel;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            managermodel = GetAdminInfo();
            if (managermodel == null && managermodel.id == 0)
                JscriptMsg("添加信息成功！", "../login.aspx");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.t_reward_distribution().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_rewardmoney", DTEnums.ActionEnum.View.ToString()); //检查权限
                                                                                      //Model.manager 
                                                                                      //取得管理员信息
                                                                                      //RoleBind(ddlRoleId, model.role_type);
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.t_reward_distribution bll = new BLL.t_reward_distribution();
            Model.t_reward_distribution model = bll.GetModel(_id);
            txt_DistributionName.Text = model.DistributionName;
            txt_PlatformRatio.Text = (model.PlatformRatio * 100).ToString();
            txt_AgentRatio.Text = (model.AgentRatio * 100).ToString();
            txt_StoreRatio.Text = (model.StoreRatio * 100).ToString();
            txt_BusinessRatio.Text = (model.BusinessRatio * 100).ToString();
            txt_DistributionName.Text = model.DistributionName;
            if (model.IsDefault == 1) rad_IsDefault02.Checked = true;
            else rad_IsDefault01.Checked = true;
            if (model.IsUse == 1) rad_IsUse02.Checked = true;
            else rad_IsUse01.Checked = true;
            if (model.IsDeleted == 1) rad_IsDeleted02.Checked = true;
            else rad_IsDeleted01.Checked = true;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.t_reward_distribution model = new Model.t_reward_distribution();
            BLL.t_reward_distribution bll = new BLL.t_reward_distribution();
            model.DistributionName = txt_DistributionName.Text;
            decimal outp;
            decimal.TryParse(txt_PlatformRatio.Text, out outp);
            model.PlatformRatio = outp / 100;
            decimal.TryParse(txt_AgentRatio.Text, out outp);
            model.AgentRatio = outp / 100;
            decimal.TryParse(txt_StoreRatio.Text, out outp);
            model.StoreRatio = outp / 100;
            decimal.TryParse(txt_BusinessRatio.Text, out outp);
            model.BusinessRatio = outp / 100;
            model.DistributionName = txt_DistributionName.Text;
            if (rad_IsDefault01.Checked) model.IsDefault = 0;
            else model.IsDefault = 1;
            if (rad_IsUse01.Checked) model.IsUse = 0;
            else model.IsUse = 1;
            if (rad_IsDeleted01.Checked) model.IsDeleted = 0;
            else model.IsDeleted = 1;
            model.CreatorUserId = managermodel.id;
            model.CreationTime = DateTime.Now;

            if (model.IsDefault == 1)
                bll.SetStatus();

            return bll.Add(model);
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.t_reward_distribution model = new Model.t_reward_distribution();
            BLL.t_reward_distribution bll = new BLL.t_reward_distribution();
            model.DistributionName = txt_DistributionName.Text;
            decimal outp;
            decimal.TryParse(txt_PlatformRatio.Text, out outp);
            model.PlatformRatio = outp / 100;
            decimal.TryParse(txt_AgentRatio.Text, out outp);
            model.AgentRatio = outp / 100;
            decimal.TryParse(txt_StoreRatio.Text, out outp);
            model.StoreRatio = outp / 100;
            decimal.TryParse(txt_BusinessRatio.Text, out outp);
            model.BusinessRatio = outp / 100;
            model.DistributionName = txt_DistributionName.Text;
            if (rad_IsDefault01.Checked) model.IsDefault = 0;
            else model.IsDefault = 1;
            if (rad_IsUse01.Checked) model.IsUse = 0;
            else model.IsUse = 1;
            if (rad_IsDeleted01.Checked) model.IsDeleted = 0;
            else model.IsDeleted = 1;
            model.LastModifierUserId = managermodel.id;
            model.LastModificationTime = DateTime.Now;
            model.ID = _id;
            if (model.IsDefault == 1)
                bll.SetStatus();

            return bll.Update(model);
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("sys_rewardmoney", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改信息成功！", "reward_distribution_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("sys_rewardmoney", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加信息成功！", "reward_distribution_list.aspx");
            }
        }
    }
}