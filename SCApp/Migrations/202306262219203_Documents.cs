namespace SCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Documents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollees", "WardDoc", c => c.Binary());
            AddColumn("dbo.Enrollees", "DisabilityDoc", c => c.Binary());
            AddColumn("dbo.Enrollees", "CertificateDoc", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollees", "CertificateDoc");
            DropColumn("dbo.Enrollees", "DisabilityDoc");
            DropColumn("dbo.Enrollees", "WardDoc");
        }
    }
}
