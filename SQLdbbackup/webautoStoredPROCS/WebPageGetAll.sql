USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[WebPageGetAll]    Script Date: 11/06/2015 16:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[WebPageGetAll]AS
SET NOCOUNT ON 
SELECT ID,Uniquename,Title,URL,Absolutepath,Notes
FROM Webpages where IsActive ='Y'