using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinalWeb.Models
{
    /// <summary>
    /// Model da Playlist do banco de dados.
    /// </summary>
    public class PlaylistModel
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PlayListId { get; set; }
        
         //[ForeignKey] //colocar como chave estrangeira        
        public string UsuarioId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório, digite o titulo de sua playlist")]
        public string Titulo { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório, defina se a playlist será pública ou não")]
        public bool Publica { get; set; }

        public bool Padrao { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }
    }
}