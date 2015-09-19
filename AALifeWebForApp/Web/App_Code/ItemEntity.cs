using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// ItemEntity 的摘要说明
/// </summary>
public class ItemEntity
{
    private int _ItemID;
    private string _ItemType;
    private string _ItemName;
    private int _CategoryTypeID;
    private double _ItemPrice;
    private DateTime _ItemBuyDate;
    private int _UserID;
    private int _Recommend;
    private int _Synchronize;
    private int _ItemAppID;
    private int _RegionID;
    private string _RegionType;
    private DateTime _ModifyDate;
    private int _ZhuanTiID;
    private int _CardID;

	public ItemEntity()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public int ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }

    public string ItemType
    {
        get { return _ItemType; }
        set { _ItemType = value; }
    }
    
    public string ItemName
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }

    public int CategoryTypeID
    {
        get { return _CategoryTypeID; }
        set { _CategoryTypeID = value; }
    }

    public double ItemPrice
    {
        get { return _ItemPrice; }
        set { _ItemPrice = value; }
    }

    public DateTime ItemBuyDate
    {
        get { return _ItemBuyDate; }
        set { _ItemBuyDate = value; }
    }

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }

    public int Recommend
    {
        get { return _Recommend; }
        set { _Recommend = value; }
    }

    public int Synchronize
    {
        get { return _Synchronize; }
        set { _Synchronize = value; }
    }

    public int ItemAppID
    {
        get { return _ItemAppID; }
        set { _ItemAppID = value; }
    }

    public int RegionID
    {
        get { return _RegionID; }
        set { _RegionID = value; }
    }

    public string RegionType
    {
        get { return _RegionType; }
        set { _RegionType = value; }
    }

    public DateTime ModifyDate
    {
        get { return _ModifyDate; }
        set { _ModifyDate = value; }
    }

    public int ZhuanTiID
    {
        get { return _ZhuanTiID; }
        set { _ZhuanTiID = value; }
    }

    public int CardID
    {
        get { return _CardID; }
        set { _CardID = value; }
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        ItemEntity item = (ItemEntity)obj;
        return item.ItemName.Equals(this.ItemName) && item.ItemBuyDate.ToString("yyyy-MM-dd").Equals(this.ItemBuyDate.ToString("yyyy-MM-dd")) && item.Recommend == this.Recommend;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}