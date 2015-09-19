/****** Object:  UserDefinedFunction [dbo].[GetCategoryTypeRate_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCategoryTypeRate_v5]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetCategoryTypeRate_v5]
(@CategoryTypePrice DECIMAL(10, 0),
@CategoryRate DECIMAL(10, 0))

RETURNS NVARCHAR(20)

AS

BEGIN

	IF(@CategoryTypePrice = 0)
	RETURN ''0''
		
	DECLARE @RatePrice DECIMAL(10, 0)
	SET @RatePrice = @CategoryTypePrice - @CategoryTypePrice * (@CategoryRate / 100)
	
	DECLARE @Result NVARCHAR(20)
	SET @Result = CONVERT(NVARCHAR, @CategoryTypePrice - @RatePrice) + '' ~ '' + CONVERT(NVARCHAR, @CategoryTypePrice + @RatePrice)
	
	RETURN @Result

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiXinZeng_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAdminTongJiXinZeng_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetAdminTongJiXinZeng_v5] 
(@BeginDate DATETIME,
@EndDate DATETIME)

AS

BEGIN

DECLARE @UserNum INT
DECLARE @ItemNum INT
DECLARE @ItemNum2 INT

SELECT @UserNum = COUNT(0)
FROM UserTable WITH(NOLOCK) WHERE CreateDate BETWEEN @BeginDate AND @EndDate

SELECT @ItemNum = COUNT(0)
FROM ItemTable WITH(NOLOCK) WHERE UserID <> 1 AND ItemBuyDate BETWEEN @BeginDate AND @EndDate

SELECT @ItemNum2 = COUNT(0)
FROM ItemTable WITH(NOLOCK) WHERE ItemBuyDate BETWEEN @BeginDate AND @EndDate

SELECT @UserNum AS ''新增用户'', @ItemNum AS ''新增消费'', @ItemNum2 AS ''包含作者''

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiQuanBu_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAdminTongJiQuanBu_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetAdminTongJiQuanBu_v5] 

AS

BEGIN

DECLARE @UserNum INT
DECLARE @ItemNum INT
DECLARE @ItemNum2 INT

SELECT @UserNum = COUNT(0) FROM UserTable WITH(NOLOCK) WHERE UserID <> 1
SELECT @ItemNum = COUNT(0) FROM ItemTable WITH(NOLOCK) WHERE UserID <> 1
SELECT @ItemNum2 = COUNT(0) FROM ItemTable WITH(NOLOCK) 

SELECT @UserNum AS ''所有用户'', @ItemNum AS ''所有消费'', @ItemNum2 AS ''包含作者''

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiHuoDong_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAdminTongJiHuoDong_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetAdminTongJiHuoDong_v5] 
(@BeginDate DATETIME,
@EndDate DATETIME)

AS

BEGIN

DECLARE @UserNum INT
DECLARE @ItemNum INT
DECLARE @ItemNum2 INT

SELECT @UserNum = COUNT(0)
FROM (SELECT UserID FROM ItemTable WHERE UserID <> 1 AND CONVERT(NVARCHAR(10), ModifyDate, 120) BETWEEN @BeginDate AND @EndDate GROUP BY UserID) tab

SELECT @ItemNum = COUNT(0)
FROM ItemTable WHERE UserID <> 1 AND CONVERT(NVARCHAR(10), ModifyDate, 120) BETWEEN @BeginDate AND @EndDate

SELECT @ItemNum2 = COUNT(0)
FROM ItemTable WHERE CONVERT(NVARCHAR(10), ModifyDate, 120) BETWEEN @BeginDate AND @EndDate

SELECT @UserNum AS ''活动用户'', @ItemNum AS ''活动消费'', @ItemNum2 AS ''包含作者''

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserCategory_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteUserCategory_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteUserCategory_v5]
(@CategoryTypeID INT,
@CategoryTypeName NVARCHAR(20),
@CategoryTypePrice DECIMAL(10, 3),
@UserID INT,
@Synchronize TINYINT,
@CategoryTypeLive TINYINT,
@ModifyDate DATETIME)

AS

BEGIN

DECLARE @Count INT
SELECT @Count = COUNT(0) FROM UserCategoryTable WHERE UserID = @UserID AND CategoryTypeID = @CategoryTypeID

IF(@Count = 0)
	INSERT INTO UserCategoryTable (CategoryTypeID, CategoryTypeName, CategoryTypePrice, UserID, CategoryTypeLive, Synchronize, ModifyDate)
	SELECT CategoryTypeID, CategoryTypeName, CategoryTypePrice, @UserID, @CategoryTypeLive, @Synchronize, @ModifyDate
	FROM CategoryTypeTable WITH(NOLOCK)
	WHERE CategoryTypeID = @CategoryTypeID
ELSE
	UPDATE UserCategoryTable SET CategoryTypeLive = 0, Synchronize = 1
	WHERE UserID = @UserID AND CategoryTypeID = @CategoryTypeID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteItem_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteItem_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteItem_v5]
(@UserID INT,
@ItemID INT,
@ItemAppID INT)

AS

BEGIN

SET XACT_ABORT ON;
BEGIN TRAN

DELETE FROM ItemTable 
WHERE ItemID = @ItemID

INSERT INTO DeleteTable (ItemID, ItemAppID, UserID)
VALUES (@ItemID, @ItemAppID, @UserID)

COMMIT TRAN

END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[CategoryTypeTableFunc_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryTypeTableFunc_v5]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[CategoryTypeTableFunc_v5]
(@UserID INT)

RETURNS @CategoryTypeTable TABLE
(CategoryTypeID INT, 
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3),
CategoryTypeLive TINYINT)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3),
CategoryTypeLive TINYINT)

INSERT INTO @CatTypeTable
SELECT CategoryTypeID, CategoryTypeName, CategoryTypePrice, 1
FROM CategoryTypeTable WITH(NOLOCK)
WHERE NOT EXISTS (
    SELECT CategoryTypeID FROM UserCategoryTable WITH(NOLOCK) WHERE UserID = @UserID AND CategoryTypeTable.CategoryTypeID = UserCategoryTable.CategoryTypeID
)

INSERT INTO @CatTypeTable
SELECT CategoryTypeID, CategoryTypeName, CategoryTypePrice, CategoryTypeLive
FROM UserCategoryTable WITH(NOLOCK)
WHERE UserID = @UserID

INSERT @CategoryTypeTable
SELECT ctt.CategoryTypeID, ctt.CategoryTypeName, ctt.CategoryTypePrice, ctt.CategoryTypeLive
FROM @CatTypeTable ctt 
LEFT JOIN (
    SELECT COUNT(CategoryTypeID) AS CatTypeCount, CategoryTypeID FROM ItemTable WITH(NOLOCK) WHERE UserID = @UserID GROUP BY CategoryTypeID
) ctc ON ctt.CategoryTypeID = ctc.CategoryTypeID
ORDER BY ctc.CatTypeCount DESC, ctt.CategoryTypeID ASC

RETURN

END
' 
END
GO
/****** Object:  View [dbo].[ItemTableView]    Script Date: 04/20/2015 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ItemTableView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ItemTableView]

AS

SELECT it.ItemID, it.ItemName, it.CategoryTypeID, it.ItemPrice, it.ItemBuyDate, it.UserID, 
it.Recommend, it.ModifyDate, it.Synchronize, it.ItemAppID, it.RegionID, rt.RegionType, 
tp.ItemType, ISNULL(it.ZhuanTiID, 0) AS ZhuanTiID, ISNULL(cd.CDID, 0) AS CardID, 
rt.RegionTypeSymbol AS RegionTypeName, tp.ItemTypeName, ISNULL(cd.CardName, ''我的钱包'') as CardName
FROM ItemTable it WITH(NOLOCK)
LEFT JOIN CardTable cd WITH(NOLOCK) ON it.CardID = cd.CDID AND it.UserID = cd.UserID
LEFT JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
LEFT JOIN RegionTypeTable rt WITH(NOLOCK) ON (CASE WHEN it.RegionID<>0 AND it.RegionType='''' THEN ''m'' ELSE it.RegionType END) = rt.RegionType
WHERE CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
'
GO
/****** Object:  View [dbo].[ItemTableTongJiView]    Script Date: 04/20/2015 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ItemTableTongJiView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ItemTableTongJiView]

AS

SELECT ROW_NUMBER() OVER(PARTITION BY ut.UserID ORDER BY ItemBuyDate DESC) AS RowNum,
ItemID, ItemName, ItemPrice, ItemBuyDate, 
ut.UserID, (CASE WHEN UserNickName IS NULL OR UserNickName='''' THEN UserName ELSE UserNickName END) AS UserName, 
ISNULL(UserFromName, ''手机APP'') AS UserFromName, CreateDate
FROM UserTable ut WITH(NOLOCK)
LEFT JOIN UserFromTable uf WITH(NOLOCK) ON ut.UserFrom = uf.UserFrom
LEFT JOIN ItemTable it WITH(NOLOCK) ON it.UserID = ut.UserID
WHERE ut.UserID <> 1
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
'
GO
/****** Object:  UserDefinedFunction [dbo].[GetCardMoney_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCardMoney_v5]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetCardMoney_v5]
(@UserID INT,
@CDID INT,
@CardMoney DECIMAL(10, 3))

RETURNS DECIMAL(10, 3)

AS

BEGIN

    DECLARE @Count INT
    SELECT @Count = COUNT(0) FROM ItemTable WITH(NOLOCK) WHERE UserID = @UserID AND CardID = @CDID
    IF(@Count = 0)
    RETURN @CardMoney

	DECLARE @Result DECIMAL(10, 3)
	
	SET @Result = (
	    SELECT @CardMoney + ISNULL(ShouRu, 0) - ISNULL(ZhiChu, 0)
		FROM (
			SELECT UserID, CardID, SUM(ItemPrice) AS ZhiChu
			FROM ItemTable WITH(NOLOCK)
			WHERE UserID = @UserID AND ISNULL(ItemType, ''zc'') IN (''zc'', ''jc'', ''hc'') AND CardID = @CDID
			AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
			GROUP BY UserID, CardID
		) zc FULL JOIN (
			SELECT UserID, CardID, SUM(ItemPrice) AS ShouRu
			FROM ItemTable WITH(NOLOCK)
			WHERE UserID = @UserID AND ItemType IN (''sr'', ''hr'', ''jr'') AND CardID = @CDID
			AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
			GROUP BY UserID, CardID
		) sr ON zc.UserID = sr.UserID AND zc.CardID = sr.CardID
	)
	
	RETURN @Result

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemDateTopList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemDateTopList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetItemDateTopList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@OrderBy NVARCHAR(10),
@PriceMax DECIMAL(10, 3) OUTPUT)

AS

BEGIN

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT CONVERT(NVARCHAR(10), ItemBuyDate, 120) AS ItemBuyDate, SUM(ZhiChuPrice) AS ZhiChuPrice, SUM(ShouRuPrice) AS ShouRuPrice
INTO #ItemListTable
FROM (
	SELECT ItemBuyDate, ItemPrice AS ZhiChuPrice, 0 AS ShouRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ISNULL(ItemType, ''zc'') IN (''zc'', ''jc'', ''hc'')
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	UNION ALL
	SELECT ItemBuyDate, 0 AS ZhiChuPrice, ItemPrice AS ShouRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType IN (''sr'', ''hr'', ''jr'')
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
) tab
GROUP BY CONVERT(NVARCHAR(10), ItemBuyDate, 120)

SELECT ItemBuyDate, ShouRuPrice, ZhiChuPrice
FROM #ItemListTable WITH(NOLOCK)
ORDER BY CASE WHEN @OrderBy=''list'' THEN ZhiChuPrice END DESC, CASE WHEN @OrderBy=''list'' THEN ShouRuPrice END DESC, CASE WHEN @OrderBy=''chart'' THEN ItemBuyDate END ASC

SELECT @PriceMax = ISNULL(CASE WHEN MAX(ZhiChuPrice) > MAX(ShouRuPrice) THEN MAX(ZhiChuPrice) ELSE MAX(ShouRuPrice) END, 0)
FROM #ItemListTable WITH(NOLOCK)

IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertZhuanTi_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertZhuanTi_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertZhuanTi_v5]
(@ZhuanTiID INT,
@ZhuanTiName NVARCHAR(20),
@ZhuanTiImage NVARCHAR(200),
@UserID INT,
@ZhuanTiLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME,
@ZTID INT)

AS


INSERT INTO ZhuanTiTable (ZhuanTiName, ZhuanTiImage, UserID, ZhuanTiLive, Synchronize, ModifyDate, ZTID)
VALUES (@ZhuanTiName, @ZhuanTiImage, @UserID, @ZhuanTiLive, @Synchronize, @ModifyDate, @ztid)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUserCategory_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertUserCategory_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertUserCategory_v5]
(@CategoryTypeID INT,
@CategoryTypeName NVARCHAR(20),
@CategoryTypePrice DECIMAL(10, 0),
@UserID INT,
@CategoryTypeLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME)

AS


INSERT INTO UserCategoryTable (CategoryTypeID, CategoryTypeName, CategoryTypePrice, UserID, CategoryTypeLive, Synchronize, ModifyDate)
VALUES (@CategoryTypeID, @CategoryTypeName, @CategoryTypePrice, @UserID, @CategoryTypeLive, @Synchronize, @ModifyDate)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertUser_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertUser_v5]
(@UserID INT,
@UserName NVARCHAR(20),
@UserPassword NVARCHAR(20),
@UserNickName NVARCHAR(50),
@UserImage NVARCHAR(200),
@UserPhone NVARCHAR(20),
@UserEmail NVARCHAR(100),
@UserTheme NVARCHAR(10),
@UserLevel TINYINT,
@UserFrom NVARCHAR(10),
@ModifyDate DATETIME,
@CreateDate DATETIME,
@UserCity NVARCHAR(20),
@UserMoney DECIMAL(10, 3),
@UserWorkDay NVARCHAR(2),
@UserFunction NVARCHAR(20),
@CategoryRate INT,
@Synchronize TINYINT,
@MoneyStart DECIMAL(10, 3),
@IsUpdate TINYINT)

AS

INSERT INTO UserTable (UserName, UserPassword, UserNickName, UserImage, UserPhone, UserEmail, UserTheme, UserLevel, UserFrom, 
ModifyDate, CreateDate, UserCity, UserMoney, UserWorkDay, UserFunction, CategoryRate, Synchronize, MoneyStart, IsUpdate)
VALUES (@UserName, @UserPassword, @UserNickName, @UserImage, @UserPhone, @UserEmail, @UserTheme, @UserLevel, @UserFrom, 
@ModifyDate, @CreateDate, @UserCity, @UserMoney, @UserWorkDay, @UserFunction, @CategoryRate, @Synchronize, @MoneyStart, @IsUpdate)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertOAuth_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertOAuth_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertOAuth_v5]
(@OAuthID INT,
@OpenID NVARCHAR(100),
@AccessToken NVARCHAR(100),
@UserID INT,
@OldUserID INT,
@OAuthBound TINYINT,
@OAuthFrom NVARCHAR(10),
@ModifyDate DATETIME)

AS

INSERT INTO OAuthTable (OpenID, AccessToken, UserID, OldUserID, OAuthBound, OAuthFrom, ModifyDate)
VALUES (@OpenID, @AccessToken, @UserID, @UserID, @OAuthBound, @OAuthFrom, @ModifyDate)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertItem_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertItem_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertItem_v5]
(@ItemID INT,
@ItemName NVARCHAR(20),
@CategoryTypeID INT,
@ItemPrice DECIMAL(10, 3),
@ItemBuyDate DATETIME,
@UserID INT,
@Recommend TINYINT,
@ModifyDate DATETIME,
@Synchronize TINYINT,
@ItemAppID INT,
@RegionID INT,
@RegionType NVARCHAR(10),
@ItemType NVARCHAR(10),
@ZhuanTiID INT,
@CardID INT)

AS

INSERT INTO ItemTable (ItemName, CategoryTypeID, ItemPrice, ItemBuyDate, UserID, Recommend, ModifyDate, Synchronize, 
ItemAppID, RegionID, RegionType, ItemType, ZhuanTiID, CardID)
VALUES (@ItemName, @CategoryTypeID, @ItemPrice, @ItemBuyDate, @UserID, @Recommend, @ModifyDate, @Synchronize, 
@ItemAppID, @RegionID, @RegionType, @ItemType, @ZhuanTiID, @CardID)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCard_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertCard_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertCard_v5]
(@CardID INT,
@CardName NVARCHAR(20),
@CardNumber NVARCHAR(50),
@CardImage NVARCHAR(50),
@CardMoney DECIMAL(10, 3),
@CardLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME,
@CDID INT,
@UserID INT,
@MoneyStart DECIMAL(10, 3))

AS

INSERT INTO CardTable (CardName, CardNumber, CardImage, CardMoney, CardLive, Synchronize, ModifyDate, CDID, UserID, MoneyStart)
VALUES (@CardName, @CardNumber, @CardImage, @CardMoney, @CardLive, @Synchronize, @ModifyDate, @CDID, @UserID, @MoneyStart)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserListByKeywords_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetUserListByKeywords_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetUserListByKeywords_v5]
(@Keywords NVARCHAR(20))

AS

SELECT * 
FROM UserTable WITH(NOLOCK)
WHERE CONVERT(NVARCHAR, UserID) = @Keywords 
OR UserName LIKE ''%''+@Keywords+''%'' OR UserNickName LIKE ''%''+@Keywords+''%'' 
OR UserEmail LIKE ''%''+@Keywords+''%'' OR UserFrom LIKE ''%''+@Keywords+''%''
ORDER BY UserID DESC
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTianShuFenXiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTianShuFenXiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetTianShuFenXiList_v5]
(@UserID INT,
@PageNumber INT,
@PagePerNumber INT,
@HowManyItems INT OUTPUT,
@NotBuyMax INT OUTPUT)

AS

BEGIN

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemBuyDate, ItemName, ItemTypeName
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemBuyTable'') IS NOT NULL DROP TABLE #ItemBuyTable

SELECT ROW_NUMBER() OVER (ORDER BY MAX(ItemBuyDate) DESC) AS RowNumber, ItemTypeName, ItemName, MAX(ItemBuyDate) AS ItemBuyDate, DATEDIFF("d", MAX(ItemBuyDate), GETDATE()) AS NotBuy
INTO #ItemBuyTable
FROM #ItemListTable WITH(NOLOCK)
GROUP BY ItemTypeName, ItemName

SELECT RowNumber, ItemTypeName, ItemName, ItemBuyDate, NotBuy
FROM #ItemBuyTable WITH(NOLOCK)
WHERE RowNumber > (@PageNumber-1) * @PagePerNumber
AND RowNumber <= @PageNumber * @PagePerNumber

--取总数量
SELECT @HowManyItems = COUNT(0) FROM #ItemBuyTable WITH(NOLOCK)

SELECT @NotBuyMax = ISNULL(MAX(NotBuy), 1) 
FROM #ItemBuyTable WITH(NOLOCK)
WHERE RowNumber <= 15

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable
IF OBJECT_ID(''tempdb..#ItemBuyTable'') IS NOT NULL DROP TABLE #ItemBuyTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetShouZhiJieHuanList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetShouZhiJieHuanList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetShouZhiJieHuanList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

BEGIN

SELECT * 
FROM (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ShouRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''sr''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) = CONVERT(NVARCHAR(10), @ItemBuyDate, 120)
	
) A LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ZhiChuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ISNULL(ItemType, ''zc'') = ''zc''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) = CONVERT(NVARCHAR(10), @ItemBuyDate, 120)
	
) B ON A.ID = B.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ShouRuPriceMonth
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''sr''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) C ON C.ID = B.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ZhiChuPriceMonth
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ISNULL(ItemType, ''zc'') = ''zc''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) E ON E.ID = C.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ShouRuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''sr''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) F ON F.ID = E.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ZhiChuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ISNULL(ItemType, ''zc'') = ''zc''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) G ON G.ID = F.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS JieChuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''jc''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) H ON H.ID = G.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS HuanRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''hr''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) I ON I.ID = H.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS JieRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''jr''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) J ON J.ID = I.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS HuanChuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''hc''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) K ON K.ID = J.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS JieChuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''jc''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) L ON L.ID = K.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS HuanRuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''hr''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) M ON M.ID = L.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS JieRuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''jr''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) N ON N.ID = M.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS HuanChuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = ''hc''
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) O ON O.ID = N.ID

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetQuJianTongJiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetQuJianTongJiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetQuJianTongJiList_v5]
(@UserID INT)

AS

SELECT ItemName, ItemPrice, UserID, tp.ItemType, ItemTypeName, RegionID, RegionTypeName, 
CONVERT(NVARCHAR(10), MIN(ItemBuyDate), 120)+''~''+CONVERT(NVARCHAR(10), MAX(ItemBuyDate), 120) AS RegionDate, MIN(ItemBuyDate) AS ItemBuyDate, MAX(ItemBuyDate) AS ItemBuyDateMax
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
INNER JOIN RegionTypeTable rt WITH(NOLOCK) ON (CASE WHEN it.RegionID<>0 AND it.RegionType='''' THEN ''m'' ELSE it.RegionType END) = rt.RegionType
WHERE UserID = @UserID AND RegionID <> 0
GROUP BY ItemName, tp.ItemType, ItemPrice, UserID, ItemTypeName, RegionID, RegionTypeName
ORDER BY RegionID DESC
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetJieHuanFenXiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetJieHuanFenXiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetJieHuanFenXiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@OrderBy NVARCHAR(10))

AS

BEGIN

DECLARE @ItemTable TABLE
(ItemBuyDate DATETIME,
ZhiChuPrice DECIMAL(10, 3),
ShouRuPrice DECIMAL(10, 3),
JieChuPrice DECIMAL(10, 3),
HuanRuPrice DECIMAL(10, 3),
JieRuPrice DECIMAL(10, 3),
HuanChuPrice DECIMAL(10, 3))

INSERT INTO @ItemTable
SELECT ItemBuyDate, ItemPrice, 0, 0, 0, 0, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ISNULL(ItemType, ''zc'') = ''zc''
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, ItemPrice, 0, 0, 0, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = ''sr''
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, 0, ItemPrice, 0, 0, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = ''jc''
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, 0, 0, ItemPrice, 0, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = ''hr''
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, 0, 0, 0, ItemPrice, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = ''jr''
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4),ItemBuyDate,120) END) = (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, 0, 0, 0, 0, ItemPrice
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = ''hc''
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN ''year'' THEN ''1'' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)

SELECT SUM(ZhiChuPrice) AS ZhiChuPrice, SUM(ShouRuPrice) AS ShouRuPrice, SUM(JieChuPrice) AS JieChuPrice, SUM(HuanRuPrice) AS HuanRuPrice, SUM(JieRuPrice) AS JieRuPrice, SUM(HuanChuPrice) AS HuanChuPrice, 
(CASE @OrderBy WHEN ''year'' THEN CONVERT(NVARCHAR(4), ItemBuyDate, 120) ELSE CONVERT(NVARCHAR(7), ItemBuyDate, 120) END) AS ItemBuyDate
FROM @ItemTable
GROUP BY CASE @OrderBy WHEN ''year'' THEN CONVERT(NVARCHAR(4), ItemBuyDate, 120) ELSE CONVERT(NVARCHAR(7), ItemBuyDate, 120) END

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetJianGeFenXiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetJianGeFenXiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetJianGeFenXiList_v5]
(@UserID INT,
@PageNumber INT,
@PagePerNumber INT,
@HowManyItems INT OUTPUT,
@NotBuyMax INT OUTPUT)

AS

BEGIN

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT it.ItemBuyDate, it.ItemName, ItemTypeName
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK) 
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
WHERE it.UserID = @UserID
AND ItemBuyDate NOT IN (
    SELECT MAX(ItemBuyDate) FROM ItemTable WITH(NOLOCK) 
    WHERE UserID = @UserID AND it.ItemName = ItemName
    AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
)
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTableMax'') IS NOT NULL DROP TABLE #ItemListMax

SELECT ItemBuyDate, ItemName, ItemTypeName
INTO #ItemListTableMax
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemBuyTable'') IS NOT NULL DROP TABLE #ItemBuyTable

SELECT ROW_NUMBER() OVER (ORDER BY MAX(a.ItemBuyDate) DESC) AS RowNumber, a.ItemTypeName, a.ItemName, MAX(a.ItemBuyDate) AS ItemBuyDateMax, MAX(b.ItemBuyDate) AS ItemBuyDate, DATEDIFF("d", MAX(b.ItemBuyDate), MAX(a.ItemBuyDate)) AS NotBuy
INTO #ItemBuyTable
FROM #ItemListTableMax a WITH(NOLOCK) 
LEFT JOIN #ItemListTable b WITH(NOLOCK) ON a.ItemName=b.ItemName
GROUP BY a.ItemTypeName, a.ItemName

SELECT RowNumber, ItemTypeName, ItemName, ItemBuyDateMax, ISNULL(ItemBuyDate, ItemBuyDateMax) AS ItemBuyDate, ISNULL(NotBuy, 0) AS NotBuy
FROM #ItemBuyTable WITH(NOLOCK)
WHERE RowNumber > (@PageNumber-1) * @PagePerNumber
AND RowNumber <= @PageNumber * @PagePerNumber

--取总数量
SELECT @HowManyItems = COUNT(0) FROM #ItemBuyTable WITH(NOLOCK)

SELECT @NotBuyMax = ISNULL(MAX(NotBuy), 1) 
FROM #ItemBuyTable WITH(NOLOCK)
WHERE RowNumber <= 15

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable
IF OBJECT_ID(''tempdb..#ItemListTableMax'') IS NOT NULL DROP TABLE #ItemListTableMax
IF OBJECT_ID(''tempdb..#ItemBuyTable'') IS NOT NULL DROP TABLE #ItemBuyTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetJiaGeFenXiMingXiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetJiaGeFenXiMingXiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetJiaGeFenXiMingXiList_v5]
(@UserID INT,
@ItemType NVARCHAR(10),
@ItemName NVARCHAR(20),
@PageNumber INT,
@PagePerNumber INT,
@HowManyItems INT OUTPUT,
@PriceMax DECIMAL(10, 3) OUTPUT)

AS

BEGIN

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT ROW_NUMBER() OVER (ORDER BY ItemPrice DESC) AS RowNumber, ItemName, ItemPrice, ItemBuyDate
INTO #ItemListTable
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ISNULL(ItemType, ''zc'') = @ItemType AND ItemName = @ItemName
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
ORDER BY ItemBuyDate DESC

SELECT RowNumber, ItemName, ItemBuyDate, ItemPrice
FROM #ItemListTable WITH(NOLOCK)
WHERE RowNumber > (@PageNumber-1) * @PagePerNumber
AND RowNumber <= @PageNumber * @PagePerNumber

--取总数量
SELECT @HowManyItems = COUNT(0) FROM #ItemListTable WITH(NOLOCK)

SELECT @PriceMax = ISNULL(MAX(ItemPrice), 0) 
FROM #ItemListTable WITH(NOLOCK)
WHERE RowNumber <= 15

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetJiaGeFenXiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetJiaGeFenXiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetJiaGeFenXiList_v5]
(@UserID INT,
@PageNumber INT,
@PagePerNumber INT,
@HowManyItems INT OUTPUT,
@PriceMax DECIMAL(10, 3) OUTPUT)

AS

BEGIN

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemID, ItemBuyDate, ItemName, ItemTypeName, tp.ItemType, ItemPrice
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)

--删除表
IF OBJECT_ID(''tempdb..#ItemBuyTable'') IS NOT NULL DROP TABLE #ItemBuyTable

SELECT ROW_NUMBER() OVER (PARTITION BY ItemName, ItemType ORDER BY ItemBuyDate DESC) AS RowNumber, ItemID, ItemType, ItemTypeName, ItemName, ItemBuyDate, ItemPrice
INTO #ItemBuyTable
FROM #ItemListTable WITH(NOLOCK)

--删除表
IF OBJECT_ID(''tempdb..#ItemRowTable'') IS NOT NULL DROP TABLE #ItemRowTable

SELECT ROW_NUMBER() OVER (ORDER BY ItemBuyDate DESC) AS RowNumber, ItemID, ItemType, ItemTypeName, ItemName, ItemBuyDate, ItemPrice
INTO #ItemRowTable
FROM #ItemBuyTable WITH(NOLOCK)
WHERE RowNumber = 1

SELECT RowNumber, ItemType, ItemTypeName, ItemName, ItemBuyDate, ItemPrice, ''itemName=''+ItemName+''&itemType=''+ItemType AS PageUrl
FROM #ItemRowTable
WHERE RowNumber > (@PageNumber-1) * @PagePerNumber
AND RowNumber <= @PageNumber * @PagePerNumber

--取总数量
SELECT @HowManyItems = COUNT(0) FROM #ItemRowTable

SELECT @PriceMax = ISNULL(MAX(ItemPrice), 0) 
FROM #ItemRowTable
WHERE RowNumber <= 15

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable
IF OBJECT_ID(''tempdb..#ItemBuyTable'') IS NOT NULL DROP TABLE #ItemBuyTable
IF OBJECT_ID(''tempdb..#ItemRowTable'') IS NOT NULL DROP TABLE #ItemRowTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemPriceTopList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemPriceTopList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetItemPriceTopList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

SELECT ItemTypeName, ItemName, ItemPrice, ItemBuyDate
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
ORDER BY ItemPrice DESC, ItemBuyDate DESC
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemNumTopList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemNumTopList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetItemNumTopList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

BEGIN

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemBuyDate, ItemPrice, ItemName, ItemTypeName, tp.ItemType
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
ORDER BY ItemBuyDate ASC

SELECT ItemType, ItemTypeName, ItemName, COUNT(ItemName) AS CountNum, SUM(ItemPrice) AS ItemPrice, ''itemName=''+ItemName+''&itemType=''+ItemType AS PageUrl
FROM #ItemListTable WITH(NOLOCK)
GROUP BY ItemType, ItemTypeName, ItemName
ORDER BY CountNum DESC, ItemPrice DESC

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemNumDetailList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemNumDetailList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetItemNumDetailList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@CategoryTypeID INT,
@ItemType NVARCHAR(10),
@ItemName NVARCHAR(20),
@OrderBy NVARCHAR(10))

AS

BEGIN

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemTypeName, ItemName, ItemPrice, ItemBuyDate, UserID, CategoryTypeID
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
WHERE UserID = @UserID AND tp.ItemType = @ItemType AND ItemName = @ItemName
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
ORDER BY CASE WHEN @OrderBy=''list'' THEN ItemPrice END DESC, CASE WHEN @OrderBy=''chart'' THEN ItemBuyDate END ASC

IF(@CategoryTypeID = 0)
    SELECT ItemTypeName, ItemName, ItemPrice, ItemBuyDate, UserID, CategoryTypeID
    FROM #ItemListTable WITH(NOLOCK)
ELSE
    SELECT ItemTypeName, ItemName, ItemPrice, ItemBuyDate, UserID, CategoryTypeID
    FROM #ItemListTable WITH(NOLOCK) WHERE CategoryTypeID = @CategoryTypeID

--删除表
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateZhuanTi_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateZhuanTi_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateZhuanTi_v5]
(@ZhuanTiID INT,
@ZhuanTiName NVARCHAR(20),
@ZhuanTiImage NVARCHAR(200),
@UserID INT,
@ZhuanTiLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME,
@ZTID INT)

AS

UPDATE ZhuanTiTable SET ZhuanTiName = @ZhuanTiName, ZhuanTiImage = @ZhuanTiImage, ZhuanTiLive = @ZhuanTiLive, 
Synchronize = @Synchronize, ModifyDate = @ModifyDate
WHERE UserID = @UserID AND ZTID = @ZTID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserCategory_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateUserCategory_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateUserCategory_v5]
(@CategoryTypeID INT,
@CategoryTypeName NVARCHAR(20),
@CategoryTypePrice DECIMAL(10, 0),
@UserID INT,
@CategoryTypeLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME)

AS


UPDATE UserCategoryTable SET CategoryTypeName = @CategoryTypeName, CategoryTypePrice = @CategoryTypePrice, CategoryTypeLive = @CategoryTypeLive, 
Synchronize = @Synchronize, ModifyDate = @ModifyDate
WHERE UserID = @UserID AND CategoryTypeID = @CategoryTypeID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateUser_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateUser_v5]
(@UserID INT,
@UserName NVARCHAR(20),
@UserPassword NVARCHAR(20),
@UserNickName NVARCHAR(50),
@UserImage NVARCHAR(200),
@UserPhone NVARCHAR(20),
@UserEmail NVARCHAR(100),
@UserTheme NVARCHAR(10),
@UserLevel TINYINT,
@UserFrom NVARCHAR(10),
@ModifyDate DATETIME,
@CreateDate DATETIME,
@UserCity NVARCHAR(20),
@UserMoney DECIMAL(10, 3),
@UserWorkDay NVARCHAR(2),
@UserFunction NVARCHAR(20),
@CategoryRate INT,
@Synchronize TINYINT,
@MoneyStart DECIMAL(10, 3),
@IsUpdate TINYINT)

AS

UPDATE UserTable
SET UserName = @UserName, UserPassword = @UserPassword, UserNickName = @UserNickName, UserImage = @UserImage, 
UserPhone = @UserPhone, UserEmail = @UserEmail, UserTheme = @UserTheme, UserLevel = @UserLevel, UserFrom = @UserFrom, 
ModifyDate = @ModifyDate, CreateDate = @CreateDate, UserCity = @UserCity, UserMoney = @UserMoney, UserWorkDay = @UserWorkDay, 
UserFunction = @UserFunction, CategoryRate = @CategoryRate, Synchronize = @Synchronize, MoneyStart = @MoneyStart, IsUpdate = @IsUpdate
WHERE UserID = @UserID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSyncByUserId_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateSyncByUserId_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateSyncByUserId_v5]
(@UserID INT)

AS

BEGIN

SET XACT_ABORT ON;
BEGIN TRAN

DELETE FROM DeleteTable WHERE UserID = @UserID

UPDATE UserCategoryTable SET Synchronize = 1
WHERE UserID = @UserID

UPDATE ZhuanTiTable SET Synchronize = 1
WHERE UserID = @UserID

UPDATE CardTable SET Synchronize = 1
WHERE UserID = @UserID

UPDATE ItemTable SET Synchronize = 1, ItemAppID = 0
WHERE UserID = @UserID

COMMIT TRAN

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateOAuth_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateOAuth_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateOAuth_v5]
(@OAuthID INT,
@OpenID NVARCHAR(100),
@AccessToken NVARCHAR(100),
@UserID INT,
@OldUserID INT,
@OAuthBound TINYINT,
@OAuthFrom NVARCHAR(10),
@ModifyDate DATETIME)

AS

UPDATE OAuthTable SET OpenID = @OpenID, AccessToken = @AccessToken, UserID = @UserID, OldUserID = @OldUserID, OAuthBound = @OAuthBound, OAuthFrom = @OAuthFrom, ModifyDate = @ModifyDate
WHERE OAuthID = @OAuthID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateItemByItemAppId_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateItemByItemAppId_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateItemByItemAppId_v5]
(@ItemID INT,
@ItemName NVARCHAR(20),
@CategoryTypeID INT,
@ItemPrice DECIMAL(10, 3),
@ItemBuyDate DATETIME,
@UserID INT,
@Recommend TINYINT,
@ModifyDate DATETIME,
@Synchronize TINYINT,
@ItemAppID INT,
@RegionID INT,
@RegionType NVARCHAR(10),
@ItemType NVARCHAR(10),
@ZhuanTiID INT,
@CardID INT)

AS

UPDATE ItemTable
SET ItemName = @ItemName, CategoryTypeID = @CategoryTypeID, ItemPrice = @ItemPrice, ItemBuyDate = @ItemBuyDate, 
Recommend = @Recommend, ModifyDate = @ModifyDate, Synchronize = @Synchronize,
RegionID = @RegionID, RegionType = @RegionType, ItemType = @ItemType, ZhuanTiID = @ZhuanTiID, CardID = @CardID
WHERE UserID = @UserID AND ItemAppID = @ItemAppID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateItem_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/****** Object:  StoredProcedure [dbo].[UpdateItem_v4]    Script Date: 03/20/2015 23:09:34 ******/
CREATE PROCEDURE [dbo].[UpdateItem_v5]
(@ItemID INT,
@ItemName NVARCHAR(20),
@CategoryTypeID INT,
@ItemPrice DECIMAL(10, 3),
@ItemBuyDate DATETIME,
@UserID INT,
@Recommend TINYINT,
@ModifyDate DATETIME,
@Synchronize TINYINT,
@ItemAppID INT,
@RegionID INT,
@RegionType NVARCHAR(10),
@ItemType NVARCHAR(10),
@ZhuanTiID INT,
@CardID INT)

