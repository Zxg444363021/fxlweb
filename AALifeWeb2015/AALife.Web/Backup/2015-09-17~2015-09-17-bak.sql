--备份转账表
DELETE FROM ZhuanZhangTable WHERE ZhuanZhangID IN (34,33,32,31,30,29)
SET IDENTITY_INSERT ZhuanZhangTable ON
INSERT INTO ZhuanZhangTable (ZhuanZhangID, ZhuanZhangFrom, ZhuanZhangTo, ZhuanZhangMoney, ZhuanZhangDate, ZhuanZhangNote, UserID, Synchronize, ZhuanZhangLive, ZZID, ModifyDate) VALUES (34, '2', '11', '200.000', '2015/9/17 23:57:05', '', '1', '1', '1', '3', '2015/9/17 23:57:05')
INSERT INTO ZhuanZhangTable (ZhuanZhangID, ZhuanZhangFrom, ZhuanZhangTo, ZhuanZhangMoney, ZhuanZhangDate, ZhuanZhangNote, UserID, Synchronize, ZhuanZhangLive, ZZID, ModifyDate) VALUES (33, '2', '10', '100.000', '2015/9/17 23:56:58', '', '1', '1', '1', '1', '2015/9/17 23:56:58')
INSERT INTO ZhuanZhangTable (ZhuanZhangID, ZhuanZhangFrom, ZhuanZhangTo, ZhuanZhangMoney, ZhuanZhangDate, ZhuanZhangNote, UserID, Synchronize, ZhuanZhangLive, ZZID, ModifyDate) VALUES (32, '4', '0', '100.000', '2015/9/17 1:02:14', '', '3', '0', '1', '7', '2015/9/17 1:02:14')
INSERT INTO ZhuanZhangTable (ZhuanZhangID, ZhuanZhangFrom, ZhuanZhangTo, ZhuanZhangMoney, ZhuanZhangDate, ZhuanZhangNote, UserID, Synchronize, ZhuanZhangLive, ZZID, ModifyDate) VALUES (31, '2', '0', '100.000', '2015/9/17 1:02:06', '', '3', '0', '1', '5', '2015/9/17 1:02:06')
INSERT INTO ZhuanZhangTable (ZhuanZhangID, ZhuanZhangFrom, ZhuanZhangTo, ZhuanZhangMoney, ZhuanZhangDate, ZhuanZhangNote, UserID, Synchronize, ZhuanZhangLive, ZZID, ModifyDate) VALUES (30, '2', '4', '30.000', '2015/9/17 1:00:35', '', '3', '0', '1', '4', '2015/9/17 1:01:52')
INSERT INTO ZhuanZhangTable (ZhuanZhangID, ZhuanZhangFrom, ZhuanZhangTo, ZhuanZhangMoney, ZhuanZhangDate, ZhuanZhangNote, UserID, Synchronize, ZhuanZhangLive, ZZID, ModifyDate) VALUES (29, '2', '4', '20.000', '2015/9/17 1:00:27', '', '3', '0', '1', '2', '2015/9/17 1:01:52')
SET IDENTITY_INSERT ZhuanZhangTable OFF

--备份钱包表
DELETE FROM CardTable WHERE CardID IN (1699,1698,161,19,1)
SET IDENTITY_INSERT CardTable ON
INSERT INTO CardTable (CardID, CardName, UserID, CDID, CardMoney, MoneyStart, CardNumber, CardImage, Synchronize, CardLive, ModifyDate) VALUES (1699, 'BBB', '3', '4', '0.000', '300.000', '', '', '0', '1', '2015/9/17 1:02:14')
INSERT INTO CardTable (CardID, CardName, UserID, CDID, CardMoney, MoneyStart, CardNumber, CardImage, Synchronize, CardLive, ModifyDate) VALUES (1698, 'AAA', '3', '2', '0.000', '1050.000', '', '', '0', '1', '2015/9/17 1:02:06')
INSERT INTO CardTable (CardID, CardName, UserID, CDID, CardMoney, MoneyStart, CardNumber, CardImage, Synchronize, CardLive, ModifyDate) VALUES (161, '支付宝', '1', '11', '0.000', '470.380', '', '', '1', '1', '2015/9/17 23:57:05')
INSERT INTO CardTable (CardID, CardName, UserID, CDID, CardMoney, MoneyStart, CardNumber, CardImage, Synchronize, CardLive, ModifyDate) VALUES (19, '硬币', '1', '10', '0.000', '142.300', '', '', '1', '1', '2015/9/17 23:56:58')
INSERT INTO CardTable (CardID, CardName, UserID, CDID, CardMoney, MoneyStart, CardNumber, CardImage, Synchronize, CardLive, ModifyDate) VALUES (1, '中国银行', '1', '2', '0.000', '18143.500', '', '', '1', '1', '2015/9/17 23:57:05')
SET IDENTITY_INSERT CardTable OFF

--清除删除表
DELETE FROM ItemTable WHERE ItemID IN (448671, 448672, 448673, 448674, 448675, 448676, 448677, 448678, 448679, 448680, 448681, 448682, 448683, 448684, 448685, 448686, 448687, 448688, 448689, 448690, 448691, 448692, 448693, 448694, 448695, 448696, 448697, 448698, 448699, 448700, 448701, 455208, 459505, 460481, 460483, 462436, 463216, 473086, 475539, 483221, 483269, 484871, 484872, 484873, 484860, 484859, 484855, 484856, 484857, 484858, 491706, 492208, 492207, 492206, 496131, 501737, 502978, 502859, 507484, 507485, 507485, 507486, 509675, 509674, 509676, 515185, 520229)
