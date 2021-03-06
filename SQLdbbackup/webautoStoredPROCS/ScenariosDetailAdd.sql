USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[ScenariosDetailAdd]    Script Date: 11/06/2015 16:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[ScenariosDetailAdd]
@ScenarioID int,
@WebpageID int,
@Testcase varchar(50),
@Action varchar(20),
@sequence int =-1


AS
/*
	16-Dec - Added is IsNUll clause while checking the scenariodetailid
*/
-- commented as this needs to be checked thoroughy. Currenrly nodes are getting appended at the bottom of the list
IF @sequence =-1
BEGIN 
	SELECT @sequence = ISNULL(MAX(Sequence)+1,1) FROM ScenarioDetail WHERE ScenarioID = @ScenarioID
END 

UPDATE ScenarioDetail
SET Sequence = Sequence+1 
WHERE 
ScenarioID = @ScenarioID
AND Sequence >=@Sequence


INSERT INTO ScenarioDetail
(ScenarioID,WebPageID,TestCase,[Action],Sequence)
VALUES
(@ScenarioID,@WebPageID,@TestCase,@Action,@sequence)

