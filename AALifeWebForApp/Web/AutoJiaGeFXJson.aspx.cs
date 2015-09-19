using System;
using System.Text;
using System.Data;

public partial class AutoJiaGeFXJson : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["page"] != "" && Request.QueryString["page"] != null)
        {
            int pageNumber = Int32.Parse(Request.QueryString["page"]);
            int userId = Int32.Parse(Session["UserID"].ToString());
            double priceMax = 0;
            int howManyItems = 0;

            StringBuilder items = new StringBuilder();
            items.Append("[");

            DataTable dt = ItemAccess.GetJiaGeFenXiList(userId, pageNumber, out howManyItems, out priceMax);
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    items.Append("{");
                    items.Append("\"RowNumber\":" + "\"" + dr["RowNumber"].ToString() + "\",");
                    items.Append("\"ItemType\":" + "\"" + dr["ItemType"].ToString() + "\",");
                    items.Append("\"ItemTypeValue\":" + "\"" + dr["ItemTypeValue"].ToString() + "\",");
                    items.Append("\"ItemName\":" + "\"" + dr["ItemName"].ToString() + "\",");
                    items.Append("\"ItemBuyDate\":" + "\"" + DateTime.Parse(dr["ItemBuyDate"].ToString()).ToString("yyyy-MM-dd") + "\",");
                    items.Append("\"ItemPrice\":" + "\"" + Double.Parse(dr["ItemPrice"].ToString()).ToString("0.0##") + "\"");
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