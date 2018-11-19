<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_rewardmoney_edit.aspx.cs" Inherits="LingLong.Admin.Web.admin.reward.sys_rewardmoney_edit1" %>

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
            <a href="sys_rewardmoney_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="t_reward_plan_list.aspx"><span>打赏金额设置</span></a>
            <i class="arrow"></i>
            <a href="t_reward_plan_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%=planid%>"><span>打赏金额方案</span></a>
            <i class="arrow"></i>
            <span>编辑商品信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">编辑商品信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>打赏规则Id</dt>
                <dd>
                    <asp:TextBox ID="txt_PlanId" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>商品图片地址</dt>
                <dd>
                    <asp:FileUpload ID="pic_upload" runat="server" CssClass="input file" /><asp:Label runat="server">上传图片格式为“.jpg、.gif、.bmp、.png”,图片大小不得超过8M</asp:Label><asp:Label ID="lbl_pic" ForeColor="Red" runat="server"></asp:Label><br />
                    <asp:Image runat="server" Width="180" Height="180" ID="img_GoodsImgUrl"/>
                </dd>
            </dl>
            <dl>
                <dt>商品名称</dt>
                <dd>
                    <asp:TextBox ID="txt_GoodsName" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>商品金额</dt>
                <dd>
                    <asp:TextBox ID="txt_Money" runat="server" CssClass="input normal"></asp:TextBox></dd>
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