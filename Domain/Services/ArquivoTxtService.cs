using Domain.DTO;
using Domain.Extensions;

namespace Domain.Services
{
    public static class ArquivoTxtService
    {
        public static List<ArquivoEntradaDTO> Ler(string caminhoArquivo = null)
        {
            if (string.IsNullOrEmpty(caminhoArquivo))
                caminhoArquivo = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent + "\\caseUploadBoletosRV-ArquivoBoletoExemplo.txt";

            List<ArquivoEntradaDTO> arquivosEntradaDTO = new List<ArquivoEntradaDTO>();

            var lines = File.ReadLines(caminhoArquivo);

            foreach (var line in lines)
            {
                if (!(line.IsHeader() || line.IsFooter()))
                {
                    var registros = line.Split('#');

                    arquivosEntradaDTO.Add(new ArquivoEntradaDTO()
                    {
                        DataDaOperacao = registros[1].ConvertToDateTime(),
                        CodigoDoClienteOuCarteira = registros[2],
                        TipoDaOperacao = registros[3],
                        IdDaBolsa = registros[4],
                        CodigoDoAtivo = registros[5],
                        Corretora = registros[6],
                        Quantidade = registros[7].ConvertToInteger(),
                        PrecoUnitario = registros[8].ConvertToDecimal()
                    });
                }
            }

            return arquivosEntradaDTO;
        }
    }
}
