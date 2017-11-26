namespace Studio_Line.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES(1,'Historical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(2,'News')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(3,'Entertainment')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(4,'Science And Medicins')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(5,'Ficitonal Journal')");
        }
        
        public override void Down()
        {
        }
    }
}
