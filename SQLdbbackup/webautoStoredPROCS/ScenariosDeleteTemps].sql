USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[ScenariosDeleteTemps]    Script Date: 11/06/2015 16:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[ScenariosDeleteTemps]
AS
DELETE  
ScenarioDetail	
FROM 
ScenarioDetail	
INNER JOIN ScenarioMaster 
ON ScenarioMaster.ID=ScenarioDetail.ScenarioID
WHERE notes ='This is for run purpose only'

DELETE FROM ScenarioMaster
WHERE NOTEs ='This is for run purpose only'