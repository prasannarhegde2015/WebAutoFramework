USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetControlList]    Script Date: 11/06/2015 16:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[GetControlList]

AS
SET NOCOUNT ON 
SELECT 
ID,[TYPE],Datavalue
FROM MstcontrolsAndActions
WHERE [TYPE] ='Control'
