using System;
using System.Data;

public partial class AALifeWeb_SyncZhuanTi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ztId = Int32.Parse(Request.Form["ztid"].ToString());
        string ztName = Request.Form["ztname"].ToString();
        string ztImage = Request.Form["ztimage"].ToString();
        int ztLive = Int32.Parse(Request.Form["ztlive"].ToString());
        int userId = Int32.Parse(Request.Form["userid"].ToString());

        ZhuanTiEntity zhuanTi = new ZhuanTiEntity();
        zhuanTi.ZhuanTiID = ztId;
        zhuanTi.ZhuanTiName = ztName;
        zhuanTi.ZhuanTiImage = ztImage;
        zhuanTi.UserID = userId;
        zhuanTi.ZhuanTiLive = ztLive;
        zhuanTi.Synchronize = 0;

        bool success = SyncHelper.SyncCheckZhuanTiIsExists(ztId, userId);
        if (success)
        {
            success = SyncHelper.SyncZhuanTiUpdate(zhuanTi);
        }
        else
        {
            success = SyncHelper.SyncZhuanTiInsert(zhuanTi);
        }
                        
        string result = "{";
        if (success)
        {
            result += "\"result\":\"ok\"";
        }
        else
        {
            result += "\"result\":\"error\"";
        } 
        result += "}";

        Response.Write(result);
        Response.End();
    }
}