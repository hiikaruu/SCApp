namespace SCApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initEnrollee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollees",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Surname = c.String(nullable: false, maxLength: 2147483647,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "UniqueAttribute",
                                    new AnnotationValues(oldValue: null, newValue: "SQLite.CodeFirst.UniqueAttribute")
                                },
                            }),
                        Name = c.String(maxLength: 2147483647),
                        Patronymic = c.String(maxLength: 2147483647),
                        DtBirth = c.String(maxLength: 2147483647),
                        FullYear = c.String(maxLength: 2147483647),
                        Gender = c.String(maxLength: 2147483647),
                        Сitizenship = c.String(maxLength: 2147483647),
                        Region = c.String(maxLength: 2147483647),
                        Class = c.String(maxLength: 2147483647),
                        Score = c.String(maxLength: 2147483647),
                        Snils = c.String(maxLength: 2147483647),
                        Education = c.String(maxLength: 2147483647),
                        Speciality = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Enrollees",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Surname",
                        new Dictionary<string, object>
                        {
                            { "UniqueAttribute", "SQLite.CodeFirst.UniqueAttribute" },
                        }
                    },
                });
        }
    }
}
