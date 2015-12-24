USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetDataFromScenarioDetail]    Script Date: 11/06/2015 16:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE 
[dbo].[GetDataFromScenarioDetail]
@ScenarioDetailID INT
AS
SET NOCOUNT ON 
SELECT 
TestCase,Sequence,[Action],WebPageID
FROM  ScenarioDetail
WHERE ID =@ScenarioDetailID

ORDER BY Sequence
