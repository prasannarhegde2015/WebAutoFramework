USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[CreateWebtable]    Script Date: 11/06/2015 16:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER Procedure
[dbo].[CreateWebtable]
@TableName NVARCHAR(500)='',
@RowNO INT=-1,
@ColumnNO INT=-1,
@ColumnName VARCHAR(100)='',
@Value VARCHAR(500) =''
AS
DECLARE @SQLQUERY NVARCHAR(4000)
DECLARE @InsertSQLQUERY NVARCHAR(4000)
SET @TableName='WebTable_' +@TableName


IF @RowNO=-1
BEGIN 
SET @SQLQUERY =
	'
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('''  + @TableName + ''') AND type in (''U''))
	
	DROP TABLE ' + @TableName + '	
	
	BEGIN  
	
	CREATE TABLE ' +  @TableName + '
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[RowNo] [int] NOT NULL,
		[ColumnNo] [int] NOT NULL,
		[ColumnName] [varchar](500) NOT NULL,
		[Value] [varchar](500)  NULL,
		CONSTRAINT [PK_' + @TableName +'] PRIMARY KEY CLUSTERED 
		(
			[ID] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]	
	) ON [PRIMARY]
	END 
	'

	EXEC SP_EXECUTESQL @SQLQUERY
END

IF @Rowno>=0
BEGIN 
	SET @InsertSQLQUERY =
	'INSERT INTO ' +  @TableName + '
	(RowNo,ColumnNo,ColumnName,Value)
	VALUES 
	(' + cast(@RowNO as varchar(100)) + ',' + CAST(@ColumnNo AS VARCHAR(100)) + ', ''' + @ColumnName +''',''' + isnull(@Value,'') + ''')'

	PRINT @InsertSQLQUERY
	EXEC SP_EXECUTESQL @InsertSQLQUERY
END 