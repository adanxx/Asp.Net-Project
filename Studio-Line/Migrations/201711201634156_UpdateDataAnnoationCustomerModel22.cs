namespace Studio_Line.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataAnnoationCustomerModel22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Magasins", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Magasins", "Name", c => c.String(nullable: false));
        }
    }
}
