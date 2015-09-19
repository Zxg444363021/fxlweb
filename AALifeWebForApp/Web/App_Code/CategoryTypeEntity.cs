using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// CategoryTypeEntity 的摘要说明
/// </summary>
public class CategoryTypeEntity
{
    private int _CategoryTypeID;
    private string _CategoryTypeName;
    private double _CategoryTypePrice;

	public CategoryTypeEntity()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public int CategoryTypeID
    {
        get { return _CategoryTypeID; }
        set { _CategoryTypeID = value; }
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

}