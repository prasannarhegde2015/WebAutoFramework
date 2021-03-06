USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[CreateVerification]    Script Date: 11/06/2015 16:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE 
[dbo].[CreateVerification]
@WebPageID INT,
@TestCase Varchar(50)
AS
INSERT INTO PageDataTestCaseLink
(WebPageID,TestCase,[Action])
VALUES 
(@WebPageID,@TestCase,'Verify')
INSERT INTO PageData 
(PageControlID,WebPageID,OrdinalPosition,TestCase,Datavalue,VerificationValue,[Action])
SELECT PageControlID,WebPageID,OrdinalPosition,TestCase,'',DataValue,'Verify'
FROM PageData
WHERE WebPageID=@WebPageID AND TestCase =@TestCase and [action] ='Add'


UPDATE PageData
SET VerificationValue='TRUE' 
FROM PageData INNER JOIN PageControls
ON PageDAta.PageControlID =PageControls.ID
WHERE PageDAta.WebPageID=@WebPageID AND TestCase =@TestCase and [action] ='Verify'
AND ( ControlType='CheckBox' OR ControlType='RadioButton')
