<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_store_edit.aspx.cs" Inherits="LingLong.Admin.Web.admin.storemanager.t_store_edit" %>

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
            <a href="manager_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="t_store_list.aspx"><span>门店管理</span></a>
            <i class="arrow"></i>
            <span>门店信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">门店信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>门店名称</dt>
                <dd>
                    <asp:TextBox ID="txt_StoreName" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>门店电话</dt>
                <dd>
                    <asp:TextBox ID="txt_PhoneNumber" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>门店图片链接</dt>
                <dd>
                    <asp:FileUpload runat="server" />
                    <asp:Image runat="server" ID="img_StoreImgUrl" Width="702" Height="360" />可上传，702 X 360 圆角 12 像素
                </dd>
            </dl>
            <dl>
                <dt>地址</dt>
                <dd>
                    <asp:TextBox ID="txt_Province" runat="server" CssClass="input normal" Width="100"></asp:TextBox><asp:TextBox ID="txt_City" runat="server" CssClass="input normal" Width="100"></asp:TextBox>
                    <asp:TextBox ID="txt_Area" runat="server" CssClass="input normal" Width="100"></asp:TextBox>
                    <asp:TextBox ID="txt_Address" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>状态</dt>
                <dd>
                    <asp:DropDownList runat="server" ID="drp_State">
                        <asp:ListItem Value="0" Text="待审核 ">
                        </asp:ListItem>
                        <asp:ListItem Value="1" Text="启用 ">
                        </asp:ListItem>
                        <asp:ListItem Value="2" Text="禁用 ">
                        </asp:ListItem>
                    </asp:DropDownList>
                </dd>
            </dl>
            <dl>
                <dt>门店评分</dt>
                <dd>
                    <asp:TextBox ID="txt_Score" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>删除标志</dt>
                <dd>
                    <asp:DropDownList runat="server" ID="drp_IsDeleted">
                        <asp:ListItem Value="0" Text="未删除 ">
                        </asp:ListItem>
                        <asp:ListItem Value="1" Text="已删除 ">
                        </asp:ListItem>
                    </asp:DropDownList></dd>
            </dl>
            <dl>
                <dt>分配方式</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txt_PlanId" CssClass="input normal"></asp:TextBox><asp:Label runat="server">输入分配金额ID，可以使用该ID的分配方案，清空输入可以使用默认方案</asp:Label>
                </dd>
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
