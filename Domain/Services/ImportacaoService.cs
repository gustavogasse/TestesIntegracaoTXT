using Domain.Interfaces.Repository;

namespace Domain.Services
{
    public class ImportacaoService
    {
        public void Executar(IArquivoSaidaRepository repository, string caminhoArquivo = null)
        {
            var service = new ArquivoSaidaService(repository, ArquivoTxtService.Ler(caminhoArquivo));
            service.Importar(out int quantidadeValidados, out int quantidadeComErro);
            if ((quantidadeValidados + quantidadeComErro) > 0)
                service.Gravar();
        }
    }
}
