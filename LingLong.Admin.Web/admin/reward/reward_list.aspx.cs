using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.reward
{
    public partial class reward_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

 
        protected string withdrawname = string.Empty;
        protected string withdrawtime = string.Empty;
        protected string stateid = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.withdrawname = DTRequest.GetQueryString("withdrawname");
            this.withdrawtime = DTRequest.GetQueryString("withdrawtime");
            this.stateid = DTRequest.GetQueryString("stateid");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_pay", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得当前管理员信息
                RptBind("1=1" + CombSqlTxt(withdrawname, withdrawtime, stateid), "CreationTime DESC");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtWithdrawName.Text = this.withdrawname;
            txtWithdrawTime.Text = this.withdrawtime;
            ddl_State.Text = this.stateid;

            BLL.t_withdraw bll = new BLL.t_withdraw();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("reward_list.aspx", "withdrawname={0}&withdrawtime={1}&stateid={2}&page={3}", withdrawname, withdrawtime, stateid, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _withdrawname, string _withdrawtime, string _stateid)
        {
            StringBuilder strTemp = new StringBuilder();
            _withdrawname = _withdrawname.Replace("'", "");
            _withdrawtime = _withdrawtime.Replace("'", "");
            _stateid = _stateid.Replace("'", "");
           
            if (!string.IsNullOrEmpty(_withdrawname))
            {
                strTemp.Append(" and (c.TrueName like '%" + _withdrawname + "%' or c.Nickname like '%" + _withdrawname + "%' or  d.TrueName like '%" + _withdrawname + "%' or d.Nickname like '%" + _withdrawname + "%')");
            }
            if (!string.IsNullOrEmpty(_withdrawtime))
            {
                strTemp.Append(" and a.WithdrawTime <='" + _withdrawtime + "'");
            }
            if (!string.IsNullOrEmpty(_stateid))
            {
                strTemp.Append(" and a.State =" + _stateid + "");
            }


            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("reward_list", "DTcmsPage"), out _pagesize))
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
            var withdrawname = this.txtWithdrawName.Text;
            var withdrawtime = this.txtWithdrawTime.Text;
            var stateid = this.ddl_State.SelectedItem.Value;
            Response.Redirect(Utils.CombUrlTxt("reward_list.aspx", "withdrawname={0}&withdrawtime={1}&stateid={2}", withdrawname, withdrawtime, stateid));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("reward_list", "DTcmsPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("reward_list.aspx", "withdrawname={0}&withdrawtime={1}&stateid={2}", withdrawname, withdrawtime, stateid));
        }
    }
}