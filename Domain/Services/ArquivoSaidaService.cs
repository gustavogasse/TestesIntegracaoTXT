using Domain.DTO;
using Domain.Entities;
using Domain.Extensions;
using Domain.Interfaces.Repository;

namespace Domain.Services
{
    public class ArquivoSaidaService
    {
        private readonly IArquivoSaidaRepository _repository;
        private List<ArquivoEntrada> ArquivosEntrada;
        private List<ArquivoSaida> ArquivosSaida;

        public ArquivoSaidaService(IArquivoSaidaRepository repository, List<ArquivoEntradaDTO> arquivosEntrada)
        {
            _repository = repository;

            ArquivosEntrada = new List<ArquivoEntrada>();
            foreach (var item in arquivosEntrada)
            {
                ArquivosEntrada.Add(item.ToArquivoEntrada());
            }
        }

        public void Importar(out int quantidadeValidados, out int quantidadeComErro)
        {
            ArquivosSaida = new List<ArquivoSaida>();

            var registrosValidos = ArquivosEntrada.Where(c => c.IsValid());
            quantidadeValidados = registrosValidos.Count();
            var registrosInvalidos = ArquivosEntrada.Where(c => !c.IsValid());
            quantidadeComErro = registrosInvalidos.Count();

            foreach (var itemAgrupado in registrosValidos)
            {
                ArquivosSaida.Add(new ArquivoSaida(itemAgrupado));
            }

            var listaAgrupada =
                from registro in ArquivosSaida
                group registro by new
                {
                    registro.CodigoDoClienteOuCarteira,
                    registro.TipoDaOperacao
                }
                into r
                select new
                {
                    r.Key.CodigoDoClienteOuCarteira,
                    r.Key.TipoDaOperacao,
                    ValorFinanceiroDaOperacao = r.Max(a => a.ValorFinanceiroDaOperacao)
                };

            foreach (var item in listaAgrupada)
            {
                var registro = ArquivosSaida
                    .Find(c => c.CodigoDoClienteOuCarteira.EhIgual(item.CodigoDoClienteOuCarteira)
                        && c.TipoDaOperacao.EhIgual(item.TipoDaOperacao)
                        && c.ValorFinanceiroDaOperacao.Equals(item.ValorFinanceiroDaOperacao));

                if (registro != null)
                    registro.CalcularValorDescontoDaOperacao();
            }

            foreach (var itemAgrupado in registrosInvalidos)
            {
                ArquivosSaida.Add(new ArquivoSaida(itemAgrupado));
            }
        }

        public void Gravar()
        {
            _repository.AdicionarEmLote(ArquivosSaida);
        }
    }
}
