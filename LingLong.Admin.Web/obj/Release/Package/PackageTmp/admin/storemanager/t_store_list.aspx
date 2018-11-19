<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_store_list.aspx.cs" Inherits="LingLong.Admin.Web.admin.storemanager.t_store_list" %>

<%@ Import Namespace="LingLong.Admin.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>门店管理</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>门店管理</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="manager_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
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
                            <th align="center" width="8%">选择</th>
                            <th align="center" width="4%">ID</th>
                            <th align="center">门店名称</th>
                            <th align="center" width="10%">申请人OpenId</th>
                            <th align="center" width="10%">门店电话</th>
                            <th align="center" width="10%">门店图片链接</th>
                            <th align="center" width="12%">详细地址</th>
                            <th align="center" width="4%">状态</th>
                            <th align="center" width="4%">门店评分</th>
                            <th align="center" width="8%">创建时间</th>
                            <th align="center" width="8%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td align="center"><%# Eval("ID") %></td>
                        <td align="center"><a href="t_store_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%# Eval("StoreName") %></a></td>
                        <td align="center"><%# Eval("ApplyOpenId") %></td>
                        <td align="center"><%# Eval("PhoneNumber") %></td>
                        <td align="center"><%# Eval("StoreImgUrl") %></td>
                        <td align="center"><%# Eval("Province").ToString() + Eval("City").ToString() + Eval("Area").ToString() + Eval("Address").ToString() %></td>
                        <td align="center"><%# Eval("State").ToString() == "0" ? "待审核": (Eval("State").ToString() == "1"?"启用":"禁用") %></td>
                        <td align="center"><%# Eval("Score") %></td>
                        <td align="center"><%# Eval("CreationTime") %></td>
                        <%--<td><%#new LingLong.Admin.BLL.manager_role().GetTitle(Convert.ToInt32(Eval("role_id")))%></td>
                        <td><%# Eval("telephone") %></td>
                        <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
                        <td align="center"><%#Eval("is_lock").ToString().Trim() == "0" ? "正常" : "禁用"%></td>--%>
                        <td align="center"><a href="t_store_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
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
