USE [WebAutomation]
GO
/****** Object:  Table [dbo].[WebTable_TEst1_TEst1]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebTable_TEst1_TEst1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RowNo] [int] NOT NULL,
	[ColumnNo] [int] NOT NULL,
	[ColumnName] [varchar](500) NOT NULL,
	[Value] [varchar](500) NULL,
 CONSTRAINT [PK_WebTable_TEst1_TEst1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebTable_TEST_HELLO_WORLD]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebTable_TEST_HELLO_WORLD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RowNo] [int] NOT NULL,
	[ColumnNo] [int] NOT NULL,
	[ColumnName] [varchar](500) NOT NULL,
	[Value] [varchar](500) NULL,
 CONSTRAINT [PK_WebTable_TEST_HELLO_WORLD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebTable_New_TEst1]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebTable_New_TEst1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RowNo] [int] NOT NULL,
	[ColumnNo] [int] NOT NULL,
	[ColumnName] [varchar](500) NOT NULL,
	[Value] [varchar](500) NULL,
 CONSTRAINT [PK_WebTable_New_TEst1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebTable_New_ContinuousFlowSystem_Land]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebTable_New_ContinuousFlowSystem_Land](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RowNo] [int] NOT NULL,
	[ColumnNo] [int] NOT NULL,
	[ColumnName] [varchar](500) NOT NULL,
	[Value] [varchar](500) NULL,
 CONSTRAINT [PK_WebTable_New_ContinuousFlowSystem_Land] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebTable_Home_Page_Example]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebTable_Home_Page_Example](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RowNo] [int] NOT NULL,
	[ColumnNo] [int] NOT NULL,
	[ColumnName] [varchar](500) NOT NULL,
	[Value] [varchar](500) NULL,
 CONSTRAINT [PK_WebTable_Home_Page_Example] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebTable_Demo_Demo]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebTable_Demo_Demo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RowNo] [int] NOT NULL,
	[ColumnNo] [int] NOT NULL,
	[ColumnName] [varchar](500) NOT NULL,
	[Value] [varchar](500) NULL,
 CONSTRAINT [PK_WebTable_Demo_Demo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebPages]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebPages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[URL] [varchar](500) NOT NULL,
	[Absolutepath] [varchar](500) NOT NULL,
	[UniqueName] [varchar](50) NOT NULL,
	[notes] [varchar](500) NULL,
	[Frame] [smallint] NOT NULL,
	[IsActive] [char](10) NOT NULL,
 CONSTRAINT [PK_WebPages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CreateWebtable]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure
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
GO
/****** Object:  Table [dbo].[MstDynamicParameters]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MstDynamicParameters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DynamicType] [varchar](20) NOT NULL,
	[DynamicName] [varchar](50) NOT NULL,
	[Length] [smallint] NOT NULL,
	[Format] [varchar](50) NULL,
 CONSTRAINT [PK_DynamicDataValues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MstControlsAndActions]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MstControlsAndActions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[DataValue] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MstControlsAndActions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetWebtableData]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure
[dbo].[GetWebtableData]
@TableName NVARCHAR(500)=''
AS
DECLARE @SQLQUERY NVARCHAR(4000)
SET @TableName='WebTable_' +@TableName
SET @SQLQUERY = 'SELECT * FROM ' + @TableName
	

	EXEC SP_EXECUTESQL @SQLQUERY
GO
/****** Object:  Table [dbo].[ScenarioMaster]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScenarioMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Scenario] [varchar](50) NOT NULL,
	[Notes] [varchar](50) NULL,
	[Closed] [char](1) NOT NULL,
	[IsTemp] [char](1) NOT NULL,
 CONSTRAINT [PK_ScenarioMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ScenarioDetail]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScenarioDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ScenarioID] [int] NOT NULL,
	[WebPageID] [int] NOT NULL,
	[TestCase] [varchar](50) NOT NULL,
	[Sequence] [int] NOT NULL,
	[Action] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ScenarioDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ScenarioAdd]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[ScenarioAdd]
@Scenario varchar(50),
@Notes varchar(50)
AS
INSERT INTO ScenarioMaster
(Scenario,Notes)
VALUES
(@Scenario,@Notes)
GO
/****** Object:  Table [dbo].[PageDataTestCaseLink]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PageDataTestCaseLink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WebPageID] [int] NOT NULL,
	[TestCase] [varchar](50) NOT NULL,
	[Notes] [varchar](50) NULL,
	[Action] [varchar](50) NOT NULL,
	[IsDeleted] [char](1) NOT NULL,
 CONSTRAINT [PK_PageDataTestCaseLink] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PageControls]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PageControls](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WebPageID] [int] NOT NULL,
	[ControlType] [varchar](50) NOT NULL,
	[ControlName] [varchar](300) NOT NULL,
	[ControlID] [varchar](300) NOT NULL,
	[ControlText] [nvarchar](4000) NULL,
	[controlValue] [varchar](300) NULL,
	[Frame] [smallint] NOT NULL,
	[IsAction] [char](1) NOT NULL,
	[Index] [smallint] NULL,
	[UserFriendlyName] [varchar](50) NULL,
 CONSTRAINT [PK_PageControls] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetWebPageURL]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetWebPageURL]
@WebPageID as int
AS
Begin

 select [URL] from [WebAutomation].[dbo].[WebPages] where ID = @WebPageID

End
GO
/****** Object:  StoredProcedure [dbo].[GetWebPages]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetWebPages]
AS
SELECT UNiqueName,ID FROM WebPages 
WHERE Isactive ='Y'
ORDER BY Title
GO
/****** Object:  StoredProcedure [dbo].[GetControlList]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetControlList]

AS
SET NOCOUNT ON 
SELECT 
ID,[TYPE],Datavalue
FROM MstcontrolsAndActions
WHERE [TYPE] ='Control'
GO
/****** Object:  StoredProcedure [dbo].[GetActionList]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetActionList]

AS
SET NOCOUNT ON 
SELECT 
ID,[TYPE],Datavalue
FROM MstcontrolsAndActions
WHERE [TYPE] ='Action'
GO
/****** Object:  StoredProcedure [dbo].[GetDynamicParameterList]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE 
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
GO
/****** Object:  StoredProcedure [dbo].[GetScenariosAll]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetScenariosAll]
@ALL CHAR ='N'
AS
SET NOCOUNT ON 
IF @ALL='N'
	BEGIN 
		SELECT 
		ID,Scenario,Notes,Closed
		FROM  ScenarioMaster
		where Closed='N'
	END 
ELSE IF @ALL='Y'
	BEGIN 
		SELECT 
		ID,Scenario,Notes,Closed
		FROM  ScenarioMaster
		where Closed='Y'
	END
ELSE
	BEGIN 
	SELECT 
		ID,Scenario,Notes,Closed
		FROM  ScenarioMaster
	END
GO
/****** Object:  StoredProcedure [dbo].[GetScenarioMasterDetails]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  PROCEDURE 
[dbo].[GetScenarioMasterDetails]
 @Scenario VARCHAR(50)

AS
SET NOCOUNT ON 
SELECT 
ID,Closed,Notes
FROM 
ScenarioMaster WHERE Scenario=@Scenario
GO
/****** Object:  StoredProcedure [dbo].[GetKeywordList]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetKeywordList]

AS
SET NOCOUNT ON 
SELECT 
ID,[TYPE],Datavalue
FROM MstcontrolsAndActions
WHERE [TYPE] ='Keyword'
GO
/****** Object:  StoredProcedure [dbo].[DynamicParametersAdd]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
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
GO
/****** Object:  StoredProcedure [dbo].[DeleteWebPageRecord]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[DeleteWebPageRecord]
@WebpageID INT
AS
UPDATE WebPages SET IsActive='N'
WHERE 
ID=@WebpageID
GO
/****** Object:  Table [dbo].[DynamicValues]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DynamicValues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ScenarioID] [int] NOT NULL,
	[DynamicName] [varchar](50) NOT NULL,
	[DynamicValue] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_DynamicValues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[WebPageGetAll]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[WebPageGetAll]AS
SET NOCOUNT ON 
SELECT ID,Uniquename,Title,URL,Absolutepath,Notes
FROM Webpages where IsActive ='Y'
GO
/****** Object:  StoredProcedure [dbo].[WebPageGet]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[WebPageGet]
@WebPageID INT
AS
SET NOCOUNT ON 
SELECT ID,Title,URL,Absolutepath,Uniquename,Notes
FROM Webpages
WHERE ID =@WebPageID
GO
/****** Object:  StoredProcedure [dbo].[WebPageAdd]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[WebPageAdd]
@title varchar(50),
@url varchar(500),
@absolutepath varchar(500),
@uniquename varchar(50),
@notes varchar(500),
@ID INT
AS
IF @ID =0
	BEGIN 
		INSERT INTO WebPages
		(Title,URL,absolutepath,[uniquename],notes)
		VALUES
		(@title,@url,@absolutepath,@uniquename,@notes);
	END 
ELSE
	BEGIN 
		UPDATE WebPages 
		SET Title =@title,URL=@url,Absolutepath=@absolutepath,UniqueName=@uniquename,notes=@notes
		WHERE ID =@ID
	END
GO
/****** Object:  Table [dbo].[MstWebTableDefinition]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MstWebTableDefinition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WebPageID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ControlName] [varchar](300) NULL,
	[ControlID] [varchar](300) NULL,
	[TableInstance] [smallint] NOT NULL,
 CONSTRAINT [PK_MstWebTableDefinition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[DeleteDynamicValues]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[DeleteDynamicValues]
@ScenarioID INT
AS
DELETE FROM DynamicValues
WHERE 
ScenarioID=@ScenarioID
GO
/****** Object:  StoredProcedure [dbo].[GetTestCaseList]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetTestCaseList]
@WebPageID INT  =-1
AS
SET NOCOUNT ON 
IF @WebPageID=-1 
BEGIN 
	SELECT  UniqueName,Title,TestCase,PageDataTestCaseLink.ID AS ID,[Action],
	 URL,PageDataTestCaseLink.Notes,WebPageID
	FROM PageDataTestCaseLink
	INNER JOIN WebPages
	ON WebPageID = WebPages.ID
	WHERE PageDataTestCaseLink.IsDeleted='N'
	order by Title,[Action],TestCase
END 
ELSE
	BEGIN 
	SELECT  Title,UniqueName,TestCase,PageDataTestCaseLink.ID AS ID,[Action],
	 URL,PageDataTestCaseLink.Notes,WebPageID
	FROM PageDataTestCaseLink
	INNER JOIN WebPages
	ON WebPageID = WebPages.ID
	WHERE WebPageID=@WebPageID
	AND PageDataTestCaseLink.IsDeleted='N'
	END
GO
/****** Object:  StoredProcedure [dbo].[GetScenarioSteps]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE 
[dbo].[GetScenarioSteps]
@ScenarioID INT
AS
SET NOCOUNT ON 
SELECT 
ScenarioDetail.ID AS ScenarioDetailID,Scenario,UniqueName,TestCase,Sequence,[Action],WebPageID
FROM  ScenarioMaster
INNER JOIN ScenarioDetail
ON ScenarioMaster.ID = ScenarioDetail.ScenarioID
INNER JOIN 
WebPages ON WebPageID = WebPages.ID
WHERE ScenarioMaster.ID =@ScenarioID
ORDER BY Sequence
GO
/****** Object:  StoredProcedure [dbo].[GetScenariosForWebPageAndTestCase]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetScenariosForWebPageAndTestCase]
@WebPageID INT,
@TestCase VARCHAR(50),
@Action VARCHAR(50)
AS
SET NOCOUNT ON 
SELECT 
TestCase,[Action] FROM
ScenarioDetail
WHERE 
WebpageID =@WebPageID 
AND
TestCase =@TestCase
AND 
[Action]=@Action
GO
/****** Object:  StoredProcedure [dbo].[ScenariosMasterDelete]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[ScenariosMasterDelete]
@ScenarioID INT

AS
DELETE FROM ScenarioDetail
WHERE ScenarioID=@ScenarioID 
--Update the Sequence numbers so that if items get added in middle the following sequence numbers get updated
DELETE FROM ScenarioMaster
WHERE ID=@ScenarioID
GO
/****** Object:  StoredProcedure [dbo].[ScenariosDetailDelete]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
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
GO
/****** Object:  StoredProcedure [dbo].[ScenariosDetailAdd]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
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
GO
/****** Object:  StoredProcedure [dbo].[ScenariosDeleteTemps]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[ScenariosDeleteTemps]
AS
DELETE  
ScenarioDetail	
FROM 
ScenarioDetail	
INNER JOIN ScenarioMaster 
ON ScenarioMaster.ID=ScenarioDetail.ScenarioID
WHERE notes ='This is for run purpose only'

DELETE FROM ScenarioMaster
WHERE NOTEs ='This is for run purpose only'
GO
/****** Object:  StoredProcedure [dbo].[DynamicValueAdd]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
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
GO
/****** Object:  StoredProcedure [dbo].[GetDynamicValue]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE 
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
GO
/****** Object:  StoredProcedure [dbo].[GetDataFromScenarioDetail]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE 
[dbo].[GetDataFromScenarioDetail]
@ScenarioDetailID INT
AS
SET NOCOUNT ON 
SELECT 
TestCase,Sequence,[Action],WebPageID
FROM  ScenarioDetail
WHERE ID =@ScenarioDetailID

ORDER BY Sequence
GO
/****** Object:  StoredProcedure [dbo].[GetWebPageIDOnly]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetWebPageIDOnly] 
	-- Add the parameters for the stored procedure here
	@ScenarioID as INT
	
	AS
BEGIN
  Select WebPageID from [WebAutomation].[dbo].[ScenarioDetail] where ScenarioID = @ScenarioID ;
           
END
GO
/****** Object:  Table [dbo].[PageData]    Script Date: 01/20/2016 17:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PageData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageControlID] [int] NOT NULL,
	[WebPageID] [int] NOT NULL,
	[OrdinalPosition] [smallint] NOT NULL,
	[TestCase] [varchar](50) NOT NULL,
	[DataValue] [varchar](1000) NOT NULL,
	[VerificationValue] [varchar](1000) NULL,
	[Action] [varchar](50) NOT NULL,
	[IsDeleted] [char](1) NOT NULL,
	[IgnorePrefix] [varchar](200) NULL,
	[IgnoreSuffix] [varchar](200) NULL,
	[Visible] [varchar](10) NULL,
 CONSTRAINT [PK_PageData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[RenameTestCase]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[RenameTestCase]
@WebPageID INT,
@OldTestCase VARCHAR(50),
@NewTestCase VARCHAR(50),
@Action VARCHAR(50)
AS
UPDATE PageDataTestCaseLink
SET TestCase = @NewTestCase
WHERE WebPageID=@WebPageID
AND 
TestCase =@OldTestCase
AND [Action]=@Action

UPDATE PageData
SET TestCase = @NewTestCase
WHERE WebPageID=@WebPageID
AND 
TestCase =@OldTestCase
AND [Action]=@Action

UPDATE ScenarioDetail
SET TestCase = @NewTestCase
WHERE WebPageID=@WebPageID
AND 
TestCase =@OldTestCase
AND [Action]=@Action
GO
/****** Object:  StoredProcedure [dbo].[PageControlsAdd]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[PageControlsAdd]
@WebPageID INT,
@pagecontrolid int,
@pagedataid int,
@FieldName varchar(100),
@Controltype varchar(50),
@ControlName varchar(300),
@ControlText Nvarchar(400),
@ControlID varchar(300),
@ControlValue varchar(300),
@ControlIndex smallint =-1,
@RowNo smallint,
@TestCase varchar(50),
@DataValue varchar(1000),
@OriginalData varchar(1000),
@DeleteRow varchar(10),
@Isaction varchar(1),  -- COntrol or actions like firevent and keyboard
@mode varchar(1),
@VerificationValue varchar(1000),
@AddOrVerify Varchar(50),
@Frame INT,
@IgnorePrefix varchar(500),
@IgnoreSuffix varchar(500),
@Visible varchar(10)
--[PageControlsAdd] 20,-1,-1,'RadioButton','','db_WellLocationID_1',-1,1,'test','','','N','N','','','Add',8

/*
	12-Dec-2014 : Added WebPageID in where clause while updating column values in PageControls table 
				  Commented the update of Pagecontrolsname in PAgeControlData	
	24-Dec-2014 : Added WebPageID in where clause while updating data in Pagedata table			  
    2-Jan-2015: Added parameter Frame
    3-Jan 2015- Added 
    @NewPageControlID as setting value to @ControlID was causing double entry in the table
    Added index clause while checking pagecontrols in pagecontrol table
    13-Jan-2015 Added Parameters StartFrom,Controltext and EndOn
    21-Jan-2015 : Added parameter @controlvalue
    2-Feb-2015 : Added parameter @visible
    19-Feb: Added Delete statement for deleting recordds from pagecontrols table when the controltype is action
*/
AS
		DECLARE @PageDataTestCaseLinkID INT 		
		DECLARE @NewPageControlID INT

		DECLARE @DropTableQuery NVARCHAR(4000)
		DECLARE @TableName  VARCHAR(4000)
		-- Verificatiovalue used for tablenames as this comes in verification case only
		SET @TableName='WebTable_' +@VerificationValue + '_' + @Testcase
		SET @DropTableQuery = 'DROP TABLE ' + @TableName
	
		SELECT @PageDataTestCaseLinkID = ID
		FROM PageDataTestCaseLink WHERE WebPageID=@WebPageID AND TestCase 
		=@TestCase AND [Action]=@AddOrVerify
		IF @@ROWCOUNT=0
		BEGIN 
			INSERT INTO PageDataTestCaseLink -- Contains only one record for webpage and testcase
			(WebPageID,TestCase,[Action])
			VALUES
			(@WebPageID,@TestCase,@AddOrVerify)
			SELECT @PageDataTestCaseLinkID = @@IDENTITY
		END 	
	
	IF @DeleteRow ='Y' 
	-- only delete data and not controls as they may be used in other test cases
		BEGIN 
			DELETE FROM PageData
			WHERE ID = @PageDataID
		IF @Controltype='WebTable'
			BEGIN 
				EXEC SP_EXECUTESQL @DropTableQuery
			END
		IF 	@Isaction='Y'
			BEGIN 
				DELETE FROM PageControls WHERE ID=@pagecontrolid
			END
			
	END
