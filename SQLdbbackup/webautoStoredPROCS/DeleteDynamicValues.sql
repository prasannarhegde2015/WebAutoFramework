USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[DeleteDynamicValues]    Script Date: 11/06/2015 16:35:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[DeleteDynamicValues]
@ScenarioID INT
AS
DELETE FROM DynamicValues
WHERE 
ScenarioID=@ScenarioID
