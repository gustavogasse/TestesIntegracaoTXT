namespace Domain.Interfaces.Entities
{
    public interface IArquivoSaida : ILayoutArquivo
    {
        decimal ValorFinanceiroDaOperacao { get; set; }
        decimal ValorDescontoDaOperacao { get; set; }
        string StatusDoBoleto { get; set; }
        string MensagemEmCasoDeErro { get; set; }
    }
}
