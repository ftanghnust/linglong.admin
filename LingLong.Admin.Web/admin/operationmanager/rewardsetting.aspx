<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rewardsetting.aspx.cs" Inherits="LingLong.Admin.Web.admin.operationmanager.rewardsetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>打赏金额设置</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>打赏金额设置</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <%--<li><a class="add" href="reward_distribution_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>--%>
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
                            <th align="center" width="8%">方案名称</th>
                            <th align="center" width="12%">平台分配比例</th>
                            <th align="center" width="8%">代理商分配比例</th>
                            <th align="center" width="8%">门店分配比例</th>
                            <th align="center" width="8%">服务人员分配比例</th>
                            <th align="center" width="4%">是否默认方案</th>
                            <th align="center" width="5%">是否使用方案</th>
                            <th align="center" width="8%">是否删除</th>
                            <th align="center" width="5%">删除用户Id</th>
                            <th align="center" width="5%">最后编辑时间</th>
                            <th align="center" width="5%">最后编辑用户Id</th>
                            <th align="center" width="5%">创建时间</th>
                            <th align="center" width="5%">创建用户Id</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        
                        <td align="center"><%#Eval("DistributionName") %></td>
                        <td align="center"><%#Eval("PlatformRatio")%></td>
                        <td align="center"><%#Eval("AgentRatio")%></td>
                        <td align="center"><%#Eval("StoreRatio")%></td>
                        <td align="center"><%#Eval("BusinessRatio")%></td>
                        <td align="center"><%#Eval("IsDefault").ToString().Trim() == "0" ? "默认" : "非默认"%></td>
                        <td align="center"><%#Eval("IsUse").ToString().Trim() == "0" ? "使用" : "未使用"%></td>
                        <td align="center"><%#Eval("IsDeleted").ToString().Trim() == "0" ? "正常" : "删除"%></td>
                        <td align="center"><%#Eval("DeleterUserId")%></td>
                        <td align="center"><%#Eval("LastModificationTime")%></td>
                        <td align="center"><%#Eval("LastModifierUserId")%></td>
                        <td align="center"><%#Eval("CreationTime")%></td>
                        <td align="center"><%#Eval("CreatorUserId")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
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
