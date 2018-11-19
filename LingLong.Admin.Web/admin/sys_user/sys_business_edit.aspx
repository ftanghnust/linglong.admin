<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_business_edit.aspx.cs" Inherits="LingLong.Admin.Web.admin.sys_user.sys_business_edit" %>

<%@ Import Namespace="LingLong.Admin.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title></title>
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
            <a href="sys_agent_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="sys_business_list.aspx"><span>商户管理</span></a>
            <i class="arrow"></i>
            <span>编辑商户</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">编辑商户</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <%--<dl>
                <dt>是否管理员</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_IsManage" runat="server" datatype="*" CssClass="select" sucmsg=" ">
                            <asp:ListItem Value="0" Text="否"></asp:ListItem>
                            <asp:ListItem Value="1" Text="是"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>--%>
            <dl>
                <dt>真实姓名</dt>
                <dd>
                    <asp:TextBox ID="txt_TrueName" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <%--<dl>
                <dt>代理商编号</dt>
                <dd>
                    <asp:TextBox ID="txt_AgentCode" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
            </dl>--%>
            <dl>
                <dt>昵称</dt>
                <dd>
                    <asp:TextBox ID="txt_Nickname" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>性别</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_Gender" runat="server" datatype="*" CssClass="select" sucmsg=" ">
                            <asp:ListItem Value="0" Text="未知"></asp:ListItem>
                            <asp:ListItem Value="1" Text="男"></asp:ListItem>
                            <asp:ListItem Value="2" Text="女"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>头像</dt>
                <dd>
                    <asp:Image ID="img_AvatarUrl" Width="60" Height="60" runat="server" /></dd>
            </dl>
            <%--<dl>
                <dt>状态</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_State" runat="server" datatype="*" CssClass="select" sucmsg=" ">
                            <asp:ListItem Value="0" Text="待审核"></asp:ListItem>
                            <asp:ListItem Value="1" Text="启用"></asp:ListItem>
                            <asp:ListItem Value="2" Text="禁用"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>--%>
            <dl>
                <dt>电话</dt>
                <dd>
                    <asp:TextBox ID="txt_PhoneNumber" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>地址</dt>
                <dd>
                    <asp:TextBox ID="txt_Country" runat="server" CssClass="input normal" Width="80"></asp:TextBox>
                    <asp:TextBox ID="txt_Province" runat="server" CssClass="input normal" Width="80"></asp:TextBox>
                    <asp:TextBox ID="txt_City" runat="server" CssClass="input normal" Width="80"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>籍贯</dt>
                <dd>
                    <asp:TextBox ID="txt_NativePlace" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>身高</dt>
                <dd>
                    <asp:TextBox ID="txt_Height" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>生日</dt>
                <dd>
                    <asp:TextBox ID="txt_Birthday" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <%--<dl>
                <dt>服务人员</dt>
                <dd>
                    <div class="table-container">
                        <asp:Repeater ID="rptList" runat="server">
                            <HeaderTemplate>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                                    <tr>
                                        <th width="5%">选择</th>
                                        <th width="5%">ID</th>
                                        <th width="5%">是否管理员</th>
                                        <th width="8%">真实姓名</th>
                                        <th width="5%">代理商编号</th>
                                        <th width="5%">昵称</th>
                                        <th width="5%">性别</th>
                                        <th width="8%">头像</th>
                                        <th width="8%">手机号码</th>
                                        <th width="8%">籍贯</th>
                                        <th width="5%">身高</th>
                                        <th width="8%">生日</th>
                                        <th width="8%">注册时间</th>
                                        <th width="8%">状态</th>
                                        <th width="5%"></th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                    </td>
                                    <td align="center"><%# Eval("ID").ToString() %></td>
                                    <td align="center"><%# Eval("IsManage").ToString() == "0"?"否":"是" %></td>
                                    <td align="center"><a href="sys_agent_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>"><%# Eval("TrueName") %></a></td>
                                    <td align="center"><%# Eval("AgentCode") %></td>
                                    <td align="center"><%# Eval("Nickname") %></td>
                                    <td align="center"><%# Eval("Gender").ToString() == "1"?"男":"女" %></td>
                                    <td align="center">
                                        <image src="<%# Eval("AvatarUrl") %>" style="width: 120px; height: 80px;"></image>
                                    </td>
                                    <td align="center"><%# Eval("PhoneNumber") %></td>
                                    <td align="center"><%# Eval("Country").ToString() +Eval("Province").ToString() + Eval("City").ToString()+Eval("NativePlace").ToString() %></td>
                                    <td align="center"><%# Eval("Height") %></td>
                                    <td align="center"><%# Eval("Birthday") %></td>
                                    <td align="center"><%# Eval("RegisterTime") %></td>
                                    <td align="center"><%# Eval("State").ToString() == "0" ? "待审核" : (Eval("State").ToString() == "1" ? "启用":"禁用") %></td>
                                    <td align="center"><a href="sys_agent_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
  </table>
 
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </dd>
            </dl>--%>
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
