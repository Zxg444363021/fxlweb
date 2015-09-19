using System;
using System.Text;
using System.Data;

public partial class AutoItemNameJson : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string key = "";

        if (Request.QueryString["term"] != "" && Request.QueryString["term"] != null)
        {
            key = Request.QueryString["term"].Replace("%", "");
            int userId = Int32.Parse(Session["UserID"].ToString());

            StringBuilder items = new StringBuilder();
            items.Append("[");

            DataTable dt = ItemAccess.GetItemNameListByKeywords(key, userId);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    items.Append("{");
                    items.Append("\"id\":" + "\"" + dr["ItemName"].ToString() + "\",");
                    items.Append("\"label\":" + "\"" + dr["ItemName"].ToString() + "\"");
                    items.Append("},");
                }
                items.Remove(items.ToString().LastIndexOf(','), 1);
            }

            items.Append("]");

            Response.Write(items.ToString());
            Response.End();
        }
    }
}