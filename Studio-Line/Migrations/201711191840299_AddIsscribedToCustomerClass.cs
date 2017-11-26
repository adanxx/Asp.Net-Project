namespace Studio_Line.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsscribedToCustomerClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubcriptedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubcriptedToNewsLetter");
        }
    }
}
