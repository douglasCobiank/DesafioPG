using DesafioPG.Models;

namespace DesafioPG.Services.Interfaces
{
    interface IMarvelWrapper
    {
        Marvel ConsultarPersonagens();
        void EscreverArquivo(Marvel marvel);
    }
}
