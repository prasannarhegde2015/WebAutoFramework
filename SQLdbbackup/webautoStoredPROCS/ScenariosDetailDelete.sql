USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[ScenariosDetailDelete]    Script Date: 11/06/2015 16:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[ScenariosDetailDelete]
@ScenarioDetailID int,
@ScenarioID INT,
@Sequence INT

AS
DELETE FROM ScenarioDetail
WHERE ID=@ScenarioDetailID 
--Update the Sequence numbers so that if items get added in middle the following sequence numbers get updated
UPDATE ScenarioDetail
SET Sequence = Sequence-1
WHERE 
ScenarioID=@ScenarioID AND Sequence>@Sequence