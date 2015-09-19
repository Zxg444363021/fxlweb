using System;
using System.Data;

public partial class JiaGeFenXi : BasePage
{
    private int userId = 0;
    public int howManyItems = 0;

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
        int pageNumber = 1;
        double priceMax = 0;
        DataTable dt = ItemAccess.GetJiaGeFenXiList(userId, pageNumber, out howManyItems, out priceMax);
        ItemList.DataSource = dt;
        ItemList.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "PageUrl");
    }
}