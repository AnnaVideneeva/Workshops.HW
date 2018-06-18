namespace Rocket.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAuthUserToUserProfile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuthorisedUsers", newName: "UserProfile");
            RenameTable(name: "dbo.AuthorisedUserGenres", newName: "UserProfileGenres");
            RenameTable(name: "dbo.AuthorisedUserMusicGenres", newName: "UserProfileMusicGenres");
            RenameColumn(table: "dbo.UserProfileGenres", name: "AuthorisedUserId", newName: "UserProfileId");
            RenameColumn(table: "dbo.UserProfileMusicGenres", name: "AuthorisedUserId", newName: "UserProfileId");
            RenameColumn(table: "dbo.DbEmails", name: "DbAuthorisedUserId", newName: "DbUserProfileId");
            RenameIndex(table: "dbo.DbEmails", name: "IX_DbAuthorisedUserId", newName: "IX_DbUserProfileId");
            RenameIndex(table: "dbo.UserProfileGenres", name: "IX_AuthorisedUserId", newName: "IX_UserProfileId");
            RenameIndex(table: "dbo.UserProfileMusicGenres", name: "IX_AuthorisedUserId", newName: "IX_UserProfileId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserProfileMusicGenres", name: "IX_UserProfileId", newName: "IX_AuthorisedUserId");
            RenameIndex(table: "dbo.UserProfileGenres", name: "IX_UserProfileId", newName: "IX_AuthorisedUserId");
            RenameIndex(table: "dbo.DbEmails", name: "IX_DbUserProfileId", newName: "IX_DbAuthorisedUserId");
            RenameColumn(table: "dbo.DbEmails", name: "DbUserProfileId", newName: "DbAuthorisedUserId");
            RenameColumn(table: "dbo.UserProfileMusicGenres", name: "UserProfileId", newName: "AuthorisedUserId");
            RenameColumn(table: "dbo.UserProfileGenres", name: "UserProfileId", newName: "AuthorisedUserId");
            RenameTable(name: "dbo.UserProfileMusicGenres", newName: "AuthorisedUserMusicGenres");
            RenameTable(name: "dbo.UserProfileGenres", newName: "AuthorisedUserGenres");
            RenameTable(name: "dbo.UserProfile", newName: "AuthorisedUsers");
        }
    }
}
