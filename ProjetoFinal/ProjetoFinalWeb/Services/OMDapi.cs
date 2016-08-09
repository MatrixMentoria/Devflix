using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinalWeb.Services
{
    public class RottenTomatoes
    {
        public string getFilmesPorNome(string nome)
        {
                HttpClient filmeNome = new HttpClient();
                var resultado = filmeNome.GetStringAsync("http://www.omdbapi.com/?r=json&t=" + nome).Result;
                return resultado;       
        }

        /*public string getFilmesPorNomeeAno(string nome, int ano)
        {
            HttpClient filmePesquisaCompleta = new HttpClient();
            var resultado = filmePesquisaCompleta.GetStringAsync("http://www.omdbapi.com/?t="+nome+"&y="+ano+"&r=json").Result;
            return resultado;
        }*/
    }
}