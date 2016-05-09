<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" %>

<script runat="server">
protected void Page_Load(object sender, EventArgs e)
{
    this.Label1.Text = Request.Form["content1"];
}

</script>

<!doctype html>

<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>KindEditor ASP.NET</title>
    <link rel="stylesheet" href="../themes/default/default.css" />
	<link rel="stylesheet" href="../plugins/code/prettify.css" />
	<script charset="utf-8" src="../kindeditor.js"></script>
	<script charset="utf-8" src="../lang/zh_CN.js"></script>
	<script charset="utf-8" src="../plugins/code/prettify.js"></script>
    <script src="../plugins/jwplayer/jwplayer.js"></script>
    <script src="../../../js/jquery-1.10.1.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
    <script src="../../../js/jquery.iframe-transport.js"></script>


	<script>
		KindEditor.ready(function(K) {
			var editor1 = K.create('#content1', {
				cssPath : '../plugins/code/prettify.css',
				uploadJson : '../asp.net/upload_json.ashx',
				fileManagerJson : '../asp.net/file_manager_json.ashx',
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
		function show() {
		    var txtContent = $(".ke-edit-iframe").contents().find(".ke-content").html();
		    $("#sss").html(txtContent);
		    alert(txtContent);
		    //
		}
	</script>
</head>
<body>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <form id="example" runat="server">
        <textarea id="content1" cols="100" rows="8" style="width:700px;height:200px;visibility:hidden;" runat="server"></textarea>
        <br />
        <a href="javascript:void(0)" onclick="show()">弹出</a>
        <asp:Button ID="Button1" runat="server" Text="提交内容" /> (提交快捷键: Ctrl + Enter)
    </form>
    <div>
        <video src="/plugins/kindeditor-4.1.10/attached/media/20140804/20140804010139_2306.mp4" loop="true" controls="true"  poster="../themes/common/v.png" preload="preload" style="80%"></video>
       
    </div> 
    
    <div>
        <textarea id="sss"></textarea>
    </div>
    
</body>
</html>
