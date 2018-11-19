﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditParticulars.aspx.cs" Inherits="LingLong.Admin.Web.admin.message.EditParticulars" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            
        </table>
    </form>
</body>
</html>--%>
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

    <link rel="stylesheet" href="../js/themes/default/default.css" />
	<link rel="stylesheet" href="../js/plugins/code/prettify.css" />
	<script charset="utf-8" src="../js/kindeditor-all.js"></script>

	<script charset="utf-8" src="../lang/zh-CN.js"></script>
	<script charset="utf-8" src="../plugins/code/prettify.js"></script>

    <script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/common.js"></script>

    <script type="text/javascript">
        KindEditor.ready(function(K) {
			var editor1 = K.create('#content1', {
				cssPath : '../plugins/code/prettify.css',
				uploadJson : 'https://api.9tx275.cn/Agent/UploadAgentImg',
				fileManagerJson : 'https://api.9tx275.cn/Agent/UploadAgentImg',
				allowFileManager : true,
				afterCreate : function() {
					var self = this;
					K.ctrl(document, 13, function() {
						self.sync();
						K('form[name=example]')[0].submit();
					});
					K.ctrl(self.edit.doc, 13, function() {
						self.sync();
						K('form[name=example]')[0].submit();
					});
				}
			});
			prettyPrint();
		});
    </script>

</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>详情编辑</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">详情</a></li>
                    </ul>
                </div>
            </div>
        </div>


        <div class="tab-content">
            <dl>
                <dt>规则名称</dt>
                <dd>
                    <asp:TextBox ID="txt_template_id" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>规则内容</dt>
                <dd>                    
                    <textarea id="content1" cols="100" rows="8" style="width:700px;height:200px;visibility:hidden;" runat="server"></textarea>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="发布" CssClass="btn" OnClick="submit_Click" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
