/****** Object:  StoredProcedure [dbo].[GetBiJiaoFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetBiJiaoFenXiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetBiJiaoMingXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetBiJiaoMingXiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetFenLeiZongJiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetFenLeiZongJiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetFenLeiZongJiMingXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetFenLeiZongJiMingXiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetItemExportList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetItemExportList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetItemList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetItemList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetItemListByKeywords_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetItemListByKeywords_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetUserListByKeywords_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetUserListByKeywords_v5]
GO
/****** Object:  View [dbo].[MonthListSumView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[MonthListSumView]
GO
/****** Object:  View [dbo].[CardTableView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[CardTableView]
GO
/****** Object:  View [dbo].[ZhuanTiTableView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[ZhuanTiTableView]
GO
/****** Object:  View [dbo].[UserTableView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[UserTableView]
GO
/****** Object:  View [dbo].[MonthListView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[MonthListView]
GO
/****** Object:  View [dbo].[OAuthTableView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[OAuthTableView]
GO
/****** Object:  View [dbo].[ItemTableNoCategoryView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[ItemTableNoCategoryView]
GO
/****** Object:  View [dbo].[ItemTableTongJiView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[ItemTableTongJiView]
GO
/****** Object:  View [dbo].[ItemTableView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[ItemTableView]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCard_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[UpdateCard_v5]
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[UpdateItem_v5]
GO
/****** Object:  StoredProcedure [dbo].[UpdateItemByItemAppId_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[UpdateItemByItemAppId_v5]
GO
/****** Object:  StoredProcedure [dbo].[UpdateOAuth_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[UpdateOAuth_v5]
GO
/****** Object:  StoredProcedure [dbo].[UpdateSyncByUserId_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[UpdateSyncByUserId_v5]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[UpdateUser_v5]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserCategory_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[UpdateUserCategory_v5]
GO
/****** Object:  StoredProcedure [dbo].[UpdateZhuanTi_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[UpdateZhuanTi_v5]
GO
/****** Object:  StoredProcedure [dbo].[InsertCard_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[InsertCard_v5]
GO
/****** Object:  StoredProcedure [dbo].[InsertItem_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[InsertItem_v5]
GO
/****** Object:  StoredProcedure [dbo].[InsertOAuth_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[InsertOAuth_v5]
GO
/****** Object:  StoredProcedure [dbo].[InsertUser_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[InsertUser_v5]
GO
/****** Object:  StoredProcedure [dbo].[InsertUserCategory_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[InsertUserCategory_v5]
GO
/****** Object:  StoredProcedure [dbo].[InsertZhuanTi_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[InsertZhuanTi_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetItemListShouZhiJieHuan_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetItemListShouZhiJieHuan_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetItemNumDetailList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetItemNumDetailList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetItemNumTopList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetItemNumTopList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetItemPriceTopList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetItemPriceTopList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetJiaGeFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetJiaGeFenXiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetJiaGeFenXiMingXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetJiaGeFenXiMingXiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetJianGeFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetJianGeFenXiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetJieHuanFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetJieHuanFenXiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetQuJianTongJiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetQuJianTongJiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetTianShuFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetTianShuFenXiList_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetItemDateTopList_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetItemDateTopList_v5]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCardMoney_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP FUNCTION [dbo].[GetCardMoney_v5]
GO
/****** Object:  UserDefinedFunction [dbo].[CategoryTypeTableFunc_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP FUNCTION [dbo].[CategoryTypeTableFunc_v5]
GO
/****** Object:  StoredProcedure [dbo].[DeleteItem_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[DeleteItem_v5]
GO
/****** Object:  StoredProcedure [dbo].[DeleteItemByZhuanTi_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[DeleteItemByZhuanTi_v5]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserCategory_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[DeleteUserCategory_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiHuoDong_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetAdminTongJiHuoDong_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiQuanBu_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetAdminTongJiQuanBu_v5]
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiXinZeng_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP PROCEDURE [dbo].[GetAdminTongJiXinZeng_v5]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCategoryTypeRate_v5]    Script Date: 04/07/2015 22:04:16 ******/
DROP FUNCTION [dbo].[GetCategoryTypeRate_v5]
GO
/****** Object:  View [dbo].[UserFromView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[UserFromView]
GO
/****** Object:  View [dbo].[ItemTypeView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[ItemTypeView]
GO
/****** Object:  View [dbo].[RegionTypeView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[RegionTypeView]
GO
/****** Object:  View [dbo].[UserWorkDayView]    Script Date: 04/07/2015 22:04:16 ******/
DROP VIEW [dbo].[UserWorkDayView]
GO
/****** Object:  View [dbo].[UserWorkDayView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserWorkDayView]
AS

SELECT     '只周一上班' AS WorkDayName, '1' AS WorkDayValue
UNION ALL

SELECT     '一到二上班' AS WorkDayName, '2' AS WorkDayValue
UNION ALL

SELECT     '一到三上班' AS WorkDayName, '3' AS WorkDayValue
UNION ALL

SELECT     '一到四上班' AS WorkDayName, '4' AS WorkDayValue
UNION ALL

SELECT     '周末双休' AS WorkDayName, '5' AS WorkDayValue
UNION ALL

SELECT     '周末单休' AS WorkDayName, '6' AS WorkDayValue
UNION ALL

SELECT     '全周无休' AS WorkDayName, '7' AS WorkDayValue
GO
/****** Object:  View [dbo].[RegionTypeView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RegionTypeView]
AS

SELECT     '每天' AS RegionTypeName, '天' AS RegionTypeSymbol, '1' AS Rank, 'd' AS RegionTypeValue
UNION ALL

SELECT     '每周' AS RegionTypeName, '周' AS RegionTypeSymbol, '2' AS Rank, 'w' AS RegionTypeValue
UNION ALL

SELECT     '每月' AS RegionTypeName, '月' AS RegionTypeSymbol, '3' AS Rank, 'm' AS RegionTypeValue
UNION ALL

SELECT     '每年' AS RegionTypeName, '年' AS RegionTypeSymbol, '4' AS Rank, 'y' AS RegionTypeValue
UNION ALL

SELECT     '工作日' AS RegionTypeName, '班' AS RegionTypeSymbol, '5' AS Rank, 'b' AS RegionTypeValue
GO
/****** Object:  View [dbo].[ItemTypeView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemTypeView]
AS

SELECT     '支出' AS ItemTypeName, '-' AS ItemTypeSymbol, '1' AS Rank, 'zc' AS ItemTypeValue
UNION ALL

SELECT     '收入' AS ItemTypeName, '+' AS ItemTypeSymbol, '2' AS Rank, 'sr' AS ItemTypeValue
UNION ALL

SELECT     '借出' AS ItemTypeName, '借-' AS ItemTypeSymbol, '3' AS Rank, 'jc' AS ItemTypeValue
UNION ALL

SELECT     '还入' AS ItemTypeName, '还+' AS ItemTypeSymbol, '4' AS Rank, 'hr' AS ItemTypeValue
UNION ALL

SELECT     '借入' AS ItemTypeName, '借+' AS ItemTypeSymbol, '5' AS Rank, 'jr' AS ItemTypeValue
UNION ALL

SELECT     '还出' AS ItemTypeName, '还-' AS ItemTypeSymbol, '6' AS Rank, 'hc' AS ItemTypeValue
GO
/****** Object:  View [dbo].[UserFromView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserFromView]
AS

SELECT     'QQ空间' AS UserFromName, 'qz' AS UserFromValue
UNION ALL

SELECT     'WEB QQ' AS UserFromName, 'qw' AS UserFromValue
UNION ALL

SELECT     'QQ登录' AS UserFromName, 'qq' AS UserFromValue
UNION ALL

SELECT     '手机QQ登录' AS UserFromName, 'sjqq' AS UserFromValue
UNION ALL

SELECT     '朋友网' AS UserFromName, 'py' AS UserFromValue
UNION ALL

SELECT     '网站' AS UserFromName, 'web' AS UserFromValue
UNION ALL

SELECT     '手机' AS UserFromName, 'sj' AS UserFromValue
UNION ALL

SELECT     '手机网站' AS UserFromName, 'sjweb' AS UserFromValue
UNION ALL

SELECT     '手机APP' AS UserFromName, 'sjapp' AS UserFromValue
GO
/****** Object:  UserDefinedFunction [dbo].[GetCategoryTypeRate_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetCategoryTypeRate_v5]
(@CategoryTypePrice DECIMAL(10, 0),
@CategoryTypeRate DECIMAL(10, 0))

RETURNS NVARCHAR(20)

AS

BEGIN

	IF(@CategoryTypePrice = 0)
	RETURN '0'
		
	DECLARE @Price DECIMAL(10, 0)
	SET @Price = @CategoryTypePrice - @CategoryTypePrice * (@CategoryTypeRate / 100)
	
	DECLARE @Result NVARCHAR(20)
	SET @Result = CONVERT(NVARCHAR, @CategoryTypePrice - @Price) + ' ~ ' + CONVERT(NVARCHAR, @CategoryTypePrice + @Price)
	
	RETURN @Result

END
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiXinZeng_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdminTongJiXinZeng_v5] 
(@BeginDate DATETIME,
@EndDate DATETIME)

AS

BEGIN

DECLARE @UserNum INT
DECLARE @ItemNum INT
DECLARE @ItemNum2 INT

SELECT @UserNum = COUNT(0)
FROM UserTable WITH(NOLOCK) WHERE CONVERT(NVARCHAR(10), CreateDate, 120) BETWEEN @BeginDate AND @EndDate

SELECT @ItemNum = COUNT(0)
FROM ItemTable WITH(NOLOCK) WHERE UserID <> 1 AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) BETWEEN @BeginDate AND @EndDate

SELECT @ItemNum2 = COUNT(0)
FROM ItemTable WITH(NOLOCK) WHERE CONVERT(NVARCHAR(10), ItemBuyDate, 120) BETWEEN @BeginDate AND @EndDate

SELECT @UserNum AS '当前用户', @ItemNum AS '当前消费', @ItemNum2 AS '包含作者'

END
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiQuanBu_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdminTongJiQuanBu_v5] 

AS

BEGIN

DECLARE @UserNum INT
DECLARE @ItemNum INT
DECLARE @ItemNum2 INT

SELECT @UserNum = COUNT(0) FROM UserTable WITH(NOLOCK) WHERE UserID <> 1
SELECT @ItemNum = COUNT(0) FROM ItemTable WITH(NOLOCK) WHERE UserID <> 1
SELECT @ItemNum2 = COUNT(0) FROM ItemTable WITH(NOLOCK) 

SELECT @UserNum AS '所有用户', @ItemNum AS '所有消费', @ItemNum2 AS '包含作者'

END
GO
/****** Object:  StoredProcedure [dbo].[GetAdminTongJiHuoDong_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdminTongJiHuoDong_v5] 
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

SELECT @UserNum AS '活动用户', @ItemNum AS '活动消费', @ItemNum2 AS '包含作者'

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserCategory_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUserCategory_v5]
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
GO
/****** Object:  StoredProcedure [dbo].[DeleteItemByZhuanTi_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteItemByZhuanTi_v5]
(@UserID INT,
@ZTID INT)

AS

BEGIN

SET XACT_ABORT ON;
BEGIN TRAN

INSERT INTO DeleteTable (ItemID, ItemAppID, UserID)
SELECT ItemID, ItemAppID, UserID
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ZhuanTiID = @ZTID

DELETE FROM ItemTable 
WHERE UserID = @UserID AND ZhuanTiID = @ZTID

COMMIT TRAN

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteItem_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteItem_v5]
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
GO
/****** Object:  UserDefinedFunction [dbo].[CategoryTypeTableFunc_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CategoryTypeTableFunc_v5]
(@UserID INT)

RETURNS @CategoryTypeTable TABLE
(CategoryTypeID INT, 
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3))

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3))

INSERT INTO @CatTypeTable
SELECT CategoryTypeID, CategoryTypeName, CategoryTypePrice
FROM CategoryTypeTable WITH(NOLOCK)
WHERE NOT EXISTS (
    SELECT CategoryTypeID FROM UserCategoryTable WITH(NOLOCK) WHERE UserID = @UserID AND CategoryTypeTable.CategoryTypeID = UserCategoryTable.CategoryTypeID
)

INSERT INTO @CatTypeTable
SELECT CategoryTypeID, CategoryTypeName, CategoryTypePrice
FROM UserCategoryTable WITH(NOLOCK)
WHERE UserID = @UserID AND CategoryTypeLive = 1

INSERT @CategoryTypeTable
SELECT ctt.CategoryTypeID, ctt.CategoryTypeName, ctt.CategoryTypePrice
FROM @CatTypeTable ctt 
LEFT JOIN (
    SELECT COUNT(CategoryTypeID) AS CatTypeCount, CategoryTypeID FROM ItemTable WITH(NOLOCK) WHERE UserID = @UserID GROUP BY CategoryTypeID
) ctc ON ctt.CategoryTypeID = ctc.CategoryTypeID
ORDER BY ctc.CatTypeCount DESC, ctt.CategoryTypeID ASC

RETURN

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCardMoney_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetCardMoney_v5]
(@UserID INT,
@CDID INT,
@CardMoney DECIMAL(10, 3))

RETURNS DECIMAL(10, 3)

AS

BEGIN

	DECLARE @Result DECIMAL(10, 3)
	
	SET @Result = (
	    SELECT @CardMoney + ISNULL(ShouRu, 0) - ISNULL(ZhiChu, 0)
		FROM (
			SELECT UserID, ISNULL(CardID, 0) AS CardID, SUM(ItemPrice) AS ZhiChu
			FROM ItemTable WITH(NOLOCK)
			WHERE UserID = @UserID AND ISNULL(CardID, 0) = @CDID AND ISNULL(ItemType, 'zc') IN ('zc', 'jc', 'hc')
			AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
			GROUP BY UserID, ISNULL(CardID, 0)
		) zc FULL JOIN (
			SELECT UserID, ISNULL(CardID, 0) AS CardID, SUM(ItemPrice) AS ShouRu
			FROM ItemTable WITH(NOLOCK)
			WHERE UserID = @UserID AND ISNULL(CardID, 0) = @CDID AND ItemType IN ('sr', 'hr', 'hr')
			and CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
			GROUP BY UserID, ISNULL(CardID, 0)
		) sr ON zc.UserID = sr.UserID AND zc.CardID = sr.CardID
	)
	
	RETURN @Result

END
GO
/****** Object:  StoredProcedure [dbo].[GetItemDateTopList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemDateTopList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@OrderBy NVARCHAR(10),
@PriceMax DECIMAL(10, 3) OUTPUT)

AS

BEGIN

--删除表
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT CONVERT(NVARCHAR(10), ItemBuyDate, 120) AS ItemBuyDate, SUM(ZhiChuPrice) AS ZhiChuPrice, SUM(ShouRuPrice) AS ShouRuPrice
INTO #ItemListTable
FROM (
	SELECT ItemBuyDate, ItemPrice AS ZhiChuPrice, 0 AS ShouRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND (ISNULL(ItemType, 'zc') = 'zc' OR ItemType = 'jc' OR ItemType = 'hc')
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	UNION ALL
	SELECT ItemBuyDate, 0 AS ZhiChuPrice, ItemPrice AS ShouRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND (ItemType = 'sr' OR ItemType = 'hr' OR ItemType = 'jr')
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
) tab
GROUP BY CONVERT(NVARCHAR(10), ItemBuyDate, 120)

SELECT ItemBuyDate, ShouRuPrice, ZhiChuPrice
FROM #ItemListTable WITH(NOLOCK)
ORDER BY CASE WHEN @OrderBy='list' THEN ZhiChuPrice END DESC, CASE WHEN @OrderBy='list' THEN ShouRuPrice END DESC, CASE WHEN @OrderBy='chart' THEN ItemBuyDate END ASC

SELECT @PriceMax = ISNULL(CASE WHEN MAX(ZhiChuPrice) > MAX(ShouRuPrice) THEN MAX(ZhiChuPrice) ELSE MAX(ShouRuPrice) END, 0)
FROM #ItemListTable WITH(NOLOCK)

IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetTianShuFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTianShuFenXiList_v5]
(@UserID INT,
@PageNumber INT,
@PagePerNumber INT,
@HowManyItems INT OUTPUT,
@NotBuyMax INT OUTPUT)

AS

BEGIN

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemBuyDate, ItemName, ItemTypeName
INTO #ItemListTable
FROM ItemTable a WITH(NOLOCK)
INNER JOIN ItemTypeView b WITH(NOLOCK) ON ISNULL(ItemType, 'zc') = ItemTypeValue
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemBuyTable') IS NOT NULL DROP TABLE #ItemBuyTable

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
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable
IF OBJECT_ID('tempdb..#ItemBuyTable') IS NOT NULL DROP TABLE #ItemBuyTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetQuJianTongJiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetQuJianTongJiList_v5]
(@UserID INT)

AS

SELECT ItemName, ItemPrice, UserID, ISNULL(ItemType, 'zc') AS ItemType, ItemTypeName, RegionTypeName, 
CONVERT(NVARCHAR(10), MIN(ItemBuyDate), 120)+'~'+CONVERT(NVARCHAR(10), MAX(ItemBuyDate), 120) AS RegionDate, MIN(ItemBuyDate) AS ItemBuyDate, MAX(ItemBuyDate) AS ItemBuyDateMax
FROM ItemTable it WITH(NOLOCK)
INNER JOIN ItemTypeView tp WITH(NOLOCK) ON ISNULL(ItemType, 'zc') = ItemTypeValue
INNER JOIN RegionTypeView rt WITH(NOLOCK) ON (CASE WHEN RegionID<>0 AND RegionType='' THEN 'm' ELSE RegionType END) = RegionTypeValue
WHERE UserID = @UserID AND RegionID <> 0
GROUP BY ItemName, ISNULL(ItemType, 'zc'), ItemPrice, UserID, ItemTypeName, RegionTypeName
GO
/****** Object:  StoredProcedure [dbo].[GetJieHuanFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJieHuanFenXiList_v5]
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
WHERE UserID = @UserID AND ISNULL(ItemType, 'zc') = 'zc'
AND (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, ItemPrice, 0, 0, 0, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = 'sr'
AND (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, 0, ItemPrice, 0, 0, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = 'jc'
AND (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, 0, 0, ItemPrice, 0, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = 'hr'
AND (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, 0, 0, 0, ItemPrice, 0
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = 'jr'
AND (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4),ItemBuyDate,120) END) = (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

INSERT INTO @ItemTable
SELECT ItemBuyDate, 0, 0, 0, 0, 0, ItemPrice
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ItemType = 'hc'
AND (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), ItemBuyDate, 120) END) = (CASE @OrderBy WHEN 'year' THEN '1' ELSE CONVERT(NVARCHAR(4), @ItemBuyDate, 120) END)
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

SELECT SUM(ZhiChuPrice) AS ZhiChuPrice, SUM(ShouRuPrice) AS ShouRuPrice, SUM(JieChuPrice) AS JieChuPrice, SUM(HuanRuPrice) AS HuanRuPrice, SUM(JieRuPrice) AS JieRuPrice, SUM(HuanChuPrice) AS HuanChuPrice, 
(CASE @OrderBy WHEN 'year' THEN CONVERT(NVARCHAR(4), ItemBuyDate, 120) ELSE CONVERT(NVARCHAR(7), ItemBuyDate, 120) END) AS ItemBuyDate
FROM @ItemTable
GROUP BY CASE @OrderBy WHEN 'year' THEN CONVERT(NVARCHAR(4), ItemBuyDate, 120) ELSE CONVERT(NVARCHAR(7), ItemBuyDate, 120) END

END
GO
/****** Object:  StoredProcedure [dbo].[GetJianGeFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJianGeFenXiList_v5]
(@UserID INT,
@PageNumber INT,
@PagePerNumber INT,
@HowManyItems INT OUTPUT,
@NotBuyMax INT OUTPUT)

AS

BEGIN

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemBuyDate, ItemName, ItemTypeName
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK) 
INNER JOIN ItemTypeView WITH(NOLOCK) ON ISNULL(ItemType, 'zc') = ItemTypeValue
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 
AND ItemBuyDate NOT IN (
    SELECT MAX(ItemBuyDate) FROM ItemTable WITH(NOLOCK) WHERE CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 
    AND UserID = @UserID AND it.ItemName = ItemName
)

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemListTableMax') IS NOT NULL DROP TABLE #ItemListMax

SELECT ItemBuyDate, ItemName, ItemTypeName
INTO #ItemListTableMax
FROM ItemTable WITH(NOLOCK)
INNER JOIN ItemTypeView ON ISNULL(ItemType, 'zc') = ItemTypeValue
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemBuyTable') IS NOT NULL DROP TABLE #ItemBuyTable

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
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable
IF OBJECT_ID('tempdb..#ItemListTableMax') IS NOT NULL DROP TABLE #ItemListTableMax
IF OBJECT_ID('tempdb..#ItemBuyTable') IS NOT NULL DROP TABLE #ItemBuyTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetJiaGeFenXiMingXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJiaGeFenXiMingXiList_v5]
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
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT ROW_NUMBER() OVER (ORDER BY ItemPrice DESC) AS RowNumber, ItemName, ItemPrice, ItemBuyDate
INTO #ItemListTable
FROM ItemTable WITH(NOLOCK)
WHERE UserID = @UserID AND ISNULL(ItemType, 'zc') = @ItemType AND ItemName = @ItemName
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
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetJiaGeFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetJiaGeFenXiList_v5]
(@UserID INT,
@PageNumber INT,
@PagePerNumber INT,
@HowManyItems INT OUTPUT,
@PriceMax DECIMAL(10, 3) OUTPUT)

AS

BEGIN

--删除表
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemID, ItemBuyDate, ItemName, ItemTypeName, ISNULL(ItemType, 'zc') AS ItemType, ItemPrice
INTO #ItemListTable
FROM ItemTable WITH(NOLOCK)
INNER JOIN ItemTypeView WITH(NOLOCK) ON ISNULL(ItemType, 'zc') = ItemTypeValue
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 

--删除表
IF OBJECT_ID('tempdb..#ItemBuyTable') IS NOT NULL DROP TABLE #ItemBuyTable

SELECT ROW_NUMBER() OVER (PARTITION BY ItemName, ItemType ORDER BY ItemBuyDate DESC) AS RowNumber, ItemID, ItemType, ItemTypeName, ItemName, ItemBuyDate, ItemPrice
INTO #ItemBuyTable
FROM #ItemListTable WITH(NOLOCK)

--删除表
IF OBJECT_ID('tempdb..#ItemRowTable') IS NOT NULL DROP TABLE #ItemRowTable

SELECT ROW_NUMBER() OVER (ORDER BY ItemBuyDate DESC) AS RowNumber, ItemID, ItemType, ItemTypeName, ItemName, ItemBuyDate, ItemPrice
INTO #ItemRowTable
FROM #ItemBuyTable WITH(NOLOCK)
WHERE RowNumber = 1

SELECT RowNumber, ItemType, ItemTypeName, ItemName, ItemBuyDate, ItemPrice, 'itemName='+ItemName+'&itemType='+ItemType AS PageUrl
FROM #ItemRowTable
WHERE RowNumber > (@PageNumber-1) * @PagePerNumber
AND RowNumber <= @PageNumber * @PagePerNumber

--取总数量
SELECT @HowManyItems = COUNT(0) FROM #ItemRowTable

SELECT @PriceMax = ISNULL(MAX(ItemPrice), 0) 
FROM #ItemRowTable
WHERE RowNumber <= 15

--删除表
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable
IF OBJECT_ID('tempdb..#ItemBuyTable') IS NOT NULL DROP TABLE #ItemBuyTable
IF OBJECT_ID('tempdb..#ItemRowTable') IS NOT NULL DROP TABLE #ItemRowTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetItemPriceTopList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemPriceTopList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

SELECT ItemTypeName, ItemName, ItemPrice, ItemBuyDate
FROM ItemTable WITH(NOLOCK)
INNER JOIN ItemTypeView WITH(NOLOCK) ON ISNULL(ItemType,'zc') = ItemTypeValue
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
ORDER BY ItemPrice DESC
GO
/****** Object:  StoredProcedure [dbo].[GetItemNumTopList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemNumTopList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

BEGIN

--删除表
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemBuyDate, ItemPrice, ItemName, ItemTypeName, ISNULL(ItemType, 'zc') AS ItemType
INTO #ItemListTable
FROM ItemTable WITH(NOLOCK)
INNER JOIN ItemTypeView WITH(NOLOCK) ON ISNULL(ItemType, 'zc') = ItemTypeValue
WHERE UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
ORDER BY ItemBuyDate ASC

SELECT ItemType, ItemTypeName, ItemName, COUNT(ItemName) AS CountNum, SUM(ItemPrice) AS ItemPrice, 'itemName='+ItemName+'&itemType='+ItemType AS PageUrl
FROM #ItemListTable WITH(NOLOCK)
GROUP BY ItemType, ItemTypeName, ItemName
ORDER BY CountNum DESC, ItemPrice DESC

--删除表
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetItemNumDetailList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemNumDetailList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@CategoryTypeID INT,
@ItemType NVARCHAR(10),
@ItemName NVARCHAR(20),
@OrderBy NVARCHAR(10))

AS

BEGIN

--删除表
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemTypeName, ItemName, ItemPrice, ItemBuyDate, UserID, CategoryTypeID
INTO #ItemListTable
FROM ItemTable WITH(NOLOCK)
INNER JOIN ItemTypeView WITH(NOLOCK) ON ISNULL(ItemType, 'zc') = ItemTypeValue
WHERE UserID = @UserID AND ISNULL(ItemType, 'zc') = @ItemType AND ItemName = @ItemName 
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
ORDER BY CASE WHEN @OrderBy='list' THEN ItemPrice END DESC, CASE WHEN @OrderBy='chart' THEN ItemBuyDate END ASC

IF(@CategoryTypeID = 0)
    SELECT ItemTypeName, ItemName, ItemPrice, ItemBuyDate, UserID, CategoryTypeID
    FROM #ItemListTable WITH(NOLOCK)
ELSE
    SELECT ItemTypeName, ItemName, ItemPrice, ItemBuyDate, UserID, CategoryTypeID
    FROM #ItemListTable WITH(NOLOCK) WHERE CategoryTypeID = @CategoryTypeID

--删除表
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetItemListShouZhiJieHuan_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemListShouZhiJieHuan_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

BEGIN

SELECT * 
FROM (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ShouRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'sr'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) = CONVERT(NVARCHAR(10), @ItemBuyDate, 120)
	
) A LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ZhiChuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ISNULL(ItemType, 'zc') = 'zc'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) = CONVERT(NVARCHAR(10), @ItemBuyDate, 120)
	
) B ON A.ID = B.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ShouRuPriceMonth
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'sr'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) C ON C.ID = B.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ZhiChuPriceMonth
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ISNULL(ItemType, 'zc') = 'zc'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) E ON E.ID = C.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ShouRuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'sr'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) F ON F.ID = E.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS ZhiChuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ISNULL(ItemType, 'zc') = 'zc'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) G ON G.ID = F.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS JieChuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'jc'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) H ON H.ID = G.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS HuanRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'hr'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) I ON I.ID = H.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS JieRuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'jr'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) J ON J.ID = I.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS HuanChuPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'hc'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)
	
) K ON K.ID = J.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS JieChuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'jc'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) L ON L.ID = K.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS HuanRuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'hr'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) M ON M.ID = L.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS JieRuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'jr'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) N ON N.ID = M.ID LEFT JOIN (

	SELECT 1 AS ID, ISNULL(SUM(ItemPrice), 0) AS HuanChuPriceYear
	FROM ItemTable WITH(NOLOCK)
	WHERE UserID = @UserID AND ItemType = 'hc'
	AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
	AND CONVERT(NVARCHAR(4), ItemBuyDate, 120) = CONVERT(NVARCHAR(4), @ItemBuyDate, 120)
	
) O ON O.ID = N.ID

END
GO
/****** Object:  StoredProcedure [dbo].[InsertZhuanTi_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertZhuanTi_v5]
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
GO
/****** Object:  StoredProcedure [dbo].[InsertUserCategory_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUserCategory_v5]
(@CategoryTypeID INT,
@CategoryTypeName NVARCHAR(20),
@CategoryTypePrice DECIMAL(10, 3),
@UserID INT,
@CategoryTypeLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME)

AS


INSERT INTO UserCategoryTable (CategoryTypeID, CategoryTypeName, CategoryTypePrice, UserID, CategoryTypeLive, Synchronize, ModifyDate)
VALUES (@CategoryTypeID, @CategoryTypeName, @CategoryTypePrice, @UserID, @CategoryTypeLive, @Synchronize, @ModifyDate)
GO
/****** Object:  StoredProcedure [dbo].[InsertUser_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser_v5]
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
@CategoryRate DECIMAL(10, 3),
@Synchronize TINYINT)

AS

INSERT INTO UserTable (UserName, UserPassword, UserNickName, UserImage, UserPhone, UserEmail, UserTheme, UserLevel, UserFrom, 
ModifyDate, CreateDate, UserCity, UserMoney, UserWorkDay, UserFunction, CategoryRate, Synchronize)
VALUES (@UserName, @UserPassword, @UserNickName, @UserImage, @UserPhone, @UserEmail, @UserTheme, @UserLevel, @UserFrom, 
@ModifyDate, @CreateDate, @UserCity, @UserMoney, @UserWorkDay, @UserFunction, @CategoryRate, @Synchronize)
GO
/****** Object:  StoredProcedure [dbo].[InsertOAuth_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOAuth_v5]
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
GO
/****** Object:  StoredProcedure [dbo].[InsertItem_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertItem_v5]
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
GO
/****** Object:  StoredProcedure [dbo].[InsertCard_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCard_v5]
(@CardID INT,
@CardName NVARCHAR(20),
@CardNumber NVARCHAR(50),
@CardImage NVARCHAR(50),
@CardMoney DECIMAL(10, 3),
@CardLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME,
@CDID INT,
@UserID INT)

AS

INSERT INTO CardTable (CardName, CardNumber, CardImage, CardMoney, CardLive, Synchronize, ModifyDate, CDID, UserID)
VALUES (@CardName, @CardNumber, @CardImage, @CardMoney, @CardLive, @Synchronize, @ModifyDate, @CDID, @UserID)
GO
/****** Object:  StoredProcedure [dbo].[UpdateZhuanTi_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateZhuanTi_v5]
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
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserCategory_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUserCategory_v5]
(@CategoryTypeID INT,
@CategoryTypeName NVARCHAR(20),
@CategoryTypePrice DECIMAL(10, 3),
@UserID INT,
@CategoryTypeLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME)

AS


UPDATE UserCategoryTable SET CategoryTypeName = @CategoryTypeName, CategoryTypePrice = @CategoryTypePrice, CategoryTypeLive = @CategoryTypeLive, 
Synchronize = @Synchronize, ModifyDate = @ModifyDate
WHERE UserID = @UserID AND CategoryTypeID = @CategoryTypeID
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser_v5]
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
@CategoryRate DECIMAL(10, 3),
@Synchronize TINYINT)

AS

UPDATE UserTable
SET UserName = @UserName, UserPassword = @UserPassword, UserNickName = @UserNickName, UserImage = @UserImage, 
UserPhone = @UserPhone, UserEmail = @UserEmail, UserTheme = @UserTheme, UserLevel = @UserLevel, UserFrom = @UserFrom, 
ModifyDate = @ModifyDate, CreateDate = @CreateDate, UserCity = @UserCity, UserMoney = @UserMoney, UserWorkDay = @UserWorkDay, 
UserFunction = @UserFunction, CategoryRate = @CategoryRate, Synchronize = @Synchronize
WHERE UserID = @UserID
GO
/****** Object:  StoredProcedure [dbo].[UpdateSyncByUserId_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSyncByUserId_v5]
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
GO
/****** Object:  StoredProcedure [dbo].[UpdateOAuth_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateOAuth_v5]
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
GO
/****** Object:  StoredProcedure [dbo].[UpdateItemByItemAppId_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateItemByItemAppId_v5]
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
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem_v4]    Script Date: 03/20/2015 23:09:34 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[UpdateCard_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCard_v5]
(@CardID INT,
@CardName NVARCHAR(20),
@CardNumber NVARCHAR(50),
@CardImage NVARCHAR(50),
@CardMoney DECIMAL(10, 3),
@CardLive TINYINT,
@Synchronize TINYINT,
@ModifyDate DATETIME,
@CDID INT,
@UserID INT)

AS

UPDATE CardTable SET CardName = @CardName, CardNumber = @CardNumber, CardImage = @CardImage, CardMoney = @CardMoney, CardLive = @CardLive, 
Synchronize = @Synchronize, ModifyDate = @ModifyDate
WHERE UserID = @UserID AND CDID = @CDID
GO
/****** Object:  View [dbo].[ItemTableView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemTableView]

AS

SELECT ItemID, ItemName, CategoryTypeID, ItemPrice, ItemBuyDate, UserID, Recommend, ModifyDate, Synchronize, ItemAppID, 
RegionID, (CASE WHEN RegionID<>0 AND RegionType='' THEN 'm' ELSE RegionType END) AS RegionType, ISNULL(ItemType, 'zc') AS ItemType,
ISNULL(ZhuanTiID,0) AS ZhuanTiID, ISNULL(CardID, 0) AS CardID
FROM ItemTable WITH(NOLOCK)
GO
/****** Object:  View [dbo].[ItemTableTongJiView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemTableTongJiView]

AS

SELECT ROW_NUMBER() OVER(PARTITION BY ut.UserID ORDER BY ItemBuyDate DESC) AS RowNum,
ItemName, ItemPrice, ItemBuyDate, 
(CASE WHEN UserNickName IS NULL OR UserNickName='' THEN UserName ELSE UserNickName END) AS UserName, ISNULL(UserFromName, '手机APP') AS UserFrom, CreateDate
FROM UserTable ut WITH(NOLOCK)
LEFT JOIN UserFromView uf WITH(NOLOCK) ON UserFrom = UserFromValue
LEFT JOIN ItemTable it WITH(NOLOCK) ON it.UserID = ut.UserID AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
WHERE ut.UserID <> 1
GO
/****** Object:  View [dbo].[ItemTableNoCategoryView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemTableNoCategoryView]
AS

SELECT it.ItemID, it.ItemName, it.CategoryTypeID, it.ItemPrice, it.ItemBuyDate, it.UserID, 
it.Recommend, it.ModifyDate, it.Synchronize, it.ItemAppID, it.RegionID, (CASE WHEN it.RegionID<>0 AND it.RegionType='' THEN 'm' ELSE it.RegionType END) AS RegionType, 
it.ItemType, ISNULL(it.ZhuanTiID, 0) AS ZhuanTiID, ISNULL(cd.CDID, 0) AS CardID, 
rg.RegionTypeSymbol AS RegionTypeName, tp.ItemTypeName, ISNULL(cd.CardName, '我的钱包') as CardName
FROM ItemTable it WITH(NOLOCK)
LEFT JOIN CardTable cd WITH(NOLOCK) ON it.CardID = cd.CDID AND it.UserID = cd.UserID
LEFT JOIN ItemTypeView tp WITH(NOLOCK) ON ISNULL(it.ItemType, 'zc') = tp.ItemTypeValue
LEFT JOIN RegionTypeView rg WITH(NOLOCK) ON (CASE WHEN it.RegionID<>0 AND it.RegionType='' THEN 'm' ELSE it.RegionType END) = rg.RegionTypeValue
WHERE CONVERT(NVARCHAR(10), it.ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
GO
/****** Object:  View [dbo].[OAuthTableView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OAuthTableView]

AS

SELECT ot.OAuthID, ot.OpenID, ot.AccessToken, ot.UserID, ot.OldUserID, ot.OAuthBound, ot.OAuthFrom, ot.ModifyDate, 
ut.UserNickName, uf.UserFromName AS OAuthFromName
FROM OAuthTable ot WITH(NOLOCK)
INNER JOIN UserTable ut WITH(NOLOCK) ON ot.OldUserID = ut.UserID
LEFT JOIN UserFromView uf WITH(NOLOCK) ON ot.OAuthFrom = uf.UserFromValue
GO
/****** Object:  View [dbo].[MonthListView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MonthListView]

AS

SELECT A.ItemID, A.ItemName, A.ItemBuyDate, A.UserID, 
ISNULL(B.ZhiChuPrice, 0) AS ZhiChuPrice, ISNULL(C.ShouRuPrice, 0) AS ShouRuPrice, ISNULL(D.JiePrice, 0) AS JiePrice, ISNULL(E.HuanPrice, 0) AS HuanPrice
FROM ItemTable A WITH(NOLOCK) 
LEFT JOIN (
	SELECT ItemID, ItemPrice AS ZhiChuPrice
	FROM ItemTable WITH(NOLOCK) 
	WHERE ISNULL(ItemType, 'zc') = 'zc'
) B ON B.ItemID = A.ItemID 
LEFT JOIN (
	SELECT ItemID, ItemPrice AS ShouRuPrice
	FROM ItemTable WITH(NOLOCK) 
	WHERE ItemType = 'sr'
) C ON C.ItemID = A.ItemID 
LEFT JOIN (
	SELECT ItemID, CASE WHEN ItemType = 'hr' THEN -ItemPrice ELSE ItemPrice END AS JiePrice
	FROM ItemTable WITH(NOLOCK) 
	WHERE ItemType = 'jc' OR ItemType = 'hr'
) D ON D.ItemID = A.ItemID 
LEFT JOIN (
	SELECT ItemID, CASE WHEN ItemType = 'jr' THEN -ItemPrice ELSE ItemPrice END AS HuanPrice
	FROM ItemTable WITH(NOLOCK) 
	WHERE ItemType = 'jr' OR ItemType = 'hc'
) E ON E.ItemID = A.ItemID
WHERE CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120)
GO
/****** Object:  View [dbo].[UserTableView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserTableView]

AS

SELECT UserID, UserName, UserPassword, UserNickName, UserImage, UserPhone, UserEmail, UserTheme, UserLevel, UserFrom, ModifyDate, CreateDate, UserCity, UserMoney, UserWorkDay, 
UserFunction, CategoryRate, Synchronize
FROM UserTable WITH(NOLOCK)
GO
/****** Object:  View [dbo].[ZhuanTiTableView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ZhuanTiTableView]
AS
SELECT zt.ZhuanTiID, zt.ZhuanTiName, zt.ZhuanTiImage, zt.UserID, zt.ZhuanTiLive, zt.Synchronize, zt.ModifyDate, zt.ZTID, 
ISNULL(t3.ZhuanTiDate, '~') AS ZhuanTiDate, ISNULL(t2.ZhuanTiPrice, 0) AS ZhuanTiShouRu, ISNULL(t1.ZhuanTiPrice, 0) AS ZhuanTiZhiChu, ISNULL(t2.ZhuanTiPrice, 0)-ISNULL(t1.ZhuanTiPrice, 0) AS ZhuanTiJieCun
FROM ZhuanTiTable zt WITH(NOLOCK)
LEFT JOIN (
    SELECT UserID, ZhuanTiID, ISNULL(SUM(ItemPrice), 0) AS ZhuanTiPrice
    FROM ItemTable WITH(NOLOCK)
    WHERE ISNULL(ZhuanTiID,0) > 0 AND ISNULL(ItemType, 'zc') IN ('zc', 'jc', 'hc')
    GROUP BY UserID, ZhuanTiID
) t1 ON zt.UserID = t1.UserID AND zt.ZTID = t1.ZhuanTiID 
LEFT JOIN (
	SELECT UserID, ZhuanTiID, ISNULL(SUM(ItemPrice), 0) AS ZhuanTiPrice
	FROM ItemTable WITH(NOLOCK)
	WHERE ISNULL(ZhuanTiID,0) > 0 AND ItemType IN ('sr', 'hr', 'jr')
	GROUP BY UserID, ZhuanTiID
) t2 ON zt.UserID = t2.UserID AND zt.ZTID = t2.ZhuanTiID 
LEFT JOIN (
	SELECT UserID, ZhuanTiID, CONVERT(NVARCHAR(10), MIN(ItemBuyDate), 120) + ' ~ ' + CONVERT(NVARCHAR(10), MAX(ItemBuyDate), 120) AS ZhuanTiDate
	FROM ItemTable WITH(NOLOCK)
	WHERE ISNULL(ZhuanTiID, 0) > 0
	GROUP BY UserID, ZhuanTiID
) t3 ON zt.UserID = t3.UserID AND zt.ZTID = t3.ZhuanTiID
WHERE zt.ZhuanTiLive = 1
GO
/****** Object:  View [dbo].[CardTableView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CardTableView]
AS

SELECT 0 AS CardID, '我的钱包' AS CardName, NULL AS CardNumber, NULL AS CardImage, UserMoney AS CardMoney, CAST('1' AS TINYINT) AS CardLive, 
Synchronize, ModifyDate, 0 AS CDID, UserID, ISNULL(dbo.GetCardMoney_v5(UserID, 0, UserMoney), 0) AS CardJieCun
FROM UserTable WITH(NOLOCK)

UNION ALL

SELECT CardID, CardName, CardNumber, CardImage, CardMoney, CardLive, Synchronize, ModifyDate, CDID, UserID, ISNULL(dbo.GetCardMoney_v5(UserID, CDID, CardMoney), 0) AS CardJieCun
FROM CardTable WITH(NOLOCK)
WHERE CardLive = 1
GO
/****** Object:  View [dbo].[MonthListSumView]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MonthListSumView]

AS

SELECT UserID, CONVERT(NVARCHAR(10), ItemBuyDate, 120) AS ItemBuyDate, 
SUM(ZhiChuPrice) AS ZhiChuPrice, SUM(ShouRuPrice) AS ShouRuPrice, SUM(JiePrice) AS JiePrice, SUM(HuanPrice) AS HuanPrice 
FROM MonthListView WITH(NOLOCK)
GROUP BY UserID, CONVERT(NVARCHAR(10), ItemBuyDate, 120)
GO
/****** Object:  StoredProcedure [dbo].[GetUserListByKeywords_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserListByKeywords_v5]
(@Keywords NVARCHAR(20))

AS

SELECT * 
FROM UserTableView WITH(NOLOCK)
WHERE CONVERT(NVARCHAR, UserID) = @Keywords 
OR UserName LIKE '%'+@Keywords+'%' OR UserNickName LIKE '%'+@Keywords+'%' 
OR UserEmail LIKE '%'+@Keywords+'%' OR UserFrom LIKE '%'+@Keywords+'%'
ORDER BY UserID DESC
GO
/****** Object:  StoredProcedure [dbo].[GetItemListByKeywords_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemListByKeywords_v5]
(@UserID INT,
@Keywords NVARCHAR(20))

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3))

INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID)

SELECT it.*, ct.CategoryTypeName
FROM ItemTableNoCategoryView it WITH(NOLOCK)
LEFT JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE it.UserID = @UserID AND it.ItemName LIKE '%'+@Keywords+'%'
ORDER BY it.ItemBuyDate DESC

END
GO
/****** Object:  StoredProcedure [dbo].[GetItemList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3))

INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID)

SELECT it.*, ct.CategoryTypeName
FROM ItemTableNoCategoryView it WITH(NOLOCK)
LEFT JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE UserID = @UserID 
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) = CONVERT(NVARCHAR(10), @ItemBuyDate, 120)
ORDER BY ItemID ASC

END
GO
/****** Object:  StoredProcedure [dbo].[GetItemExportList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetItemExportList_v5]
(@UserID INT)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3))

INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID)

SELECT it.ItemTypeName AS 分类, it.ItemName AS 商品名称, ct.CategoryTypeName AS 商品类别, it.ItemPrice AS 商品价格, CONVERT(NVARCHAR(10), it.ItemBuyDate, 120) AS 购买日期, 
CASE WHEN it.Recommend = 0 THEN '否' ELSE '是' END AS 推荐否
FROM ItemTableNoCategoryView it WITH(NOLOCK)
INNER JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE it.UserID = @UserID
ORDER BY it.ItemBuyDate DESC

END
GO
/****** Object:  StoredProcedure [dbo].[GetFenLeiZongJiMingXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFenLeiZongJiMingXiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@CategoryTypeID INT,
@PriceMax DECIMAL(10, 3) OUTPUT)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3))

--Fun解决嵌套Exec问题
INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID)

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT ItemTypeName, ISNULL(ItemType, 'zc') AS ItemType, ItemName, ItemPrice, ItemBuyDate, ct.CategoryTypeID
INTO #ItemListTable
FROM ItemTable WITH(NOLOCK)
INNER JOIN ItemTypeView WITH(NOLOCK) ON ISNULL(ItemType, 'zc') = ItemTypeValue
INNER JOIN @CatTypeTable ct ON ItemTable.CategoryTypeID = ct.CategoryTypeID
WHERE ct.CategoryTypeID = @CategoryTypeID 
AND UserID = @UserID
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)

SELECT ItemType, ItemTypeName, ItemName, COUNT(ItemName) AS CountNum, SUM(ItemPrice) AS ItemPrice, CategoryTypeID, 
'itemName='+ItemName+'&itemType='+ItemType+'&catTypeId='+CONVERT(NVARCHAR(10), CategoryTypeID) AS PageUrl
FROM #ItemListTable WITH(NOLOCK)
GROUP BY ItemType, ItemTypeName, ItemName, CategoryTypeID
ORDER BY COUNT(ItemName) DESC, SUM(ItemPrice) DESC

SELECT @PriceMax = ISNULL(SUM(ItemPrice), 0)
FROM #ItemListTable WITH(NOLOCK)
GROUP BY ItemType, ItemTypeName, ItemName, CategoryTypeID
ORDER BY SUM(ItemPrice) ASC

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetFenLeiZongJiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFenLeiZongJiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME)

AS

BEGIN

DECLARE @CatTypeTable TABLE
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10, 3))

--Fun解决嵌套Exec问题
INSERT INTO @CatTypeTable SELECT * FROM dbo.CategoryTypeTableFunc_v5(@UserID)

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

SELECT ct.CategoryTypeID, ct.CategoryTypeName, ct.CategoryTypePrice, it.ItemPrice
INTO #ItemListTable
FROM ItemTable it WITH(NOLOCK) 
INNER JOIN @CatTypeTable ct ON it.CategoryTypeID = ct.CategoryTypeID
WHERE UserID = @UserID 
AND CONVERT(NVARCHAR(10), ItemBuyDate, 120) <= CONVERT(NVARCHAR(10), GETDATE(), 120) 
AND CONVERT(NVARCHAR(7), ItemBuyDate, 120) = CONVERT(NVARCHAR(7), @ItemBuyDate, 120)

SELECT a.CategoryTypeID, a.CategoryTypeName, MAX(a.CategoryTypePrice) AS CategoryTypePrice, 
ISNULL(SUM(b.ItemPrice), 0) AS ItemPriceTotal, 'catTypeId='+CONVERT(NVARCHAR(10), a.CategoryTypeID)+'&catTypeName='+a.CategoryTypeName AS PageUrl
FROM @CatTypeTable a 
LEFT JOIN #ItemListTable b WITH(NOLOCK) ON a.CategoryTypeID = b.CategoryTypeID
GROUP BY a.CategoryTypeID, a.CategoryTypeName
ORDER BY ItemPriceTotal DESC, a.CategoryTypeID ASC

--临时表是否存在
IF OBJECT_ID('tempdb..#ItemListTable') IS NOT NULL DROP TABLE #ItemListTable

END
GO
/****** Object:  StoredProcedure [dbo].[GetBiJiaoMingXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBiJiaoMingXiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@CategoryTypeID INT,
@PriceMax DECIMAL(10, 3) OUTPUT,
@CountMax INT OUTPUT)

AS

BEGIN

--临时表是否存在
IF OBJECT_ID('tempdb..#TempCur') IS NOT NULL DROP TABLE #TempCur

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
IF OBJECT_ID('tempdb..#TempPrev') IS NOT NULL DROP TABLE #TempPrev

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
'itemName='+a.ItemName+'&itemType='+a.ItemType+'&catTypeId='+CONVERT(NVARCHAR(10), a.CategoryTypeID) AS PageUrlCur, 'itemName='+b.ItemName+'&itemType='+b.ItemType+'&catTypeId='+CONVERT(NVARCHAR(10), b.CategoryTypeID) AS PageUrlPrev
FROM #TempCur a WITH(NOLOCK)
FULL JOIN #TempPrev b WITH(NOLOCK) ON b.ItemName = a.ItemName

SELECT @PriceMax = (CASE WHEN ISNULL(MAX(a.ItemPrice), 0) > ISNULL(MAX(b.ItemPrice), 0) THEN ISNULL(MAX(a.ItemPrice), 0) ELSE ISNULL(MAX(b.ItemPrice), 0) END),
@CountMax = (CASE WHEN ISNULL(MAX(a.CountNum), 0) > ISNULL(MAX(b.CountNum), 0) THEN ISNULL(MAX(a.CountNum), 0) ELSE ISNULL(MAX(b.CountNum), 0) END)
FROM #TempCur a WITH(NOLOCK)
FULL JOIN #TempPrev b WITH(NOLOCK) ON b.ItemName = a.ItemName

--临时表是否存在
IF OBJECT_ID('tempdb..#TempCur') IS NOT NULL DROP TABLE #TempCur
IF OBJECT_ID('tempdb..#TempPrev') IS NOT NULL DROP TABLE #TempPrev

END
GO
/****** Object:  StoredProcedure [dbo].[GetBiJiaoFenXiList_v5]    Script Date: 04/07/2015 22:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBiJiaoFenXiList_v5]
(@UserID INT,
@ItemBuyDate DATETIME,
@OrderBy NVARCHAR(10),
@PriceMax DECIMAL(10,3) OUTPUT)

AS

BEGIN

--临时表是否存在
IF OBJECT_ID('tempdb..#TempCur') IS NOT NULL DROP TABLE #TempCur

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
IF OBJECT_ID('tempdb..#TempPrev') IS NOT NULL DROP TABLE #TempPrev

CREATE TABLE #TempPrev
(CategoryTypeID INT,
CategoryTypeName NVARCHAR(20),
CategoryTypePrice DECIMAL(10,3),
ItemPrice DECIMAL(10,3),
PageUrl NVARCHAR(100))

--插入上月分类总计到临时表
INSERT INTO #TempPrev Exec GetFenLeiZongJiList_v5 @UserID, @MonthPrev

SELECT a.CategoryTypeID, a.CategoryTypeName, a.ItemPrice AS ItemPriceCur, b.ItemPrice AS ItemPricePrev, 'catTypeId='+CONVERT(NVARCHAR(10), a.CategoryTypeID)+'&catTypeName='+a.CategoryTypeName AS PageUrl
FROM #TempCur a WITH(NOLOCK)
INNER JOIN #TempPrev b WITH(NOLOCK) ON b.CategoryTypeID = a.CategoryTypeID
ORDER BY CASE WHEN @OrderBy='chart' THEN a.CategoryTypeID END ASC, ItemPriceCur DESC, ItemPricePrev DESC

SELECT @PriceMax = CASE WHEN ISNULL(MAX(a.ItemPrice), 0) > ISNULL(MAX(b.ItemPrice), 0) THEN ISNULL(MAX(a.ItemPrice), 0) ELSE ISNULL(MAX(b.ItemPrice), 0) END
FROM #TempCur a WITH(NOLOCK)
INNER JOIN #TempPrev b WITH(NOLOCK) ON b.CategoryTypeID = a.CategoryTypeID

--临时表是否存在
IF OBJECT_ID('tempdb..#TempCur') IS NOT NULL DROP TABLE #TempCur
IF OBJECT_ID('tempdb..#TempPrev') IS NOT NULL DROP TABLE #TempPrev

END
GO