AS

UPDATE ItemTable
SET ItemName = @ItemName, CategoryTypeID = @CategoryTypeID, ItemPrice = @ItemPrice, ItemBuyDate = @ItemBuyDate, 
UserID = @UserID, Recommend = @Recommend, ModifyDate = @ModifyDate, Synchronize = @Synchronize, ItemAppID = @ItemAppID, 
RegionID = @RegionID, RegionType = @RegionType, ItemType = @ItemType, ZhuanTiID = @ZhuanTiID, CardID = @CardID
WHERE ItemID = @ItemID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCard_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateCard_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateCard_v5]
(@CardID INT,
@CardName NVARCHAR(20),
@CardNumber NVARCHAR(50),
@CardImage NVARCHAR(50),
@CardMoney DECIMAL(10, 3),
@CardLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME,
@CDID INT,
@UserID INT,
@MoneyStart DECIMAL(10, 3))

AS

UPDATE CardTable SET CardName = @CardName, CardNumber = @CardNumber, CardImage = @CardImage, CardMoney = @CardMoney, CardLive = @CardLive, 
Synchronize = @Synchronize, ModifyDate = @ModifyDate, MoneyStart = @MoneyStart
WHERE UserID = @UserID AND CDID = @CDID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBalanceMoney_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateBalanceMoney_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateBalanceMoney_v5]
(@UserID INT,
@ItemID INT,
@ItemType NVARCHAR(10),
@ItemPrice DECIMAL(10, 3),
@Type NVARCHAR(10),
@CDID INT)

