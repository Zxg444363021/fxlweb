using System;
using System.Text;
using System.Data;

public partial class QuJianChartJson : BasePage
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
        int userId = Int32.Parse(Session["UserID"].ToString());

        DataTable dt = ItemAccess.GetQuJianTongJiList(userId);

        string value = "";
        string itemName = "";

        if (dt.Rows.Count > 0)
        {
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                DateTime d1 = DateTime.Parse(dr["ItemBuyDate"].ToString());
                DateTime d2 = DateTime.Parse(dr["ItemBuyDateMax"].ToString());
                string dot = (i < dt.Rows.Count - 1 ? "," : "");
                value += "{\"left\":\"" + (Int32.Parse(d1.ToString("MM"))-1) + "\",\"right\":" + (GetRegionDate(d1, d2)-1) + ",\"tip\":\"区间 "+d1.ToString("yyyy-MM-dd")+"~"+d2.ToString("yyyy-MM-dd")+"\"}" + dot;
                itemName = "\"" + dr["ItemName"].ToString() + "\"," + itemName;
                i++;
            }
            itemName = itemName.Remove(itemName.Length - 1);
        }
        else
        {
            itemName = "\"0\"";
        }

        Response.Write(GetChartJsonString(value, itemName));
        Response.End();
    }

    protected string GetChartJsonString(string value, string itemName)
    {
        StringBuilder items = new StringBuilder();
        items.Append("{\"title\":{\"text\":\"消费区间统计\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"x_axis\":{\"labels\":{\"labels\":[\"一月\",\"二月\",\"三月\",\"四月\",\"五月\",\"六月\",\"七月\",\"八月\",\"九月\",\"十月\",\"十一月\",\"十二月\"]}},");
        items.Append("\"y_axis\":{\"offset\":1,\"labels\":[" + itemName + "]},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"hbar\",\"values\":[" + value + "],\"colour\":\"#742894\"}]}");

        return items.ToString();
    }

    protected int GetRegionDate(DateTime d1, DateTime d2)
    {
        if (d2.Year == d1.Year && d2.Month == d1.Month && d2.Day > d1.Day)
        {
            return d2.Month + 1;
        }
        else
        {
            return d2.Month;
        }
    }
}