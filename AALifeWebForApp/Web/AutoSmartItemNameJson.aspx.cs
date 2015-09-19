using System;
using System.Text;
using System.Data;

public partial class AutoSmartItemNameJson : BasePage
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
        int catTypeId = 0;
        int userId = Int32.Parse(Session["UserID"].ToString());
        if (Request.QueryString["term"] != null && Request.QueryString["term"] != "")
        {
            catTypeId = Int32.Parse(Request.QueryString["term"]);
        }
        
        DataTable dt = ItemAccess.GetItemNameListByCatTypeId(userId, catTypeId);

        StringBuilder items = new StringBuilder();
        items.Append("[");

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                items.Append("{\"label\":" + "\"" + dr["ItemName"].ToString() + "\"},");
            }
            items.Remove(items.ToString().LastIndexOf(','), 1);
        }

        items.Append("]");

        Response.Write(items.ToString());
        Response.End();
    }
}