AS

BEGIN

DECLARE @OldMoney DECIMAL(10, 3)
DECLARE @NewMoney DECIMAL(10, 3)

--取钱包金额
IF(@CDID = 0)
    SELECT @OldMoney = UserMoney FROM UserTable WITH(NOLOCK) WHERE UserID = @UserID
ELSE
    SELECT @OldMoney = CardMoney FROM CardTable WITH(NOLOCK) WHERE UserID = @UserID AND CDID = @CDID

--更新取旧数据
IF(@Type = ''update'')
    SELECT @ItemType = ItemType, @ItemPrice = ItemPrice FROM ItemTable WITH(NOLOCK) WHERE ItemID = @ItemID

--根据@Type判读是增还是减
IF(@ItemType IN (''zc'', ''jc'', ''hc''))
    IF(@Type = ''insert'')
        SET @NewMoney = @OldMoney - @ItemPrice
    ELSE
        SET @NewMoney = @OldMoney + @ItemPrice
ELSE
    IF(@Type = ''insert'')
        SET @NewMoney = @OldMoney + @ItemPrice
    ELSE
        SET @NewMoney = @OldMoney - @ItemPrice

--更新钱包
IF(@CDID = 0)
    UPDATE UserTable SET UserMoney = @NewMoney, Synchronize = 1 WHERE UserID = @UserID
