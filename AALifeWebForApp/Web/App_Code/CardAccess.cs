using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

public class CardAccess
{
	static CardAccess()
	{
	}

    public static DataTable GetAdminCardList(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminCardList_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    public static DataTable GetCardList(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetCardList_v4"; 
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    public static CardEntity GetCardByCardId(int cardId, int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetCardByCardId_v4";
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

        CardEntity card = new CardEntity();
        DataTable dt = GenericDataAccess.ExecuteCommand(comm);
        if (dt.Rows.Count > 0)
        {
            card.CardID = Int32.Parse(dt.Rows[0]["CardID"].ToString());
            card.CardName = dt.Rows[0]["CardName"].ToString();
            card.CardMoney = Double.Parse(dt.Rows[0]["CardMoney"].ToString());
            card.CardLive = Int32.Parse(dt.Rows[0]["CardLive"].ToString());
            card.Synchronize = Int32.Parse(dt.Rows[0]["Synchronize"].ToString());
        }

        return card;
    }

    public static bool InsertCard(CardEntity card)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "InsertCard_v4";
        DbParameter param = comm.CreateParameter();
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

    public static bool CheckItemListByCardId(int userId, int cardId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CheckItemListByCardId_v4";
        DbParameter param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param = comm.CreateParameter();
        param.ParameterName = "@CardID";
        param.Value = cardId;
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
    
    public static bool UpdateCard(CardEntity card)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "UpdateCard_v4";
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
        param.ParameterName = "@CardLive";
        param.Value = card.CardLive;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Synchronize";
        param.Value = card.Synchronize;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = card.UserID;
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