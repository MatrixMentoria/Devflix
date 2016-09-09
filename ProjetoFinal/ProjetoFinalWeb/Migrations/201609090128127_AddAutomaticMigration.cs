namespace ProjetoFinalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAutomaticMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayListFilmesModels", "FilmesId", c => c.Guid(nullable: false));
            DropColumn("dbo.PlayListFilmesModels", "IDdoFilme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayListFilmesModels", "IDdoFilme", c => c.String());
            DropColumn("dbo.PlayListFilmesModels", "FilmesId");
        }
    }
}
