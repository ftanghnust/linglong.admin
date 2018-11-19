<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BannerUpdate.aspx.cs" Inherits="LingLong.Admin.Web.admin.banner.BannerUpdate" %>

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

    <link rel="stylesheet" type="text/css" href="../../scripts/artdialog/ui-dialog.css" />
    <link rel="stylesheet" type="text/css" href="../skin/icon/iconfont.css" />
    <link rel="stylesheet" type="text/css" href="../skin/default/style.css" />
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/ueditor.all.min.js"> </script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
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

            <a href="SettingBanner.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="SettingBanner.aspx"><span>Banner图管理</span></a>
            <i class="arrow"></i>
            <span>Banner图上传</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">Banner图上传</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>banner主题</dt>
                <dd>
                    <asp:TextBox ID="txt_BannerTitle" CssClass="input normal" runat="server"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>点击状态</dt>
                <dd>
                    <asp:DropDownList ID="sel_ClickStatus" runat="server" CssClass="select">
                        <asp:ListItem Value="0" Text="不可点击"></asp:ListItem>
                        <asp:ListItem Value="1" Text="可点击"></asp:ListItem>
                    </asp:DropDownList>
                </dd>
            </dl>
            <dl>
                <dt>跳转图片URL</dt>
                <dd>
                    <asp:FileUpload runat="server" ID="file_ClickTrunOnUrl" CssClass="input file" /><asp:Label runat="server">上传图片格式为“.jpg、.gif、.bmp、.png”,图片大小不得超过8M</asp:Label><asp:Label ID="lab_ClickTrunOnUrl" ForeColor="Red" runat="server"></asp:Label><br />
                    <%--<asp:TextBox ID="txt_TrunUrl" runat="server" CssClass="input normal"></asp:TextBox><br />--%>
                    <asp:Image ID="img_ClickTrunOnUrl" runat="server" CssClass="img-view" Style="width: 300px; height: 300px" />
                </dd>
            </dl>
            <dl>
                <dt>上线时间</dt>
                <dd>
                    <asp:TextBox ID="txt_UpOnLineTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                    <%--<asp:TextBox CssClass="input rule-date-input" ID="" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>--%>
                </dd>
            </dl>
            <dl>
                <dt>下线时间</dt>
                <dd>
                    <asp:TextBox ID="txt_DownOnLimeTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>Banner图</dt>
                <dd>
                    <asp:FileUpload ID="pic_upload" runat="server" CssClass="input file" /><asp:Label runat="server">上传图片格式为“.jpg、.gif、.bmp、.png”,图片大小不得超过8M</asp:Label><asp:Label ID="lbl_pic" ForeColor="Red" runat="server"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <asp:Button ID="btn_upload" runat="server" Text="上传" CssClass="btn" OnClick="btn_upload_Click" />
                    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
                </dd>
            </dl>
            <dl>
                <dd>
                    <asp:Image ID="img_UpdateResult" runat="server" />
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <!--工具栏-->
        <!--/工具栏-->
    </form>
</body>
</html>
