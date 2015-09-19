USE [aalife20150903]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ZhuanZhangTable_Synchronize]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ZhuanZhangTable] DROP CONSTRAINT [DF_ZhuanZhangTable_Synchronize]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ZhuanZhangTable_ZhuanZhangLive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ZhuanZhangTable] DROP CONSTRAINT [DF_ZhuanZhangTable_ZhuanZhangLive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ZhuanZhangTable_ModifyDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ZhuanZhangTable] DROP CONSTRAINT [DF_ZhuanZhangTable_ModifyDate]
END

GO

USE [aalife20150903]
GO

/****** Object:  Table [dbo].[ZhuanZhangTable]    Script Date: 09/12/2015 23:07:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZhuanZhangTable]') AND type in (N'U'))
DROP TABLE [dbo].[ZhuanZhangTable]
GO

USE [aalife20150903]
GO

/****** Object:  Table [dbo].[ZhuanZhangTable]    Script Date: 09/12/2015 23:07:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ZhuanZhangTable](
	[ZhuanZhangID] [int] IDENTITY(1,1) NOT NULL,
	[ZhuanZhangFrom] [int] NOT NULL,
	[ZhuanZhangTo] [int] NOT NULL,
	[ZhuanZhangMoney] [decimal](10, 3) NOT NULL,
	[Synchronize] [tinyint] NOT NULL,
	[ZhuanZhangLive] [tinyint] NOT NULL,
	[ModifyDate] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_ZhuanZhangTable] PRIMARY KEY CLUSTERED 
(
	[ZhuanZhangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转账ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZhuanZhangTable', @level2type=N'COLUMN',@level2name=N'ZhuanZhangID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转账来自' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZhuanZhangTable', @level2type=N'COLUMN',@level2name=N'ZhuanZhangFrom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转账给' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZhuanZhangTable', @level2type=N'COLUMN',@level2name=N'ZhuanZhangTo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转账金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZhuanZhangTable', @level2type=N'COLUMN',@level2name=N'ZhuanZhangMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同步否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZhuanZhangTable', @level2type=N'COLUMN',@level2name=N'Synchronize'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZhuanZhangTable', @level2type=N'COLUMN',@level2name=N'ZhuanZhangLive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZhuanZhangTable', @level2type=N'COLUMN',@level2name=N'ModifyDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZhuanZhangTable', @level2type=N'COLUMN',@level2name=N'UserID'
GO

ALTER TABLE [dbo].[ZhuanZhangTable] ADD  CONSTRAINT [DF_ZhuanZhangTable_Synchronize]  DEFAULT ((1)) FOR [Synchronize]
GO

ALTER TABLE [dbo].[ZhuanZhangTable] ADD  CONSTRAINT [DF_ZhuanZhangTable_ZhuanZhangLive]  DEFAULT ((1)) FOR [ZhuanZhangLive]
GO

ALTER TABLE [dbo].[ZhuanZhangTable] ADD  CONSTRAINT [DF_ZhuanZhangTable_ModifyDate]  DEFAULT (getdate()) FOR [ModifyDate]
GO


