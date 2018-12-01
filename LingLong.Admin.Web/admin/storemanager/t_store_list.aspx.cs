using LingLong.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LingLong.Admin.Web.admin.storemanager
{
    public partial class t_store_list : Web.UI.ManagePage
    {

        protected int totalCount;
        protected int page;
        protected int pageSize;

 
        protected string agentname = string.Empty;
        protected string storeName = string.Empty;
        protected string createtime = string.Empty;
        protected string stateId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.agentname = DTRequest.GetQueryString("agentname");
            this.storeName = DTRequest.GetQueryString("storeName");
            this.createtime = DTRequest.GetQueryString("createtime");
            this.stateId = DTRequest.GetQueryString("stateId");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_store", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得当前管理员信息
                RptBind("1=1" + CombSqlTxt(agentname, storeName, createtime, stateId), "CreationTime desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtAgentName.Text = this.agentname;
            txtStoreName.Text = this.storeName;
            txtCreateTime.Text = this.createtime;
            ddl_State.Text = this.stateId;

            BLL.t_store bll = new BLL.t_store();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("t_store_list.aspx", "agentname={0}&storeName={1}&createtime={2}&stateId={3}&page={4}", agentname, storeName, createtime, stateId, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _agentname, string _storeName, string _createtime, string _stateId)
        {
            StringBuilder strTemp = new StringBuilder();
            _agentname = _agentname.Replace("'", "");
            _storeName = _storeName.Replace("'", "");
            _createtime = _createtime.Replace("'", "");
            _stateId = _stateId.Replace("'", "");
            if (!string.IsNullOrEmpty(_agentname))
            {
                strTemp.Append(" and (d.TrueName like '%" + _agentname + "%' or d.Nickname like '%" + _agentname + "%' )");
            }
            if (!string.IsNullOrEmpty(_storeName))
            {
                strTemp.Append(" and a.StoreName like '%" + _storeName + "%'");
            }
            if (!string.IsNullOrEmpty(_createtime))
            {
                strTemp.Append(" and a.CreationTime <='" + _createtime + "'");
            }
            if (!string.IsNullOrEmpty(_stateId))
            {
                if (_stateId == "000")
                {
                    strTemp.Append(" and a.State =0");
                }
                else
                {
                    strTemp.Append(" and a.State =" + _stateId + "");
                }
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
            var agentname = this.txtAgentName.Text;
            var storeName = this.txtStoreName.Text;
            var createtime = this.txtCreateTime.Text;
            var stateId = this.ddl_State.SelectedItem.Value;
            Response.Redirect(Utils.CombUrlTxt("t_store_list.aspx", "agentname={0}&storeName={1}&createtime={2}&stateId={3}", agentname, storeName, createtime, stateId));
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
            Response.Redirect(Utils.CombUrlTxt("manager_list.aspx", "agentname={0}&storeName={1}&createtime={2}&stateId={3}", agentname, storeName, createtime, stateId));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("sys_store", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.t_store bll = new BLL.t_store();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除管理员" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("manager_list.aspx", "agentname={0}&storeName={1}&createtime={2}&stateId={3}", agentname, storeName, createtime, stateId));
        }
    }
}