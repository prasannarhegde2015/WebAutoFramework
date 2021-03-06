USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[WebPageAdd]    Script Date: 11/06/2015 16:48:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  PROCEDURE 
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