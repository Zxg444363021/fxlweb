<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Users测试页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
	<br><br>服务器图片控件一般可以显示<br><br>
	<asp:image imageurl="info.gif"   runat="server"/><br><br>
	<br><br>html img标签有可能不能显示<br><br>
	<img src="info.gif" width="40" height="50"><br><br>
	<br><br>修改为绝对路径src="/testurl/info.gif"后，可以正常显示<br><br>
	<img src="/testurl/info.gif" width="40" height="50"><br><br>
</body>
</html>
