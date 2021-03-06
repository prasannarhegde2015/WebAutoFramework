USE [WebAutomation]
GO
/****** Object:  StoredProcedure [dbo].[CheckControlNameUsage]    Script Date: 11/06/2015 16:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CheckControlNameUsage 40,'session_key','session_key-login'

ALTER Procedure [dbo].[CheckControlNameUsage]
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
