USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[PageControlsAdd]    Script Date: 11/06/2015 16:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
[dbo].[PageControlsAdd]
@WebPageID INT,
@pagecontrolid int,
@pagedataid int,
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
						(WebPageID,ControlType,COntrolName,ControlID,ControlText,ControlValue,IsAction,[Index],Frame)
						VALUES
						(@WebPageID,@ControlType,@COntrolName,@ControlID,@ControlText,@ControlValue,'N',@ControlIndex,@Frame)
						SELECT @NewPageControlID= @@IDENTITY
					END
					
			END
		ELSE IF  @Isaction='Y'-- 
		--This is for custom functions where there is no controlID hence they can be multiple times
			BEGIN 
			INSERT INTO	PageControls (WebPageID,ControlType,COntrolName,ControlText,ControlID,ControlValue,IsAction,[Index],Frame)
				VALUES
				(@WebPageID,@ControlType,@COntrolName,@COntrolText,@ControlID,@ControlValue,'Y',@ControlIndex,@Frame)
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