namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiednew : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "ExpId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "ExpId", c => c.Int(nullable: false));
        }
    }
}
