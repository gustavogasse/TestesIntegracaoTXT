using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IArquivoSaidaRepository
    {
        IEnumerable<ArquivoSaida> ListarTodos();
        IEnumerable<ArquivoSaida> ListarTodosValidos();
        IEnumerable<ArquivoSaida> ListarTodosComErro();
        IEnumerable<ArquivoSaida> ListarPorCliente(string codigoCliente);
        void Adicionar(ArquivoSaida arquivo);
        void AdicionarEmLote(IEnumerable<ArquivoSaida> arquivos);
    }
}
