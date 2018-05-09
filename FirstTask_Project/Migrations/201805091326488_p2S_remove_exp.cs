namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p2S_remove_exp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PersonToSkills", "ExperienceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonToSkills", "ExperienceId", c => c.Int(nullable: false));
        }
    }
}
