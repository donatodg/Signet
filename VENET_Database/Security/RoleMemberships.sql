EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'Ersa-Pc\Diego';


GO
EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'sysTrafico';


GO
EXECUTE sp_addrolemember @rolename = N'db_ddladmin', @membername = N'Ersa-Pc\Diego';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'Ersa-Pc\Diego';

