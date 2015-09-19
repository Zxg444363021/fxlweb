<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClearCache.aspx.cs" Inherits="ClearCache" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
<script type="text/javascript" src="/common/jquery.min.js"></script>
<script type="text/javascript" src="/common/jquery.cookie.min.js"></script>
<script type="text/javascript">
    $(function () {
        if ($.cookie("message") == "1") {
            $.cookie("message", "undefined");
        }
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Done.
    </div>
    </form>
</body>
</html>
