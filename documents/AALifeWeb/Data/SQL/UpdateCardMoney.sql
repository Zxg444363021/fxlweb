--用户表
UPDATE UserTable SET UserMoney = 0, MoneyStart = (
	SELECT UserMoney + ISNULL(ZhiChu, 0) - ISNULL(ShouRu, 0)
	FROM CardTableView ct WITH(NOLOCK)
	LEFT JOIN (
		SELECT UserID, CardID, SUM(ItemPrice) AS ZhiChu
		FROM ItemTableViewAll WITH(NOLOCK)
		WHERE ItemType IN ('zc', 'jc', 'hc') AND CardID = 0
		GROUP BY UserID, CardID
	) zc ON ct.UserID = zc.UserID AND ct.CDID = zc.CardID
	LEFT JOIN (
		SELECT UserID, CardID, SUM(ItemPrice) AS ShouRu
		FROM ItemTableViewAll WITH(NOLOCK)
		WHERE ItemType IN ('sr', 'hr', 'jr') AND CardID = 0
		GROUP BY UserID, CardID
	) sr ON ct.UserID = sr.UserID AND ct.CDID = sr.CardID
	WHERE ct.UserID = UserTable.UserID AND ct.CDID = 0 AND ct.CardMoney <> 0
)

--钱包表
UPDATE CardTable SET CardMoney = 0, MoneyStart = ISNULL((
	SELECT CardMoney + ISNULL(ZhiChu, 0) - ISNULL(ShouRu, 0)
	FROM CardTable ct WITH(NOLOCK)
	LEFT JOIN (
		SELECT UserID, CardID, SUM(ItemPrice) AS ZhiChu
		FROM ItemTableViewAll WITH(NOLOCK)
		WHERE ItemType IN ('zc', 'jc', 'hc') AND CardID > 0
		GROUP BY UserID, CardID
	) zc ON ct.UserID = zc.UserID AND ct.CDID = zc.CardID
	LEFT JOIN (
		SELECT UserID, CardID, SUM(ItemPrice) AS ShouRu
		FROM ItemTableViewAll WITH(NOLOCK)
		WHERE ItemType IN ('sr', 'hr', 'jr') AND CardID > 0
		GROUP BY UserID, CardID
	) sr ON ct.UserID = sr.UserID AND ct.CDID = sr.CardID
	WHERE ct.CardID = CardTable.CardID AND ct.CDID > 0 AND ct.CardMoney <> 0
), 0)
