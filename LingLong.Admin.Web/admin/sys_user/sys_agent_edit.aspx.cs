using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.sys_user
{
    public partial class sys_agent_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.t_agent().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_agent", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得管理员信息
                //RoleBind(ddlRoleId, model.role_type);
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void RoleBind(DropDownList ddl, int role_type)
        {
            BLL.manager_role bll = new BLL.manager_role();
            DataTable dt = bll.GetList("").Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["role_type"]) >= role_type)
                {
                    ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.t_agent bll = new BLL.t_agent();
            Model.t_agent model = bll.GetModel(_id);
            ddl_IsManage.SelectedValue = model.IsManage.ToString();
            txt_TrueName.Text = model.TrueName;
            txt_AgentCode.Text = model.AgentCode;
            txt_Nickname.Text = model.Nickname;
            ddl_Gender.SelectedValue = model.Gender.ToString();
            ddl_State.SelectedValue = model.State.ToString();
            img_AvatarUrl.ImageUrl = model.AvatarUrl;
            txt_PhoneNumber.Text = model.PhoneNumber;
            txt_Country.Text = model.Country;
            txt_Province.Text = model.Province;
            txt_City.Text = model.City;
            txt_NativePlace.Text = model.NativePlace;
            txt_Height.Text = model.Height.ToString();
            txt_Birthday.Text = model.Birthday.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.t_agent model = new Model.t_agent();
            BLL.t_agent bll = new BLL.t_agent();
            model.IsManage = Convert.ToInt32(ddl_IsManage.SelectedValue);
            model.TrueName = txt_TrueName.Text;
            model.AgentCode = txt_AgentCode.Text;
            model.Nickname = txt_Nickname.Text;
            model.Gender = Convert.ToInt32(ddl_Gender.SelectedValue);
            model.AvatarUrl = img_AvatarUrl.ImageUrl;
            model.PhoneNumber = txt_PhoneNumber.Text;
            model.State = Convert.ToInt32(ddl_State.SelectedValue); 
            model.Country = txt_Country.Text;
            model.Province = txt_Province.Text;
            model.City = txt_City.Text;
            model.NativePlace = txt_NativePlace.Text;
            model.Height = Convert.ToDecimal(txt_Height.Text);
            model.Birthday = txt_Birthday.Text == "" ? DateTime.Now : Convert.ToDateTime(txt_Birthday.Text);
            model.CreationTime = DateTime.Now;

            if (bll.Add(model))
            {
                //AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加管理员:" + model.user_name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.t_agent bll = new BLL.t_agent();
            Model.t_agent model = bll.GetModel(_id);
            model.ID = _id;
            model.IsManage = Convert.ToInt32(ddl_IsManage.SelectedValue);
            model.TrueName = txt_TrueName.Text;
            model.AgentCode = txt_AgentCode.Text;
            model.Nickname = txt_Nickname.Text;
            model.Gender = Convert.ToInt32(ddl_Gender.SelectedValue);
            model.State = Convert.ToInt32(ddl_State.SelectedValue);
            model.AvatarUrl = img_AvatarUrl.ImageUrl;
            model.PhoneNumber = txt_PhoneNumber.Text;
            model.Country = txt_Country.Text;
            model.Province = txt_Province.Text;
            model.City = txt_City.Text;
            model.NativePlace = txt_NativePlace.Text;
            model.Height = Convert.ToDecimal(txt_Height.Text);
            model.Birthday = txt_Birthday.Text == "" ? DateTime.Now : Convert.ToDateTime(txt_Birthday.Text);
            model.LastModificationTime = DateTime.Now;

            if (bll.Update(model))
            {
                //AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改管理员:" + model.user_name); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("sys_agent", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改管理员信息成功！", "sys_agent_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("sys_agent", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加管理员信息成功！", "sys_agent_list.aspx");
            }
        }
    }
}