IF @pagecontrolid=-1  -- WHEN THE control is newly added the @pagecontrolid will be -1
	BEGIN 
		IF @Isaction ='N'--This is applicable for controls
			BEGIN 	
					IF LEN(@ControlID) >0
					BEGIN
						SELECT @NewPageControlID=ID FROM PageControls 
						WHERE (ControlID =@ControlID)
						AND WebPageID=@WebPageID AND [Index] =@ControlIndex
						END 
					ELSE iF LEN(@ControlName)>0
					BEGIN
						SELECT @NewPageControlID=ID FROM PageControls 
						WHERE (ControlName =@ControlName)
						AND WebPageID=@WebPageID AND [Index] =@ControlIndex
					END 
					ELSE iF LEN(@ControlValue)>0
					BEGIN
						SELECT @NewPageControlID=ID FROM PageControls 
						WHERE (ControlValue =@ControlValue)
						AND WebPageID=@WebPageID AND [Index] =@ControlIndex
					END 
					IF @@ROWCOUNT=0
					BEGIN 
						INSERT INTO PageControls
						(WebPageID,UserFriendlyName,ControlType,COntrolName,ControlID,ControlText,ControlValue,IsAction,[Index],Frame)
						VALUES
						(@WebPageID,@FieldName,@ControlType,@COntrolName,@ControlID,@ControlText,@ControlValue,'N',@ControlIndex,@Frame)
						SELECT @NewPageControlID= @@IDENTITY
					END
					
			END
		ELSE IF  @Isaction='Y'-- 
		--This is for custom functions where there is no controlID hence they can be multiple times
			BEGIN 
			INSERT INTO	PageControls (WebPageID, UserFriendlyName, ControlType,ControlName, ControlText,ControlID,ControlValue,IsAction,[Index],Frame)
				VALUES
				(@WebPageID, @FieldName,@ControlType,@COntrolName,@COntrolText,@ControlID,@ControlValue,'Y',@ControlIndex,@Frame)
				SELECT @NewPageControlID= @@IDENTITY
				
			 END 
		INSERT INTO PageData --Always enter in pagedata table 
			(PageControlID,WebPageID,TestCase,DataValue,OrdinalPosition,VerificationValue,[Action],IgnorePrefix,IgnoreSuffix,Visible)
			VALUES
			(@NewPageControlID,@WebPageID,@TestCase,@DataValue,@RowNo,@VerificationValue,@AddOrVerify,@IgnorePrefix,@IgnoreSuffix,@Visible)
			print 'added in pagedata 1'
			
	 END 

