using Domain.Interfaces.Entities;
using Domain.Interfaces.Repository;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("IntegracaoTXT")]
    public class ImportacaoController : Controller
    {
        private readonly IArquivoSaidaRepository repository;

        public ImportacaoController(IServiceProvider service)
        {
            repository = service.GetRequiredService<IArquivoSaidaRepository>();
        }

        [HttpGet("GetAll")]
        public IEnumerable<IArquivoSaida> GetAll()
        {
            return repository.ListarTodos();
        }

        [HttpGet("GetAllValidos")]
        public IEnumerable<IArquivoSaida> GetAllValidos()
        {
            return repository.ListarTodosValidos();
        }

        [HttpGet("GetAllComErro")]
        public IEnumerable<IArquivoSaida> GetAllComErro()
        {
            return repository.ListarTodosComErro();
        }

        [HttpGet("Get")]
        public IEnumerable<IArquivoSaida> Get(string codigoCliente)
        {
            return repository.ListarPorCliente(codigoCliente);
        }

        [HttpPost("")]
        public void Post(string caminhoArquivo)
        {
            var importacaoService = new ImportacaoService();
            importacaoService.Executar(repository, caminhoArquivo);
        }
    }
}
