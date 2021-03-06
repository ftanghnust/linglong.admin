﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_reward_list.aspx.cs" Inherits="LingLong.Admin.Web.admin.score.sys_reward_list" %>

<%@ Import Namespace="LingLong.Admin.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>打赏数据</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>打赏数据</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <%--<div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="reward_distribution_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>--%>
                    <div class="r-list">
                        <table>
                            <tr>
                                <td><span>门店名称</span></td>
                                <td>
                                    <asp:TextBox ID="txtStoreName" runat="server" CssClass="keyword" /></td>
                                <td><span>被打赏人</span></td>
                                <td>
                                    <asp:TextBox ID="txtBusinessName" runat="server" CssClass="keyword" /></td>
                                <td><span>打赏人</span></td>
                                <td>
                                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="keyword" /></td>
                                <td><span>打赏时间</span></td>
                                <td>
                                    <asp:TextBox ID="txtRewardTime" runat="server"  class="input rule-date-input" onfocus="WdatePicker({dateFmt:&#39;yyyy-MM-dd HH:mm:ss&#39;})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <%--<th width="5%">选择</th>--%>
                       <%--     <th align="center" width="10%">ID</th>--%>
                            <th align="center" width="10%">打赏订单号</th>
                            <th align="center" width="10%">打赏人</th>
                            <th align="center" width="10%">打赏时间</th>
                            <th align="center" width="10%">打赏金额</th>
                            <th align="center" width="10%">被打赏人</th>
                         <%--   <th align="center" width="5%">所属门店Id</th>--%>
                            <th align="center" width="5%">门店名称</th>
                            <th align="center" width="5%">门店所属代理商</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                    <%--    <td align="center"><%# Eval("ID") %></td>--%>
                        <td align="center"><%# Eval("PaymentNo") %></td>
                        <td align="center"><%# Eval("CustomerName") %></td>
                        <td align="center"><%# Eval("RewardTime") %></td>
                        <td align="center"><%# Eval("Money") %></td>
                        <td align="center"><%# Eval("BusinessName") %></td>
                <%--        <td align="center"><%# Eval("StoreId") %></td>--%>
                        <td align="center"><%# Eval("StoreName") %></td>
                        <td align="center"><%# Eval("AgentName") %></td>
                       <%-- <td align="center"><%#Convert.ToDecimal( Eval("DistributionRatio").ToString())* 100 %>%</td>
                        <td align="center"><%# Eval("UserType").ToString() == "0"?"平台":(Eval("UserType").ToString() == "1"?"代理商":(Eval("UserType").ToString() == "2"?"门店":"服务员")) %></td>
                        <td align="center"><%# Eval("RewardMoney") %></td>
                        <td align="center"><%# Eval("BenefitMoney") %></td>--%>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"14\">暂无记录</td></tr>" : ""%>
  </table>
 
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                    OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
