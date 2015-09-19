using System;
using System.Data;

public partial class AALifeWeb_SyncGetItemListWeb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Request.Form["userid"].ToString());
        int type = Int32.Parse(Request.Form["type"].ToString());

        DataTable dt = null;
        if (type == 1)
        {
            dt = SyncHelper.SyncGetItemListWebFirst(userId);
        }
        else
        {
            dt = SyncHelper.SyncGetItemListWeb(userId);
        }

        string result = "{";
        if (dt.Rows.Count > 0)
        {
            result += "\"itemlist\":[";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "{\"itemid\":\"" + dt.Rows[i]["ItemID"].ToString() + "\",";
                result += "\"itemappid\":\"" + dt.Rows[i]["ItemAppID"].ToString() + "\",";
                result += "\"itemname\":\"" + dt.Rows[i]["ItemName"].ToString() + "\",";
                result += "\"catid\":\"" + dt.Rows[i]["CategoryTypeID"].ToString() + "\",";
                result += "\"itemprice\":\"" + dt.Rows[i]["ItemPrice"].ToString() + "\",";
                result += "\"itembuydate\":\"" + DateTime.Parse(dt.Rows[i]["ItemBuyDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "\",";
                result += "\"recommend\":\"" + dt.Rows[i]["Recommend"].ToString() + "\",";
                result += "\"regionid\":\"" + dt.Rows[i]["RegionID"].ToString() + "\",";
                result += "\"regiontype\":\"" + dt.Rows[i]["RegionType"].ToString() + "\",";
                result += "\"itemtype\":\"" + dt.Rows[i]["ItemType"].ToString() + "\",";
                result += "\"ztid\":\"" + dt.Rows[i]["ZhuanTiID"].ToString() + "\",";
                result += "\"cardid\":\"" + dt.Rows[i]["CardID"].ToString() + "\"},";
            }
            result = result.Substring(0, result.Length - 1);
            result += "]";
        }
        else
        {
            result += "\"itemlist\":[]";
        }
        result += "}";

        Response.Write(result);
        Response.End();
    }
}