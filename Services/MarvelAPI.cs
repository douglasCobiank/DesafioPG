using DesafioPG.Services.Interfaces;
using System.IO;
using System.Net;

namespace DesafioPG.Services
{
    public class MarvelAPI: IMarvelAPI
    {
        public string ListaPersonagens()
        {
            string response = "";
            var rest = WebRequest.CreateHttp("http://gateway.marvel.com/v1/public/characters?ts=1&apikey=473da253b3977826288936c4a61c0991&hash=8be15a064f1557728066139e0619aaf6");
            rest.Method = "GET";
            using (var resposta = rest.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                response = reader.ReadToEnd();
                streamDados.Close();
                resposta.Close();
            }

            return response;
        }
    }
}
