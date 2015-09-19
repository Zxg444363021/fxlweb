using System;
using System.Data;
using System.Data.Common;

public class OAuthAccess
{
    static OAuthAccess()
    {
    }

    //取授权登录列表通过用户ID//
    public static DataTable GetOAuthByUserId(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetOAuthByUserId_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取已绑定列表通过用户ID//
    public static DataTable GetOAuthListBoundById(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetOAuthListBoundById_v2";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取管理授权登录表//
    public static DataTable GetAdminOAuthList(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminOAuthList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //检查授权登录通过OpenID//
    public static bool CheckOAuthLogin(string openId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CheckOAuthLogin_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OpenID";
        param.Value = openId;
        param.DbType = DbType.String;
        param.Size = 100;
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
        
        int result = 1;
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        if (dt.Rows.Count > 0)
        {
            result = Int32.Parse(dt.Rows[0]["OAuthBound"].ToString());
        }

        return (result != 0);
    }

    //检查是否绑定根据OpenID//
    public static int CheckOAuthBoundByOpenId(string openId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CheckOAuthBoundByOpenId_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OpenID";
        param.Value = openId;
        param.DbType = DbType.String;
        param.Size = 100;
        comm.Parameters.Add(param);

        int result = 2;
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        if (dt.Rows.Count > 0)
        {
            result = Int32.Parse(dt.Rows[0]["OAuthBound"].ToString());
        }

        return result;
    }

    //注册授权登录新用户//
    public static bool InsertOAuth(OAuthEntity oAuth)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "InsertOAuth_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserName";
        param.Value = oAuth.User.UserName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserPassword";
        param.Value = oAuth.User.UserPassword;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserNickName";
        param.Value = oAuth.User.UserNickName;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserImage";
        param.Value = oAuth.User.UserImage;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserTheme";
        param.Value = oAuth.User.UserTheme;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserFrom";
        param.Value = oAuth.User.UserFrom;
        param.DbType = DbType.String;
        param.Size = 10;
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

    //绑定授权登录新用户//
    public static bool OAuthBoundNew(int userId, string userName, string userPassword)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "OAuthBoundNew_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserName";
        param.Value = userName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserPassword";
        param.Value = userPassword;
        param.DbType = DbType.String;
        param.Size = 20;
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

    //绑定授权登录已有用户//
    public static bool OAuthBoundUser(int userId, int newUserId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "OAuthBoundUser_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@NewUserID";
        param.Value = newUserId;
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

    //解除授权登录绑定//
    public static bool OAuthBoundCancel(int oauthId, int oldUserId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "OAuthBoundCancel_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OAuthId";
        param.Value = oauthId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OldUserId";
        param.Value = oldUserId;
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

    //取授权登录列表通过OpenID//
    public static DataTable GetOAuthByOpenId(string openId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetOAuthByOpenId_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OpenID";
        param.Value = openId;
        param.DbType = DbType.String;
        param.Size = 100;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }
    
}
