namespace Studio_Line.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGenreModelAndToMagasinModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Magasins", "genre_Id", c => c.Byte());
            CreateIndex("dbo.Magasins", "genre_Id");
            AddForeignKey("dbo.Magasins", "genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Magasins", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Magasins", new[] { "genre_Id" });
            DropColumn("dbo.Magasins", "genre_Id");
            DropTable("dbo.Genres");
        }
    }
}
