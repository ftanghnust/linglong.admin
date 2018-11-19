using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.storemanager
{
    public partial class t_store_edit : Web.UI.ManagePage
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
                if (!new BLL.t_store().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_store", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.t_store bll = new BLL.t_store();
            Model.t_store model = bll.GetModel(_id);

            txt_StoreName.Text = model.StoreName;
            txt_PhoneNumber.Text = model.PhoneNumber;
            img_StoreImgUrl.ImageUrl = model.StoreImgUrl;
            txt_Area.Text = model.Area;
            txt_City.Text = model.City;
            txt_Province.Text = model.Province;
            txt_Address.Text = model.Address;
            txt_Score.Text = model.Score.ToString();
            drp_State.SelectedValue = model.State.ToString();
            drp_IsDeleted.SelectedValue = model.IsDeleted.ToString();
            txt_PlanId.Text = model.PlanId.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.t_store model = new Model.t_store();
            BLL.t_store bll = new BLL.t_store();
            model.StoreName = txt_StoreName.Text;
            model.PhoneNumber = txt_PhoneNumber.Text;
            model.StoreImgUrl = img_StoreImgUrl.ImageUrl;
            model.Area = txt_Area.Text;
            model.City = txt_City.Text;
            model.Province = txt_Province.Text;
            model.Address = txt_Address.Text;
            model.Score = Convert.ToDecimal(txt_Score.Text);
            model.State = Convert.ToInt32(drp_State.SelectedValue);
            model.IsDeleted = Convert.ToInt32(drp_IsDeleted.SelectedValue);
            model.PlanId = txt_PlanId.Text.Trim() == "" ? 0 :Convert.ToInt32(txt_PlanId.Text);
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
            BLL.t_store bll = new BLL.t_store();
            Model.t_store model = bll.GetModel(_id);

            model.StoreName = txt_StoreName.Text;
            model.PhoneNumber = txt_PhoneNumber.Text;
            model.StoreImgUrl = img_StoreImgUrl.ImageUrl;
            model.Area = txt_Area.Text;
            model.City = txt_City.Text;
            model.Province = txt_Province.Text;
            model.Address = txt_Address.Text;
            model.Score = Convert.ToDecimal(txt_Score.Text);
            model.State = Convert.ToInt32(drp_State.SelectedValue);
            model.IsDeleted = Convert.ToInt32(drp_IsDeleted.SelectedValue);
            model.PlanId = txt_PlanId.Text.Trim() == "" ? 0 : Convert.ToInt32(txt_PlanId.Text);
            model.ID = _id;

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
                ChkAdminLevel("sys_store", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("修改门店信息成功！", "t_store_list.aspx");
            }
            else //添加
            {
                ChkAdminLevel("manager_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "");
                    return;
                }
                JscriptMsg("添加门店信息成功！", "t_store_list.aspx");
            }
        }
    }
}