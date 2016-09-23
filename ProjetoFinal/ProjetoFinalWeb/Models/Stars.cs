using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinalWeb.Models
{
    public enum Stars
    {
        None = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public class StarsFilmeModel
    {
        public Stars Rate { get; set; }
        public Guid FilmeId { get; set; }
        public string Imdb { get; set; }        
    }
}