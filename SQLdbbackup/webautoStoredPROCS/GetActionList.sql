USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetActionList]    Script Date: 11/06/2015 16:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[GetActionList]

AS
SET NOCOUNT ON 
SELECT 
ID,[TYPE],Datavalue
FROM MstcontrolsAndActions
WHERE [TYPE] ='Action'
