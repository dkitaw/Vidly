namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id,Name) values (1,'Action')");
            Sql("Insert into Genres (Id,Name) values (2,'Thriller')");
            Sql("Insert into Genres (Id,Name) values (3,'Family')");
            Sql("Insert into Genres (Id,Name) values (4,'Romance')");
            Sql("Insert into Genres (Id,Name) values (5,'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
