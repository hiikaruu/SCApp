namespace SCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class o : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollees", "Subject", c => c.String(maxLength: 2147483647));
            AddColumn("dbo.Enrollees", "Disability", c => c.String(maxLength: 2147483647));
            AddColumn("dbo.Enrollees", "Ward", c => c.String(maxLength: 2147483647));
            AddColumn("dbo.Enrollees", "Certificate", c => c.String(maxLength: 2147483647));
            AddColumn("dbo.Enrollees", "Enrollment", c => c.String(maxLength: 2147483647));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollees", "Enrollment");
            DropColumn("dbo.Enrollees", "Certificate");
            DropColumn("dbo.Enrollees", "Ward");
            DropColumn("dbo.Enrollees", "Disability");
            DropColumn("dbo.Enrollees", "Subject");
        }
    }
}
