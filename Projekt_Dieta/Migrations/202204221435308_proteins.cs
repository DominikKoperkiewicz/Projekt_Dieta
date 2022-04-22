namespace Projekt_Dieta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proteins : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "Protein", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entries", "Protein");
        }
    }
}
