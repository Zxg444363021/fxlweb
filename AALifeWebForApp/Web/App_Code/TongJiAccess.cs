using System;
using System.Data;
using System.Data.Common;

public class TongJiAccess
{
    static TongJiAccess()
    {        
    }

    //取消费商品最多次数//
    public static DataTable GetTongJiByItemNameCount()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetTongJiByItemNameCount_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费价格最高//
    public static DataTable GetTongJiByItemPriceMax()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetTongJiByItemPriceMax_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取最后添加消费//
    public static DataTable GetTongJiByItemAddLast()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetTongJiByItemAddLast_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费最多的用户//
    public static DataTable GetTongJiByUserItemCount()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetTongJiByUserItemCount_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取最后消费的用户//
    public static DataTable GetTongJiByUserItemLast()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetTongJiByUserItemLast_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取最后注册的用户//
    public static DataTable GetTongJiByUserAddLast()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetTongJiByUserAddLast_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    } 

}
