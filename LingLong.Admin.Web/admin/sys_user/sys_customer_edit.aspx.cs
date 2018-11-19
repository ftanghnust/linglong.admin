using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.sys_user
{
    public partial class sys_customer_edit : Web.UI.ManagePage
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
                if (!new BLL.t_customer().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_customer", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得管理员信息
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
            BLL.t_customer bll = new BLL.t_customer();
            Model.t_customer model = bll.GetModel(_id);
            ddl_CustomerType.SelectedValue = model.CustomerType.ToString();
            txt_TrueName.Text = model.TrueName;
            txt_Wechat.Text = model.Wechat;
            txt_Nickname.Text = model.Nickname;
            ddl_Gender.SelectedValue = model.Gender.ToString();
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
            Model.t_customer model = new Model.t_customer();
            BLL.t_customer bll = new BLL.t_customer();
            model.CustomerType = Convert.ToInt32(ddl_CustomerType.SelectedValue);
            model.TrueName = txt_TrueName.Text;
            model.Wechat = txt_Wechat.Text;
            model.Nickname = txt_Nickname.Text;
            model.Gender = Convert.ToInt32(ddl_Gender.SelectedValue);
            model.AvatarUrl = img_AvatarUrl.ImageUrl;
            model.PhoneNumber = txt_PhoneNumber.Text;
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
            BLL.t_customer bll = new BLL.t_customer();
            Model.t_customer model = bll.GetModel(_id);
            model.ID = _id;
            model.CustomerType = Convert.ToInt32(ddl_CustomerType.SelectedValue);
            model.TrueName = txt_TrueName.Text;
            model.Wechat = txt_Wechat.Text;
            model.Nickname = txt_Nickname.Text;
            model.Gender = Convert.ToInt32(ddl_Gender.SelectedValue);
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
                ChkAdminLevel("sys_customer", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改管理员信息成功！", "sys_customer_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("sys_customer", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加管理员信息成功！", "sys_customer_list.aspx");
            }
        }
    }
}