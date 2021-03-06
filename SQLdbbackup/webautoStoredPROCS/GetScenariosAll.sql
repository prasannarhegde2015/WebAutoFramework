USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetScenariosAll]    Script Date: 11/06/2015 16:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[GetScenariosAll]
@ALL CHAR ='N'
AS
SET NOCOUNT ON 
IF @ALL='N'
	BEGIN 
		SELECT 
		ID,Scenario,Notes,Closed
		FROM  ScenarioMaster
		where Closed='N'
	END 
ELSE IF @ALL='Y'
	BEGIN 
		SELECT 
		ID,Scenario,Notes,Closed
		FROM  ScenarioMaster
		where Closed='Y'
	END
ELSE
	BEGIN 
	SELECT 
		ID,Scenario,Notes,Closed
		FROM  ScenarioMaster
	END