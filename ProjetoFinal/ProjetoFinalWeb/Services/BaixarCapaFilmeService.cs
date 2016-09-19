using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using ProjetoFinalWeb.Services;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Models
{
    /// <summary>
    /// Classe de serviço utilizada para baixar a capa do filme buscado e salvar no banco de dados. 
    /// </summary>
    public class BaixarCapaFilmeService
    {
        private void GravarCapa(WebResponse response, string path)
        {
            byte[] imageBytes;
            Stream responseStream = response.GetResponseStream();

            using (BinaryReader br = new BinaryReader(responseStream))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            response.Close();

            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }

        private WebResponse BaixarCapa(FilmesModel filme)
        {
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(filme.Poster);
            return imageRequest.GetResponse();
        }

        public async Task PegarCapa(string tituloFilme)
        {
            FilmesModel filme = await new OMDService().ObterFilmePorNomeComDetalhe(tituloFilme);
            await PegarCapa(filme);
        }

        public async Task PegarCapa(FilmesModel filme)
        {
            String appData = HttpContext.Current.ApplicationInstance.Server.MapPath("~/Content/FilmeImages");
            Directory.CreateDirectory(appData);
            string path = string.Format("{0}/{1}.jpg", appData, filme.imdbID);

            if (!File.Exists(path) && filme.Poster != "N/A")
            {
                var capaResponse = BaixarCapa(filme);
                GravarCapa(capaResponse, path);
            }
        }
    }
}