IF @pagecontrolid <>-1  AND @DeleteRow <>'Y' --AND @OriginalData	<> @DataValue
BEGIN 
 --  Deepankar Code 
	--UPDATE PageControls
	----SET ControlType=@Controltype,
	----ControlName= @ControlName, ControlID=@ControlID,IsAction =@Isaction,[index]=@ControlIndex
	--SET frame=@Frame
	--WHERE ID=@pagecontrolID AND Webpageid=@WebPageID
	
	
	UPDATE PageControls
	SET ControlType=@Controltype,
	UserFriendlyName=@FieldName,
	ControlName= @ControlName, ControlID=@ControlID,IsAction =@Isaction,[index]=@ControlIndex
	, frame=@Frame
	WHERE ID=@pagecontrolID AND Webpageid=@WebPageID
	
	UPDATE PageData 
	SET DataValue= @DataValue, OrdinalPosition = @RowNo,VerificationValue=@VerificationValue,Visible=@Visible
	WHERE  ID =@PageDataID
	--PageControlID=@pagecontrolID AND TestCase=@TestCase AND [Action]=@AddOrVerify
	--AND WebPageID =@WebPageID

IF @@ROWCOUNT =0 
	BEGIN 
		
		INSERT INTO PageData --Always enter in pagedata table 
		(PageControlID,WebPageID,TestCase,DataValue,OrdinalPosition,VerificationValue,[Action],IgnorePrefix,IgnoreSuffix,Visible)
		VALUES
		(@PageControlID,@WebPageID,@TestCase,@DataValue,@RowNo,@VerificationValue,@AddOrVerify,@IgnorePrefix,@IgnoreSuffix,@Visible)
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[GetWebPageControlsAndData]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetWebPageControlsAndData]
@WebPageID INT,
@TestCase Varchar(50),
@AddorVerfiy Varchar(50)
/*2-Feb-2015 : Added parameter @visible
*/
AS
SET NOCOUNT ON 
SELECT
PageData.ID as PageDataID, 
UserFriendlyName, ControlType,ControlName,ControlID,ControlText,Controlvalue,[Index],PageControls.ID as PageControlID,IsAction,
DataValue AS DATA,DataValue AS OriginalDATA,OrdinalPosition,VerificationValue as originalVerificationData,
ControlID AS OriginalControlID,ControlName AS OriginalControlname,Frame as FramePosition,
NUllIF(IgnoreSuffix,'') AS IgnoreSuffix ,NUllIF(IgnorePrefix,'') AS IgnorePrefix,
NUllIF(Visible,'') AS Visible
FROM 
PageData LEFT JOIN
PageControls ON PageData.PageControlID=PageControls.ID
--PageControls INNER JOIN PageData
--ON PageControls.ID = PageData.PageControlID
WHERE PageControls.WebPageID=@WebPageID AND PageData.TestCase= @TestCase And [Action]=@AddorVerfiy
ORDER BY OrdinalPosition
GO
/****** Object:  StoredProcedure [dbo].[GetDataForRun]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[GetDataForRun]
@ScenarioID INT,
@Step INT =1
/*
13-Jan-2015 Added Fields StartFrom, EndOn,Controltext in the query
2-Feb-2015 : Added parameter @visible
*/

