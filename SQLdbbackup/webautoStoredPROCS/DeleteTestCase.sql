USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTestCase]    Script Date: 11/06/2015 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[DeleteTestCase]
@WebPageID INT,
@TestCase VARCHAR(50),
@Action Varchar(50)
AS
DELETE FROM PageDataTestCaseLink
--SET IsDeleted='Y'
WHERE WebPageID=@WebPageID
AND 
TestCase =@TestCase
AND
[Action]=@Action

DELETE FROM PageData
--SET IsDeleted='Y'
WHERE WebPageID=@WebPageID
AND 
TestCase =@TestCase
AND
[Action]=@Action

DELETE FROM ScenarioDetail
WHERE WebPageID=@WebPageID
AND 
TestCase =@TestCase
AND
[Action]=@Action