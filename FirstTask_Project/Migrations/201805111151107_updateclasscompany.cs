namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateclasscompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Email", c => c.String());
            AddColumn("dbo.Companies", "Phoneno", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "ContactPerson", c => c.String());
            AddColumn("dbo.Companies", "CompanyURL", c => c.String());
            AddColumn("dbo.Companies", "Logo", c => c.String());
            AddColumn("dbo.Companies", "FacebookURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "FacebookURL");
            DropColumn("dbo.Companies", "Logo");
            DropColumn("dbo.Companies", "CompanyURL");
            DropColumn("dbo.Companies", "ContactPerson");
            DropColumn("dbo.Companies", "Phoneno");
            DropColumn("dbo.Companies", "Email");
        }
    }
}
