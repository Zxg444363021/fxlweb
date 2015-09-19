using System;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;

public class UserAccess
{
    static UserAccess()
    {
    }

    //取管理所有用户//
    public static DataTable GetAdminUserList()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminUserList_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //管理导出用户数据//
    public static DataTable ExportUserData(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "ExportUserData_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取用户资料根据UserID用于更新//
    public static UserEntity GetUserById(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetUserById_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteCommand(comm);

        UserEntity user = new UserEntity();
        if (dt.Rows.Count > 0)
        {
            user.UserID = Int32.Parse(dt.Rows[0]["UserID"].ToString());
            user.UserName = dt.Rows[0]["UserName"].ToString();
            user.UserPassword = dt.Rows[0]["UserPassword"].ToString();
            user.UserNickName = dt.Rows[0]["UserNickName"].ToString();
            user.UserImage = dt.Rows[0]["UserImage"].ToString();
            user.UserEmail = dt.Rows[0]["UserEmail"].ToString();
            user.UserPhone = dt.Rows[0]["UserPhone"].ToString();
            user.UserTheme = dt.Rows[0]["UserTheme"].ToString();
            user.UserLevel = Int32.Parse(dt.Rows[0]["UserLevel"].ToString());
            user.UserFrom = dt.Rows[0]["UserFrom"].ToString();
            user.UserCity = dt.Rows[0]["UserCity"].ToString();
            user.UserMoney = Double.Parse(dt.Rows[0]["UserMoney"].ToString());
            user.UserWorkDay = dt.Rows[0]["UserWorkDay"].ToString();
            user.UserFunction = dt.Rows[0]["UserFunction"].ToString();
            user.ModifyDate = DateTime.Parse(dt.Rows[0]["ModifyDate"].ToString());
            user.CreateDate = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString());
            user.CategoryRate = Double.Parse(dt.Rows[0]["CategoryRate"].ToString());
        }

        return user;
    }
    
    //取管理用户资料根据用户ID//
    public static DataTable GetAdminUserListById(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminUserListById_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //检查登录根据用户名和密码，输出用户ID用于登录//
    public static bool CheckUserLogin(string userName, string userPassword, out int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CheckUserLogin_v4";
        DbParameter param = comm.CreateParameter();
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

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        userId = 0;
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
            userId = Int32.Parse(comm.Parameters["@UserID"].Value.ToString());
        }
        catch
        {
        }

        return (userId != 0);
    }
    
    //检查用户名是否重复//
    public static bool CheckUserRepeat(string userName)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CheckUserRepeat_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserName";
        param.Value = userName;
        param.DbType = DbType.String;
        param.Size = 20;
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

    //注册新用户，输出用户ID用于登录//
    public static bool InsertUser(UserEntity user, out int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "InsertUser_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserName";
        param.Value = user.UserName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserPassword";
        param.Value = user.UserPassword;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserNickName";
        param.Value = user.UserNickName;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserImage";
        param.Value = user.UserImage;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserEmail";
        param.Value = user.UserEmail;
        param.DbType = DbType.String;
        param.Size = 100;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserPhone";
        param.Value = user.UserPhone;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param); 
        
