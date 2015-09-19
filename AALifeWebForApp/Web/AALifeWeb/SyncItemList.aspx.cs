using System;
using System.Data;

public partial class AALifeWeb_SyncItemList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string itemName = Request.Form["itemname"].ToString();
        int itemAppId = Int32.Parse(Request.Form["itemid"].ToString());
        int itemId = Int32.Parse(Request.Form["itemwebid"].ToString());
        int catId = Int32.Parse(Request.Form["catid"].ToString());
        double itemPrice = Double.Parse(Request.Form["itemprice"].ToString());
        DateTime itemBuyDate = DateTime.Parse(Request.Form["itembuydate"].ToString()); 
        int userId = Int32.Parse(Request.Form["userid"].ToString());
        int recommend = Int32.Parse(Request.Form["recommend"].ToString());
        int regionId = Int32.Parse(Request.Form["regionid"].ToString());
        string regionType = (regionId == 0 ? "" : Request.Form["regiontype"] ?? "m");
        string itemType = Request.Form["itemtype"].ToString();
        string ztId = Request.Form["ztid"] ?? "0";
        string cardId = Request.Form["cardid"] ?? "0";

        ItemEntity item = new ItemEntity();
        item.ItemID = itemId;
        item.ItemType = itemType;
        item.ItemName = itemName;
        item.CategoryTypeID = catId;
        item.ItemPrice = itemPrice;
        item.ItemBuyDate = itemBuyDate;
        item.ItemAppID = itemAppId;
        item.Recommend = recommend;
        item.RegionID = regionId;
        item.RegionType = regionType;
        item.Synchronize = 0;
        item.UserID = userId;
        item.ZhuanTiID = Int32.Parse(ztId);
        item.CardID = Int32.Parse(cardId);
        
        bool success = false;
        DataTable dt = SyncHelper.SyncCheckItemListByItemAppId(itemAppId, userId);
        if (dt.Rows.Count > 0)
        {
            success = SyncHelper.SyncItemListUpdateByItemAppId(item);
        }
        else if (itemId > 0)
        {
            dt = SyncHelper.GetItemListById(itemId);
            if (dt.Rows.Count > 0)
            {
                success = ItemAccess.UpdateItem(item, 0);
            }
            else
            {
                success = ItemAccess.InsertItem(item, 0);
            }
        }
        else
        {
            success = ItemAccess.InsertItem(item, 0);
        }

        dt = SyncHelper.SyncCheckItemListByItemAppId(itemAppId, userId);
        if (dt.Rows.Count > 0)
        {
            itemId = Int32.Parse(dt.Rows[0]["ItemID"].ToString());
        }
                
        string result = "{";
        if (success)
        {
            result += "\"result\":\"" + itemId + "\"";
        }
        else
        {
            result += "\"result\":\"0\"";
        } 
        result += "}";

        Response.Write(result);
        Response.End();
    }
}