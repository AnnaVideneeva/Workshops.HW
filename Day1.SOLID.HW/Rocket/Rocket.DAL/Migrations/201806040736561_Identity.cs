namespace Rocket.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersRoles", "RoleId", "dbo.t_role");
            DropIndex("dbo.UsersRoles", new[] { "UserId" });
            DropIndex("dbo.UsersRoles", new[] { "RoleId" });
            CreateTable(
                "dbo.t_user_claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.t_user_logins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.t_users_roles",
                c => new
                    {
                        UserRole_id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRole_id)
                .ForeignKey("dbo.t_role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Users", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserName", c => c.String());
            DropTable("dbo.UsersRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            DropForeignKey("dbo.t_users_roles", "UserId", "dbo.Users");
            DropForeignKey("dbo.t_users_roles", "RoleId", "dbo.t_role");
            DropForeignKey("dbo.t_user_logins", "UserId", "dbo.Users");
            DropForeignKey("dbo.t_user_claims", "UserId", "dbo.Users");
            DropIndex("dbo.t_users_roles", new[] { "RoleId" });
            DropIndex("dbo.t_users_roles", new[] { "UserId" });
            DropIndex("dbo.t_user_logins", new[] { "UserId" });
            DropIndex("dbo.t_user_claims", new[] { "UserId" });
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "AccessFailedCount");
            DropColumn("dbo.Users", "LockoutEnabled");
            DropColumn("dbo.Users", "LockoutEndDateUtc");
            DropColumn("dbo.Users", "TwoFactorEnabled");
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "SecurityStamp");
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "Email");
            DropTable("dbo.t_users_roles");
            DropTable("dbo.t_user_logins");
            DropTable("dbo.t_user_claims");
            CreateIndex("dbo.UsersRoles", "RoleId");
            CreateIndex("dbo.UsersRoles", "UserId");
            AddForeignKey("dbo.UsersRoles", "RoleId", "dbo.t_role", "role_id", cascadeDelete: true);
            AddForeignKey("dbo.UsersRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
