using Domain.Interfaces.Entities;
using Domain.Validations;

namespace Domain.Entities
{
    public class ArquivoEntrada : EntitiesValidation, IArquivoEntrada
    {
        public ArquivoEntrada(DateTime dataDaOperacao, string codigoDoClienteOuCarteira, string tipoDaOperacao, string idDaBolsa, string codigoDoAtivo, string corretora, int quantidade, decimal precoUnitario)
        {
            Id = Guid.NewGuid();
            DataDaOperacao = dataDaOperacao;
            CodigoDoClienteOuCarteira = codigoDoClienteOuCarteira;
            TipoDaOperacao = tipoDaOperacao;
            IdDaBolsa = idDaBolsa;
            CodigoDoAtivo = codigoDoAtivo;
            Corretora = corretora;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;

            ResultadosDaValidacao = new ArquivoEntradaValidation().Validate(this);
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

        public override bool IsValid()
        {
            return ResultadosDaValidacao.IsValid;
        }        
    }
}
