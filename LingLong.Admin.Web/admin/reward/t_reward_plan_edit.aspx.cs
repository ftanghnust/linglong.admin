using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.reward
{
    public partial class t_reward_plan_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected int id = 0;
        private static Model.manager managermodel;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            managermodel = GetAdminInfo();
            if(managermodel == null && managermodel.id ==0)
                JscriptMsg("添加信息成功！", "../login.aspx");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["ID"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.t_reward_plan().Exists(this.id))
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
                RptBind("1=1", "CreationTime asc,id desc");
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            //this.page = DTRequest.GetQueryInt("page", 1);
            //txtKeywords.Text = this.keywords;
            BLL.t_reward_goods bll = new BLL.t_reward_goods();
            this.rptList.DataSource = bll.GetList("PlanId = " + id);
            this.rptList.DataBind();

            //绑定页码
            //txtPageNum.Text = this.pageSize.ToString();
            //string pageUrl = Utils.CombUrlTxt("t_reward_plan_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            //PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.t_reward_plan bll = new BLL.t_reward_plan();
            Model.t_reward_plan model = bll.GetModel(_id);
            txt_PlanName.Text = model.PlanName;            
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
            Model.t_reward_plan model = new Model.t_reward_plan();
            BLL.t_reward_plan bll = new BLL.t_reward_plan();
            model.PlanName = txt_PlanName.Text;
            if (rad_IsDefault01.Checked) model.IsDefault = 0;
            else model.IsDefault = 1;
            if (rad_IsUse01.Checked) model.IsUse = 0;
            else model.IsUse = 1;
            if (rad_IsDeleted01.Checked) model.IsDeleted = 0;
            else model.IsDeleted = 1;
            model.CreatorUserId = managermodel.id;
            model.CreationTime = DateTime.Now;
            return bll.Add(model);
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.t_reward_plan model = new Model.t_reward_plan();
            BLL.t_reward_plan bll = new BLL.t_reward_plan();            
            if (rad_IsDefault01.Checked) model.IsDefault = 0;
            else model.IsDefault = 1;
            if (rad_IsUse01.Checked) model.IsUse = 0;
            else model.IsUse = 1;
            if (rad_IsDeleted01.Checked) model.IsDeleted = 0;
            else model.IsDeleted = 1;
            model.LastModifierUserId = managermodel.id;
            model.LastModificationTime = DateTime.Now;
            return bll.Add(model);
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
                JscriptMsg("修改信息成功！", "t_reward_plan_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("sys_rewardmoney", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加信息成功！", "t_reward_plan_list.aspx");
            }
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("sys_rewardmoney", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.t_reward_goods bll = new BLL.t_reward_goods();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除方案" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("t_reward_plan_list.aspx", "keywords={0}", ""));
        }
    }
}