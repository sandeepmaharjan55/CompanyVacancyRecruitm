namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedrecuit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecruitmentRequests", "Exp", c => c.Int(nullable: false));
            DropColumn("dbo.RecruitmentRequests", "ExpId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecruitmentRequests", "ExpId", c => c.Int(nullable: false));
            DropColumn("dbo.RecruitmentRequests", "Exp");
        }
    }
}
