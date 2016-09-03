using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinalWeb.Models
{
    public class PlaylistModel
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PlaylistId { get; set; }
        
         //[ForeignKey] //colocar como chave estrangeira        
        public string UsuarioId { get; set; }
        public string Titulo { get; set; }
        public bool Publica { get; set; }
        public bool Padrao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}