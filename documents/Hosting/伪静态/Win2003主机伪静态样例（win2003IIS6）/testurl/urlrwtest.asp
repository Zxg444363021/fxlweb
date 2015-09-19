<style type="text/css">
<!--
.style2 {
	font-size: 24;
	font-weight: bold;
}
-->
</style>
<p>URL-rewrite 效果展示：
</p>
<p>URLrewrite 实现url重写.实际您访问的页面是不存在的,我们通过正则表达式把你的url重写到另一个实际存在的页面.</p>
<p>ReWrite规则:rewrite url="~/lmh$" to="~/Users.aspx?user=lmh" processing="stop"</p>
<p><a href="user/lmh">用户输入的url</a> &nbsp;&nbsp;&nbsp;<a href="Users.aspx?user=lmh">实际的url</a></p>
<p>ReWrite规则:rewrite url="~/tags/(.+)" to="~tagcloud.aspx?tag=$1" processing="stop"</p>
<p><a href="tags/abc">用户输入的url</a> &nbsp;&nbsp;&nbsp;<a href="tagcloud.aspx?tag=abc">实际的url</a></p>
<hr>
</p>要测试 本urlrewrite.您需要按照安装手册安装组件后，将testurl文件夹放到用户网站下，即可测试。</p>
</p>如果不能正确，请先确认：</p>
</p>1.网站在属性->主目录->配置->通配符应用程序映射->插入->aspnet_isapi.dll->确认文件是否存在未勾选</p>
</p>2.网站主目录下Bin目录和App_Browsers目录所需文件已经存在</p>
</p>3.web.config文件配置正确</p>