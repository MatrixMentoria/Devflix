using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ProjetoFinalWeb.Services
{
    /// <summary>
    /// Essa é uma classe de serviço e deve ser usada como exemplo.
    /// </summary>
    public class Sample
    {
        /// <summary>
        /// Esse é um método de exemplo escrito de forma simplificada.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetFilmsByName(string name)
        {   
            HttpClient http = new HttpClient();
            var result = http.GetStringAsync("http://url_da_api?name=" + name).Result;

            return result;
        }
    }
}