USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetKeywordList]    Script Date: 11/06/2015 16:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[GetKeywordList]

AS
SET NOCOUNT ON 
SELECT 
ID,[TYPE],Datavalue
FROM MstcontrolsAndActions
WHERE [TYPE] ='Keyword'
