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
        //1. http://se.kanav222.com
		result.Append("{\"siteid\":\"1\",\"siterank\":\"1\",\"ishided\":\"0\",\"sitename\":\"好了KK kanav222.com\",\"listpage\":\"list5-(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://se.kanav222.com\",\"sitelink\":\"http://se.kanav222.com/article/html/list5-1.html\",\"liststart\":\"<divclass=\\\"list\\\">\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=\\\"content\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/article\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //2. http://www.mmdd44.link
		result.Append("{\"siteid\":\"2\",\"siterank\":\"2\",\"ishided\":\"0\",\"sitename\":\"摸逼逼博客 mmdd44.link\",\"listpage\":\"(*).jsp\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.mmdd44.link\",\"sitelink\":\"http://www.mmdd44.link/jkruzf/6/1.jsp\",\"liststart\":\"<divclass=list>\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=content>\",\"imageend\":\"</div>\",\"oninclude\":\"/gykx\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //3. http://www.seyy33.com
		result.Append("{\"siteid\":\"3\",\"siterank\":\"3\",\"ishided\":\"0\",\"sitename\":\"涩Y33 seyy33.com\",\"listpage\":\"(*).html\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.seyy33.com\",\"sitelink\":\"http://www.seyy33.com/bceq9/6/1.html\",\"liststart\":\"<divclass=\\\"zxlist\\\">\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=n_bd>\",\"imageend\":\"</div>\",\"oninclude\":\"/ftxyz\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//4. http://www.wanwangan.com
        result.Append("{\"siteid\":\"4\",\"siterank\":\"4\",\"ishided\":\"0\",\"sitename\":\"晩晚干\",\"listpage\":\"index_(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.wanwangan.com\",\"sitelink\":\"http://www.wanwangan.com/toupaizipai/index.html\",\"liststart\":\"<divclass=\\\"zxlist\\\">\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=temp23>\",\"imageend\":\"</div>\",\"oninclude\":\"/toupaizipai\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //5. http://www.259ai.com
        result.Append("{\"siteid\":\"5\",\"siterank\":\"5\",\"ishided\":\"0\",\"sitename\":\"蛋蛋撸\",\"listpage\":\"index_(*).html\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.259ai.com\",\"sitelink\":\"http://www.259ai.com/tupian/toupai/index.html\",\"liststart\":\"<divclass=\\\"zxlist\\\">\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=temp23>\",\"imageend\":\"</div>\",\"oninclude\":\"/tupian\",\"notinclude\":\"\",\"pagestart\":\"<atitle=\\\"Page\\\">\",\"pageend\"=\"<div\"},");
        //6. http://www.7771.me
		result.Append("{\"siteid\":\"6\",\"siterank\":\"6\",\"ishided\":\"0\",\"sitename\":\"神马影院\",\"listpage\":\"index60_(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.7771.me\",\"sitelink\":\"http://www.7771.me/nv/you/index60.html\",\"liststart\":\"<divclass=list>\",\"listend\":\"</div>\",\"imagestart\":\"<divclass=\\\"n_bd\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/nv/so\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//7. http://luntan.91p.website/
		result.Append("{\"siteid\":\"7\",\"siterank\":\"8\",\"ishided\":\"0\",\"sitename\":\"原创申请 91Porn\",\"listpage\":\"forumdisplay.php?fid=19&orderby=dateline&page=(*)\",\"pageencode\":\"utf-8\",\"domain\":\"http://luntan.91p.website/\",\"sitelink\":\"http://luntan.91p.website/forumdisplay.php?fid=19&orderby=dateline&page=1\",\"liststart\":\"<divid=\\\"threadlist\\\"\",\"listend\":\"</div>\",\"imagestart\":\"<divid=\\\"threadtitle\\\">\",\"imageend\":\"<divclass=\\\"postactions\\\">\",\"oninclude\":\"viewthread\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //8. http://www.75ri.com
		result.Append("{\"siteid\":\"8\",\"siterank\":\"10\",\"ishided\":\"0\",\"sitename\":\"CaoPorn 75ri.com\",\"listpage\":\"albums?page=(*)\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.75ri.com\",\"sitelink\":\"http://www.75ri.com/albums?page=1\",\"liststart\":\"<divclass=\\\"blinkp\\\">\",\"listend\":\"<divclass=\\\"pagination\\\">\",\"imagestart\":\"<divid=\\\"album\",\"imageend\":\"<divclass=\\\"pagination\\\">\",\"oninclude\":\"/album\",\"notinclude\":\"\",\"pagestart\":\"<divclass=\\\"pagination\\\">\",\"pageend\"=\"</div>\"},");
		//9. http://www.964vv.com
		result.Append("{\"siteid\":\"9\",\"siterank\":\"7\",\"ishided\":\"0\",\"sitename\":\"狠狠撸 964vv.com\",\"listpage\":\"index20_(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.964vv.com\",\"sitelink\":\"http://www.964vv.com/html/part/index20.html\",\"liststart\":\"<divclass=list>\",\"listend\":\"<divclass=box_page>\",\"imagestart\":\"<divclass=content>\",\"imageend\":\"</div>\",\"oninclude\":\"/html/se\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//10. http://www.1000rt.net
		result.Append("{\"siteid\":\"10\",\"siterank\":\"13\",\"ishided\":\"0\",\"sitename\":\"1000人体 1000rt.net\",\"listpage\":\"index(*).htm\",\"pageencode\":\"gbk\",\"domain\":\"http://www.1000rt.net\",\"sitelink\":\"http://www.1000rt.net/yzrt/index.htm\",\"liststart\":\"<body\",\"listend\":\"</center>\",\"imagestart\":\"<p\",\"imageend\":\"<table\",\"oninclude\":\"/News\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//11. http://www.68s.net
		result.Append("{\"siteid\":\"11\",\"siterank\":\"14\",\"ishided\":\"0\",\"sitename\":\"人体艺术 68s.net\",\"listpage\":\"list_(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.68s.net\",\"sitelink\":\"http://www.68s.net/list/zhongguorenti/list_1.html\",\"liststart\":\"<divclass=\\\"list\\\">\",\"listend\":\"<divclass=\\\"pages\\\">\",\"imagestart\":\"<divclass=\\\"imgbox\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"http\",\"notinclude\":\"\",\"pagestart\":\"<divclass=\\\"pages\\\">\",\"pageend\"=\"</div>\"},");
        //12. http://luntan.91p.website/
		result.Append("{\"siteid\":\"12\",\"siterank\":\"9\",\"ishided\":\"0\",\"sitename\":\"我爱我妻 91Porn\",\"listpage\":\"forumdisplay.php?fid=21&orderby=dateline&page=(*)\",\"pageencode\":\"utf-8\",\"domain\":\"http://luntan.91p.website/\",\"sitelink\":\"http://luntan.91p.website/forumdisplay.php?fid=21&orderby=dateline&page=1\",\"liststart\":\"<divid=\\\"threadlist\\\"\",\"listend\":\"</div>\",\"imagestart\":\"<divid=\\\"threadtitle\\\">\",\"imageend\":\"<divclass=\\\"postactions\\\">\",\"oninclude\":\"viewthread\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
        //13. http://www.mzitu.com/
		result.Append("{\"siteid\":\"13\",\"siterank\":\"15\",\"ishided\":\"0\",\"sitename\":\"妹子图 Mzitu.com\",\"listpage\":\"(*)\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.mzitu.com\",\"sitelink\":\"http://www.mzitu.com/page/1\",\"liststart\":\"<divclass=\\\"m-list-main\\\"\",\"listend\":\"<divclass=\\\"m-page\",\"imagestart\":\"<divclass=\\\"m-list-content\\\">\",\"imageend\":\"<divclass=\\\"m-page\",\"oninclude\":\"http\",\"notinclude\":\"\",\"pagestart\":\"<divclass=\\\"m-page\",\"pageend\"=\"</div>\"},");
		//14. http://tt.mop.com/xuan
		result.Append("{\"siteid\":\"14\",\"siterank\":\"16\",\"ishided\":\"0\",\"sitename\":\"猫扑炫图 xuan\",\"listpage\":\"list_(*).html\",\"pageencode\":\"utf-8\",\"domain\":\"http://tt.mop.com\",\"sitelink\":\"http://tt.mop.com/xuan/list_1.html\",\"liststart\":\"<divclass=\\\"main\",\"listend\":\"<divclass=\\\"page\",\"imagestart\":\"<divclass=\\\"txtmod\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"http://tt\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//15. http://bbs.zol.com.cn/dcbbs
		result.Append("{\"siteid\":\"15\",\"siterank\":\"17\",\"ishided\":\"0\",\"sitename\":\"ZOL人像摄影 dcbbs\",\"listpage\":\"d16_pic_new_p(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://bbs.zol.com.cn\",\"sitelink\":\"http://bbs.zol.com.cn/dcbbs/d16_pic_new_p1.html\",\"liststart\":\"id=\\\"picBookList\\\"\",\"listend\":\"</ul>\",\"imagestart\":\"<divid=\\\"bookContent\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/dcbbs\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//16. http://bbs.we560.com/xtu
		result.Append("{\"siteid\":\"16\",\"siterank\":\"11\",\"ishided\":\"0\",\"sitename\":\"精彩生活自拍汇 xtu\",\"listpage\":\"(*)\",\"pageencode\":\"gbk\",\"domain\":\"http://bbs.we560.com/xtu/\",\"sitelink\":\"http://bbs.we560.com/xtu\",\"liststart\":\"<divalign=center>\",\"listend\":\"</div>\",\"imagestart\":\"<table\",\"imageend\":\"</div>\",\"oninclude\":\"html/\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//17. http://bbs.we560.com/xz
		result.Append("{\"siteid\":\"17\",\"siterank\":\"12\",\"ishided\":\"0\",\"sitename\":\"正妹写真套图 xz\",\"listpage\":\"(*)\",\"pageencode\":\"gbk\",\"domain\":\"http://bbs.we560.com/xz/cn\",\"sitelink\":\"http://bbs.we560.com/xz/cn\",\"liststart\":\"<divclass=\\\"viewbox\\\">\",\"listend\":\"</body>\",\"imagestart\":\"<divclass=\\\"img-show\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"http\",\"notinclude\":\"\",\"pagestart\":\"<select\",\"pageend\"=\"</select>\"},");
        //18. http://www.heisiwang.com/xinggan
		result.Append("{\"siteid\":\"18\",\"siterank\":\"18\",\"ishided\":\"0\",\"sitename\":\"黑丝网 xinggan\",\"listpage\":\"index_(*).html\",\"pageencode\":\"utf-8\",\"domain\":\"http://www.heisiwang.com\",\"sitelink\":\"http://www.heisiwang.com/xinggan/index.html\",\"liststart\":\"<divclass=\\\"channel-ctn\\\">\",\"listend\":\"<divclass=\\\"pages\\\">\",\"imagestart\":\"<divclass=\\\"endtext\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"/pic\",\"notinclude\":\"\",\"pagestart\":\"\",\"pageend\"=\"\"},");
		//19. http://www.airenti.co/yazhourenti
		result.Append("{\"siteid\":\"19\",\"siterank\":\"19\",\"ishided\":\"0\",\"sitename\":\"爱人体 yazhourenti\",\"listpage\":\"(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.airenti.co/yazhourenti/\",\"sitelink\":\"http://www.airenti.co/yazhourenti/index.html\",\"liststart\":\"<divclass=\\\"lm\\\">\",\"listend\":\"<ulclass=\\\"page\\\"\",\"imagestart\":\"<ulclass=\\\"file\\\">\",\"imageend\":\"</ul>\",\"oninclude\":\"20\",\"notinclude\":\"\",\"pagestart\":\"<ulclass=\\\"photo\",\"pageend\"=\"</ul>\"},");
		//20. http://www.ppmsg.net/jiepaimeinv
		result.Append("{\"siteid\":\"20\",\"siterank\":\"20\",\"ishided\":\"0\",\"sitename\":\"漂漂美术馆 jiepaimeinv\",\"listpage\":\"(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.ppmsg.net/jiepaimeinv/\",\"sitelink\":\"http://www.ppmsg.net/jiepaimeinv/index.html\",\"liststart\":\"<divclass=\\\"lm\\\">\",\"listend\":\"<ulclass=\\\"page\\\"\",\"imagestart\":\"<divid=\\\"imagelist\\\">\",\"imageend\":\"</div>\",\"oninclude\":\"20\",\"notinclude\":\"\",\"pagestart\":\"<ulclass=\\\"image\\\">\",\"pageend\"=\"</ul>\"},");
		//21. http://www.rentiyishu.tv/rentiwaipai
		result.Append("{\"siteid\":\"21\",\"siterank\":\"21\",\"ishided\":\"0\",\"sitename\":\"人体艺术 rentiwaipai\",\"listpage\":\"(*).html\",\"pageencode\":\"gbk\",\"domain\":\"http://www.rentiyishu.tv/rentiwaipai/\",\"sitelink\":\"http://www.rentiyishu.tv/rentiwaipai/index.html\",\"liststart\":\"<divclass=\\\"lm\\\">\",\"listend\":\"<ulclass=\\\"page\\\"\",\"imagestart\":\"<ulclass=\\\"file\\\">\",\"imageend\":\"</ul>\",\"oninclude\":\"20\",\"notinclude\":\"\",\"pagestart\":\"<ulclass=\\\"photo\",\"pageend\"=\"</ul>\"}");
        //end
		result.Append("]}");

        Response.Write(result.ToString());
        Response.End();
    }
}