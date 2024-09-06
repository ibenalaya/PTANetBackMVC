USE [master]
GO

/****** Object:  Table [dbo].[Fees]    Script Date: 06/09/2024 16:25:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Fees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[TimestampUTC] [datetime] NOT NULL,
	[Country] [nvarchar](20) NOT NULL,
	[ImbalanceFee] [decimal](18, 2) NULL,
	[HourlyImbalanceFee] [decimal](18, 2) NULL,
	[PeakLoadFee] [decimal](18, 2) NULL,
	[VolumeFee] [decimal](18, 2) NULL,
	[WeeklyFee] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

