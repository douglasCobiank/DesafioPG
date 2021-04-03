using System.Collections.Generic;

namespace DesafioPG.Services.Dto
{
    public class DadosArquivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Quadrinhos { get; set; }
        public List<string> Serie { get; set; }
        public List<string> Historias { get; set; }
        public List<string> Eventos { get; set; }
    }
}
