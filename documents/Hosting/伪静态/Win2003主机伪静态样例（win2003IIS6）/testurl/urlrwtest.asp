<style type="text/css">
<!--
.style2 {
	font-size: 24;
	font-weight: bold;
}
-->
</style>
<p>URL-rewrite Ч��չʾ��
</p>
<p>URLrewrite ʵ��url��д.ʵ�������ʵ�ҳ���ǲ����ڵ�,����ͨ��������ʽ�����url��д����һ��ʵ�ʴ��ڵ�ҳ��.</p>
<p>ReWrite����:rewrite url="~/lmh$" to="~/Users.aspx?user=lmh" processing="stop"</p>
<p><a href="user/lmh">�û������url</a> &nbsp;&nbsp;&nbsp;<a href="Users.aspx?user=lmh">ʵ�ʵ�url</a></p>
<p>ReWrite����:rewrite url="~/tags/(.+)" to="~tagcloud.aspx?tag=$1" processing="stop"</p>
<p><a href="tags/abc">�û������url</a> &nbsp;&nbsp;&nbsp;<a href="tagcloud.aspx?tag=abc">ʵ�ʵ�url</a></p>
<hr>
</p>Ҫ���� ��urlrewrite.����Ҫ���հ�װ�ֲᰲװ����󣬽�testurl�ļ��зŵ��û���վ�£����ɲ��ԡ�</p>
</p>���������ȷ������ȷ�ϣ�</p>
</p>1.��վ������->��Ŀ¼->����->ͨ���Ӧ�ó���ӳ��->����->aspnet_isapi.dll->ȷ���ļ��Ƿ����δ��ѡ</p>
</p>2.��վ��Ŀ¼��BinĿ¼��App_BrowsersĿ¼�����ļ��Ѿ�����</p>
</p>3.web.config�ļ�������ȷ</p>