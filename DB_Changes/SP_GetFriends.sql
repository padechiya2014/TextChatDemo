USE [RTCI_SBDC_2]
GO

/****** Object:  StoredProcedure [dbo].[GetFriends]    Script Date: 02/27/2019 4:23:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE Procedure [dbo].[GetFriends]  
(
@userid int
)
as
Begin
Select * from tblUser where userid <> @userid;
End



GO

