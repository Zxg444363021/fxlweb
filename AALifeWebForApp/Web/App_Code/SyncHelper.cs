using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

/// <summary>
/// SyncHelper 的摘要说明
/// </summary>
public class SyncHelper
{
	static SyncHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //根据UserGroupID取消费列表，返回DataTable//
    public static DataTable SyncGetItemListWeb(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncGetItemListWeb_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //根据UserGroupID取消费列表，返回DataTable//
    public static DataTable SyncGetItemListWebFirst(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncGetItemListWebFirst_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }
    
    //取所有删除消费列表//
    public static DataTable SyncGetDeleteListWeb(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncGetDeleteListWeb_v4";
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取得同步类别//
    public static DataTable SyncGetCategoryWeb(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncGetCategoryWeb_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取得同步专题//
    public static DataTable SyncGetZhuanTiWeb(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncGetZhuanTiWeb_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取得同步钱包//
    public static DataTable SyncGetCardWeb(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncGetCardWeb_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取得同步用户//
    public static DataTable SyncGetUserInfoWeb(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncGetUserInfoWeb_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //检查用户名根据UserID//修改用户时修改用户名使用//
    public static bool SyncCheckUserLogin(string userName, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCheckUserLogin_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserName";
        param.Value = userName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        string result = "0";
        try
        {
            result = GenericDataAccess.ExecuteScalar(comm);
        }
        catch
        {
        }

        return (result != "0");
    }

    //根据类别ID检查类别//
    public static bool SyncCheckCategoryIsExists(int categoryTypeId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCheckCategoryIsExists_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = categoryTypeId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        string result = "0";
        try
        {
            result = GenericDataAccess.ExecuteScalar(comm);
        }
        catch
        {
        }

        return (result != "0");
    }

    //根据ID检查专题//
    public static bool SyncCheckZhuanTiIsExists(int ztId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCheckZhuanTiIsExists_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiID";
        param.Value = ztId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        string result = "0";
        try
        {
            result = GenericDataAccess.ExecuteScalar(comm);
        }
        catch
        {
        }

        return (result != "0");
    }

    //根据ID检查钱包//
    public static bool SyncCheckCardIsExists(int cardId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCheckCardIsExists_v4";
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

        string result = "0";
        try
        {
            result = GenericDataAccess.ExecuteScalar(comm);
        }
        catch
        {
        }

        return (result != "0");
    }

    //同步类别名称//
    public static bool SyncCategoryInsert(UserCategoryEntity userCat)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCategoryInsert_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = userCat.CategoryTypeID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeName";
        param.Value = userCat.CategoryTypeName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypePrice";
        param.Value = userCat.CategoryTypePrice;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userCat.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeLive";
        param.Value = userCat.CategoryTypeLive;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = userCat.Synchronize;
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

    //同步专题//
    public static bool SyncZhuanTiInsert(ZhuanTiEntity zhuanTi)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncZhuanTiInsert_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiID";
        param.Value = zhuanTi.ZhuanTiID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiName";
        param.Value = zhuanTi.ZhuanTiName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiImage";
        param.Value = zhuanTi.ZhuanTiImage;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = zhuanTi.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiLive";
        param.Value = zhuanTi.ZhuanTiLive;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = zhuanTi.Synchronize;
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

    //同步钱包//
    public static bool SyncCardInsert(CardEntity card)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCardInsert_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CardID";
        param.Value = card.CardID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CardName";
        param.Value = card.CardName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CardMoney";
        param.Value = card.CardMoney;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = card.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CardLive";
        param.Value = card.CardLive;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = card.Synchronize;
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

    //同步数据初始化//
    public static bool SyncUserDataSynchronize(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncUserDataSynchronize_v4";
        DbParameter param = comm.CreateParameter();
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

    //更新同步类别//
    public static bool SyncCategoryUpdate(UserCategoryEntity userCat)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCategoryUpdate_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = userCat.CategoryTypeID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeName";
        param.Value = userCat.CategoryTypeName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypePrice";
        param.Value = userCat.CategoryTypePrice;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userCat.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeLive";
        param.Value = userCat.CategoryTypeLive;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = userCat.Synchronize;
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

    //更新专题//
    public static bool SyncZhuanTiUpdate(ZhuanTiEntity zhuanTi)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncZhuanTiUpdate_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiID";
        param.Value = zhuanTi.ZhuanTiID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiName";
        param.Value = zhuanTi.ZhuanTiName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiImage";
        param.Value = zhuanTi.ZhuanTiImage;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = zhuanTi.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiLive";
        param.Value = zhuanTi.ZhuanTiLive;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = zhuanTi.Synchronize;
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

    //更新钱包//
    public static bool SyncCardUpdate(CardEntity card)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCardUpdate_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CardID";
        param.Value = card.CardID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CardName";
        param.Value = card.CardName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CardMoney";
        param.Value = card.CardMoney;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = card.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CardLive";
        param.Value = card.CardLive;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = card.Synchronize;
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

    //删除同步消费商品，New//
    public static bool SyncDeleteList(int itemId, int itemWebId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncDeleteList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemID";
        param.Value = itemId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemWebID";
        param.Value = itemWebId;
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

    //根据ItemAppID取消费列表，返回DataTable//
    public static DataTable SyncCheckItemListByItemAppId(int itemAppId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCheckItemListByItemAppId_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemAppID";
        param.Value = itemAppId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //更新消费商品网络同步//
    public static bool SyncItemListUpdateByItemAppId(ItemEntity item)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncItemListUpdateByItemAppId_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemAppID";
        param.Value = item.ItemAppID;
        param.DbType = DbType.Int32;
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
        param.ParameterName = "@RegionType";
        param.Value = item.RegionType;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemType";
        param.Value = item.ItemType;
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

    //取消费列表根据ItemID用于更新消费//
    public static DataTable GetItemListById(int itemId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetItemListById_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemID";
        param.Value = itemId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //删除同步删除消费商品//
    public static bool SyncDeleteListWebBack(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncDeleteListWebBack_v4";
        DbParameter param = comm.CreateParameter();
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

    //根据UserID更新类别返回//
    public static bool SyncCategoryWebBack(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCategoryWebBack_v4";
        DbParameter param = comm.CreateParameter();
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

    //根据UserID更新专题返回//
    public static bool SyncZhuanTiWebBack(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncZhuanTiWebBack_v4";
        DbParameter param = comm.CreateParameter();
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

    //根据UserID更新钱包返回//
    public static bool SyncCardWebBack(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncCardWebBack_v4";
        DbParameter param = comm.CreateParameter();
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

    //根据UserID更新用户返回//
    public static bool SyncUserInfoWebBack(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncUserInfoWebBack_v4";
        DbParameter param = comm.CreateParameter();
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

    //更新同步New//
    public static bool SyncItemListWebBack(int itemId, int itemAppId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncItemListWebBack_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ItemID";
        param.Value = itemId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ItemAppID";
        param.Value = itemAppId;
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

    //同步授权登录//
    public static bool SyncInsertOAuth(OAuthEntity oAuth)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncInsertOAuth_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = oAuth.User.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OpenID";
        param.Value = oAuth.OpenID;
        param.DbType = DbType.String;
        param.Size = 100;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@AccessToken";
        param.Value = oAuth.AccessToken;
        param.DbType = DbType.String;
        param.Size = 100;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OAuthFrom";
        param.Value = oAuth.OAuthFrom;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OAuthBound";
        param.Value = oAuth.OAuthBound;
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

    //修改同步授权登录//
    public static bool SyncUpdateOAuth(OAuthEntity oAuth)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SyncUpdateOAuth_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = oAuth.User.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param); 
        
        param = comm.CreateParameter();
        param.ParameterName = "@OpenID";
        param.Value = oAuth.OpenID;
        param.DbType = DbType.String;
        param.Size = 100;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OAuthBound";
        param.Value = oAuth.OAuthBound;
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

    //检查是否绑定根据UserID//
    public static bool CheckOAuthBound(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CheckOAuthBound_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = 0;
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        if (dt.Rows.Count > 0)
        {
            result = Int32.Parse(dt.Rows[0]["OAuthBound"].ToString());
        }

        return (result != 0);
    }


}