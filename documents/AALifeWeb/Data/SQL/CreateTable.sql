/****** Object:  Table [dbo].[WorkDayTable]    Script Date: 04/20/2015 23:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkDayTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WorkDayTable](
	[WorkDay] [tinyint] NOT NULL,
	[WorkDayName] [nvarchar](10) NOT NULL,
	[Rank] [tinyint] NOT NULL,
 CONSTRAINT [PK_WorkDayTable] PRIMARY KEY CLUSTERED 
(
	[WorkDay] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserFromTable]    Script Date: 04/20/2015 23:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFromTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserFromTable](
	[UserFrom] [nvarchar](10) NOT NULL,
	[UserFromName] [nvarchar](10) NOT NULL,
	[Rank] [tinyint] NOT NULL,
 CONSTRAINT [PK_UserFromTable] PRIMARY KEY CLUSTERED 
(
	[UserFrom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[RegionTypeTable]    Script Date: 04/20/2015 23:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegionTypeTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RegionTypeTable](
	[RegionType] [nvarchar](10) NOT NULL,
	[RegionTypeName] [nvarchar](10) NOT NULL,
	[RegionTypeSymbol] [nvarchar](10) NOT NULL,
	[Rank] [tinyint] NOT NULL,
 CONSTRAINT [PK_RegionTypeTable] PRIMARY KEY CLUSTERED 
(
	[RegionType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ItemTypeTable]    Script Date: 04/20/2015 23:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemTypeTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemTypeTable](
	[ItemType] [nvarchar](10) NOT NULL,
	[ItemTypeName] [nvarchar](10) NOT NULL,
	[ItemTypeSymbol] [nvarchar](10) NOT NULL,
	[Rank] [tinyint] NOT NULL,
 CONSTRAINT [PK_ItemTypeTable] PRIMARY KEY CLUSTERED 
(
	[ItemType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
