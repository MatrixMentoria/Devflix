using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoFinalWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinalWeb.Services
{
    /// <summary>
    /// http://img.omdbapi.com/?i=tt2294629&apikey=35652245
    /// Passar a utilizar essa chave a partir de amanhã.
    /// Eu fiz o cadastro no site pra ter uma chave
    /// ------  API que retorna 1 filme apenas
    /// ------  string url = "http://www.omdbapi.com/?t=" + nome + "&y=&plot=short&r=json";
    /// </summary>
    public class OMDService
    {
        private List<FilmesModel> itens;
        private readonly string BASE_URI = "http://www.omdbapi.com/?s={0}&type=movie";

        public async Task<List<FilmesModel>> ObterFilmesPorNome(string nome)
        {
            string url = string.Format(BASE_URI, nome);

            System.Net.Http.HttpClient http = new System.Net.Http.HttpClient();
            var json = await http.GetStringAsync(url);
            var result = JObject.Parse(json);
            itens = JsonConvert.DeserializeObject<List<FilmesModel>>(result.GetValue("Search").ToString());
            
            return itens;            
        }
    }
}