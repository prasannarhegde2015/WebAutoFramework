USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[RenameTestCase]    Script Date: 11/06/2015 16:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[RenameTestCase]
@WebPageID INT,
@OldTestCase VARCHAR(50),
@NewTestCase VARCHAR(50),
@Action VARCHAR(50)
AS
UPDATE PageDataTestCaseLink
SET TestCase = @NewTestCase
WHERE WebPageID=@WebPageID
AND 
TestCase =@OldTestCase
AND [Action]=@Action

UPDATE PageData
SET TestCase = @NewTestCase
WHERE WebPageID=@WebPageID
AND 
TestCase =@OldTestCase
AND [Action]=@Action

UPDATE ScenarioDetail
SET TestCase = @NewTestCase
WHERE WebPageID=@WebPageID
AND 
TestCase =@OldTestCase
AND [Action]=@Action