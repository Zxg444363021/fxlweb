using System;
using System.Data;

public partial class AALifeWeb_SyncCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int cardId = Int32.Parse(Request.Form["cardid"].ToString());
        string cardName = Request.Form["cardname"].ToString();
        double cardMoney = Double.Parse(Request.Form["cardmoney"].ToString());
        int cardLive = Int32.Parse(Request.Form["cardlive"].ToString());
        int userId = Int32.Parse(Request.Form["userid"].ToString());

        CardEntity card = new CardEntity();
        card.CardID = cardId;
        card.CardName = cardName;
        card.CardMoney = cardMoney;
        card.UserID = userId;
        card.CardLive = cardLive;
        card.Synchronize = 0;

        bool success = SyncHelper.SyncCheckCardIsExists(cardId, userId);
        if (success)
        {
            success = SyncHelper.SyncCardUpdate(card);
        }
        else
        {
            success = SyncHelper.SyncCardInsert(card);
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