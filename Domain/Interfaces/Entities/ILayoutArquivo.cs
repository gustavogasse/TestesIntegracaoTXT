using System.ComponentModel.DataAnnotations;

namespace Domain.Interfaces.Entities
{
    public interface ILayoutArquivo
    {
        [Key]
        Guid Id { get; }
        DateTime DataDaOperacao { get; set; }
        string CodigoDoClienteOuCarteira { get; set; }
        string TipoDaOperacao { get; set; }
        string IdDaBolsa { get; set; }
        string CodigoDoAtivo { get; set; }
        string Corretora { get; set; }
        int Quantidade { get; set; }
        decimal PrecoUnitario { get; set; }
    }
}
