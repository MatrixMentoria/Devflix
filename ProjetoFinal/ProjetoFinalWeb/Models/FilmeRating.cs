using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinalWeb.Models
{
    public class FilmeRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FilmeRatingId { get; set; }
                
        [ForeignKey("FilmeId")]
        public FilmesModel Filme { get; set; }
        public Guid FilmeId { get; set; }

        [ForeignKey("UsuarioId")]
        public ApplicationUser Usuario { get; set; }
        public string UsuarioId { get; set; }

        public DateTime DataDeAvaliacao { get; set; }

        public Stars Rate { get; set; }
    }
}