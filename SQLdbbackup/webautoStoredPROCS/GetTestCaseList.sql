USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetTestCaseList]    Script Date: 11/06/2015 16:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
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