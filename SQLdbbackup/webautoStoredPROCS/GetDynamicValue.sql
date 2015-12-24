USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetDynamicValue]    Script Date: 11/06/2015 16:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER    PROCEDURE 
[dbo].[GetDynamicValue]
@DynamicName Varchar(50)='',
@ScenarioID INT
AS
SET NOCOUNT ON 

BEGIN 
	SELECT DynamicName,DynamicValue
	FROM DynamicValues
	WHERE Dynamicname =@DynamicName
	 AND ScenarioID=@ScenarioID
END 