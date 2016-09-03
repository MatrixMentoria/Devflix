namespace ProjetoFinalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlaylistModelFields : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PlaylistModels");
            AddColumn("dbo.PlaylistModels", "PlaylistId", c => c.Guid(nullable: false, identity: true));
            AddColumn("dbo.PlaylistModels", "UsuarioId", c => c.String());
            AddColumn("dbo.PlaylistModels", "Titulo", c => c.String());
            AddColumn("dbo.PlaylistModels", "Publica", c => c.Boolean(nullable: false));
            AddColumn("dbo.PlaylistModels", "DataCriacao", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.PlaylistModels", "PlaylistId");
            DropColumn("dbo.PlaylistModels", "Id");
            DropColumn("dbo.PlaylistModels", "UserId");
            DropColumn("dbo.PlaylistModels", "Nome");
            DropColumn("dbo.PlaylistModels", "Privada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlaylistModels", "Privada", c => c.Boolean(nullable: false));
            AddColumn("dbo.PlaylistModels", "Nome", c => c.String());
            AddColumn("dbo.PlaylistModels", "UserId", c => c.String());
            AddColumn("dbo.PlaylistModels", "Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.PlaylistModels");
            DropColumn("dbo.PlaylistModels", "DataCriacao");
            DropColumn("dbo.PlaylistModels", "Publica");
            DropColumn("dbo.PlaylistModels", "Titulo");
            DropColumn("dbo.PlaylistModels", "UsuarioId");
            DropColumn("dbo.PlaylistModels", "PlaylistId");
            AddPrimaryKey("dbo.PlaylistModels", "Id");
        }
    }
}
