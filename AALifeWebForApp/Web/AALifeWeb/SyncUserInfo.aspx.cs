using System;
using System.Web;

public partial class AALifeWeb_SyncUserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Request.Form["userid"].ToString());
        string userFrom = Request.Form["userfrom"].ToString();
        string userMoney = Request.Form["usermoney"] ?? "";
        string userWorkDay = Request.Form["userworkday"] ?? "";
        string categoryRate = Request.Form["categoryrate"] ?? "";

        if (userFrom.Length > 5)
        {
            userFrom = userFrom.Replace("_", "");
            userFrom = userFrom.Insert(5, "_");
        }

        UserEntity user = null;
        if (userId > 0)
        {
            user = UserAccess.GetUserById(userId);
            user.UserFrom = userFrom;
            if (userMoney != "") user.UserMoney = Double.Parse(userMoney);
            if (userWorkDay != "") user.UserWorkDay = userWorkDay;
            if (categoryRate != "") user.CategoryRate = Double.Parse(categoryRate);
        }
                
        string result = "{";

        bool success = UserAccess.UpdateUser(user);
        if (success)
        {
            result += "\"result\":\"1\"";
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