USE [RTCI_SBDC_2]
GO

/****** Object:  StoredProcedure [dbo].[GetUsers_Temp]    Script Date: 02/27/2019 4:23:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE Procedure [dbo].[GetUsers_Temp]  
(
@email varchar (50),
@password varchar (50)
)
as
Begin
Select COUNT(*)from tblUser where email = @email AND password = @password; 
End



GO

