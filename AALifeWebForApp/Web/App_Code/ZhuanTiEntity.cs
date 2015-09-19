using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// ZhuanTiEntity 的摘要说明
/// </summary>
public class ZhuanTiEntity
{
    private int _ZhuanTiID;
    private string _ZhuanTiName;
    private string _ZhuanTiImage;
    private int _UserID;
    private DateTime _ModifyDate;
    private int _ZhuanTiLive;
    private int _Synchronize;
    private string _ZhuanTiDate;
    private double _ZhuanTiShouRu;
    private double _ZhuanTiZhiChu;

	public ZhuanTiEntity()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public int ZhuanTiID
    {
        get { return _ZhuanTiID; }
        set { _ZhuanTiID = value; }
    }

    public string ZhuanTiName
    {
        get { return _ZhuanTiName; }
        set { _ZhuanTiName = value; }
    }

    public string ZhuanTiImage
    {
        get { return _ZhuanTiImage; }
        set { _ZhuanTiImage = value; }
    }

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }

    public DateTime ModifyDate
    {
        get { return _ModifyDate; }
        set { _ModifyDate = value; }
    }

    public int ZhuanTiLive
    {
        get { return _ZhuanTiLive; }
        set { _ZhuanTiLive = value; }
    }

    public int Synchronize
    {
        get { return _Synchronize; }
        set { _Synchronize = value; }
    }

    public string ZhuanTiDate
    {
        get { return _ZhuanTiDate; }
        set { _ZhuanTiDate = value; }
    }

    public double ZhuanTiShouRu
    {
        get { return _ZhuanTiShouRu; }
        set { _ZhuanTiShouRu = value; }
    }

    public double ZhuanTiZhiChu
    {
        get { return _ZhuanTiZhiChu; }
        set { _ZhuanTiZhiChu = value; }
    }
}