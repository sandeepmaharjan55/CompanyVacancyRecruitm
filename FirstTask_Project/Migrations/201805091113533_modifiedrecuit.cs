namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedrecuit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RecruitmentRequests", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecruitmentRequests", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