AS
SET NOCOUNT ON 
DECLARE @Rowno INT =0

SELECT ROW_NUMBER() OVER (ORDER BY ScenarioMaster.ID,ScenarioDetail.sequence,OrdinalPosition ASC) AS RowNo,
ScenarioMaster.ID,
ScenarioDetail.ID as ScenarioDetailID,
Scenario,
ScenarioDetail.[Action],
URL,
Absolutepath,
Title,
ControlType,
ControlID,
ControlName,
ControlText,
ControlValue,
[INDEX],
PageData.TestCase,
PageData.ID,
DataValue,
VerificationValue,
WebPages.ID As webpageID,
PageControls.Frame,
NUllIF(IgnoreSuffix,'') AS IgnoreSuffix ,
NUllIF(IgnorePrefix,'') AS IgnorePrefix,
NUllIF(Visible,'') AS Visible
FROM  ScenarioMaster
INNER JOIN ScenarioDetail
ON ScenarioMaster.ID = ScenarioDetail.ScenarioID
INNER JOIN PageData
ON ScenarioDetail.WebPageID  = PageData.WebPageID
AND ScenarioDetail.TestCase = PageData.TestCase AND ScenarioDetail.Action =PageData.Action
INNER JOIN PageControls ON PageData.PageControlID= PageControls.ID
INNER JOIN WebPages ON PageControls.WebPageID = WebPages.ID
WHERE 
ScenarioMaster.ID =@ScenarioID 
AND 
PageData.IsDeleted='N'
ORDER by ScenarioMaster.ID,ScenarioDetail.sequence,OrdinalPosition
GO
/****** Object:  StoredProcedure [dbo].[FindControlUsage]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE
[dbo].[FindControlUsage]
@ControlID INT
AS
-- 1 Check if the control type is same
DECLARE @ControlName VARCHAR(300)
DECLARE @ControlType VARCHAR(50)
DECLARE @IsAction CHAR(1)
DECLARE @ControlINDEX INT
DECLARE @Frame INT

SELECT @ControlType=ControlType,@IsAction=IsAction,@ControlIndex=[Index]
FROM PageData
INNER JOIN 
PageControl 
ON PageControlID=PageData.PageControlID
WHERE ID=@ControlID

IF @@ROWCOUNT=1
BEGIN
   UPDATE PageControls
	SET ControlType=@Controltype,
	ControlName= @ControlName,IsAction =@Isaction,[index]=@ControlIndex,
	frame=@Frame
	WHERE ID=@ControlID 

	DELETE FROM PageData WHERE PageControlID=@ControlID
	DELETE FROM PageControl WHERE ID =@ControlID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTestCase]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE 
[dbo].[DeleteTestCase]
@WebPageID INT,
@TestCase VARCHAR(50),
@Action Varchar(50)
AS
DELETE FROM PageDataTestCaseLink
--SET IsDeleted='Y'
WHERE WebPageID=@WebPageID
AND 
TestCase =@TestCase
AND
[Action]=@Action

DELETE FROM PageData
--SET IsDeleted='Y'
WHERE WebPageID=@WebPageID
AND 
TestCase =@TestCase
AND
[Action]=@Action

DELETE FROM ScenarioDetail
WHERE WebPageID=@WebPageID
AND 
TestCase =@TestCase
AND
[Action]=@Action
GO
/****** Object:  StoredProcedure [dbo].[CreateVerification]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE 
[dbo].[CreateVerification]
@WebPageID INT,
@TestCase Varchar(50)
AS
INSERT INTO PageDataTestCaseLink
(WebPageID,TestCase,[Action])
VALUES 
(@WebPageID,@TestCase,'Verify')
INSERT INTO PageData 
(PageControlID,WebPageID,OrdinalPosition,TestCase,Datavalue,VerificationValue,[Action])
SELECT PageControlID,WebPageID,OrdinalPosition,TestCase,'',DataValue,'Verify'
FROM PageData
WHERE WebPageID=@WebPageID AND TestCase =@TestCase and [action] ='Add'


UPDATE PageData
SET VerificationValue='TRUE' 
FROM PageData INNER JOIN PageControls
ON PageDAta.PageControlID =PageControls.ID
WHERE PageDAta.WebPageID=@WebPageID AND TestCase =@TestCase and [action] ='Verify'
AND ( ControlType='CheckBox' OR ControlType='RadioButton')
GO
/****** Object:  StoredProcedure [dbo].[CheckControlNameUsage]    Script Date: 01/20/2016 17:06:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CheckControlNameUsage 40,'session_key','session_key-login'

CREATE Procedure [dbo].[CheckControlNameUsage]
@webpageid int,
@controlname varchar(300),
@controlID varchar(300)
AS
print len(@controlname)
print len(@controlid)
IF len(@controlname)>0 AND len(@controlid) >0
BEGIN 
	SELECT pagecontrols.webpageid,UniqueName,testcase
	from pagecontrols 
	inner join pagedata on pagecontrols.id=pagedata.pagecontrolid
	inner join webpages on webpages.id = pagecontrols.webpageid
	where webpages.id=@webpageid AND (controlname=@controlname or controlid=@controlID)
END	
ELSE IF len(@controlname)>0
BEGIN 
	SELECT pagecontrols.webpageid,UniqueName,testcase
	from pagecontrols 
	inner join pagedata on pagecontrols.id=pagedata.pagecontrolid
	inner join webpages on webpages.id = pagecontrols.webpageid
	where webpages.id=@webpageid and controlname=@controlname
END
ELSE IF len(@controlid)>0
BEGIN 
	SELECT pagecontrols.webpageid,UniqueName,testcase
	from pagecontrols 
	inner join pagedata on pagecontrols.id=pagedata.pagecontrolid
	inner join webpages on webpages.id = pagecontrols.webpageid
	where webpages.id=@webpageid and controlid=@controlid
END
GO
/****** Object:  Default [DF_DynamicValues_CreatedOn]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[DynamicValues] ADD  CONSTRAINT [DF_DynamicValues_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_DynamicDataValues_Length]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[MstDynamicParameters] ADD  CONSTRAINT [DF_DynamicDataValues_Length]  DEFAULT ((0)) FOR [Length]
GO
/****** Object:  Default [DF_MstWebTableDefinition_Index]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[MstWebTableDefinition] ADD  CONSTRAINT [DF_MstWebTableDefinition_Index]  DEFAULT ((0)) FOR [TableInstance]
GO
/****** Object:  Default [DF_PageControls_Frame]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageControls] ADD  CONSTRAINT [DF_PageControls_Frame]  DEFAULT ((-1)) FOR [Frame]
GO
/****** Object:  Default [DF_PageData_IsDeleted]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageData] ADD  CONSTRAINT [DF_PageData_IsDeleted]  DEFAULT ('N') FOR [IsDeleted]
GO
/****** Object:  Default [DF_PageData_StartFrom]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageData] ADD  CONSTRAINT [DF_PageData_StartFrom]  DEFAULT ((-1)) FOR [IgnorePrefix]
GO
/****** Object:  Default [DF_PageData_EndOn]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageData] ADD  CONSTRAINT [DF_PageData_EndOn]  DEFAULT ((-1)) FOR [IgnoreSuffix]
GO
/****** Object:  Default [DF_PageDataTestCaseLink_Action]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageDataTestCaseLink] ADD  CONSTRAINT [DF_PageDataTestCaseLink_Action]  DEFAULT ('Add') FOR [Action]
GO
/****** Object:  Default [DF_PageDataTestCaseLink_IsDeleted]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageDataTestCaseLink] ADD  CONSTRAINT [DF_PageDataTestCaseLink_IsDeleted]  DEFAULT ('N') FOR [IsDeleted]
GO
/****** Object:  Default [DF_ScenarioMaster_Close]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[ScenarioMaster] ADD  CONSTRAINT [DF_ScenarioMaster_Close]  DEFAULT ('N') FOR [Closed]
GO
/****** Object:  Default [DF_ScenarioMaster_IsTemp]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[ScenarioMaster] ADD  CONSTRAINT [DF_ScenarioMaster_IsTemp]  DEFAULT ('N') FOR [IsTemp]
GO
/****** Object:  Default [DF_WebPages_Frame]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[WebPages] ADD  CONSTRAINT [DF_WebPages_Frame]  DEFAULT ((-1)) FOR [Frame]
GO
/****** Object:  Default [DF_WebPages_IsActive]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[WebPages] ADD  CONSTRAINT [DF_WebPages_IsActive]  DEFAULT ('Y') FOR [IsActive]
GO
/****** Object:  ForeignKey [FK_DynamicValues_ScenarioMaster]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[DynamicValues]  WITH CHECK ADD  CONSTRAINT [FK_DynamicValues_ScenarioMaster] FOREIGN KEY([ScenarioID])
REFERENCES [dbo].[ScenarioMaster] ([ID])
GO
ALTER TABLE [dbo].[DynamicValues] CHECK CONSTRAINT [FK_DynamicValues_ScenarioMaster]
GO
/****** Object:  ForeignKey [FK_MstWebTableDefinition_WebPages]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[MstWebTableDefinition]  WITH CHECK ADD  CONSTRAINT [FK_MstWebTableDefinition_WebPages] FOREIGN KEY([WebPageID])
REFERENCES [dbo].[WebPages] ([ID])
GO
ALTER TABLE [dbo].[MstWebTableDefinition] CHECK CONSTRAINT [FK_MstWebTableDefinition_WebPages]
GO
/****** Object:  ForeignKey [FK_PageControls_WebPages]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageControls]  WITH CHECK ADD  CONSTRAINT [FK_PageControls_WebPages] FOREIGN KEY([WebPageID])
REFERENCES [dbo].[WebPages] ([ID])
GO
ALTER TABLE [dbo].[PageControls] CHECK CONSTRAINT [FK_PageControls_WebPages]
GO
/****** Object:  ForeignKey [FK_PageData_PageControls]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageData]  WITH CHECK ADD  CONSTRAINT [FK_PageData_PageControls] FOREIGN KEY([PageControlID])
REFERENCES [dbo].[PageControls] ([ID])
GO
ALTER TABLE [dbo].[PageData] CHECK CONSTRAINT [FK_PageData_PageControls]
GO
/****** Object:  ForeignKey [FK_PageData_WebPages]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageData]  WITH CHECK ADD  CONSTRAINT [FK_PageData_WebPages] FOREIGN KEY([WebPageID])
REFERENCES [dbo].[WebPages] ([ID])
GO
ALTER TABLE [dbo].[PageData] CHECK CONSTRAINT [FK_PageData_WebPages]
GO
/****** Object:  ForeignKey [FK_PageDataTestCaseLink_WebPages]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[PageDataTestCaseLink]  WITH CHECK ADD  CONSTRAINT [FK_PageDataTestCaseLink_WebPages] FOREIGN KEY([WebPageID])
REFERENCES [dbo].[WebPages] ([ID])
GO
ALTER TABLE [dbo].[PageDataTestCaseLink] CHECK CONSTRAINT [FK_PageDataTestCaseLink_WebPages]
GO
/****** Object:  ForeignKey [FK_ScenarioDetail_ScenarioDetail]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[ScenarioDetail]  WITH CHECK ADD  CONSTRAINT [FK_ScenarioDetail_ScenarioDetail] FOREIGN KEY([ID])
REFERENCES [dbo].[ScenarioDetail] ([ID])
GO
ALTER TABLE [dbo].[ScenarioDetail] CHECK CONSTRAINT [FK_ScenarioDetail_ScenarioDetail]
GO
/****** Object:  ForeignKey [FK_ScenarioDetail_ScenarioMaster]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[ScenarioDetail]  WITH CHECK ADD  CONSTRAINT [FK_ScenarioDetail_ScenarioMaster] FOREIGN KEY([ScenarioID])
REFERENCES [dbo].[ScenarioMaster] ([ID])
GO
ALTER TABLE [dbo].[ScenarioDetail] CHECK CONSTRAINT [FK_ScenarioDetail_ScenarioMaster]
GO
/****** Object:  ForeignKey [FK_ScenarioDetail_WebPages]    Script Date: 01/20/2016 17:06:23 ******/
ALTER TABLE [dbo].[ScenarioDetail]  WITH CHECK ADD  CONSTRAINT [FK_ScenarioDetail_WebPages] FOREIGN KEY([WebPageID])
REFERENCES [dbo].[WebPages] ([ID])
GO
ALTER TABLE [dbo].[ScenarioDetail] CHECK CONSTRAINT [FK_ScenarioDetail_WebPages]
GO
