namespace ProjetoFinalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableAutomaticMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayListFilmesModels",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        UsuarioID = c.String(),
                        PlayListID = c.Guid(nullable: false),
                        FilmeID = c.Guid(nullable: false),
                        FilmeTitulo = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlayListFilmesModels");
        }
    }
}
