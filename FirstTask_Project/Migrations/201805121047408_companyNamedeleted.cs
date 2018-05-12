namespace FirstTask_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyNamedeleted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false));
        }
    }
}
