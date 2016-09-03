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
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // permite que crie a chave primaria no lugar da auto-geração.
        public int Id { get; set; }
      //  [ForeignKey] colocar como chave estrangeira
        public string UserId { get; set; }
        public string Nome { get; set; }
        public bool Privada { get; set; }
        public bool Padrao { get; set; }


    }
}