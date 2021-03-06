USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetDataForRun]    Script Date: 11/06/2015 16:36:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[GetDataForRun]
@ScenarioID INT,
@Step INT =1
/*
13-Jan-2015 Added Fields StartFrom, EndOn,Controltext in the query
2-Feb-2015 : Added parameter @visible
*/

AS
SET NOCOUNT ON 
DECLARE @Rowno INT =0

SELECT ROW_NUMBER() OVER (ORDER BY ScenarioMaster.ID,ScenarioDetail.sequence,OrdinalPosition ASC) AS RowNo,
ScenarioMaster.ID,
ScenarioDetail.ID as ScenarioDetailID,
Scenario,
ScenarioDetail.[Action],
URL,
Absolutepath,
Title,
ControlType,
ControlID,
ControlName,
ControlText,
ControlValue,
[INDEX],
PageData.TestCase,
PageData.ID,
DataValue,
VerificationValue,
WebPages.ID As webpageID,
PageControls.Frame,
NUllIF(IgnoreSuffix,'') AS IgnoreSuffix ,
NUllIF(IgnorePrefix,'') AS IgnorePrefix,
NUllIF(Visible,'') AS Visible
FROM  ScenarioMaster
INNER JOIN ScenarioDetail
ON ScenarioMaster.ID = ScenarioDetail.ScenarioID
INNER JOIN PageData
ON ScenarioDetail.WebPageID  = PageData.WebPageID
AND ScenarioDetail.TestCase = PageData.TestCase AND ScenarioDetail.Action =PageData.Action
INNER JOIN PageControls ON PageData.PageControlID= PageControls.ID
INNER JOIN WebPages ON PageControls.WebPageID = WebPages.ID
WHERE 
ScenarioMaster.ID =@ScenarioID 
AND 
PageData.IsDeleted='N'
ORDER by ScenarioMaster.ID,ScenarioDetail.sequence,OrdinalPosition