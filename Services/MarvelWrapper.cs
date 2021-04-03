using DesafioPG.Models;
using DesafioPG.Services.Dto;
using DesafioPG.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace DesafioPG.Services
{
    public class MarvelWrapper: IMarvelWrapper
    {
        public Marvel ConsultarPersonagens()
        {
            var api = new MarvelAPI();
            return JsonConvert.DeserializeObject<Marvel>(api.ListaPersonagens());
        }

        public void EscreverArquivo(Marvel marvel)
        {
            string curDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString());

            StreamWriter writer = null;
            if (!File.Exists(curDir + @"\personagensmarvel.txt"))
                writer = File.CreateText(curDir + @"\personagensmarvel.txt");
            else
                writer = new StreamWriter(curDir + @"\personagensmarvel.txt");

            marvel.data.results.ForEach(c =>
            {
                var dadosArquivo = new DadosArquivo() 
                { 
                    Id = c.id,
                    Nome = c.name,
                    Descricao = c.description,
                    Quadrinhos = c.comics.items.Select(x => x.name).ToList(),
                    Serie = c.series.items.Select(x => x.name).ToList(),
                    Historias = c.stories.items.Select(x => x.name).ToList(),
                    Eventos = c.events.items.Select(x => x.name).ToList()
                };

                EscreveEmArquivo(writer, dadosArquivo);
            });

            writer.Close();
        }

        private void EscreveEmArquivo(StreamWriter writer, DadosArquivo dadosArquivo)
        {
            writer.WriteLine($"Id: {dadosArquivo.Id}, Nome: {dadosArquivo.Nome}");
            writer.WriteLine($"Descrição: {dadosArquivo.Descricao}");
            writer.WriteLine("\nLista de Quadrinhos:");
            dadosArquivo.Quadrinhos.ForEach(x =>
            {
                writer.WriteLine($" - {x}");
            });
            writer.WriteLine("\nLista de Series:");
            dadosArquivo.Serie.ForEach(x =>
            {
                writer.WriteLine($" - {x}");
            });
            writer.WriteLine("\nLista de Histórias:");
            dadosArquivo.Historias.ForEach(x =>
            {
                writer.WriteLine($" - {x}");
            });
            writer.WriteLine("\nLista de Eventos:");
            dadosArquivo.Eventos.ForEach(x =>
            {
                writer.WriteLine($" - {x}");
            });
            writer.WriteLine("====================================================================================");
        }
    }
}
