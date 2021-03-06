USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[DynamicParametersAdd]    Script Date: 11/06/2015 16:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[DynamicParametersAdd]
@DynamicName varchar(50),
@DynamicType varchar(20),
@Length smallint,
@Format VARCHAR(50)
AS
INSERT INTO MstDynamicParameters
(DynamicName,DynamicType,[Length],Format)
VALUES
(@DynamicName,@DynamicType,@Length,@Format)