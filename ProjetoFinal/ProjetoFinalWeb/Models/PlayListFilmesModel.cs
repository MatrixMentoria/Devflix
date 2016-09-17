using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinalWeb.Models
{
    /// <summary>
    /// Model da Playlist criada pelo usuário.
    /// </summary>
    public class PlayListFilmesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid PlayListID { get; set; }
        public Guid FilmesId { get; set; }

        public string UsuarioID { get; set; }
        public string FilmeTitulo { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}