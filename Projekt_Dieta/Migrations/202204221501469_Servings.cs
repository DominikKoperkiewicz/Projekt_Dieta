namespace Projekt_Dieta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Servings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "Servings", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entries", "Servings");
        }
    }
}
