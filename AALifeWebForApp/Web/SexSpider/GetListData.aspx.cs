using System;
using System.Text;

public partial class SexSpider_GetListData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder result = new StringBuilder();
        result.Append("{");
        //start
		result.Append("list:[");
        //1. http://se.haole018.com
		result.Append("{\"siteid\":\"1\",\"pageregion\":\"list5-(*).html\",\"pageencode\":\"gbk\",\"mainsite\":\"http://se.haole018.com\",\"mainlink\":\"http://se.haole018.com/article/html/list5-1.html\",\"htmlstart\":\"<divclass=\\\"list\\\">\",\"htmlend\":\"</div>\",\"imagestart\":\"<divclass=\\\"content\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/article\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //2. http://www.aa544.com
		result.Append("{\"siteid\":\"2\",\"pageregion\":\"(*).html\",\"pageencode\":\"utf-8\",\"mainsite\":\"http://www.aa544.com\",\"mainlink\":\"http://www.aa544.com/chxuan/6/1.html\",\"htmlstart\":\"<divclass=list>\",\"htmlend\":\"</div>\",\"imagestart\":\"<divclass=content>\",\"imageend\":\"</div>\",\"oninclude\":\"/tuvebk\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //3. http://www.seyy33.com
		result.Append("{\"siteid\":\"3\",\"pageregion\":\"(*).html\",\"pageencode\":\"utf-8\",\"mainsite\":\"http://www.seyy33.com\",\"mainlink\":\"http://www.seyy33.com/bceq9/15/1.html\",\"htmlstart\":\"<divclass=\\\"zxlist\\\">\",\"htmlend\":\"</div>\",\"imagestart\":\"<divclass=n_bd>\",\"imageend\":\"</div>\",\"oninclude\":\"/ftxyz\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//4. http://www.wanwangan.com
        result.Append("{\"siteid\":\"4\",\"pageregion\":\"index_(*).html\",\"pageencode\":\"gbk\",\"mainsite\":\"http://www.wanwangan.com\",\"mainlink\":\"http://www.wanwangan.com/toupaizipai/index.html\",\"htmlstart\":\"<divclass=\\\"zxlist\\\">\",\"htmlend\":\"</div>\",\"imagestart\":\"<divclass=temp23>\",\"imageend\":\"</div>\",\"oninclude\":\"/toupaizipai\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //5. http://www.anqulu.net
		result.Append("{\"siteid\":\"5\",\"pageregion\":\"index_(*).html\",\"pageencode\":\"utf-8\",\"mainsite\":\"http://www.anqulu.net\",\"mainlink\":\"http://www.anqulu.net/tupian/toupai/index.html\",\"htmlstart\":\"<divclass=\\\"zxlist\\\">\",\"htmlend\":\"</div>\",\"imagestart\":\"<divclass=temp23>\",\"imageend\":\"</div>\",\"oninclude\":\"/tupian\",\"outinclude\":\"\",\"pagestart\":\"<atitle=\\\"Page\\\">\",\"pageend\"=\"<div\"},");
        //6. http://www.777e.me
		result.Append("{\"siteid\":\"6\",\"pageregion\":\"index60_(*).html\",\"pageencode\":\"gbk\",\"mainsite\":\"http://www.777e.me\",\"mainlink\":\"http://www.777e.me/nv/you/index60.html\",\"htmlstart\":\"<divclass=list>\",\"htmlend\":\"</div>\",\"imagestart\":\"<divclass=\\\"n_bd\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/nv/so\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//7. http://luntan.w3p.la/
		result.Append("{\"siteid\":\"7\",\"pageregion\":\"forumdisplay.php?fid=19&orderby=dateline&page=(*)\",\"pageencode\":\"utf-8\",\"mainsite\":\"http://luntan.w3p.la/\",\"mainlink\":\"http://luntan.w3p.la/forumdisplay.php?fid=19&orderby=dateline&page=1\",\"htmlstart\":\"<divid=\\\"threadlist\\\"\",\"htmlend\":\"</div>\",\"imagestart\":\"<divid=\\\"threadtitle\\\">\",\"imageend\":\"<divclass=\\\"postactions\\\">\",\"oninclude\":\"viewthread\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //8. http://www.cao79.com
		result.Append("{\"siteid\":\"8\",\"pageregion\":\"albums?page=(*)\",\"pageencode\":\"utf-8\",\"mainsite\":\"http://www.cao79.com\",\"mainlink\":\"http://cao79.com/albums?page=1\",\"htmlstart\":\"<divclass=\\\"blinkp\\\">\",\"htmlend\":\"<divclass=\\\"pagination\\\">\",\"imagestart\":\"<divclass=\\\"blinkr\\\">\",\"imageend\":\"<divclass=\\\"pagination\\\">\",\"oninclude\":\"/album\",\"outinclude\":\"\",\"pagestart\":\"<divclass=\\\"pagination\\\">\",\"pageend\"=\"</div>\"},");
		//9. http://www.943vv.com
		result.Append("{\"siteid\":\"9\",\"pageregion\":\"index20_(*).html\",\"pageencode\":\"gbk\",\"mainsite\":\"http://www.943vv.com\",\"mainlink\":\"http://www.943vv.com/html/part/index20.html\",\"htmlstart\":\"<divclass=list>\",\"htmlend\":\"<divclass=box_page>\",\"imagestart\":\"<divclass=content>\",\"imageend\":\"</div>\",\"oninclude\":\"/html/se\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//10. http://www.1000rt.net
		result.Append("{\"siteid\":\"10\",\"pageregion\":\"index(*).htm\",\"pageencode\":\"gbk\",\"mainsite\":\"http://www.1000rt.net\",\"mainlink\":\"http://www.1000rt.net/yzrt/index.htm\",\"htmlstart\":\"<body\",\"htmlend\":\"</center>\",\"imagestart\":\"<p\",\"imageend\":\"<table\",\"oninclude\":\"/News\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//11. http://www.68s.net
		result.Append("{\"siteid\":\"11\",\"pageregion\":\"list_(*).html\",\"pageencode\":\"gbk\",\"mainsite\":\"http://www.68s.net\",\"mainlink\":\"http://www.68s.net/list/zhongguorenti/list_1.html\",\"htmlstart\":\"<divclass=\\\"list\\\">\",\"htmlend\":\"<divclass=\\\"pages\\\">\",\"imagestart\":\"<divclass=\\\"imgbox\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"http\",\"outinclude\":\"\",\"pagestart\":\"<divclass=\\\"pages\\\">\",\"pageend\"=\"</div>\"},");
        //12. http://luntan.w3p.la/
		result.Append("{\"siteid\":\"12\",\"pageregion\":\"forumdisplay.php?fid=21&orderby=dateline&page=(*)\",\"pageencode\":\"utf-8\",\"mainsite\":\"http://luntan.w3p.la/\",\"mainlink\":\"http://luntan.w3p.la/forumdisplay.php?fid=21&orderby=dateline&page=1\",\"htmlstart\":\"<divid=\\\"threadlist\\\"\",\"htmlend\":\"</div>\",\"imagestart\":\"<divid=\\\"threadtitle\\\">\",\"imageend\":\"<divclass=\\\"postactions\\\">\",\"oninclude\":\"viewthread\",\"outinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"}");
        //end
		result.Append("]}");

        Response.Write(result.ToString());
        Response.End();
    }
}