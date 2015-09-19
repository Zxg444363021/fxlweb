using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class QuWeiTongJi : FirstPage
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
        ItemNameCountList.DataSource = TongJiAccess.GetTongJiByItemNameCount();
        ItemNameCountList.DataBind();

        ItemPriceMaxList.DataSource = TongJiAccess.GetTongJiByItemPriceMax();
        ItemPriceMaxList.DataBind();

        ItemAddLastList.DataSource = TongJiAccess.GetTongJiByItemAddLast();
        ItemAddLastList.DataBind();

        UserItemCountList.DataSource = TongJiAccess.GetTongJiByUserItemCount();
        UserItemCountList.DataBind();

        UserItemLastList.DataSource = TongJiAccess.GetTongJiByUserItemLast();
        UserItemLastList.DataBind();

        UserAddLastList.DataSource = TongJiAccess.GetTongJiByUserAddLast();
        UserAddLastList.DataBind();
    }
}