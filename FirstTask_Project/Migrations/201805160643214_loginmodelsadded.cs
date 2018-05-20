namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginmodelsadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Username", c => c.String());
            AddColumn("dbo.People", "Password", c => c.String());
            AddColumn("dbo.People", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.People", "LastLogin", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Status");
            DropColumn("dbo.People", "LastLogin");
            DropColumn("dbo.People", "ModifiedDate");
            DropColumn("dbo.People", "CreatedDate");
            DropColumn("dbo.People", "Password");
            DropColumn("dbo.People", "Username");
        }
    }
}
