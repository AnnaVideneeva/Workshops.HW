namespace Rocket.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitAll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Subscribable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorisedUsers",
                c => new
                    {
                        DbUserId = c.Int(nullable: false, identity: true),
                        AvatarPath = c.String(maxLength: 200),
                        DbUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DbUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.DbUser_Id)
                .Index(t => t.DbUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AccountStatusId = c.Int(),
                        AccountLevelId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountLevels", t => t.AccountLevelId)
                .ForeignKey("dbo.AccountStatuses", t => t.AccountStatusId)
                .Index(t => t.AccountStatusId)
                .Index(t => t.AccountLevelId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AccountLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Role_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.Role_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.DbPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ValueName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Season",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        PosterImageUrl = c.String(),
                        TvSeriesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TvSerias", t => t.TvSeriesId)
                .Index(t => t.TvSeriesId);
            
            CreateTable(
                "dbo.PersonType",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.MusicTrack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Duration = c.Time(precision: 7),
                        MusicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Music", t => t.MusicId)
                .Index(t => t.MusicId);
            
            CreateTable(
                "dbo.ResourceItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        ResourceInternalId = c.String(nullable: false, maxLength: 50),
                        ResourceItemLink = c.String(),
                        CreatedDateTime = c.DateTime(name: "CreatedDateTime", nullable: false, defaultValueSql: "GETDATE()"),
                        LastModified = c.DateTime(name: "LastModified", nullable: false, defaultValueSql: "GETDATE()"),
                        MusicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Music", t => t.MusicId)
                .ForeignKey("dbo.Resource", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId)
                .Index(t => t.MusicId);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ResourceLink = c.String(nullable: false, maxLength: 150),
                        ParseIsSwitchOn = c.Boolean(nullable: false),
                        ParsePeriodInMinutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParserSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        BaseUrl = c.String(nullable: false, maxLength: 250),
                        Prefix = c.String(maxLength: 200),
                        StartPoint = c.Int(),
                        EndPoint = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resource", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.DbEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DbAuthorisedUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthorisedUsers", t => t.DbAuthorisedUserId, cascadeDelete: true)
                .Index(t => t.DbAuthorisedUserId);
            
            CreateTable(
                "dbo.CustomMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiverId = c.Int(nullable: false),
                        SenderName = c.String(nullable: false),
                        Subject = c.String(),
                        Body = c.String(nullable: false),
                        HtmlBody = c.Boolean(nullable: false),
                        Viewed = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receivers", t => t.ReceiverId, cascadeDelete: true)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        NotifyByEmail = c.Boolean(nullable: false),
                        NotifyByPush = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ReceiversJoinReleases",
                c => new
                    {
                        ReceiverId = c.Int(nullable: false),
                        ReleaseMessageId = c.Int(nullable: false),
                        Viewed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReceiverId, t.ReleaseMessageId })
                .ForeignKey("dbo.ReleaseMessages", t => t.ReleaseMessageId, cascadeDelete: true)
                .ForeignKey("dbo.Receivers", t => t.ReceiverId, cascadeDelete: true)
                .Index(t => t.ReceiverId)
                .Index(t => t.ReleaseMessageId);
            
            CreateTable(
                "dbo.ReleaseMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReleaseId = c.Int(nullable: false),
                        ReleaseType = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBillingMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiverId = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Viewed = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receivers", t => t.ReceiverId, cascadeDelete: true)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ZipCode = c.String(maxLength: 15),
                        CountryId = c.Int(),
                        City = c.String(maxLength: 25),
                        Building = c.String(maxLength: 25),
                        BuildingBlock = c.String(maxLength: 20),
                        Flat = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.UserDetails", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivationNeeded = c.Boolean(),
                        SitizenshipId = c.Int(),
                        LanguageId = c.Int(),
                        DateOfBirth = c.DateTime(),
                        GenderId = c.Int(),
                        HowToCallId = c.Int(),
                        MailAddressId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.HowToCalls", t => t.HowToCallId)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .ForeignKey("dbo.Countries", t => t.SitizenshipId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.SitizenshipId)
                .Index(t => t.LanguageId)
                .Index(t => t.GenderId)
                .Index(t => t.HowToCallId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HowToCalls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuestBillingMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotificationsLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReleaseId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotificationsSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        NotifyIsSwitchOn = c.Boolean(nullable: false),
                        NotifyPeriodInMinutes = c.Int(nullable: false),
                        PushUrl = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbPermissionDbRoles",
                c => new
                    {
                        DbPermission_Id = c.Int(nullable: false),
                        DbRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.DbPermission_Id, t.DbRole_Id })
                .ForeignKey("dbo.DbPermissions", t => t.DbPermission_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.DbRole_Id, cascadeDelete: true)
                .Index(t => t.DbPermission_Id)
                .Index(t => t.DbRole_Id);
            
            CreateTable(
                "dbo.SubscriptionsToUsers",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SubscriptionId, t.UserId })
                .ForeignKey("dbo.Subscribable", t => t.SubscriptionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SubscriptionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TvSeriasToGenres",
                c => new
                    {
                        TvSeriasId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TvSeriasId, t.GenreId })
                .ForeignKey("dbo.TvSerias", t => t.TvSeriasId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .Index(t => t.TvSeriasId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.TvSeriasToPersons",
                c => new
                    {
                        TvSeriasId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TvSeriasId, t.PersonId })
                .ForeignKey("dbo.TvSerias", t => t.TvSeriasId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.TvSeriasId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.MusicReleaseGenres",
                c => new
                    {
                        MusicId = c.Int(nullable: false),
                        MusicGenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MusicId, t.MusicGenreId })
                .ForeignKey("dbo.Music", t => t.MusicId)
                .ForeignKey("dbo.MusicGenres", t => t.MusicGenreId)
                .Index(t => t.MusicId)
                .Index(t => t.MusicGenreId);
            
            CreateTable(
                "dbo.MusicMusicians",
                c => new
                    {
                        MusicId = c.Int(nullable: false),
                        MusiciansId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MusicId, t.MusiciansId })
                .ForeignKey("dbo.Music", t => t.MusicId)
                .ForeignKey("dbo.Musician", t => t.MusiciansId)
                .Index(t => t.MusicId)
                .Index(t => t.MusiciansId);
            
            CreateTable(
                "dbo.AuthorisedUserGenres",
                c => new
                    {
                        AuthorisedUserId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorisedUserId, t.GenreId })
                .ForeignKey("dbo.AuthorisedUsers", t => t.AuthorisedUserId, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AuthorisedUserId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.AuthorisedUserMusicGenres",
                c => new
                    {
                        AuthorisedUserId = c.Int(nullable: false),
                        MusicGenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorisedUserId, t.MusicGenreId })
                .ForeignKey("dbo.AuthorisedUsers", t => t.AuthorisedUserId, cascadeDelete: true)
                .ForeignKey("dbo.MusicGenres", t => t.MusicGenreId, cascadeDelete: true)
                .Index(t => t.AuthorisedUserId)
                .Index(t => t.MusicGenreId);
            
            CreateTable(
                "dbo.UserDetailsEmailAddresses",
                c => new
                    {
                        UserDetailId = c.Int(nullable: false),
                        EmailAddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserDetailId, t.EmailAddressId })
                .ForeignKey("dbo.UserDetails", t => t.UserDetailId, cascadeDelete: true)
                .ForeignKey("dbo.EmailAddresses", t => t.EmailAddressId, cascadeDelete: true)
                .Index(t => t.UserDetailId)
                .Index(t => t.EmailAddressId);
            
            CreateTable(
                "dbo.UserDetailsPhoneNumbers",
                c => new
                    {
                        UserDetailId = c.Int(nullable: false),
                        PhoneNumberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserDetailId, t.PhoneNumberId })
                .ForeignKey("dbo.UserDetails", t => t.UserDetailId, cascadeDelete: true)
                .ForeignKey("dbo.PhoneNumbers", t => t.PhoneNumberId, cascadeDelete: true)
                .Index(t => t.UserDetailId)
                .Index(t => t.PhoneNumberId);
            
            CreateTable(
                "dbo.MusicGenres",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribable", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Music",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        PosterImagePath = c.String(maxLength: 200),
                        PosterImageUrl = c.String(),
                        Duration = c.Int(),
                        Artist = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribable", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Episode",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ReleaseDateRu = c.DateTime(),
                        ReleaseDateEn = c.DateTime(),
                        Number = c.Int(nullable: false),
                        TitleRu = c.String(nullable: false, maxLength: 250),
                        TitleEn = c.String(nullable: false, maxLength: 250),
                        DurationInMinutes = c.Double(),
                        UrlForEpisodeSource = c.String(nullable: false),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribable", t => t.Id)
                .ForeignKey("dbo.Season", t => t.SeasonId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.SeasonId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        CategoryCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribable", t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryCode, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.CategoryCode);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FullNameRu = c.String(nullable: false, maxLength: 250),
                        FullNameEn = c.String(nullable: false, maxLength: 250),
                        LostfilmPersonalPageUrl = c.String(nullable: false),
                        PhotoThumbnailUrl = c.String(),
                        PersonTypeCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribable", t => t.Id)
                .ForeignKey("dbo.PersonType", t => t.PersonTypeCode, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.PersonTypeCode);
            
            CreateTable(
                "dbo.TvSerias",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TitleRu = c.String(nullable: false, maxLength: 250),
                        TitleEn = c.String(nullable: false, maxLength: 250),
                        PosterImageUrl = c.String(),
                        LostfilmRate = c.Double(),
                        RateImDb = c.Double(),
                        UrlToOfficialSite = c.String(),
                        CurrentStatus = c.String(maxLength: 50),
                        TvSerialCanal = c.String(maxLength: 150),
                        TvSerialYearStart = c.String(),
                        Summary = c.String(),
                        UrlToSource = c.String(),
                        PremiereDateForParse = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribable", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Musician",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribable", t => t.Id)
                .Index(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musician", "Id", "dbo.Subscribable");
            DropForeignKey("dbo.TvSerias", "Id", "dbo.Subscribable");
            DropForeignKey("dbo.Person", "PersonTypeCode", "dbo.PersonType");
            DropForeignKey("dbo.Person", "Id", "dbo.Subscribable");
            DropForeignKey("dbo.Genre", "CategoryCode", "dbo.Category");
            DropForeignKey("dbo.Genre", "Id", "dbo.Subscribable");
            DropForeignKey("dbo.Episode", "SeasonId", "dbo.Season");
            DropForeignKey("dbo.Episode", "Id", "dbo.Subscribable");
            DropForeignKey("dbo.Music", "Id", "dbo.Subscribable");
            DropForeignKey("dbo.MusicGenres", "Id", "dbo.Subscribable");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserDetails", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDetails", "SitizenshipId", "dbo.Countries");
            DropForeignKey("dbo.UserDetailsPhoneNumbers", "PhoneNumberId", "dbo.PhoneNumbers");
            DropForeignKey("dbo.UserDetailsPhoneNumbers", "UserDetailId", "dbo.UserDetails");
            DropForeignKey("dbo.Addresses", "Id", "dbo.UserDetails");
            DropForeignKey("dbo.UserDetails", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.UserDetails", "HowToCallId", "dbo.HowToCalls");
            DropForeignKey("dbo.UserDetails", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.UserDetailsEmailAddresses", "EmailAddressId", "dbo.EmailAddresses");
            DropForeignKey("dbo.UserDetailsEmailAddresses", "UserDetailId", "dbo.UserDetails");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.UserBillingMessages", "ReceiverId", "dbo.Receivers");
            DropForeignKey("dbo.ReceiversJoinReleases", "ReceiverId", "dbo.Receivers");
            DropForeignKey("dbo.ReceiversJoinReleases", "ReleaseMessageId", "dbo.ReleaseMessages");
            DropForeignKey("dbo.CustomMessages", "ReceiverId", "dbo.Receivers");
            DropForeignKey("dbo.AuthorisedUserMusicGenres", "MusicGenreId", "dbo.MusicGenres");
            DropForeignKey("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId", "dbo.AuthorisedUsers");
            DropForeignKey("dbo.AuthorisedUserGenres", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.AuthorisedUserGenres", "AuthorisedUserId", "dbo.AuthorisedUsers");
            DropForeignKey("dbo.DbEmails", "DbAuthorisedUserId", "dbo.AuthorisedUsers");
            DropForeignKey("dbo.AuthorisedUsers", "DbUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ResourceItem", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.ParserSettings", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.ResourceItem", "MusicId", "dbo.Music");
            DropForeignKey("dbo.MusicTrack", "MusicId", "dbo.Music");
            DropForeignKey("dbo.MusicMusicians", "MusiciansId", "dbo.Musician");
            DropForeignKey("dbo.MusicMusicians", "MusicId", "dbo.Music");
            DropForeignKey("dbo.MusicReleaseGenres", "MusicGenreId", "dbo.MusicGenres");
            DropForeignKey("dbo.MusicReleaseGenres", "MusicId", "dbo.Music");
            DropForeignKey("dbo.Season", "TvSeriesId", "dbo.TvSerias");
            DropForeignKey("dbo.TvSeriasToPersons", "PersonId", "dbo.Person");
            DropForeignKey("dbo.TvSeriasToPersons", "TvSeriasId", "dbo.TvSerias");
            DropForeignKey("dbo.TvSeriasToGenres", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.TvSeriasToGenres", "TvSeriasId", "dbo.TvSerias");
            DropForeignKey("dbo.SubscriptionsToUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubscriptionsToUsers", "SubscriptionId", "dbo.Subscribable");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "Role_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.DbPermissionDbRoles", "DbRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.DbPermissionDbRoles", "DbPermission_Id", "dbo.DbPermissions");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AccountStatusId", "dbo.AccountStatuses");
            DropForeignKey("dbo.AspNetUsers", "AccountLevelId", "dbo.AccountLevels");
            DropIndex("dbo.Musician", new[] { "Id" });
            DropIndex("dbo.TvSerias", new[] { "Id" });
            DropIndex("dbo.Person", new[] { "PersonTypeCode" });
            DropIndex("dbo.Person", new[] { "Id" });
            DropIndex("dbo.Genre", new[] { "CategoryCode" });
            DropIndex("dbo.Genre", new[] { "Id" });
            DropIndex("dbo.Episode", new[] { "SeasonId" });
            DropIndex("dbo.Episode", new[] { "Id" });
            DropIndex("dbo.Music", new[] { "Id" });
            DropIndex("dbo.MusicGenres", new[] { "Id" });
            DropIndex("dbo.UserDetailsPhoneNumbers", new[] { "PhoneNumberId" });
            DropIndex("dbo.UserDetailsPhoneNumbers", new[] { "UserDetailId" });
            DropIndex("dbo.UserDetailsEmailAddresses", new[] { "EmailAddressId" });
            DropIndex("dbo.UserDetailsEmailAddresses", new[] { "UserDetailId" });
            DropIndex("dbo.AuthorisedUserMusicGenres", new[] { "MusicGenreId" });
            DropIndex("dbo.AuthorisedUserMusicGenres", new[] { "AuthorisedUserId" });
            DropIndex("dbo.AuthorisedUserGenres", new[] { "GenreId" });
            DropIndex("dbo.AuthorisedUserGenres", new[] { "AuthorisedUserId" });
            DropIndex("dbo.MusicMusicians", new[] { "MusiciansId" });
            DropIndex("dbo.MusicMusicians", new[] { "MusicId" });
            DropIndex("dbo.MusicReleaseGenres", new[] { "MusicGenreId" });
            DropIndex("dbo.MusicReleaseGenres", new[] { "MusicId" });
            DropIndex("dbo.TvSeriasToPersons", new[] { "PersonId" });
            DropIndex("dbo.TvSeriasToPersons", new[] { "TvSeriasId" });
            DropIndex("dbo.TvSeriasToGenres", new[] { "GenreId" });
            DropIndex("dbo.TvSeriasToGenres", new[] { "TvSeriasId" });
            DropIndex("dbo.SubscriptionsToUsers", new[] { "UserId" });
            DropIndex("dbo.SubscriptionsToUsers", new[] { "SubscriptionId" });
            DropIndex("dbo.DbPermissionDbRoles", new[] { "DbRole_Id" });
            DropIndex("dbo.DbPermissionDbRoles", new[] { "DbPermission_Id" });
            DropIndex("dbo.UserDetails", new[] { "User_Id" });
            DropIndex("dbo.UserDetails", new[] { "HowToCallId" });
            DropIndex("dbo.UserDetails", new[] { "GenderId" });
            DropIndex("dbo.UserDetails", new[] { "LanguageId" });
            DropIndex("dbo.UserDetails", new[] { "SitizenshipId" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropIndex("dbo.UserBillingMessages", new[] { "ReceiverId" });
            DropIndex("dbo.ReceiversJoinReleases", new[] { "ReleaseMessageId" });
            DropIndex("dbo.ReceiversJoinReleases", new[] { "ReceiverId" });
            DropIndex("dbo.CustomMessages", new[] { "ReceiverId" });
            DropIndex("dbo.DbEmails", new[] { "DbAuthorisedUserId" });
            DropIndex("dbo.ParserSettings", new[] { "ResourceId" });
            DropIndex("dbo.ResourceItem", new[] { "MusicId" });
            DropIndex("dbo.ResourceItem", new[] { "ResourceId" });
            DropIndex("dbo.MusicTrack", new[] { "MusicId" });
            DropIndex("dbo.Season", new[] { "TvSeriesId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Role_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "AccountLevelId" });
            DropIndex("dbo.AspNetUsers", new[] { "AccountStatusId" });
            DropIndex("dbo.AuthorisedUsers", new[] { "DbUser_Id" });
            DropTable("dbo.Musician");
            DropTable("dbo.TvSerias");
            DropTable("dbo.Person");
            DropTable("dbo.Genre");
            DropTable("dbo.Episode");
            DropTable("dbo.Music");
            DropTable("dbo.MusicGenres");
            DropTable("dbo.UserDetailsPhoneNumbers");
            DropTable("dbo.UserDetailsEmailAddresses");
            DropTable("dbo.AuthorisedUserMusicGenres");
            DropTable("dbo.AuthorisedUserGenres");
            DropTable("dbo.MusicMusicians");
            DropTable("dbo.MusicReleaseGenres");
            DropTable("dbo.TvSeriasToPersons");
            DropTable("dbo.TvSeriasToGenres");
            DropTable("dbo.SubscriptionsToUsers");
            DropTable("dbo.DbPermissionDbRoles");
            DropTable("dbo.NotificationsSettings");
            DropTable("dbo.NotificationsLog");
            DropTable("dbo.GuestBillingMessages");
            DropTable("dbo.EmailTemplates");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Languages");
            DropTable("dbo.HowToCalls");
            DropTable("dbo.Genders");
            DropTable("dbo.EmailAddresses");
            DropTable("dbo.UserDetails");
            DropTable("dbo.Addresses");
            DropTable("dbo.Countries");
            DropTable("dbo.UserBillingMessages");
            DropTable("dbo.ReleaseMessages");
            DropTable("dbo.ReceiversJoinReleases");
            DropTable("dbo.Receivers");
            DropTable("dbo.CustomMessages");
            DropTable("dbo.DbEmails");
            DropTable("dbo.ParserSettings");
            DropTable("dbo.Resource");
            DropTable("dbo.ResourceItem");
            DropTable("dbo.MusicTrack");
            DropTable("dbo.PersonType");
            DropTable("dbo.Season");
            DropTable("dbo.DbPermissions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AccountStatuses");
            DropTable("dbo.AccountLevels");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AuthorisedUsers");
            DropTable("dbo.Subscribable");
            DropTable("dbo.Category");
        }
    }
}
