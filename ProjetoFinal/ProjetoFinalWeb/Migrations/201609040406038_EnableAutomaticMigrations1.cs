namespace ProjetoFinalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableAutomaticMigrations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlaylistModels", "Titulo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlaylistModels", "Titulo", c => c.String());
        }
    }
}
