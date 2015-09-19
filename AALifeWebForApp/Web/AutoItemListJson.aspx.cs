using System;
using System.Text;
using System.Data;

public partial class AutoItemListJson : BasePage
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
        string today = "";
        int userId = Int32.Parse(Session["UserID"].ToString());
        if (Request.QueryString["term"] != null && Request.QueryString["term"] != "")
        {
            today = Request.QueryString["term"];
        }

        DataTable dt = ItemAccess.GetMonthItemList(today, userId);

        StringBuilder items = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            items.Append("<table cellspacing=\"0\" border=\"1\" style=\"width:100%;\" class=\"tablelist\">");
            foreach (DataRow dr in dt.Rows)
            {
                double shouruPrice = Double.Parse(dr["ShouRuPrice"].ToString());
                double zhichuPrice = Double.Parse(dr["ZhiChuPrice"].ToString());
                double jiePrice = Double.Parse(dr["JiePrice"].ToString());
                double huanPrice = Double.Parse(dr["HuanPrice"].ToString());

                items.Append("<tr>");
                items.Append("<td style=\"width:16%;\">" + dr["ItemName"].ToString() + "</td>");
                items.Append("<td style=\"width:17%;\" class=\"cellprice\">" + (shouruPrice == 0 ? "" : "￥" + shouruPrice.ToString("0.0##")) + "</td>");
                items.Append("<td style=\"width:17%;\" class=\"cellprice\">" + (zhichuPrice == 0 ? "" : "￥" + zhichuPrice.ToString("0.0##")) + "</td>");
                items.Append("<td style=\"width:17%;\" class=\"cellprice\">" + (jiePrice == 0 ? "" : "￥" + jiePrice.ToString("0.##")) + "</td>");
                items.Append("<td style=\"width:17%;\" class=\"cellprice\">" + (huanPrice == 0 ? "" : "￥" + huanPrice.ToString("0.##")) + "</td>");
                items.Append("<td style=\"width:16%;\"><a href=\"ItemList.aspx?date=" + dr["ItemBuyDate"].ToString() + "\">查看</a></td>");
                items.Append("</tr>");
            }
            items.Append("</table>");
        }

        Response.Write(items.ToString());
        Response.End();
    }
}