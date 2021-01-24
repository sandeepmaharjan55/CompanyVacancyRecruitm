namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recruitreq_skillid_notnull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecruitmentRequests", "SkillId", "dbo.Skills");
            DropIndex("dbo.RecruitmentRequests", new[] { "SkillId" });
            AlterColumn("dbo.RecruitmentRequests", "SkillId", c => c.Int(nullable: false));
            CreateIndex("dbo.RecruitmentRequests", "SkillId");
            AddForeignKey("dbo.RecruitmentRequests", "SkillId", "dbo.Skills", "SkillId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecruitmentRequests", "SkillId", "dbo.Skills");
            DropIndex("dbo.RecruitmentRequests", new[] { "SkillId" });
            AlterColumn("dbo.RecruitmentRequests", "SkillId", c => c.Int());
            CreateIndex("dbo.RecruitmentRequests", "SkillId");
            AddForeignKey("dbo.RecruitmentRequests", "SkillId", "dbo.Skills", "SkillId");
        }
    }
}
