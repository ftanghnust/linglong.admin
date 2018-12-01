using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.score
{
    public partial class sys_service_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string businessName = string.Empty;
        protected string storeName = string.Empty;
        protected string customerName = string.Empty;
        protected string evaluateTime = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.businessName = DTRequest.GetQueryString("businessName");
            this.storeName = DTRequest.GetQueryString("storeName");
            this.customerName = DTRequest.GetQueryString("customerName");
            this.evaluateTime = DTRequest.GetQueryString("evaluateTime");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_service", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得当前管理员信息
                RptBind("1=1" + CombSqlTxt(storeName, businessName, customerName, evaluateTime), "id desc");
            }


        }


        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtStoreName.Text = this.storeName;
            txtBusinessName.Text = this.businessName;
            txtCustomerName.Text = this.customerName;
            txtEvaluateTime.Text = this.evaluateTime;


            BLL.t_service_evaluation bll = new BLL.t_service_evaluation();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("sys_service_list.aspx", "storeName={0}&businessName={1}&customerName={2}&evaluateTime={3}&page={4}", storeName, businessName, customerName, evaluateTime,"__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _storeName, string _businessName, string _customerName, string _evaluateTime)
        {
            StringBuilder strTemp = new StringBuilder();

            _businessName = _businessName.Replace("'", "");
            _storeName = _storeName.Replace("'", "");
            _customerName = _customerName.Replace("'", "");
            _evaluateTime = _evaluateTime.Replace("'", "");
            if (!string.IsNullOrEmpty(_businessName))
            {
                strTemp.Append(" and (d.TrueName like '%" + _businessName + "%' or d.Nickname like '%" + _businessName + "%' )");
            }
            if (!string.IsNullOrEmpty(_storeName))
            {
                strTemp.Append(" and b.StoreName like '%" + _storeName + "%'");
            }
            if (!string.IsNullOrEmpty(_customerName))
            {
                strTemp.Append(" and (c.TrueName like '%" + _customerName + "%' or c.Nickname like '%" + _customerName + "%' )");
            }
            if (!string.IsNullOrEmpty(_evaluateTime))
            {
                strTemp.Append(" and a.EvaluateTime <='" + _evaluateTime + "'");
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
            var businessName = this.txtBusinessName.Text;
            var storeName = this.txtStoreName.Text;
            var customerName = this.txtCustomerName.Text;
            var evaluateTime = this.txtEvaluateTime.Text;
            Response.Redirect(Utils.CombUrlTxt("sys_service_list.aspx", "storeName={0}&businessName={1}&customerName={2}&evaluateTime={3}", storeName, businessName, customerName, evaluateTime));
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
            Response.Redirect(Utils.CombUrlTxt("sys_service_list.aspx", "storeName={0}&businessName={1}&customerName={2}&evaluateTime={3}", storeName, businessName, customerName, evaluateTime));
        }

    }
}