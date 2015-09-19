using System;

/// <summary>
/// UserEntity 的摘要说明
/// </summary>
public class UserEntity
{
    private int _UserID;
    private string _UserName;
    private string _UserPassword;
    private string _UserNickName;
    private string _UserImage;
    private string _UserEmail;
    private string _UserPhone;
    private string _UserTheme;
    private int _UserLevel;
    private string _UserFrom;
    private string _UserCity;
    private double _UserMoney;
    private string _UserWorkDay;
    private string _UserFunction;
    private DateTime _ModifyDate;
    private DateTime _CreateDate;
    private double _CategoryRate;
    private int _Synchronize;

    public UserEntity()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }
    
    public string UserPassword
    {
        get { return _UserPassword; }
        set { _UserPassword = value; }
    }
    
    public string UserNickName
    {
        get { return _UserNickName; }
        set { _UserNickName = value; }
    }
    
    public string UserImage
    {
        get { return _UserImage; }
        set { _UserImage = value; }
    }
    
    public string UserEmail
    {
        get { return _UserEmail; }
        set { _UserEmail = value; }
    }
    
    public string UserPhone
    {
        get { return _UserPhone; }
        set { _UserPhone = value; }
    }

    public string UserTheme
    {
        get { return _UserTheme; }
        set { _UserTheme = value; }
    }

    public int UserLevel
    {
        get { return _UserLevel; }
        set { _UserLevel = value; }
    }
    
    public string UserFrom
    {
        get { return _UserFrom; }
        set { _UserFrom = value; }
    }

    public string UserCity
    {
        get { return _UserCity; }
        set { _UserCity = value; }
    }

    public double UserMoney
    {
        get { return _UserMoney; }
        set { _UserMoney = value; }
    }

    public string UserWorkDay
    {
        get { return _UserWorkDay; }
        set { _UserWorkDay = value; }
    }

    public string UserFunction
    {
        get { return _UserFunction; }
        set { _UserFunction = value; }
    }
    
    public DateTime ModifyDate
    {
        get { return _ModifyDate; }
        set { _ModifyDate = value; }
    }
    
    public DateTime CreateDate
    {
        get { return _CreateDate; }
        set { _CreateDate = value; }
    }

    public double CategoryRate
    {
        get { return _CategoryRate; }
        set { _CategoryRate = value; }
    }

    public int Synchronize
    {
        get { return _Synchronize; }
        set { _Synchronize = value; }
    }

}