USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetScenarioMasterDetails]    Script Date: 11/06/2015 16:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[GetScenarioMasterDetails]
 @Scenario VARCHAR(50)

AS
SET NOCOUNT ON 
SELECT 
ID,Closed,Notes
FROM 
ScenarioMaster WHERE Scenario=@Scenario