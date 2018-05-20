namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertoskillmodelchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Username", c => c.String());
            AddColumn("dbo.People", "Password", c => c.String());
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        LastLogin = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.People", "Password");
            DropColumn("dbo.People", "Username");
        }
    }
}
