USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetWebPages]    Script Date: 11/06/2015 16:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[GetWebPages]
AS
SELECT UNiqueName,ID FROM WebPages 
WHERE Isactive ='Y'
ORDER BY Title