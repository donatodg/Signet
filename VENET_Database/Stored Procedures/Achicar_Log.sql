CREATE  PROCEDURE [dbo].[Achicar_Log]  

AS

declare @database varchar(100)

--declare cursorDataBases cursor for
--SELECT NAME FROM master..sysdatabases
--where NAME not in ('master', 'tempdb', 'model', 'msdb')
--and NAME not like '%ReportServer%'
--and NAME not like '%-%'

--open cursorDataBases
--fetch next from cursorDataBases into @database
--while @@fetch_status = 0
--begin
--	declare @sql varchar(1000)
	
--	set @sql = 'USE ' + @database + '; CHECKPOINT 1'
--	print(@sql)
--	exec(@sql)
	
--	set @sql = 'ALTER DATABASE ' + @database + ' SET RECOVERY SIMPLE'
	
--	print(@sql)
--	exec(@sql)
	
--	set @sql = 'USE ' + @database + '; declare @logfile varchar(1000); declare @logid int; set @logfile = (select name from sysfiles where groupid = 0); set @logid = (select fileid from sysfiles where groupid = 0); DBCC SHRINKFILE (@logid , 0, TRUNCATEONLY)'
	
--	print(@sql)
--	exec(@sql)
	
--	set @sql = 'ALTER DATABASE ' + @database + ' SET RECOVERY FULL'
	
--	print(@sql)
--	exec(@sql)
	
--	fetch next from cursorDataBases into @database
--end

--close cursorDataBases
--deallocate cursorDataBases
