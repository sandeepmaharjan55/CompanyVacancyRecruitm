namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusermodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Username");
            DropColumn("dbo.People", "Password");
            DropColumn("dbo.People", "CreatedDate");
            DropColumn("dbo.People", "ModifiedDate");
            DropColumn("dbo.People", "LastLogin");
            DropColumn("dbo.People", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "LastLogin", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.People", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "Password", c => c.String());
            AddColumn("dbo.People", "Username", c => c.String());
        }
    }
}
