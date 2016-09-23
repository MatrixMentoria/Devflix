namespace ProjetoFinalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingFilmes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilmeRatings",
                c => new
                    {
                        FilmeRatingId = c.Guid(nullable: false, identity: true),
                        FilmeId = c.Guid(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        DataDeAvaliacao = c.DateTime(nullable: false),
                        Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmeRatingId)
                .ForeignKey("dbo.FilmesModels", t => t.FilmeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.FilmeId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmeRatings", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FilmeRatings", "FilmeId", "dbo.FilmesModels");
            DropIndex("dbo.FilmeRatings", new[] { "UsuarioId" });
            DropIndex("dbo.FilmeRatings", new[] { "FilmeId" });
            DropTable("dbo.FilmeRatings");
        }
    }
}
