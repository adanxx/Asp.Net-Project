namespace Studio_Line.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdAndDataTimeToMagasinModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Magasins", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Magasins", new[] { "genre_Id" });
            RenameColumn(table: "dbo.Magasins", name: "genre_Id", newName: "GenreId");
            AddColumn("dbo.Magasins", "RealeaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Magasins", "DataAdd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Magasins", "InStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Magasins", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Magasins", "GenreId");
            AddForeignKey("dbo.Magasins", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Magasins", "GenreId", "dbo.Genres");
            DropIndex("dbo.Magasins", new[] { "GenreId" });
            AlterColumn("dbo.Magasins", "GenreId", c => c.Byte());
            DropColumn("dbo.Magasins", "InStock");
            DropColumn("dbo.Magasins", "DataAdd");
            DropColumn("dbo.Magasins", "RealeaseDate");
            RenameColumn(table: "dbo.Magasins", name: "GenreId", newName: "genre_Id");
            CreateIndex("dbo.Magasins", "genre_Id");
            AddForeignKey("dbo.Magasins", "genre_Id", "dbo.Genres", "Id");
        }
    }
}
