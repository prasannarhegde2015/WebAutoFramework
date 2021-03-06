USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetScenarioSteps]    Script Date: 11/06/2015 16:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE 
[dbo].[GetScenarioSteps]
@ScenarioID INT
AS
SET NOCOUNT ON 
SELECT 
ScenarioDetail.ID AS ScenarioDetailID,Scenario,UniqueName,TestCase,Sequence,[Action],WebPageID
FROM  ScenarioMaster
INNER JOIN ScenarioDetail
ON ScenarioMaster.ID = ScenarioDetail.ScenarioID
INNER JOIN 
WebPages ON WebPageID = WebPages.ID
WHERE ScenarioMaster.ID =@ScenarioID
ORDER BY Sequence

