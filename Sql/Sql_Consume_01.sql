USE [master]
GO
/****** Object:  Database [ConsumeCore]    Script Date: 2018/9/30 17:14:13 ******/
CREATE DATABASE [ConsumeCore] ON  PRIMARY 
( NAME = N'ConsumeCore', FILENAME = N'D:\ConsumeCore.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ConsumeCore_log', FILENAME = N'D:\ConsumeCore_log.ldf' , SIZE = 2048KB , MAXSIZE = 500GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ConsumeCore] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ConsumeCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ConsumeCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ConsumeCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ConsumeCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ConsumeCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ConsumeCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [ConsumeCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ConsumeCore] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ConsumeCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ConsumeCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ConsumeCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ConsumeCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ConsumeCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ConsumeCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ConsumeCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ConsumeCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ConsumeCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ConsumeCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ConsumeCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ConsumeCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ConsumeCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ConsumeCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ConsumeCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ConsumeCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ConsumeCore] SET RECOVERY FULL 
GO
ALTER DATABASE [ConsumeCore] SET  MULTI_USER 
GO
ALTER DATABASE [ConsumeCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ConsumeCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ConsumeCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ConsumeCore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ConsumeCore', N'ON'
GO
USE [ConsumeCore]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 2018/9/30 17:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CardNo] [nvarchar](50) NULL,
	[PersonId] [nvarchar](50) NULL,
	[Balance] [nvarchar](50) NULL,
	[CardCost] [nvarchar](50) NULL,
	[BackMoney] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[BeginTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_Card_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardCharge]    Script Date: 2018/9/30 17:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardCharge](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CardNo] [nvarchar](50) NULL,
	[OprType] [int] NULL,
	[PreMoney] [nvarchar](50) NULL,
	[OprMoney] [nvarchar](50) NULL,
	[AfterMoney] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_CardCharge] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 2018/9/30 17:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [nvarchar](50) NULL,
	[DeptId] [nvarchar](50) NULL,
	[ParentId] [nvarchar](50) NULL,
	[DeptNo] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
	[IsRoot] [int] NULL,
	[ThirdDeptId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Department_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 2018/9/30 17:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [nvarchar](50) NULL,
	[PersonName] [nvarchar](50) NULL,
	[PersonNo] [nvarchar](50) NULL,
	[CellPhone] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[DeptId] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[ThirdPersonId] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_Person_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Card] ADD  CONSTRAINT [DF_Card_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Card] ADD  CONSTRAINT [DF_Card_BeginTime]  DEFAULT (getdate()) FOR [BeginTime]
GO
ALTER TABLE [dbo].[Card] ADD  CONSTRAINT [DF_Card_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Card] ADD  CONSTRAINT [DF_Card_ModifyTime]  DEFAULT (getdate()) FOR [ModifyTime]
GO
ALTER TABLE [dbo].[CardCharge] ADD  CONSTRAINT [DF_CardCharge_PreMoney]  DEFAULT (N'操作前的卡余额') FOR [PreMoney]
GO
ALTER TABLE [dbo].[CardCharge] ADD  CONSTRAINT [DF_CardCharge_OprMoney]  DEFAULT (N'操作金额') FOR [OprMoney]
GO
ALTER TABLE [dbo].[CardCharge] ADD  CONSTRAINT [DF_CardCharge_AfterMoney]  DEFAULT (N'操作后的卡余额') FOR [AfterMoney]
GO
ALTER TABLE [dbo].[CardCharge] ADD  CONSTRAINT [DF_CardCharge_Remark]  DEFAULT (N'备注') FOR [Remark]
GO
ALTER TABLE [dbo].[CardCharge] ADD  CONSTRAINT [DF_CardCharge_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[CardCharge] ADD  CONSTRAINT [DF_CardCharge_ModifyTime]  DEFAULT (getdate()) FOR [ModifyTime]
GO
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_ModifyTime]  DEFAULT (getdate()) FOR [ModifyTime]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_PersonId]  DEFAULT (N'人员标识') FOR [PersonId]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_PersonName]  DEFAULT (N'人员姓名') FOR [PersonName]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_PersonNo]  DEFAULT (N'人员编号') FOR [PersonNo]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_CellPhone]  DEFAULT (N'手机号') FOR [CellPhone]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_Tel]  DEFAULT (N'电话') FOR [Tel]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_Mail]  DEFAULT (N'邮箱') FOR [Mail]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_DeptId]  DEFAULT (N'部门标识，多个部门用分号; 间隔') FOR [DeptId]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_ModifyTime]  DEFAULT (getdate()) FOR [ModifyTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card', @level2type=N'COLUMN',@level2name=N'CardNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card', @level2type=N'COLUMN',@level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡余额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card', @level2type=N'COLUMN',@level2name=N'Balance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡成本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card', @level2type=N'COLUMN',@level2name=N'CardCost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退回金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card', @level2type=N'COLUMN',@level2name=N'BackMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：正常，1：注销' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡启用时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card', @level2type=N'COLUMN',@level2name=N'BeginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardCharge', @level2type=N'COLUMN',@level2name=N'CardNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：充值，2：退款' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardCharge', @level2type=N'COLUMN',@level2name=N'OprType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'DeptName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'DeptId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父节点ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'DeptNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：正常，1：删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否根节点，1：是 ：0不是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'IsRoot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'集成第三方的部门标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'ThirdDeptId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：正常 1：删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Person', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'集成第三方的人员标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Person', @level2type=N'COLUMN',@level2name=N'ThirdPersonId'
GO
USE [master]
GO
ALTER DATABASE [ConsumeCore] SET  READ_WRITE 
GO
