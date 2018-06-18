namespace Rocket.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAuthUserIdToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbEmails", "DbAuthorisedUserId", "dbo.AuthorisedUsers");
            DropForeignKey("dbo.AuthorisedUserGenres", "AuthorisedUserId", "dbo.AuthorisedUsers");
            DropForeignKey("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId", "dbo.AuthorisedUsers");
            DropIndex("dbo.DbEmails", new[] { "DbAuthorisedUserId" });
            DropIndex("dbo.AuthorisedUserGenres", new[] { "AuthorisedUserId" });
            DropIndex("dbo.AuthorisedUserMusicGenres", new[] { "AuthorisedUserId" });
            DropPrimaryKey("dbo.AuthorisedUsers");
            DropPrimaryKey("dbo.AuthorisedUserGenres");
            DropPrimaryKey("dbo.AuthorisedUserMusicGenres");
            AlterColumn("dbo.DbEmails", "DbAuthorisedUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AuthorisedUserGenres", "AuthorisedUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AuthorisedUsers", "DbUser_Id");
            AddPrimaryKey("dbo.AuthorisedUserGenres", new[] { "AuthorisedUserId", "GenreId" });
            AddPrimaryKey("dbo.AuthorisedUserMusicGenres", new[] { "AuthorisedUserId", "MusicGenreId" });
            CreateIndex("dbo.DbEmails", "DbAuthorisedUserId");
            CreateIndex("dbo.AuthorisedUserGenres", "AuthorisedUserId");
            CreateIndex("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId");
            AddForeignKey("dbo.DbEmails", "DbAuthorisedUserId", "dbo.AuthorisedUsers", "DbUser_Id", cascadeDelete: true);
            AddForeignKey("dbo.AuthorisedUserGenres", "AuthorisedUserId", "dbo.AuthorisedUsers", "DbUser_Id", cascadeDelete: true);
            AddForeignKey("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId", "dbo.AuthorisedUsers", "DbUser_Id", cascadeDelete: true);
            DropColumn("dbo.AuthorisedUsers", "DbUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AuthorisedUsers", "DbUserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId", "dbo.AuthorisedUsers");
            DropForeignKey("dbo.AuthorisedUserGenres", "AuthorisedUserId", "dbo.AuthorisedUsers");
            DropForeignKey("dbo.DbEmails", "DbAuthorisedUserId", "dbo.AuthorisedUsers");
            DropIndex("dbo.AuthorisedUserMusicGenres", new[] { "AuthorisedUserId" });
            DropIndex("dbo.AuthorisedUserGenres", new[] { "AuthorisedUserId" });
            DropIndex("dbo.DbEmails", new[] { "DbAuthorisedUserId" });
            DropPrimaryKey("dbo.AuthorisedUserMusicGenres");
            DropPrimaryKey("dbo.AuthorisedUserGenres");
            DropPrimaryKey("dbo.AuthorisedUsers");
            AlterColumn("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AuthorisedUserGenres", "AuthorisedUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.DbEmails", "DbAuthorisedUserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AuthorisedUserMusicGenres", new[] { "AuthorisedUserId", "MusicGenreId" });
            AddPrimaryKey("dbo.AuthorisedUserGenres", new[] { "AuthorisedUserId", "GenreId" });
            AddPrimaryKey("dbo.AuthorisedUsers", "DbUserId");
            CreateIndex("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId");
            CreateIndex("dbo.AuthorisedUserGenres", "AuthorisedUserId");
            CreateIndex("dbo.DbEmails", "DbAuthorisedUserId");
            AddForeignKey("dbo.AuthorisedUserMusicGenres", "AuthorisedUserId", "dbo.AuthorisedUsers", "DbUserId", cascadeDelete: true);
            AddForeignKey("dbo.AuthorisedUserGenres", "AuthorisedUserId", "dbo.AuthorisedUsers", "DbUserId", cascadeDelete: true);
            AddForeignKey("dbo.DbEmails", "DbAuthorisedUserId", "dbo.AuthorisedUsers", "DbUserId", cascadeDelete: true);
        }
    }
}
