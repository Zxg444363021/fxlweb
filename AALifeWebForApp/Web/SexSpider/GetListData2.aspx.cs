using System;
using System.Text;

public partial class SexSpider_GetListData2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder result = new StringBuilder();
        result.Append("{");
        //start
		result.Append("list:[");
        //1. http://se.haole018.com
		result.Append("{\"siteid\":\"1\",\"siterank\":\"1\",\"ishided\":\"0\",\"sitename\":\"好了KK kanav005.com\",\"listpage\":\"list5-(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://se.kanav005.com\",\"sitelink\":\"http://se.kanav005.com/article/html/list5-1.html\",\"liststart\":\"<divclass=\\\"list\\\">\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=\\\"content\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/article\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //2. http://www.aa544.com
		result.Append("{\"siteid\":\"2\",\"siterank\":\"2\",\"ishided\":\"0\",\"sitename\":\"摸逼逼博客 aa544.com\",\"listpage\":\"(*).html\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.aa544.com\",\"sitelink\":\"http://www.aa544.com/chxuan/6/1.html\",\"liststart\":\"<divclass=list>\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=content>\",\"imageend\":\"</div>\",\"oninclude\":\"/tuvebk\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //3. http://www.seyy33.com
		result.Append("{\"siteid\":\"3\",\"siterank\":\"3\",\"ishided\":\"0\",\"sitename\":\"涩Y33 seyy33.com\",\"listpage\":\"(*).html\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.seyy33.com\",\"sitelink\":\"http://www.seyy33.com/bceq9/15/1.html\",\"liststart\":\"<divclass=\\\"zxlist\\\">\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=n_bd>\",\"imageend\":\"</div>\",\"oninclude\":\"/ftxyz\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//4. http://www.wanwangan.com
        result.Append("{\"siteid\":\"4\",\"siterank\":\"4\",\"ishided\":\"0\",\"sitename\":\"晩晚干 wanwangan.com\",\"listpage\":\"index_(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.wanwangan.com\",\"sitelink\":\"http://www.wanwangan.com/toupaizipai/index.html\",\"liststart\":\"<divclass=\\\"zxlist\\\">\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=temp23>\",\"imageend\":\"</div>\",\"oninclude\":\"/toupaizipai\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //5. http://www.anqulu.net
		result.Append("{\"siteid\":\"5\",\"siterank\":\"5\",\"ishided\":\"0\",\"sitename\":\"俺去撸 anqulula.com\",\"listpage\":\"index_(*).html\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.anqulula.com\",\"sitelink\":\"http://www.anqulula.com/tupian/toupai/index.html\",\"liststart\":\"<divclass=\\\"zxlist\\\">\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=temp23>\",\"imageend\":\"</div>\",\"oninclude\":\"/tupian\",\"notinclude\":\"\",\"pagestart\":\"<atitle=\\\"Page\\\">\",\"pageend\"=\"<div\"},");
        //6. http://www.777j.me
		result.Append("{\"siteid\":\"6\",\"siterank\":\"6\",\"ishided\":\"0\",\"sitename\":\"神马影院 777j.me\",\"listpage\":\"index60_(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.777j.me\",\"sitelink\":\"http://www.777j.me/nv/you/index60.html\",\"liststart\":\"<divclass=list>\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=\\\"n_bd\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/nv/so\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//7. http://luntan.w3p.la/
		result.Append("{\"siteid\":\"7\",\"siterank\":\"8\",\"ishided\":\"0\",\"sitename\":\"原创申请 91Porn\",\"listpage\":\"forumdisplay.php?fid=19&orderby=dateline&page=(*)\",\"pageencode\":\"utf-8\",\"domain\":\"http://luntan.w3p.la/\",\"sitelink\":\"http://luntan.w3p.la/forumdisplay.php?fid=19&orderby=dateline&page=1\",\"liststart\":\"<divid=\\\"threadlist\\\"\",\"listend\":\"</div>\",\"imagestart\":\"<divid=\\\"threadtitle\\\">\",\"imageend\":\"<divclass=\\\"postactions\\\">\",\"oninclude\":\"viewthread\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //8. http://www.fuck44.com
		result.Append("{\"siteid\":\"8\",\"siterank\":\"10\",\"ishided\":\"0\",\"sitename\":\"CaoPorn fuck44.com\",\"listpage\":\"albums?page=(*)\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.fuck44.com\",\"sitelink\":\"http://fuck44.com/albums?page=1\",\"liststart\":\"<divclass=\\\"blinkp\\\">\",\"listend\":\"<divclass=\\\"pagination\\\">\",\"imagestart\":\"<divclass=\\\"blinkr\\\">\",\"imageend\":\"<divclass=\\\"pagination\\\">\",\"oninclude\":\"/album\",\"notinclude\":\"\",\"pagestart\":\"<divclass=\\\"pagination\\\">\",\"pageend\"=\"</div>\"},");
		//9. http://www.943vv.com
		result.Append("{\"siteid\":\"9\",\"siterank\":\"7\",\"ishided\":\"0\",\"sitename\":\"狠狠撸 943vv.com\",\"listpage\":\"index20_(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.943vv.com\",\"sitelink\":\"http://www.943vv.com/html/part/index20.html\",\"liststart\":\"<divclass=list>\",\"listend\":\"<divclass=box_page>\",\"imagestart\":\"<divclass=content>\",\"imageend\":\"</div>\",\"oninclude\":\"/html/se\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//10. http://www.1000rt.net
		result.Append("{\"siteid\":\"10\",\"siterank\":\"11\",\"ishided\":\"0\",\"sitename\":\"1000人体 1000rt.net\",\"listpage\":\"index(*).htm\",\"pageencode\":\"gbk\",\"domain\":\"http://www.1000rt.net\",\"sitelink\":\"http://www.1000rt.net/yzrt/index.htm\",\"liststart\":\"<body\",\"listend\":\"</center>\",\"imagestart\":\"<p\",\"imageend\":\"<table\",\"oninclude\":\"/News\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//11. http://www.68s.net
		result.Append("{\"siteid\":\"11\",\"siterank\":\"12\",\"ishided\":\"0\",\"sitename\":\"人体艺术 68s.net\",\"listpage\":\"list_(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.68s.net\",\"sitelink\":\"http://www.68s.net/list/zhongguorenti/list_1.html\",\"liststart\":\"<divclass=\\\"list\\\">\",\"listend\":\"<divclass=\\\"pages\\\">\",\"imagestart\":\"<divclass=\\\"imgbox\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"http\",\"notinclude\":\"\",\"pagestart\":\"<divclass=\\\"pages\\\">\",\"pageend\"=\"</div>\"},");
        //12. http://luntan.w3p.la/
		result.Append("{\"siteid\":\"12\",\"siterank\":\"9\",\"ishided\":\"0\",\"sitename\":\"我爱我妻 91Porn\",\"listpage\":\"forumdisplay.php?fid=21&orderby=dateline&page=(*)\",\"pageencode\":\"utf-8\",\"domain\":\"http://luntan.w3p.la/\",\"sitelink\":\"http://luntan.w3p.la/forumdisplay.php?fid=21&orderby=dateline&page=1\",\"liststart\":\"<divid=\\\"threadlist\\\"\",\"listend\":\"</div>\",\"imagestart\":\"<divid=\\\"threadtitle\\\">\",\"imageend\":\"<divclass=\\\"postactions\\\">\",\"oninclude\":\"viewthread\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //13. http://www.mzitu.com/
		result.Append("{\"siteid\":\"13\",\"siterank\":\"13\",\"ishided\":\"0\",\"sitename\":\"妹子图 Mzitu.com\",\"listpage\":\"(*)\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.mzitu.com/\",\"sitelink\":\"http://www.mzitu.com/page/1\",\"liststart\":\"<divid=\\\"postlist\\\"\",\"listend\":\"<divid=\\\"pagenavi\\\"\",\"imagestart\":\"<divclass=\\\"main-body\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"http\",\"notinclude\":\"\",\"pagestart\":\"<divclass=\\\"link_pages\\\"\",\"pageend\"=\"</div>\"},");
		//14. http://tt.mop.com/xuan
		result.Append("{\"siteid\":\"14\",\"siterank\":\"14\",\"ishided\":\"0\",\"sitename\":\"猫扑炫图 xuan\",\"listpage\":\"list_(*).html\",\"pageencode\":\"utf-8\",\"domain\":\"http://tt.mop.com/\",\"sitelink\":\"http://tt.mop.com/xuan/list_1.html\",\"liststart\":\"<divclass=\\\"main\",\"listend\":\"<divclass=\\\"page\",\"imagestart\":\"<divclass=\\\"txtmod\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"http://tt\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//15. http://bbs.zol.com.cn/dcbbs
		result.Append("{\"siteid\":\"15\",\"siterank\":\"15\",\"ishided\":\"0\",\"sitename\":\"ZOL人像摄影 dcbbs\",\"listpage\":\"d16_pic_new_p(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://bbs.zol.com.cn/\",\"sitelink\":\"http://bbs.zol.com.cn/dcbbs/d16_pic_new_p1.html\",\"liststart\":\"id=\\\"picBookList\\\"\",\"listend\":\"</ul>\",\"imagestart\":\"<divid=\\\"bookContent\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/dcbbs\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"}");
        //end
		result.Append("]}");

        Response.Write(result.ToString());
        Response.End();
    }
}