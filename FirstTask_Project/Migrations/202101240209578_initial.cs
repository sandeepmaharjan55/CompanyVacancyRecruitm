namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phoneno = c.Int(nullable: false),
                        ContactPerson = c.String(),
                        CompanyURL = c.String(),
                        Logo = c.String(),
                        FacebookURL = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        ExpYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        ExperienceId = c.Int(nullable: false),
                        Gender = c.String(),
                        Contactno = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Experiences", t => t.ExperienceId, cascadeDelete: true)
                .Index(t => t.ExperienceId);
            
            CreateTable(
                "dbo.PersonToSkills",
                c => new
                    {
                        PersonToSkillId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
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
                        Title = c.String(),
                        Description = c.String(),
                        RequestDate = c.DateTime(),
                        NumOfOpening = c.Int(nullable: false),
                        Deadline = c.DateTime(),
                        Exp = c.Int(nullable: false),
                        From = c.String(),
                        To = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
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
            DropForeignKey("dbo.People", "ExperienceId", "dbo.Experiences");
            DropIndex("dbo.RecruitmentRequests", new[] { "CompanyId" });
            DropIndex("dbo.PersonToSkills", new[] { "SkillId" });
            DropIndex("dbo.PersonToSkills", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "ExperienceId" });
            DropTable("dbo.RecruitmentRequests");
            DropTable("dbo.Skills");
            DropTable("dbo.PersonToSkills");
            DropTable("dbo.People");
            DropTable("dbo.Experiences");
            DropTable("dbo.Companies");
        }
    }
}
