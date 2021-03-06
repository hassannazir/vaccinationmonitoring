USE [vaccinationmonitoringdb]
GO
/****** Object:  Table [dbo].[area]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[area](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[city_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_area] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[city]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[province_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compaign]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compaign](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[area_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
	[assigned_by] [int] NULL,
	[assigned_to] [int] NULL,
	[status] [int] NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_compaign] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compaign_area_house]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compaign_area_house](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[house_id] [int] NULL,
	[compaign_id] [int] NULL,
	[area_id] [int] NULL,
	[status] [int] NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_compaign_area_house] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[feedback] [nvarchar](max) NULL,
	[compaign_id] [int] NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [date] NULL,
 CONSTRAINT [PK_feedback] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[house]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[house](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[house_no] [nvarchar](50) NULL,
	[area_id] [int] NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_house] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[province]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[province](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[country_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_province] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[area_id] [int] NULL,
	[role] [int] NULL,
	[status] [int] NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NULL,
	[modified_by] [int] NULL,
	[modified_date] [datetime] NULL,
	[email_address] [nvarchar](50) NULL,
	[address] [nvarchar](150) NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[is_active] [bit] NULL,
	[phone_number] [nvarchar](50) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_login]    Script Date: 7/18/2020 10:24:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_login](
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[CreationTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
