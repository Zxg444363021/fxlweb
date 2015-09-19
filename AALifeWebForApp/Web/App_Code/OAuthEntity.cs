using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// OAuthEntity 的摘要说明
/// </summary>
public class OAuthEntity
{
    private int _OAuthID;
    private string _OpenID;
    private string _AccessToken;
    private UserEntity _User;
    private UserEntity _OldUser;
    private int _OAuthBound;
    private string _OAuthFrom;
    private DateTime _ModifyDate;

	public OAuthEntity()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public int OAuthID
    {
        get { return _OAuthID; }
        set { _OAuthID = value; }
    }

    public string OpenID
    {
        get { return _OpenID; }
        set { _OpenID = value; }
    }

    public string AccessToken
    {
        get { return _AccessToken; }
        set { _AccessToken = value; }
    }

    public UserEntity User
    {
        get { return _User; }
        set { _User = value; }
    }

    public UserEntity OldUser
    {
        get { return _OldUser; }
        set { _OldUser = value; }
    }

    public int OAuthBound
    {
        get { return _OAuthBound; }
        set { _OAuthBound = value; }
    }

    public string OAuthFrom
    {
        get { return _OAuthFrom; }
        set { _OAuthFrom = value; }
    }

    public DateTime ModifyDate
    {
        get { return _ModifyDate; }
        set { _ModifyDate = value; }
    }

}