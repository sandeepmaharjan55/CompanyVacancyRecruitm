namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sendmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecruitmentRequests", "From", c => c.String());
            AddColumn("dbo.RecruitmentRequests", "To", c => c.String());
            AddColumn("dbo.RecruitmentRequests", "Subject", c => c.String());
            AddColumn("dbo.RecruitmentRequests", "Body", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecruitmentRequests", "Body");
            DropColumn("dbo.RecruitmentRequests", "Subject");
            DropColumn("dbo.RecruitmentRequests", "To");
            DropColumn("dbo.RecruitmentRequests", "From");
        }
    }
}
