USE [RTCI_SBDC_2]
GO

/****** Object:  Table [dbo].[tblUser]    Script Date: 02/27/2019 4:20:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUser](
	[userid] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[mobile] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[confirmPassword] [varchar](50) NOT NULL,
	[dob] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


