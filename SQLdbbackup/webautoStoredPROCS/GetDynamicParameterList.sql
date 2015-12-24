USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetDynamicParameterList]    Script Date: 11/06/2015 16:51:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER    PROCEDURE 
[dbo].[GetDynamicParameterList]
@DynamicName Varchar(50)=''
AS
SET NOCOUNT ON 
IF LEN(@DynamicName)>0
BEGIN 
	SELECT DynamicName,DynamicType,format
	FROM MstDynamicParameters
	WHERE DynamicName=@DynamicName
END 
ELSE
BEGIN 
	SELECT DynamicName,DynamicType,format
	FROM MstDynamicParameters
	
END 