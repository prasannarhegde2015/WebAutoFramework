USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetWebtableData]    Script Date: 11/06/2015 16:47:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER Procedure
[dbo].[GetWebtableData]
@TableName NVARCHAR(500)=''
AS
DECLARE @SQLQUERY NVARCHAR(4000)
SET @TableName='WebTable_' +@TableName
SET @SQLQUERY = 'SELECT * FROM ' + @TableName
	

	EXEC SP_EXECUTESQL @SQLQUERY
