namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinPerson1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Experience_ExperienceId", "dbo.Experiences");
            DropIndex("dbo.People", new[] { "Experience_ExperienceId" });
            RenameColumn(table: "dbo.People", name: "Experience_ExperienceId", newName: "ExperienceId");
            AddColumn("dbo.People", "Email", c => c.String());
            AlterColumn("dbo.People", "ExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "ExperienceId");
            AddForeignKey("dbo.People", "ExperienceId", "dbo.Experiences", "ExperienceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "ExperienceId", "dbo.Experiences");
            DropIndex("dbo.People", new[] { "ExperienceId" });
            AlterColumn("dbo.People", "ExperienceId", c => c.Int());
            DropColumn("dbo.People", "Email");
            RenameColumn(table: "dbo.People", name: "ExperienceId", newName: "Experience_ExperienceId");
            CreateIndex("dbo.People", "Experience_ExperienceId");
            AddForeignKey("dbo.People", "Experience_ExperienceId", "dbo.Experiences", "ExperienceId");
        }
    }
}
