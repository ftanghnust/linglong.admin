﻿using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.sys_user
{
    public partial class sys_business_list : Web.UI.ManagePage
    {

        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string telphone = string.Empty;
        protected string storeName = string.Empty;
        protected string roleId = string.Empty;
        protected string stateId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.telphone = DTRequest.GetQueryString("telphone");
            this.storeName = DTRequest.GetQueryString("storeName");
            this.roleId = DTRequest.GetQueryString("roleId");
            this.stateId = DTRequest.GetQueryString("stateId");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_business", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得当前管理员信息
                RptBind(" b.ID is not null " + CombSqlTxt(telphone, storeName, roleId, stateId), "CreationTime desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtTelPhone.Text = this.telphone;
            txtStoreName.Text = this.storeName;
            ddl_Role.Text = this.roleId;
            ddl_State.Text = this.stateId;

            BLL.t_business bll = new BLL.t_business();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("sys_business_list.aspx", "telphone={0}&storeName={1}&roleId={2}&stateId={3}&page={4}", telphone, storeName, roleId, stateId, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _telphone, string _storeName, string _roleId, string _stateId)
        {
            StringBuilder strTemp = new StringBuilder();
            _telphone = _telphone.Replace("'", "");
            _storeName = _storeName.Replace("'", "");
            _roleId = _roleId.Replace("'", "");
            _stateId = _stateId.Replace("'", "");
            if (!string.IsNullOrEmpty(_telphone))
            {
                strTemp.Append(" and b.PhoneNumber like '%" + _telphone + "%'");
            }
            if (!string.IsNullOrEmpty(_storeName))
            {
                strTemp.Append(" and c.StoreName like '%" + _storeName + "%'");
            }
            if (!string.IsNullOrEmpty(_roleId))
            {
                strTemp.Append(" and a.RoleId =" + _roleId + "");
            }
            if (!string.IsNullOrEmpty(_stateId))
            {
                strTemp.Append(" and a.State =" + _stateId + "");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manager_page_size", "DTcmsPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var telphone = this.txtTelPhone.Text;
            var storeName = this.txtStoreName.Text;
            var roleId = this.ddl_Role.SelectedItem.Value;
            var stateId = this.ddl_State.SelectedItem.Value;
            Response.Redirect(Utils.CombUrlTxt("sys_business_list.aspx", "telphone={0}&storeName={1}&roleId={2}&stateId={3}", telphone, storeName, roleId, stateId));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manager_page_size", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("sys_business_list.aspx", "telphone={0}&storeName={1}&roleId={2}&stateId={3}", telphone, storeName, roleId, stateId));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("sys_business", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.t_business bll = new BLL.t_business();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("sys_business_list.aspx", "telphone={0}&storeName={1}&roleId={2}&stateId={3}", telphone, storeName, roleId, stateId));
        }
    }
}