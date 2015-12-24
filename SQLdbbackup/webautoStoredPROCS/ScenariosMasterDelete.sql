USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[ScenariosMasterDelete]    Script Date: 11/06/2015 16:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[ScenariosMasterDelete]
@ScenarioID INT

AS
DELETE FROM ScenarioDetail
WHERE ScenarioID=@ScenarioID 
--Update the Sequence numbers so that if items get added in middle the following sequence numbers get updated
DELETE FROM ScenarioMaster
WHERE ID=@ScenarioID 