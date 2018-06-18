DECLARE @ResourceID int;

INSERT INTO [dbo].[Resource]
           ([Name]
           ,[ResourceLink]
		   ,[ParseIsSwitchOn]
		   ,[ParsePeriodInMinutes]
		   )
     VALUES
           ('Album Info'
           ,'http://www.album-info.ru/'
		   ,1	
		   ,30
		   );

SET @ResourceID = SCOPE_IDENTITY();

INSERT INTO [dbo].[ParserSettings]
           ([ResourceId]
           ,[BaseUrl]
           ,[Prefix]
           ,[StartPoint]
           ,[EndPoint])
     VALUES
           (@ResourceID
           ,'http://www.album-info.ru/albumlist.aspx?'
           ,'page='
           ,1
           ,5);


