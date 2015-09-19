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
<p>ReWrite规则：详见web.config文件规则1，将/article/11/12转向article.aspx
         			</p>
<p><a href="/article/11/12">用户输入的url为：/article/11/12</a> &nbsp;&nbsp;&nbsp;<a href="/article.aspx?id=11&title=12">实际的显示页面为：/article.aspx</a></p>

<p>ReWrite规则：详见web.config文件规则2，将/tags/11转向tags.php
         			</p>
<p><a href="/tags/11">用户输入的url为：/tags/11</a> &nbsp;&nbsp;&nbsp;<a href="/tags.php?tags=11">实际的显示页面为：tags.php</a></p>

<p>ReWrite规则：详见web.config文件规则3，将test.html转向test.asp 
         			</p>
<p><a href="/test.html">用户输入的url为：/test.html</a> &nbsp;&nbsp;&nbsp;<a href="/test.asp">实际的显示页面为：test.asp</a></p>

<hr>
