using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinalWeb.Models
{
    public class FilmesPlaylistViewModel
    {
        public Guid id { get; set; }
        public string ImdbId { get; set; }
        public Guid PlayListID { get; set; }
        public Guid FilmesId { get; set; }

        public string UsuarioID { get; set; }
        [Display(Name = "Título")]
        public string FilmeTitulo { get; set; }
        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }
    }
}