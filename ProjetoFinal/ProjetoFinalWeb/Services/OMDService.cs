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
    /// Classe de serviço com a chave da API OMD autorizada para buscar filmes no IMDB.
    /// </summary>
    public class OMDService
    {
        private List<FilmesModel> itens;
        private readonly string BASE_URI = "http://www.omdbapi.com/?s={0}&type=movie";
        private readonly string BASE_URI_DETALHES = "http://www.omdbapi.com/?t={0}&type=movie&y=&plot=short&r=json";

        public async Task<FilmesModel> ObterFilmePorNomeComDetalhe(string nome)
        {
            string url = string.Format(BASE_URI_DETALHES, nome);

            HttpClient http = new HttpClient();
            try
            {
                var json = await http.GetStringAsync(url);                
                return  JsonConvert.DeserializeObject<FilmesModel>(json);
                
            }
            catch (WebException)
            {
                return null;
            }
        }

        public async Task<List<FilmesModel>> ObterFilmesPorNome(string nome)
        {
            string url = string.Format(BASE_URI, nome);

                HttpClient http = new HttpClient();
            try
            {
                var json = await http.GetStringAsync(url);
                var result = JObject.Parse(json);
                bool status;

                bool.TryParse(result.GetValue("Response").ToString(), out status);

                if (status)
                    itens = JsonConvert.DeserializeObject<List<FilmesModel>>(result.GetValue("Search").ToString());
                else
                    itens = new List<FilmesModel>();
            }
            catch(WebException)
            {
                itens = new List<FilmesModel>();
            }
            return itens;
        }
    }
}