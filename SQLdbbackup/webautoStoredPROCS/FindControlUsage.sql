USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[FindControlUsage]    Script Date: 11/06/2015 16:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE
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