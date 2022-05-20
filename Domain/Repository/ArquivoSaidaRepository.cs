using Domain.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Repository
{
    public class ArquivoSaidaRepository : IArquivoSaidaRepository
    {
        private readonly DataContext _context;
        public ArquivoSaidaRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetService<DataContext>();
        }

        public void AdicionarEmLote(IEnumerable<ArquivoSaida> arquivos)
        {
            foreach (var arquivo in arquivos)
            {
                _context.ArquivosSaida.Add(arquivo);
            }
            _context.SaveChanges();
        }

        public void Adicionar(ArquivoSaida arquivo)
        {
            _context.ArquivosSaida.Add(arquivo);
            _context.SaveChanges();
        }

        public IEnumerable<ArquivoSaida> ListarPorCliente(string codigoCliente)
        {
            return _context.ArquivosSaida.Where(c => c.CodigoDoClienteOuCarteira.Equals(codigoCliente)).ToList();
        }

        public IEnumerable<ArquivoSaida> ListarTodos()
        {
            return _context.ArquivosSaida.ToList();
        }

        public IEnumerable<ArquivoSaida> ListarTodosValidos()
        {
            return ListarTodos().Where(c => c.IsValid);
        }

        public IEnumerable<ArquivoSaida> ListarTodosComErro()
        {
            return ListarTodos().Where(c => !c.IsValid);
        }
    }
}
