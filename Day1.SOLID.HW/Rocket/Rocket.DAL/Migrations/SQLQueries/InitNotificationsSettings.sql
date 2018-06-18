INSERT INTO [dbo].[NotificationsSettings]
           ([Name]
           ,[NotifyIsSwitchOn]
           ,[NotifyPeriodInMinutes]
		   ,[PushUrl])
     VALUES
           ('Notifications'
           ,1
           ,10
		   ,'http://rocket-api.belpyro.net/api/notifications/notifyOfReleasePush');



