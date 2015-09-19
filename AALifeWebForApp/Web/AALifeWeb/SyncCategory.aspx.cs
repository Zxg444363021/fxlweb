using System;
using System.Data;

public partial class AALifeWeb_SyncCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int catId = Int32.Parse(Request.Form["catid"].ToString());
        string catName = Request.Form["catname"].ToString();
        string catPrice = Request.Form["catprice"] ?? "";
        int catLive = Int32.Parse(Request.Form["catlive"].ToString());
        int userId = Int32.Parse(Request.Form["userid"].ToString());
        
        UserCategoryEntity userCat = new UserCategoryEntity();
        userCat.CategoryTypeID = catId;
        userCat.CategoryTypeName = catName;
        if (catPrice != "") userCat.CategoryTypePrice = Double.Parse(catPrice);
        userCat.UserID = userId;
        userCat.CategoryTypeLive = catLive;
        userCat.Synchronize = 0;

        bool success = SyncHelper.SyncCheckCategoryIsExists(catId, userId);
        if (success)
        {
            success = SyncHelper.SyncCategoryUpdate(userCat);
        }
        else
        {
            success = SyncHelper.SyncCategoryInsert(userCat);
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