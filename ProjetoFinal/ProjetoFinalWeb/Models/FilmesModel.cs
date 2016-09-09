using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinalWeb.Models
{
    public class FilmesModel
    {
        //public string Title { get; set; }
        //public string Year { get; set; }
        //public string imdbID { get; set; }
        //public string Type { get; set; }
        //public string Poster { get; set; }
        public string Response { get; set; }

        // MODEL PARA API QUE RETORNA 1 FILME
        public string Title { get; set; } //ok
        public string Year { get; set; }   //ok
        public string Rated { get; set; }
        public string Released { get; set; } //ok
        public string Runtime { get; set; } //ok
        public string Genre { get; set; }  //ok
        public string Director { get; set; } //ok
        public string Writer { get; set; } //ok
        public string Actors { get; set; } //ok
        public string Plot { get; set; } //ok
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; } //ok
        public string Type { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FilmesId { get; set; }

    }
}