USE [DesktopDesign]
GO
/****** Object:  Table [dbo].[Details]    Script Date: 16-10-2024 18:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Company_Name] [varchar](50) NOT NULL,
	[Phone_No] [int] NULL,
	[Email] [varchar](45) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[city] [varchar](25) NOT NULL,
	[state] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 16-10-2024 18:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](45) NOT NULL,
	[Password] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[_InsertDetails]    Script Date: 16-10-2024 18:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[_InsertDetails]
( 
  @Name varchar(45),
  @Company_Name varchar(50),
  @Phone_No int,
  @Email varchar(45),
  @Address varchar(100),
  @city varchar(25),
  @state varchar(30)
)
as
 insert into Details values(@Name,@Company_Name,@Phone_No,@Email,@Address,@city,@state)

GO
/****** Object:  StoredProcedure [dbo].[CheckLogin]    Script Date: 16-10-2024 18:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[CheckLogin]
( 
  @UserName varchar(45),
  @Password varchar(45)
)
as
 SELECT COUNT(1) FROM Login WHERE UserName = @UserName AND Password = @Password
GO
