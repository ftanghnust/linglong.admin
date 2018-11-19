<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reward_distribution_edit.aspx.cs" Inherits="LingLong.Admin.Web.admin.reward.sys_rewardmoney_edit" %>

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
            <a href="sys_rewardmoney_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="reward_distribution_list.aspx"><span>打赏金额分配比例</span></a>
            <i class="arrow"></i>
            <span>编辑打赏金额分配方案</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">打赏金额分配方案</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>方案名称</dt>
                <dd>
                    <asp:TextBox ID="txt_DistributionName" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>平台分配比例</dt>
                <dd>
                    <asp:TextBox ID="txt_PlatformRatio" runat="server" CssClass="input normal"></asp:TextBox>%
                </dd>
            </dl>
            <dl>
                <dt>代理商分配比例</dt>
                <dd>
                    <asp:TextBox ID="txt_AgentRatio" runat="server" CssClass="input normal"></asp:TextBox>%</dd>
            </dl>
            <dl>
                <dt>门店分配比例</dt>
                <dd>
                    <asp:TextBox ID="txt_StoreRatio" runat="server" CssClass="input normal"></asp:TextBox>%</dd>
            </dl>
            <dl>
                <dt>服务人员分配比例</dt>
                <dd>
                    <asp:TextBox ID="txt_BusinessRatio" runat="server" CssClass="input normal"></asp:TextBox>%</dd>
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
