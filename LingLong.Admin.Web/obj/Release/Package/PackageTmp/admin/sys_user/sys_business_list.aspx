<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_business_list.aspx.cs" Inherits="LingLong.Admin.Web.admin.sys_user.sys_business_list" %>

<%@ Import Namespace="LingLong.Admin.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>商户管理</title>
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
            <span>商户管理</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="sys_business_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
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
                            <th width="5%" align="center">选择</th>
                            <%--<th width="5%" align="center">ID</th>--%>
                            <%--<th width="5%">是否管理员</th>--%>
                            <th width="8%" align="center">真实姓名</th>
                            <th width="5%" align="center">门店名</th>
                            <th width="5%" align="center">昵称</th>
                            <th width="5%" align="center">角色ID</th>
                            <th width="5%" align="center">性别</th>
                            <th width="8%" align="center">头像</th>
                            <th width="8%" align="center">手机号码</th>
                            <th width="8%" align="center">籍贯</th>
                            <%--<th width="5%">身高</th>
                            <th width="8%">生日</th>--%>
                            <th width="8%" align="center">注册时间</th>
                            <%--<th width="8%">状态</th>--%>
                            <th width="5%"></th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <%--<td align="center"><%# Eval("ID") %></td>--%>
                        <%--<td align="center"><%# Eval("IsManage").ToString() == "0"?"否":"是" %></td>--%>
                        <td align="center"><a href="sys_business_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>"><%# Eval("TrueName") %></a></td>
                        <%--<td align="center"><%# Eval("Wechat") %></td>--%>
                        <td align="center"><%# Eval("StoreName") %></td>
                        <td align="center"><%# Eval("Nickname") %></td>                        
                        <td align="center"><%# Eval("RoleId") %></td>
                        <td align="center"><%# Eval("Gender").ToString() == "1"?"男":"女" %></td>
                        <td align="center">
                            <image src="<%# Eval("AvatarUrl") %>" style="width:120px;height:80px;"></image>
                        </td>
                        <td align="center"><%# Eval("PhoneNumber") %></td>
                        <td align="center"><%# Eval("Country").ToString() +Eval("Province").ToString() + Eval("City").ToString()+Eval("NativePlace").ToString() %></td>
                        <%--<td align="center"><%# Eval("Height") %></td>
                        <td align="center"><%# Eval("Birthday") %></td>--%>
                        <td align="center"><%# Eval("RegisterTime") %></td>
                        <%--<td align="center"><%# Eval("State").ToString() == "0" ? "待审核" : (Eval("State").ToString() == "1" ? "启用":"禁用") %></td>--%>
                        <td align="center">
                            <a href="sys_business_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a>
                            <a href="sys_business_edit.aspx?action=<%#DTEnums.ActionEnum.Delete %>&id=<%#Eval("r_ID")%>">删除</a>
                        </td>
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
