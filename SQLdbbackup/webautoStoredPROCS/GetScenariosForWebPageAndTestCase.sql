USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetScenariosForWebPageAndTestCase]    Script Date: 11/06/2015 16:45:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[GetScenariosForWebPageAndTestCase]
@WebPageID INT,
@TestCase VARCHAR(50),
@Action VARCHAR(50)
AS
SET NOCOUNT ON 
SELECT 
TestCase,[Action] FROM
ScenarioDetail
WHERE 
WebpageID =@WebPageID 
AND
TestCase =@TestCase
AND 
[Action]=@Action