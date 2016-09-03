namespace ProjetoFinalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Playlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaylistModels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.String(),
                        Nome = c.String(),
                        Privada = c.Boolean(nullable: false),
                        Padrao = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlaylistModels");
        }
    }
}
