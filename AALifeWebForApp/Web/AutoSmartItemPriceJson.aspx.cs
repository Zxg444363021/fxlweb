using System;
using System.Text;
using System.Data;

public partial class AutoSmartItemPriceJson : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        string itemName = "";
        int userId = Int32.Parse(Session["UserID"].ToString());
        if (Request.QueryString["term"] != null && Request.QueryString["term"] != "")
        {
            itemName = Request.QueryString["term"];
        }

        DataTable dt = ItemAccess.GetItemPriceListByName(userId, itemName);

        StringBuilder items = new StringBuilder();
        items.Append("[");

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                items.Append("{\"label\":" + "\"" + Double.Parse(dr["ItemPrice"].ToString()).ToString("0.0##") + "\"},");
            }
            items.Remove(items.ToString().LastIndexOf(','), 1);
        }

        items.Append("]");

        Response.Write(items.ToString());
        Response.End();
    }
}