ELSE
    UPDATE CardTable SET CardMoney = @NewMoney, Synchronize = 1 WHERE UserID = @UserID AND CDID = @CDID

END
' 
END
GO
/****** Object:  View [dbo].[ZhuanTiTableView]    Script Date: 04/20/2015 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ZhuanTiTableView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ZhuanTiTableView]

AS

SELECT zt.ZhuanTiID, zt.ZhuanTiName, zt.ZhuanTiImage, zt.UserID, zt.ZhuanTiLive, zt.Synchronize, zt.ModifyDate, zt.ZTID, 
ISNULL(t3.ZhuanTiDate, ''~'') AS ZhuanTiDate, ISNULL(t2.ZhuanTiPrice, 0) AS ZhuanTiShouRu, ISNULL(t1.ZhuanTiPrice, 0) AS ZhuanTiZhiChu, ISNULL(t2.ZhuanTiPrice, 0)-ISNULL(t1.ZhuanTiPrice, 0) AS ZhuanTiJieCun
FROM ZhuanTiTable zt WITH(NOLOCK)
LEFT JOIN (
    SELECT UserID, ZhuanTiID, ISNULL(SUM(ItemPrice), 0) AS ZhuanTiPrice
    FROM ItemTable WITH(NOLOCK)
    WHERE ZhuanTiID > 0 AND ISNULL(ItemType, ''zc'') IN (''zc'', ''jc'', ''hc'')
    AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
    GROUP BY UserID, ZhuanTiID
) t1 ON zt.UserID = t1.UserID AND zt.ZTID = t1.ZhuanTiID 
LEFT JOIN (
	SELECT UserID, ZhuanTiID, ISNULL(SUM(ItemPrice), 0) AS ZhuanTiPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE ZhuanTiID > 0 AND ItemType IN (''sr'', ''hr'', ''jr'')
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	GROUP BY UserID, ZhuanTiID
) t2 ON zt.UserID = t2.UserID AND zt.ZTID = t2.ZhuanTiID 
LEFT JOIN (
	SELECT UserID, ZhuanTiID, CONVERT(NVARCHAR(10), MIN(ItemBuyDate), 120) + '' ~ '' + CONVERT(NVARCHAR(10), MAX(ItemBuyDate), 120) AS ZhuanTiDate
	FROM ItemTable WITH(NOLOCK)
	WHERE ZhuanTiID > 0
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	GROUP BY UserID, ZhuanTiID
) t3 ON zt.UserID = t3.UserID AND zt.ZTID = t3.ZhuanTiID
WHERE ZhuanTiLive = 1
'
GO
/****** Object:  View [dbo].[UserTableView]    Script Date: 04/20/2015 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[UserTableView]'))
EXEC dbo.sp_executesql @statement = N'


CREATE VIEW [dbo].[UserTableView]

AS

SELECT UserID, UserName, UserPassword, UserNickName, UserImage, UserPhone, UserEmail, UserTheme, UserLevel, ut.UserFrom, ModifyDate, CreateDate, UserCity, UserMoney, UserWorkDay, 
UserFunction, CategoryRate, Synchronize, MoneyStart, IsUpdate, ISNULL(UserFromName, ''手机APP'') AS UserFromName
FROM UserTable ut WITH(NOLOCK)
LEFT JOIN UserFromTable uf WITH(NOLOCK) ON ut.UserFrom = uf.UserFrom


'
GO
/****** Object:  View [dbo].[MonthListView]    Script Date: 04/20/2015 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[MonthListView]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[MonthListView]

AS

SELECT A.ItemID, A.ItemName, A.ItemBuyDate, A.UserID, 
ISNULL(B.ZhiChuPrice, 0) AS ZhiChuPrice, ISNULL(C.ShouRuPrice, 0) AS ShouRuPrice, ISNULL(D.JiePrice, 0) AS JiePrice, ISNULL(E.HuanPrice, 0) AS HuanPrice
FROM ItemTable A WITH(NOLOCK) 
LEFT JOIN (
	SELECT ItemID, ItemPrice AS ZhiChuPrice
	FROM ItemTable WITH(NOLOCK) 
	WHERE ISNULL(ItemType, ''zc'') = ''zc'' 
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
) B ON B.ItemID = A.ItemID 
LEFT JOIN (
	SELECT ItemID, ItemPrice AS ShouRuPrice
	FROM ItemTable WITH(NOLOCK) 
	WHERE ItemType = ''sr'' 
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
) C ON C.ItemID = A.ItemID 
LEFT JOIN (
	SELECT ItemID, CASE WHEN ItemType = ''hr'' THEN -ItemPrice ELSE ItemPrice END AS JiePrice
	FROM ItemTable WITH(NOLOCK) 
	WHERE ItemType IN (''jc'', ''hr'') 
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
) D ON D.ItemID = A.ItemID 
LEFT JOIN (
	SELECT ItemID, CASE WHEN ItemType = ''jr'' THEN -ItemPrice ELSE ItemPrice END AS HuanPrice
	FROM ItemTable WITH(NOLOCK) 
	WHERE ItemType IN (''jr'', ''hc'') 
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
) E ON E.ItemID = A.ItemID
WHERE CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)

'
GO
/****** Object:  View [dbo].[OAuthTableView]    Script Date: 04/20/2015 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[OAuthTableView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[OAuthTableView]

AS

SELECT ot.OAuthID, ot.OpenID, ot.AccessToken, ot.UserID, ot.OldUserID, ot.OAuthBound, ot.OAuthFrom, ot.ModifyDate, 
UserNickName, UserFromName AS OAuthFromName
FROM OAuthTable ot WITH(NOLOCK)
INNER JOIN UserTable ut WITH(NOLOCK) ON ot.OldUserID = ut.UserID
LEFT JOIN UserFromTable uf WITH(NOLOCK) ON ot.OAuthFrom = uf.UserFrom
'
GO
/****** Object:  View [dbo].[CardTableView]    Script Date: 04/20/2015 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[CardTableView]'))
EXEC dbo.sp_executesql @statement = N'


CREATE VIEW [dbo].[CardTableView]

AS

SELECT 0 AS CardID, ''我的钱包'' AS CardName, NULL AS CardNumber, NULL AS CardImage, UserMoney AS CardMoney, CAST(''1'' AS TINYINT) AS CardLive, Synchronize, ModifyDate, 0 AS CDID, UserID, ISNULL(MoneyStart, 0) AS MoneyStart,
(CASE UserMoney WHEN 0 THEN ISNULL(dbo.GetCardMoney_v5(UserID, 0, MoneyStart), 0) ELSE UserMoney END) AS CardBalance
FROM UserTable WITH(NOLOCK)

UNION ALL

SELECT CardID, CardName, CardNumber, CardImage, CardMoney, CardLive, Synchronize, ModifyDate, CDID, UserID, ISNULL(MoneyStart, 0) AS MoneyStart,
(CASE CardMoney WHEN 0 THEN ISNULL(dbo.GetCardMoney_v5(UserID, CDID, MoneyStart), 0) ELSE CardMoney END) AS CardBalance
FROM CardTable WITH(NOLOCK)
WHERE CardLive = 1



'
GO
/****** Object:  View [dbo].[MonthListSumView]    Script Date: 04/20/2015 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[MonthListSumView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[MonthListSumView]

AS

SELECT UserID, CONVERT(NVARCHAR(10), ItemBuyDate, 120) AS ItemBuyDate, 
SUM(ZhiChuPrice) AS ZhiChuPrice, SUM(ShouRuPrice) AS ShouRuPrice, SUM(JiePrice) AS JiePrice, SUM(HuanPrice) AS HuanPrice 
FROM MonthListView WITH(NOLOCK)
GROUP BY UserID, CONVERT(NVARCHAR(10), ItemBuyDate, 120)
'
GO
/****** Object:  StoredProcedure [dbo].[GetItemListByKeywords_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemListByKeywords_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetItemListByKeywords_v5]
(@UserID INT,
@Keywords NVARCHAR(20))

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3),
CategoryTypeLive TINYINT)

INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID) WHERE CategoryTypeLive = 1

SELECT it.*, ct.CategoryTypeName
FROM ItemTableView it WITH(NOLOCK)
LEFT JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE it.UserID = @UserID
AND it.ItemName LIKE ''%''+@Keywords+''%''
ORDER BY it.ItemBuyDate DESC

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetItemList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3),
CategoryTypeLive TINYINT)

INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID) WHERE CategoryTypeLive = 1

SELECT it.*, ct.CategoryTypeName
FROM ItemTableView it WITH(NOLOCK)
LEFT JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) = CONVERT(NVARCHAR(10), @ItemBuyDate, 120)
ORDER BY ItemID ASC

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemExportList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemExportList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetItemExportList_v5]
(@UserID INT)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3),
CategoryTypeLive TINYINT)

INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID) WHERE CategoryTypeLive = 1

SELECT ItemTypeName AS 分类, it.ItemName AS 商品名称, ct.CategoryTypeName AS 商品类别, it.ItemPrice AS 商品价格, CONVERT(NVARCHAR(10), it.ItemBuyDate, 120) AS 购买日期, 
CASE WHEN it.Recommend = 0 THEN ''否'' ELSE ''是'' END AS 推荐否
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
INNER JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE it.UserID = @UserID
ORDER BY it.ItemBuyDate DESC

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetFenLeiZongJiMingXiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetFenLeiZongJiMingXiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetFenLeiZongJiMingXiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@CategoryTypeID INT,
@PriceMax DECIMAL(10, 3) OUTPUT)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3),
CategoryTypeLive TINYINT)

--Fun解决嵌套Exec问题
INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID) WHERE CategoryTypeLive = 1

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemTypeName, it.ItemType, ItemName, ItemPrice, ItemBuyDate, ct.CategoryTypeID
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeTable tp WITH(NOLOCK) ON ISNULL(it.ItemType, ''zc'') = tp.ItemType
INNER JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE ct.CategoryTypeID = @CategoryTypeID 
AND UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)

SELECT ItemType, ItemTypeName, ItemName, COUNT(ItemName) AS CountNum, SUM(ItemPrice) AS ItemPrice, CategoryTypeID, 
''itemName=''+ItemName+''&itemType=''+ItemType+''&catTypeId=''+CONVERT(NVARCHAR(10), CategoryTypeID) AS PageUrl
FROM #ItemListTable WITH(NOLOCK)
GROUP BY ItemType, ItemTypeName, ItemName, CategoryTypeID
ORDER BY CountNum DESC, ItemPrice DESC

SELECT @PriceMax = ISNULL(SUM(ItemPrice), 0)
FROM #ItemListTable WITH(NOLOCK)
GROUP BY ItemType, ItemTypeName, ItemName, CategoryTypeID
ORDER BY SUM(ItemPrice) ASC

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetFenLeiZongJiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetFenLeiZongJiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetFenLeiZongJiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3),
CategoryTypeLive TINYINT)

--Fun解决嵌套Exec问题
INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID) WHERE CategoryTypeLive = 1

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

SELECT ct.CategoryTypeID, ct.CategoryTypeName, ct.CategoryTypePrice, it.ItemPrice
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK) 
INNER JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE UserID = @UserID 
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)

SELECT a.CategoryTypeID, a.CategoryTypeName, MAX(a.CategoryTypePrice) AS CategoryTypePrice, 
ISNULL(SUM(b.ItemPrice), 0) AS ItemPriceTotal, ''catTypeId=''+CONVERT(NVARCHAR(10), a.CategoryTypeID)+''&catTypeName=''+a.CategoryTypeName AS PageUrl
FROM @CatTypeTable a 
LEFT JOIN #ItemListTable b WITH(NOLOCK) ON a.CategoryTypeID = b.CategoryTypeID
GROUP BY a.CategoryTypeID, a.CategoryTypeName
ORDER BY ItemPriceTotal DESC, a.CategoryTypeID ASC

--临时表是否存在
IF OBJECT_ID(''tempdb..#ItemListTable'') IS NOT NULL DROP TABLE #ItemListTable

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetBiJiaoMingXiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBiJiaoMingXiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetBiJiaoMingXiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@CategoryTypeID INT,
@PriceMax DECIMAL(10, 3) OUTPUT,
@CountMax INT OUTPUT)

AS

BEGIN

--临时表是否存在
IF OBJECT_ID(''tempdb..#TempCur'') IS NOT NULL DROP TABLE #TempCur

CREATE TABLE #TempCur
(ItemType NVARCHAR(10),
ItemTypeName NVARCHAR(10),
ItemName NVARCHAR(20),
CountNum INT,
ItemPrice DECIMAL(10, 3),
CategoryTypeID INT,
PageUrl NVARCHAR(100))

DECLARE @PriceMaxCur MONEY
INSERT INTO #TempCur Exec GetFenLeiZongJiMingXiList_v5 @UserID, @ItemBuyDate, @CategoryTypeID, @PriceMaxCur OUTPUT

DECLARE @MonthPrev DATETIME
SET @MonthPrev=CONVERT(NVARCHAR(10), DATEADD(MONTH, -1, @ItemBuyDate), 120)

--临时表是否存在
IF OBJECT_ID(''tempdb..#TempPrev'') IS NOT NULL DROP TABLE #TempPrev

CREATE TABLE #TempPrev
(ItemType NVARCHAR(10),
ItemTypeName NVARCHAR(10),
ItemName NVARCHAR(20),
CountNum INT,
ItemPrice DECIMAL(10,3),
CategoryTypeID INT,
PageUrl NVARCHAR(100))

DECLARE @PriceMaxPrev MONEY
INSERT INTO #TempPrev Exec GetFenLeiZongJiMingXiList_v5 @UserID, @MonthPrev, @CategoryTypeID, @PriceMaxPrev OUTPUT

SELECT a.ItemType AS ItemTypeCur, b.ItemType AS ItemTypePrev, ISNULL(a.ItemName, b.ItemName) AS ItemName, ISNULL(a.CountNum, 0) AS CountNumCur, ISNULL(a.ItemPrice, 0) AS ItemPriceCur,
ISNULL(b.CountNum, 0) AS CountNumPrev, ISNULL(b.ItemPrice, 0) AS ItemPricePrev, a.CategoryTypeID AS CatTypeIDCur, b.CategoryTypeID AS CatTypeIDPrev, 
''itemName=''+a.ItemName+''&itemType=''+a.ItemType+''&catTypeId=''+CONVERT(NVARCHAR(10), a.CategoryTypeID) AS PageUrlCur, ''itemName=''+b.ItemName+''&itemType=''+b.ItemType+''&catTypeId=''+CONVERT(NVARCHAR(10), b.CategoryTypeID) AS PageUrlPrev
FROM #TempCur a WITH(NOLOCK)
FULL JOIN #TempPrev b WITH(NOLOCK) ON b.ItemName = a.ItemName

SELECT @PriceMax = (CASE WHEN ISNULL(MAX(a.ItemPrice), 0) > ISNULL(MAX(b.ItemPrice), 0) THEN ISNULL(MAX(a.ItemPrice), 0) ELSE ISNULL(MAX(b.ItemPrice), 0) END),
@CountMax = (CASE WHEN ISNULL(MAX(a.CountNum), 0) > ISNULL(MAX(b.CountNum), 0) THEN ISNULL(MAX(a.CountNum), 0) ELSE ISNULL(MAX(b.CountNum), 0) END)
FROM #TempCur a WITH(NOLOCK)
FULL JOIN #TempPrev b WITH(NOLOCK) ON b.ItemName = a.ItemName

--临时表是否存在
IF OBJECT_ID(''tempdb..#TempCur'') IS NOT NULL DROP TABLE #TempCur
IF OBJECT_ID(''tempdb..#TempPrev'') IS NOT NULL DROP TABLE #TempPrev

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetBiJiaoFenXiList_v5]    Script Date: 04/20/2015 23:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBiJiaoFenXiList_v5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetBiJiaoFenXiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@OrderBy NVARCHAR(10),
@PriceMax DECIMAL(10,3) OUTPUT)

AS

BEGIN

--临时表是否存在
IF OBJECT_ID(''tempdb..#TempCur'') IS NOT NULL DROP TABLE #TempCur

CREATE TABLE #TempCur 
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3),
ItemPrice DECIMAL(10, 3),
PageUrl NVARCHAR(100))

--插入当月分类总计到临时表
INSERT INTO #TempCur Exec GetFenLeiZongJiList_v5 @UserID, @ItemBuyDate

--定义上月
DECLARE @MonthPrev DATETIME
SET @MonthPrev=CONVERT(NVARCHAR(10), DATEADD(MONTH, -1, @ItemBuyDate), 120)

--临时表是否存在
IF OBJECT_ID(''tempdb..#TempPrev'') IS NOT NULL DROP TABLE #TempPrev

CREATE TABLE #TempPrev
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10,3),
ItemPrice DECIMAL(10,3),
PageUrl NVARCHAR(100))

--插入上月分类总计到临时表
INSERT INTO #TempPrev Exec GetFenLeiZongJiList_v5 @UserID, @MonthPrev

SELECT a.CategoryTypeID, a.CategoryTypeName, a.ItemPrice AS ItemPriceCur, b.ItemPrice AS ItemPricePrev, ''catTypeId=''+CONVERT(NVARCHAR(10), a.CategoryTypeID)+''&catTypeName=''+a.CategoryTypeName AS PageUrl
FROM #TempCur a WITH(NOLOCK)
INNER JOIN #TempPrev b WITH(NOLOCK) ON b.CategoryTypeID = a.CategoryTypeID
ORDER BY CASE WHEN @OrderBy=''chart'' THEN a.CategoryTypeID END ASC, ItemPriceCur DESC, ItemPricePrev DESC

SELECT @PriceMax = CASE WHEN ISNULL(MAX(a.ItemPrice), 0) > ISNULL(MAX(b.ItemPrice), 0) THEN ISNULL(MAX(a.ItemPrice), 0) ELSE ISNULL(MAX(b.ItemPrice), 0) END
FROM #TempCur a WITH(NOLOCK)
INNER JOIN #TempPrev b WITH(NOLOCK) ON b.CategoryTypeID = a.CategoryTypeID

--临时表是否存在
IF OBJECT_ID(''tempdb..#TempCur'') IS NOT NULL DROP TABLE #TempCur
IF OBJECT_ID(''tempdb..#TempPrev'') IS NOT NULL DROP TABLE #TempPrev

END
' 
END
GO
