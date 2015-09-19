using System;
using System.Data;
using System.Data.Common;

public class ItemAccess
{
    static ItemAccess()
    {        
    }

    //取消费列表通过当前用户和日期//ItemList.aspx
    public static DataTable GetItemList(string date, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemBuyDate";
        param.Value = DateTime.Parse(date);
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //搜索消费列表通过关键字//SearchItem.aspx
    public static DataTable GetItemListByKeywords(string words, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListByKeywords_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Keywords";
        param.Value = words;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //搜索管理所有消费列表通过关键字//AdminItemList.aspx
    public static DataTable GetAdminItemListByKeywords(string words)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminItemListByKeywords_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Keywords";
        param.Value = words;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取管理所有消费列表//AdminItemList.aspx
    public static DataTable GetAdminItemList()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminItemList_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费类别//ItemList.aspx//UserCategoryAdmin.aspx
    public static DataTable GetItemListType()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListType_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取管理消费列表根据当天时间//AdminItemList.aspx
    public static DataTable GetAdminItemListToday()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminItemListToday_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费列表商品名称根据类别ID//ItemAddSmart.aspx
    public static DataTable GetItemNameListByCatTypeId(int userId, int catTypeId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemNameListByCatTypeId_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = catTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费列表商品价格根据商品名称//ItemAddSmart.aspx
    public static DataTable GetItemPriceListByName(int userId, string itemName)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemPriceListByName_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemName";
        param.Value = itemName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费天数分析，从商品购买日期至今相隔的天数//
    public static DataTable GetTianShuFenXiList(int userId, int pageNumber, out int howManyItems, out int notBuyMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetTianShuFenXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PagePerNumber";
        param.Value = WebConfiguration.PagePerNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyItems";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@NotBuyMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        howManyItems = Int32.Parse(comm.Parameters["@HowManyItems"].Value.ToString());
        notBuyMax = Int32.Parse(comm.Parameters["@NotBuyMax"].Value.ToString());

        return dt;
    }

    //取消费价格分析，最新商品价格列表//
    public static DataTable GetJiaGeFenXiList(int userId, int pageNumber, out int howManyItems, out double priceMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetJiaGeFenXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PagePerNumber";
        param.Value = WebConfiguration.PagePerNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyItems";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PriceMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        howManyItems = Int32.Parse(comm.Parameters["@HowManyItems"].Value.ToString());
        priceMax = Double.Parse(comm.Parameters["@PriceMax"].Value.ToString());

        return dt;
    }  
  
    //取商品推荐分析//
    public static DataTable GetTuiJianFenXiList(int userId, out int monthMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetTuiJianFenXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@MonthMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        monthMax = Int32.Parse(comm.Parameters["@MonthMax"].Value.ToString());

        return dt;
    }

    //取消费间隔分析，从商品购买日期与前一个购买日期相隔的天数//
    public static DataTable GetJianGeFenXiList(int userId, int pageNumber, out int howManyItems, out int notBuyMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetJianGeFenXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PagePerNumber";
        param.Value = WebConfiguration.PagePerNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyItems";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@NotBuyMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        howManyItems = Int32.Parse(comm.Parameters["@HowManyItems"].Value.ToString());
        notBuyMax = Int32.Parse(comm.Parameters["@NotBuyMax"].Value.ToString());

        return dt;
    }

    //取分类总计排行//
    public static DataTable GetFenLeiZongJiList(string date, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetFenLeiZongJiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取分类总计比较分析//
    public static DataTable GetBiJiaoFenXiList(string date, int userId, string orderBy, out double priceMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetBiJiaoFenXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OrderBy";
        param.Value = orderBy;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PriceMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        priceMax = Double.Parse(comm.Parameters["@PriceMax"].Value.ToString());

        return dt;
    }

    //取分类总计排行明细//
    public static DataTable GetFenLeiZongJiMingXiList(int catTypeId, string date, int userId, out double priceMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetFenLeiZongJiMingXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = catTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PriceMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        priceMax = Double.Parse(comm.Parameters["@PriceMax"].Value.ToString());

        return dt;
    }

    //取分类总计比较明细//
    public static DataTable GetBiJiaoMingXiList(int catTypeId, string date, int userId, out double priceMax, out int countMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetBiJiaoMingXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = catTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PriceMaxOut";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CountMaxOut";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        priceMax = 0;
        countMax = 0;
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        priceMax = Double.Parse(comm.Parameters["@PriceMaxOut"].Value.ToString());
        countMax = Int32.Parse(comm.Parameters["@CountMaxOut"].Value.ToString());

        return dt;
    }

    //取消费列表根据ItemID用于更新消费//
    public static ItemEntity GetItemListById(int itemId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListById_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemID";
        param.Value = itemId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        ItemEntity item = new ItemEntity();
        if (dt.Rows.Count > 0)
        {
            item.ItemID = Int32.Parse(dt.Rows[0]["ItemID"].ToString());
            item.ItemType = dt.Rows[0]["ItemType"].ToString();
            item.ItemName = dt.Rows[0]["ItemName"].ToString();
            item.CategoryTypeID = Int32.Parse(dt.Rows[0]["CategoryTypeID"].ToString());
            item.ItemPrice = Double.Parse(dt.Rows[0]["ItemPrice"].ToString());
            item.ItemBuyDate = DateTime.Parse(dt.Rows[0]["ItemBuyDate"].ToString());
            item.UserID = Int32.Parse(dt.Rows[0]["UserID"].ToString());
            item.Recommend = Int32.Parse(dt.Rows[0]["Recommend"].ToString());
            item.Synchronize = Int32.Parse(dt.Rows[0]["Synchronize"].ToString());
            item.ItemAppID = Int32.Parse(dt.Rows[0]["ItemAppID"].ToString());
            item.RegionID = Int32.Parse(dt.Rows[0]["RegionID"].ToString());
            item.RegionType = dt.Rows[0]["RegionType"].ToString();
            item.ZhuanTiID = Int32.Parse(dt.Rows[0]["ZhuanTiID"].ToString());
        }

        return item;
    }

    //取管理消费列表根据用户ID用于用户消费明细//
    public static DataTable GetAdminItemListByUserId(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminItemListByUserId_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取每月消费列表//
    public static DataTable GetMonthList(string date, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetMonthList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取每月消费列表展开明细//
    public static DataTable GetMonthItemList(string date, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetMonthItemList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取首页收支消费统计//
    public static DataTable GetItemListShouZhi(string date, int userId, out double shouruPrice, out double zhichuPrice, out double shouruPriceMonth, out double zhichuPriceMonth, out double shouruPriceYear, out double zhichuPriceYear)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListShouZhi_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ShouRuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhiChuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ShouRuPriceMonth";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhiChuPriceMonth";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ShouRuPriceYear";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhiChuPriceYear";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        shouruPrice = 0;
        zhichuPrice = 0;
        shouruPriceMonth = 0;
        zhichuPriceMonth = 0;
        shouruPriceYear = 0;
        zhichuPriceYear = 0;
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        try
        {
            shouruPrice = Double.Parse(comm.Parameters["@ShouRuPrice"].Value.ToString());
            zhichuPrice = Double.Parse(comm.Parameters["@ZhiChuPrice"].Value.ToString());
            shouruPriceMonth = Double.Parse(comm.Parameters["@ShouRuPriceMonth"].Value.ToString());
            zhichuPriceMonth = Double.Parse(comm.Parameters["@ZhiChuPriceMonth"].Value.ToString());
            shouruPriceYear = Double.Parse(comm.Parameters["@ShouRuPriceYear"].Value.ToString());
            zhichuPriceYear = Double.Parse(comm.Parameters["@ZhiChuPriceYear"].Value.ToString());
        }
        catch
        {
        }

        return dt;
    }

    //取列表页借还消费统计//
    public static DataTable GetItemListJieHuan(string date, int userId, out double jiechuPrice, out double huanruPrice, out double jieruPrice, out double huanchuPrice)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListJieHuan_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@JieChuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@HuanRuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@JieRuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@HuanChuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        jiechuPrice = 0;
        huanruPrice = 0;
        jieruPrice = 0;
        huanchuPrice = 0;
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        try
        {
            jiechuPrice = Double.Parse(comm.Parameters["@JieChuPrice"].Value.ToString());
            huanruPrice = Double.Parse(comm.Parameters["@HuanRuPrice"].Value.ToString());
            jieruPrice = Double.Parse(comm.Parameters["@JieRuPrice"].Value.ToString());
            huanchuPrice = Double.Parse(comm.Parameters["@HuanChuPrice"].Value.ToString());
        }
        catch
        {
        }

        return dt;
    }

    //取首页借还消费统计//
    public static DataTable GetItemListJieHuanYear(string date, int userId, out double jiechuPrice, out double huanruPrice, out double jieruPrice, out double huanchuPrice)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListJieHuanYear_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@JieChuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@HuanRuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@JieRuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@HuanChuPrice";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        jiechuPrice = 0;
        huanruPrice = 0;
        jieruPrice = 0;
        huanchuPrice = 0;
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        try
        {
            jiechuPrice = Double.Parse(comm.Parameters["@JieChuPrice"].Value.ToString());
            huanruPrice = Double.Parse(comm.Parameters["@HuanRuPrice"].Value.ToString());
            jieruPrice = Double.Parse(comm.Parameters["@JieRuPrice"].Value.ToString());
            huanchuPrice = Double.Parse(comm.Parameters["@HuanChuPrice"].Value.ToString());
        }
        catch
        {
        }

        return dt;
    }

    //插入消费商品//
    public static bool InsertItem(ItemEntity item, int type)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "InsertItem_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemAppID";
        param.Value = item.ItemAppID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemType";
        param.Value = item.ItemType;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemName";
        param.Value = item.ItemName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = item.CategoryTypeID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemPrice";
        param.Value = item.ItemPrice;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemBuyDate";
        param.Value = item.ItemBuyDate;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = item.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@RegionID";
        param.Value = item.RegionID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@RegionType";
        param.Value = item.RegionType;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = item.Synchronize;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiID";
        param.Value = item.ZhuanTiID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CardID";
        param.Value = item.CardID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
        }

        return (result != -1);
    }

    //更新消费商品//
    public static bool UpdateItem(ItemEntity item, int type)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateItem_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemID";
        param.Value = item.ItemID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemType";
        param.Value = item.ItemType;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemName";
        param.Value = item.ItemName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = item.CategoryTypeID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemPrice";
        param.Value = item.ItemPrice;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemBuyDate";
        param.Value = item.ItemBuyDate;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = item.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Recommend";
        param.Value = item.Recommend;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = item.Synchronize;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemAppID";
        param.Value = item.ItemAppID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@RegionID";
        param.Value = item.RegionID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@RegionType";
        param.Value = item.RegionType;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiID";
        param.Value = item.ZhuanTiID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CardID";
        param.Value = item.CardID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = type;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
        }

        return (result != -1);
    }

