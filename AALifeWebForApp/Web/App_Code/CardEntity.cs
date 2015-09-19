using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// CardEntity 的摘要说明
/// </summary>
public class CardEntity
{
    private int _CardID;
    private string _CardName;
    private string _CardNumber;
    private string _CardImage;
    private double _CardMoney;
    private int _CardLive;
    private int _Synchronize;
    private DateTime _ModifyDate;
    private int _UserID;

    public CardEntity()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int CardID
    {
        get { return _CardID; }
        set { _CardID = value; }
    }

    public string CardName
    {
        get { return _CardName; }
        set { _CardName = value; }
    }

    public string CardNumber
    {
        get { return _CardNumber; }
        set { _CardNumber = value; }
    }

    public string CardImage
    {
        get { return _CardImage; }
        set { _CardImage = value; }
    }

    public double CardMoney
    {
        get { return _CardMoney; }
        set { _CardMoney = value; }
    }

    public int CardLive
    {
        get { return _CardLive; }
        set { _CardLive = value; }
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
    
    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }

}