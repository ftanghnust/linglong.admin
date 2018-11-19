<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_agent_edit.aspx.cs" Inherits="LingLong.Admin.Web.admin.sys_user.sys_agent_edit" %>

<%@ Import Namespace="LingLong.Admin.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑管理员</title>
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
            <a href="sys_agent_list.aspx"><span>代理商管理</span></a>
            <i class="arrow"></i>
            <span>编辑代理商</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">编辑代理商</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>是否管理员</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddl_IsManage" runat="server" datatype="*" CssClass="select" sucmsg=" " Enabled="false">
                            <asp:ListItem Value="0" Text="否" Selected="True" ></asp:ListItem>
                            <asp:ListItem Value="1" Text="是"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>真实姓名</dt>
                <dd>
                    <asp:TextBox ID="txt_TrueName" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>代理商编号</dt>
                <dd>
                    <asp:TextBox ID="txt_AgentCode" runat="server" CssClass="input normal" Enabled="false"></asp:TextBox>
            </dl>
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
            <dl>
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
            </dl>
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
