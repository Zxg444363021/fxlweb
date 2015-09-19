using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

/// <summary>
/// ZhuanTiAccess 的摘要说明
/// </summary>
public class ZhuanTiAccess
{
	static ZhuanTiAccess()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //取管理专题类别//
    public static DataTable GetAdminZhuanTiList(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminZhuanTiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取专题列表//
    public static DataTable GetZhuanTiList(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetZhuanTiList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取专题列表根据专题ID//
    public static ZhuanTiEntity GetZhuanTiListById(int zhuanTiId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetZhuanTiListById_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiID";
        param.Value = zhuanTiId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        ZhuanTiEntity zhuanTi = new ZhuanTiEntity();
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        if (dt.Rows.Count > 0)
        {
            zhuanTi.ZhuanTiID = Int32.Parse(dt.Rows[0]["ZTID"].ToString());
            zhuanTi.ZhuanTiName = dt.Rows[0]["ZhuanTiName"].ToString();
            zhuanTi.ZhuanTiImage = dt.Rows[0]["ZhuanTiImage"].ToString();
            zhuanTi.ZhuanTiLive = Int32.Parse(dt.Rows[0]["ZhuanTiLive"].ToString());
            zhuanTi.Synchronize = Int32.Parse(dt.Rows[0]["Synchronize"].ToString());
            zhuanTi.ZhuanTiDate = dt.Rows[0]["ZhuanTiDate"].ToString();
            zhuanTi.ZhuanTiShouRu = Double.Parse(dt.Rows[0]["ZhuanTiShouRu"].ToString());
            zhuanTi.ZhuanTiZhiChu = Double.Parse(dt.Rows[0]["ZhuanTiZhiChu"].ToString());
        }

        return zhuanTi;
    }

    //插入专题//
    public static bool InsertZhuanTi(ZhuanTiEntity zhuanTi)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "InsertZhuanTi_v4";
        DbParameter param = comm.CreateParameter();
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

    //更新专题//
    public static bool UpdateZhuanTi(ZhuanTiEntity zhuanTi)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateZhuanTi_v4";
        DbParameter param = comm.CreateParameter();
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
        param.ParameterName = "@ZhuanTiID";
        param.Value = zhuanTi.ZhuanTiID;
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

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = zhuanTi.UserID;
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

    //取专题列表明细//
    public static DataTable GetZhuanTiListDetail(int zhuanTiId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetZhuanTiListDetail_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiID";
        param.Value = zhuanTiId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param); 
        
        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //删除专题//
    public static bool DeleteZhuanTi(int zhuanTiId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "DeleteZhuanTi_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ZhuanTiID";
        param.Value = zhuanTiId;
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
}