    //更新钱包金额//
    public static bool UpdateMoneyProc(int cardId, int userId, string itemType, double itemPrice, string type)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateMoneyProc_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CardID";
        param.Value = cardId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemType";
        param.Value = itemType;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemPrice";
        param.Value = itemPrice;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = type;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);
        
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
        }

        return (result != -1);
    }

    //更新推荐//
    public static bool UpdateItemRecommend(int itemId, int recommend)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateItemRecommend_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemID";
        param.Value = itemId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Recommend";
        param.Value = recommend;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
        }

        return (result != -1);
    }

    //取消费商品单价排行//
    public static DataTable GetItemPriceTopList(string date, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemPriceTopList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费区间统计//
    public static DataTable GetQuJianTongJiList(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetQuJianTongJiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取支出借还消费分析//
    public static DataTable GetJieHuanFenXiList(int userId, string date, string type)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetJieHuanFenXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = type;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费日期排行//
    public static DataTable GetItemDateTopList(string date, int userId, string orderBy, out double priceMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemDateTopList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OrderBy";
        param.Value = orderBy;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@PriceMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        priceMax = Double.Parse(comm.Parameters["@PriceMax"].Value.ToString());

        return dt;
    } 

    //取消费商品数量排行//
    public static DataTable GetItemNumTopList(string date, int userId, out int countMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemNumTopList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CountMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        countMax = Int32.Parse(comm.Parameters["@CountMax"].Value.ToString());

        return dt;
    }

    //删除消费商品//
    public static bool DeleteItem(int itemId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "DeleteItem_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemID";
        param.Value = itemId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
        }

        return (result != -1);
    }

    //取消费次数排行明细//
    public static DataTable GetItemNumDetailList(string itemName, string itemType, int userId, int catTypeId, string date, string orderBy, out double priceMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemNumDetailList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemName";
        param.Value = itemName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemType";
        param.Value = itemType;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CatTypeID";
        param.Value = catTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OrderBy";
        param.Value = orderBy;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@PriceMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        priceMax = Double.Parse(comm.Parameters["@PriceMax"].Value.ToString());

        return dt;
    }

    //取消费列表价格分析明细//
    public static DataTable GetJiaGeFenXiMingXiList(string itemName, string itemType, int userId, int pageNumber, out int howManyItems, out double priceMax)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetJiaGeFenXiMingXiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemName";
        param.Value = itemName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemType";
        param.Value = itemType;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PagePerNumber";
        param.Value = WebConfiguration.PagePerNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@HowManyItems";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@PriceMax";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm); 
        howManyItems = Int32.Parse(comm.Parameters["@HowManyItems"].Value.ToString());
        priceMax = Double.Parse(comm.Parameters["@PriceMax"].Value.ToString());

        return dt;
    }

    //取商品名称通过关键字//ItemAddSmart.aspx
    public static DataTable GetItemNameListByKeywords(string keywords, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemNameListByKeywords_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Keywords";
        param.Value = keywords;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }  
  
    //取消费最大RegionID//
    public static string GetItemListMaxRegionId(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListMaxRegionId_v4";
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteScalar(comm);
    }

    //取区间消费根据RegionID用于删除消费时删除区间//
    public static DataTable GetItemListByRegionId(int userId, int regionId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListByRegionId_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@RegionID";
        param.Value = regionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

}
