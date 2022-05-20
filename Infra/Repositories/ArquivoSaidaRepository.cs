using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Repositories
{
    public class ArquivoSaidaRepository : IArquivoRepository
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
    }
}
