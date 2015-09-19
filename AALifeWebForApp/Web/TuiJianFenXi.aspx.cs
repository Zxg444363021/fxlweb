using System;
using System.Data;

public partial class TuiJianFenXi : BasePage
{
    private int userId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        int monthMax = 0;
        DataTable dt = ItemAccess.GetTuiJianFenXiList(userId, out monthMax);
        ItemList.DataSource = dt;
        ItemList.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "ItemBuyDate");
    }
}