using System;
using System.Data;
using System.Data.Common;

public class UserCategoryAccess
{
    static UserCategoryAccess()
    {
    }

    //取管理用户类别//
    public static DataTable GetAdminUserCategoryList(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminUserCategoryList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取消费类别列表//
    public static DataTable GetCategoryTypeList(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetCategoryTypeList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取类别表原始数据用于数据导入时比较//暂时不用//
    public static DataTable GetCategoryTypeTable()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetCategoryTypeTable_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }    

    //删除用户类别名称//
    public static bool DeleteCategoryType(UserCategoryEntity userCat)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "DeleteCategoryType_v4";
        DbParameter param = comm.CreateParameter();
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
        param.ParameterName = "@CategoryTypeID";
        param.Value = userCat.CategoryTypeID;
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

    //更新用户类别名称//
    public static bool UpdateCategoryType(UserCategoryEntity userCat)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateCategoryType_v4";
        DbParameter param = comm.CreateParameter();
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
        param.ParameterName = "@CategoryTypeID";
        param.Value = userCat.CategoryTypeID;
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

    //插入用户类别名称//输出类别ID用于数据导入时插入类别//
    public static bool InsertCategoryType(UserCategoryEntity userCat, out int catTypeId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "InsertCategoryType_v4";
        DbParameter param = comm.CreateParameter();
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

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        catTypeId = 0;
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
            catTypeId = Int32.Parse(comm.Parameters["@CategoryTypeID"].Value.ToString());
        }
        catch
        {
        }

        return (catTypeId != 0);
    }

    //检查分类是否有消费//
    public static bool CheckItemListByCatId(int userId, int catTypeId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CheckItemListByCatId_v4";
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param); 
        
        param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "@CategoryTypeID";
        param.Value = catTypeId;
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

        return result != "0";
    }
}
