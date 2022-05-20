using Domain.Entities;

namespace Domain.DTO
{
    public class ArquivoEntradaDTO
    {
        public DateTime DataDaOperacao { get; set; }
        public string CodigoDoClienteOuCarteira { get; set; }
        public string TipoDaOperacao { get; set; }
        public string IdDaBolsa { get; set; }
        public string CodigoDoAtivo { get; set; }
        public string Corretora { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public ArquivoEntrada ToArquivoEntrada()
        {
            return new ArquivoEntrada(DataDaOperacao,
                CodigoDoClienteOuCarteira,
                TipoDaOperacao,
                IdDaBolsa,
                CodigoDoAtivo,
                Corretora,
                Quantidade,
                PrecoUnitario);
        }
    }
}