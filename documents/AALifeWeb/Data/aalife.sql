--导出存储过程
SELECT B.[name], A.[text] FROM syscomments A INNER JOIN sysobjects B ON A.ID=B.ID 
WHERE B.xtype='p' ORDER BY B.[name] ASC

SELECT * FROM syscolumns WHERE id=1410104064

SELECT * FROM sysobjects WHERE xtype='u'

--生成插入语句
declare @userid varchar(50)
set @userid='1665'
select 'insert itemtable(ItemID,','ItemName,','CategoryTypeID,','ItemPrice,','ItemBuyDate,','UserID,','UserID,','Recommend,','Remark,','ModifyDate,','Synchronize,','ItemAppID) values('as'--',ItemID,',',''''+ItemName+'''',',',CategoryTypeID,',',''''+CONVERT(VARCHAR,ItemPrice)+'''',',',''''+CONVERT(VARCHAR,ItemBuyDate,121)+'''',',',UserID,',',UserID,',',Recommend,',',''''+Remark+'''',',',''''+CONVERT(VARCHAR,ModifyDate,121)+'''',',',Synchronize,',',ItemAppID,')'
from itemtable where userid=@userid

--修改存储过程所有者
Select 'Alter SCHEMA dbo TRANSFER ' + s.Name + '.' + p.Name 
FROM sys.Procedures p INNER JOIN sys.Schemas s on p.schema_id = s.schema_id 
Where s.Name = 'pyfxl'

--删除未使用数据
SELECT * FROM UserTable WHERE UserID IN (
  SELECT UserID FROM ItemTable WHERE YEAR(ModifyDate) = YEAR(GETDATE()) AND MONTH(ModifyDate) = MONTH(GETDATE())
)

--更新查询
--(MS SQL Server)语句：update b   set   ClientName    = a.name    from a,b    where a.id = b.id  
--(Oralce)语句：update b   set   (ClientName)    =   (SELECT name FROM a WHERE b.id = a.id)

--删除临时表
if object_id('tempdb..#unit') is not null drop table #unit

--行转列
--select 姓名,语言,数学,英语
--from 表名
--pivot
--(max(成绩) for 科目 in([语言],[数学],[英语])) as d

--用户名
sp_helpuser
exec sp_change_users_login 'AUTO_FIX', 'dotnet'

--修复数据库
use ZHHF_20150714  
go  
ALTER DATABASE ZHHF_20150714 SET SINGLE_USER   --设置为单用户  
DBCC CHECKDB (ZHHF_20150714, repair_allow_data_loss) with NO_INFOMSGS   --允许丢失错误 
--DBCC CHECKDB (ZHHF_20150714, repair_rebuild)    --不会丢失数据
go  
ALTER DATABASE ZHHF_20150714 SET MULTI_USER   --设置为多用户  
go  