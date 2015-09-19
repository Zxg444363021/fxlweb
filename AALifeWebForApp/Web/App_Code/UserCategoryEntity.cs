using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// UserCategoryEntity 的摘要说明
/// </summary>
public class UserCategoryEntity
{
    private int _UserCategoryID;
    private string _CategoryTypeName;
    private double _CategoryTypePrice;
    private int _UserID;
    private int _CategoryTypeID;
    private int _CategoryTypeLive;
    private int _Synchronize;
    private DateTime _ModifyDate;

	public UserCategoryEntity()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public int UserCategoryID
    {
        get { return _UserCategoryID; }
        set { _UserCategoryID = value; }
    }

    public string CategoryTypeName
    {
        get { return _CategoryTypeName; }
        set { _CategoryTypeName = value; }
    }

    public double CategoryTypePrice
    {
        get { return _CategoryTypePrice; }
        set { _CategoryTypePrice = value; }
    }

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }

    public int CategoryTypeID
    {
        get { return _CategoryTypeID; }
        set { _CategoryTypeID = value; }
    }

    public int CategoryTypeLive
    {
        get { return _CategoryTypeLive; }
        set { _CategoryTypeLive = value; }
    }

    public int Synchronize
    {
        get { return _Synchronize; }
        set { _Synchronize = value; }
    }

    public DateTime ModifyDate
    {
        get { return _ModifyDate; }
        set { _ModifyDate = value; }
    }

}