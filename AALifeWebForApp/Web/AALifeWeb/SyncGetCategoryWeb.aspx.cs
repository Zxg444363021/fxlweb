using System;
using System.Data;

public partial class AALifeWeb_SyncGetCategoryWeb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Request.Form["userid"].ToString());

        DataTable dt = SyncHelper.SyncGetCategoryWeb(userId);

        string result = "{";
        if (dt.Rows.Count > 0)
        {
            result += "\"catlist\":[";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "{\"catid\":\"" + dt.Rows[i]["CategoryTypeID"].ToString() + "\",";
                result += "\"catname\":\"" + dt.Rows[i]["CategoryTypeName"].ToString() + "\",";
                result += "\"catprice\":\"" + dt.Rows[i]["CategoryTypePrice"].ToString() + "\",";
                result += "\"catlive\":\"" + dt.Rows[i]["CategoryTypeLive"].ToString() + "\"},";
            }
            result = result.Substring(0, result.Length - 1);
            result += "]";
        }
        else
        {
            result += "\"catlist\":[]";
        }
        result += "}";

        Response.Write(result);
        Response.End();
    }
}