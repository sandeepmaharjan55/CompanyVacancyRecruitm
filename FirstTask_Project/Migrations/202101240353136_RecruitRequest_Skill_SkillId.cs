namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecruitRequest_Skill_SkillId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecruitmentRequests", "SkillId", c => c.Int());
            CreateIndex("dbo.RecruitmentRequests", "SkillId");
            AddForeignKey("dbo.RecruitmentRequests", "SkillId", "dbo.Skills", "SkillId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecruitmentRequests", "SkillId", "dbo.Skills");
            DropIndex("dbo.RecruitmentRequests", new[] { "SkillId" });
            DropColumn("dbo.RecruitmentRequests", "SkillId");
        }
    }
}
