namespace SCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollees", "Year", c => c.String(maxLength: 2147483647));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollees", "Year");
        }
    }
}
