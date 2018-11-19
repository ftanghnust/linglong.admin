<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_reward_plan_edit.aspx.cs" Inherits="LingLong.Admin.Web.admin.reward.t_reward_plan_edit" %>

<%@ Import Namespace="LingLong.Admin.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑打赏方案</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="sys_rewardmoney_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="sys_rewardmoney_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%=id%>"><span>打赏金额设置</span></a>
            <i class="arrow"></i>
            <span>编辑打赏信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">编辑打赏信息</a></li>
                    </ul>
                </div>
            </div>
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="sys_rewardmoney_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>&planid=<%=id%>"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th align="center" width="5%">选择</th>
                            <th align="center" width="5%">ID</th>
                            <th align="center" width="15%">商品名称</th>
                            <th align="center" width="5%">打赏规则Id</th>
                            <th align="center" width="15%">商品图片地址</th>
                            <th align="center" width="10%">商品金额</th>
                            <th align="center" width="10%">创建时间</th>
                            <th align="center" width="5%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                        </td>
                        <th align="center"><%#Eval("ID")%></th>
                        <td align="center"><a href="sys_rewardmoney_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>&planid=<%=id%>"><%# Eval("GoodsName") %></a></td>
                        <td align="center"><%# Eval("PlanId") %></td>
                        <td align="center"><image src="<%# Eval("GoodsImgUrl") %>" style="width:120px;height:80px;"></image></td>
                        <td align="center"><%# Eval("Money") %></td>
                        <td align="center"><%# Eval("CreationTime").ToString() %></td>
                        <td align="center"><a href="sys_rewardmoney_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&planid=<%=id%>">修改</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="tab-content">

            <dl>
                <dt>方案名称</dt>
                <dd>
                    <asp:TextBox ID="txt_PlanName" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>是否默认方案</dt>
                <dd>
                    <asp:RadioButton runat="server" ID="rad_IsDefault01" GroupName="IsDefault" Text="否" /><asp:RadioButton runat="server" ID="rad_IsDefault02" GroupName="IsDefault" Text="是" Checked="true" />
            </dl>
            <dl>
                <dt>是否使用</dt>
                <dd>
                    <asp:RadioButton runat="server" ID="rad_IsUse01" GroupName="IsUse" Text="否" /><asp:RadioButton runat="server" ID="rad_IsUse02" GroupName="IsUse" Text="是" Checked="true" /></dd>
            </dl>
            <dl>
                <dt>是否删除</dt>
                <dd>
                    <asp:RadioButton runat="server" ID="rad_IsDeleted01" GroupName="IsDeleted" Text="否" Checked="true" /><asp:RadioButton runat="server" ID="rad_IsDeleted02" GroupName="IsDeleted" Text="是" /></dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
