USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[GetWebPageControlsAndData]    Script Date: 11/06/2015 16:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
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
ControlType,ControlName,ControlID,ControlText,Controlvalue,[Index],PageControls.ID as PageControlID,IsAction,
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