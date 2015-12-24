USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[DynamicValueAdd]    Script Date: 11/06/2015 16:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[DynamicValueAdd]
@DynamicName varchar(50),
@DynamicValue varchar(50),
@ScenarioID INT
AS

BEGIN 
	INSERT INTO DynamicValues
	(ScenarioID,DynamicName,DynamicValue)
	VALUES
	(@ScenarioID,@DynamicName,@DynamicValue)
END 