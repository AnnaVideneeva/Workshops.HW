namespace Rocket.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDetail : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DbRoles", newName: "t_role");
            RenameTable(name: "dbo.DbPermissions", newName: "t_permission");
            RenameTable(name: "dbo.DbPermissionDbRoles", newName: "DbRoleDbPermissions");
            RenameColumn(table: "dbo.t_role", name: "Id", newName: "role_id");
            RenameColumn(table: "dbo.t_permission", name: "Id", newName: "permission_id");
            RenameColumn(table: "dbo.t_permission", name: "ValueName", newName: "value_name");
            DropPrimaryKey("dbo.DbRoleDbPermissions");
            AddColumn("dbo.t_role", "DbPermission_Id", c => c.Int());
            AlterColumn("dbo.t_role", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_permission", "value_name", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.DbRoleDbPermissions", new[] { "DbRole_Id", "DbPermission_Id" });
            CreateIndex("dbo.t_role", "DbPermission_Id");
            AddForeignKey("dbo.t_role", "DbPermission_Id", "dbo.t_permission", "permission_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_role", "DbPermission_Id", "dbo.t_permission");
            DropIndex("dbo.t_role", new[] { "DbPermission_Id" });
            DropPrimaryKey("dbo.DbRoleDbPermissions");
            AlterColumn("dbo.t_permission", "value_name", c => c.String());
            AlterColumn("dbo.t_role", "name", c => c.String());
            DropColumn("dbo.t_role", "DbPermission_Id");
            AddPrimaryKey("dbo.DbRoleDbPermissions", new[] { "DbPermission_Id", "DbRole_Id" });
            RenameColumn(table: "dbo.t_permission", name: "value_name", newName: "ValueName");
            RenameColumn(table: "dbo.t_permission", name: "permission_id", newName: "Id");
            RenameColumn(table: "dbo.t_role", name: "role_id", newName: "Id");
            RenameTable(name: "dbo.DbRoleDbPermissions", newName: "DbPermissionDbRoles");
            RenameTable(name: "dbo.t_permission", newName: "DbPermissions");
            RenameTable(name: "dbo.t_role", newName: "DbRoles");
        }
    }
}
