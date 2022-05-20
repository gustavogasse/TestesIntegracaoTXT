using Domain.Extensions;
using Domain.Interfaces.Entities;
using System.Text;

namespace Domain.Entities
{
    public class ArquivoSaida : IArquivoSaida
    {
        protected ArquivoSaida()
        {

        }

        public ArquivoSaida(ArquivoEntrada arquivo)
        {
            Id = Guid.NewGuid();
            DataDaOperacao = arquivo.DataDaOperacao;
            CodigoDoClienteOuCarteira = arquivo.CodigoDoClienteOuCarteira;
            TipoDaOperacao = arquivo.TipoDaOperacao;
            IdDaBolsa = arquivo.IdDaBolsa;
            CodigoDoAtivo = arquivo.CodigoDoAtivo;
            Corretora = arquivo.Corretora;
            Quantidade = arquivo.Quantidade;
            PrecoUnitario = arquivo.PrecoUnitario;
            ValorFinanceiroDaOperacao = Quantidade * PrecoUnitario;
            StatusDoBoleto = arquivo.IsValid() ? "OK" : "ERRO";

            MensagemEmCasoDeErro = string.Empty;
            var mensagemErroStrBdr = new StringBuilder();
            foreach (var mensagem in arquivo.ResultadosDaValidacao.Errors)
            {
                mensagemErroStrBdr.AppendLine(mensagem.ErrorMessage);
            }
            MensagemEmCasoDeErro = mensagemErroStrBdr.ToString();
        }

        public Guid Id { get; set; }
        public DateTime DataDaOperacao { get; set; }
        public string CodigoDoClienteOuCarteira { get; set; }
        public string TipoDaOperacao { get; set; }
        public string IdDaBolsa { get; set; }
        public string CodigoDoAtivo { get; set; }
        public string Corretora { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorFinanceiroDaOperacao { get; set; }
        public decimal ValorDescontoDaOperacao { get; set; }
        public string StatusDoBoleto { get; set; }
        public string MensagemEmCasoDeErro { get; set; }
        public bool IsValid => this.StatusDoBoleto.EhIgual("OK");        

        public void CalcularValorDescontoDaOperacao()
        {
            this.ValorDescontoDaOperacao = this.ValorFinanceiroDaOperacao * 10 / 100;
        }
    }
}
