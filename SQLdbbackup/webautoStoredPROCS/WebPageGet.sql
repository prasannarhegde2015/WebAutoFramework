USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[WebPageGet]    Script Date: 11/06/2015 16:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[WebPageGet]
@WebPageID INT
AS
SET NOCOUNT ON 
SELECT ID,Title,URL,Absolutepath,Uniquename,Notes
FROM Webpages
WHERE ID =@WebPageID