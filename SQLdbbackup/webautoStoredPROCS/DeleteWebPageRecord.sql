USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[DeleteWebPageRecord]    Script Date: 11/06/2015 16:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[DeleteWebPageRecord]
@WebpageID INT
AS
UPDATE WebPages SET IsActive='N'
WHERE 
ID=@WebpageID
