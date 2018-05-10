namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Gender", c => c.String());
            AddColumn("dbo.People", "Contactno", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Contactno");
            DropColumn("dbo.People", "Gender");
        }
    }
}
