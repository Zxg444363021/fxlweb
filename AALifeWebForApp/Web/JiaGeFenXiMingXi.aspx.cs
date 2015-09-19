using System;
using System.Data;

public partial class JiaGeFenXiMingXi : BasePage
{
    int userId = 0;
    public string itemName = "";
    public string itemType = ""; 
    public int howManyItems = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        itemName = Request.QueryString["itemName"] ?? "";
        itemType = Request.QueryString["itemType"] ?? "";
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
        DataTable dt = ItemAccess.GetJiaGeFenXiMingXiList(itemName, itemType, userId, pageNumber, out howManyItems, out priceMax);
        List.DataSource = dt;
        List.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "ItemBuyDate");
    }
}