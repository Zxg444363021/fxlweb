<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <title>urlrewrite asp example</title>
</head>
<body>
    <div>
    article.asp    
    </div>	
    <% Response.Write(" id= "& request.querystring("id") ) 
    Response.Write(" sid= "& request.querystring("sid") ) 
     Response.Write(" page= "& request.querystring("page") ) %>
</body>
</html>