        param = comm.CreateParameter();
        param.ParameterName = "@UserTheme";
        param.Value = user.UserTheme;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserFrom";
        param.Value = user.UserFrom;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserWorkDay";
        param.Value = user.UserWorkDay;
        param.DbType = DbType.String;
        param.Size = 2;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserMoney";
        param.Value = user.UserMoney;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryRate";
        param.Value = user.CategoryRate;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        userId = 0;
        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
            userId = Int32.Parse(comm.Parameters["@UserID"].Value.ToString());
        }
        catch
        {
        }

        return (userId != 0);
    }

    //更新用户资料//
    public static bool UpdateUser(UserEntity user)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateUser_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = user.UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserName";
        param.Value = user.UserName;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserPassword";
        param.Value = user.UserPassword;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserNickName";
        param.Value = user.UserNickName;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserImage";
        param.Value = user.UserImage;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@UserEmail";
        param.Value = user.UserEmail;
        param.DbType = DbType.String;
        param.Size = 100;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserPhone";
        param.Value = user.UserPhone;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserTheme";
        param.Value = user.UserTheme;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserLevel";
        param.Value = user.UserLevel;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserFrom";
        param.Value = user.UserFrom;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserCity";
        param.Value = user.UserCity;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserMoney";
        param.Value = user.UserMoney;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserWorkDay";
        param.Value = user.UserWorkDay;
        param.DbType = DbType.String;
        param.Size = 2;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CategoryRate";
        param.Value = user.CategoryRate;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = user.Synchronize;
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

    //更新用户头像资料//
    public static bool UpdateUserImage(int userId, string userImage)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateUserImage_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@UserImage";
        param.Value = userImage;
        param.DbType = DbType.String;
        param.Size = 200;
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

    //根据UserID取密码并返回//
    public static string GetUserPasswordById(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetUserPasswordById_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteScalar(comm);
    }

    //更新密码//
    public static bool UpdateUserPassword(int userId, string userPassword)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateUserPassword_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserPassword";
        param.Value = userPassword;
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

    //更新功能设置//
    public static bool UpdateUserFunction(int userId, string funValue)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateUserFunction_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserFunction";
        param.Value = funValue;
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

    //取管理用户列表根据日期//
    public static DataTable GetAdminUserListByDate(string date)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminUserListByDate_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取管理用户列表根据关键字//
    public static DataTable GetAdminUserListByKeywords(string keywords)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminUserListByKeywords_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Keywords";
        param.Value = keywords;
        param.DbType = DbType.String;
        param.Size = 20;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //删除用户//
    public static bool DeleteUser(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "DeleteUser_v4";
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

    //更新主题//
    public static void UpdateUserTheme(int userId, string userTheme)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateUserTheme_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserTheme";
        param.Value = userTheme;
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
    }
    
    //取用户功能设置链接
    public static string GetUserFunctionText(string str)
    {
        string result = "<p><img src='/Images/Others/ico_meet.gif' border='0' alt='' /> 常用功能：</p>";

        if (str != "")
        {
            string[] arr = str.Split(',');

            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case "1":
                        result += "<a href='FenLeiZongJi.aspx'>消费分类排行</a>";
                        break;
                    case "2":
                        result += "<a href='ItemNumTop.aspx'>消费次数排行</a>";
                        break;
                    case "3":
                        result += "<a href='ItemPriceTop.aspx'>消费单价排行</a>";
                        break;
                    case "4":
                        result += "<a href='ItemDateTop.aspx'>消费日期排行</a>";
                        break;
                    case "5":
                        result += "<a href='QuJianTongJi.aspx'>消费区间统计</a>";
                        break;
                    case "6":
                        result += "<a href='TuiJianFenXi.aspx'>消费推荐统计</a>";
                        break;
                    case "7":
                        result += "<a href='BiJiaoFenXi.aspx'>消费分析比较</a>";
                        break;
                    case "8":
                        result += "<a href='JianGeFenXi.aspx'>消费间隔分析</a>";
                        break;
                    case "9":
                        result += "<a href='TianShuFenXi.aspx'>消费天数分析</a>";
                        break;
                    case "10":
                        result += "<a href='JiaGeFenXi.aspx'>消费价格分析</a>";
                        break;
                    case "11":
                        result += "<a href='JieHuanFenXi.aspx'>收支借还分析</a>";
                        break;
                    case "12":
                        result += "<a href='QuWeiTongJi.aspx'>趣味统计分析</a>";
                        break;
                    case "13":
                        result += "<a href='UserAdmin.aspx'>用户资料</a>";
                        break;
                    case "14":
                        result += "<a href='UserBoundAdmin.aspx'>用户绑定</a>";
                        break;
                    case "15":
                        result += "<a href='UserCategoryAdmin.aspx'>类别管理</a>";
                        break;
                    case "16":
                        result += "<a href='UserDataAdmin.aspx'>数据管理</a>";
                        break;
                    case "17":
                        result += "<a href='UserFunctionSetting.aspx'>功能设置</a>";
                        break;
                    case "18":
                        result += "<a href='SearchItem.aspx'>消费搜索</a>";
                        break;
                    case "19":
                        result += "<a href='UserLogout.aspx'>用户退出</a>";
                        break;
                    case "20":
                        result += "<a href='UserZhuanTi.aspx'>用户专题</a>";
                        break;
                    case "21":
                        result += "<a href='Helper.aspx'>网站说明</a>";
                        break;
                    case "22":
                        result += "<a href='UserCardAdmin.aspx'>钱包管理</a>";
                        break;
                }
            }

            result += "<a href='UserFunctionSetting.aspx' class='linkedit'>更改</a>";
        }
        else
        {
            result += "<a href='UserFunctionSetting.aspx'>未设置</a>";
        }

        return result;
    }

    public static ListItem[] GetUserWorkDayData()
    {
        ListItem[] items = new ListItem[7];
        items[0] = new ListItem("只周一上班", "1");
        items[1] = new ListItem("一到二上班", "2");
        items[2] = new ListItem("一到三上班", "3");
        items[3] = new ListItem("一到四上班", "4");
        items[4] = new ListItem("周末双休", "5");
        items[5] = new ListItem("周末单休", "6");
        items[6] = new ListItem("全周无休", "7");

        return items;
    }
    
    //更新用户钱包//
    public static bool UpdateUserMoneyNew(int userId, double userMoney)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateUserMoneyNew_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        param = comm.CreateParameter();
        param.ParameterName = "@UserMoney";
        param.Value = userMoney;
        param.DbType = DbType.Double;
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
        
    public static double calcUserMoney(double userMoney, double itemPrice, string itemType, int type)
    {
        if (itemType == "zc" || itemType == "jc" || itemType == "hc")
        {
            if (type == 1)
            {
                userMoney -= itemPrice;
            }
            else
            {
                userMoney += itemPrice;
            }
        }
        else
        {
            if (type == 1)
            {
                userMoney += itemPrice;
            }
            else
            {
                userMoney -= itemPrice;
            }
        }

        return userMoney;
    }


}
