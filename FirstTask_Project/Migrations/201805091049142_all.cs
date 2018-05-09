namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ExpId = c.Int(nullable: false),
                        Experience_ExperienceId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Experiences", t => t.Experience_ExperienceId)
                .Index(t => t.Experience_ExperienceId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        ExpYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceId);
            
            CreateTable(
                "dbo.PersonToSkills",
                c => new
                    {
                        PersonToSkillId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                        ExperienceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonToSkillId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Skills = c.String(),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.RecruitmentRequests",
                c => new
                    {
                        RecruitId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        RequestDate = c.DateTime(),
                        NumOfOpening = c.Int(nullable: false),
                        Deadline = c.DateTime(),
                        ExpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecruitId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecruitmentRequests", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.PersonToSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.PersonToSkills", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "Experience_ExperienceId", "dbo.Experiences");
            DropIndex("dbo.RecruitmentRequests", new[] { "CompanyId" });
            DropIndex("dbo.PersonToSkills", new[] { "SkillId" });
            DropIndex("dbo.PersonToSkills", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "Experience_ExperienceId" });
            DropTable("dbo.RecruitmentRequests");
            DropTable("dbo.Skills");
            DropTable("dbo.PersonToSkills");
            DropTable("dbo.Experiences");
            DropTable("dbo.People");
            DropTable("dbo.Companies");
        }
    }
}
