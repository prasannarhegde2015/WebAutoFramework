USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[ScenarioAdd]    Script Date: 11/06/2015 16:47:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[ScenarioAdd]
@Scenario varchar(50),
@Notes varchar(50)
AS
INSERT INTO ScenarioMaster
(Scenario,Notes)
VALUES
(@Scenario,@Notes)