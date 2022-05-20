using Domain.Entities;
using FluentValidation;

namespace Domain.Validations
{
    public class ArquivoEntradaValidation : AbstractValidator<ArquivoEntrada>
    {
        public ArquivoEntradaValidation()
        {
            RuleFor(c => c.CodigoDoClienteOuCarteira)
                .Must(c => c.Equals("CARTEIRA CLIENTE A") || c.Equals("CARTEIRA CLIENTE B") || c.Equals("CARTEIRA CLIENTE C"))
                .WithMessage("Cliente inválido/inexistente");

            RuleFor(c => c.TipoDaOperacao)
                .Must(c => c.Equals("Compra") || c.Equals("Venda"))
                .WithMessage("Operação inválida");

            RuleFor(c => c.IdDaBolsa)
                .Equal("BVSP")
                .WithMessage("Id de Bolsa inválido");

            RuleFor(c => c.CodigoDoAtivo)
                .Must(c => c.Equals("PETR4") || c.Equals("VALE3"))
                .WithMessage("Código do Ativo inválido");

            RuleFor(c => c.Corretora)
                .Equal("AGORA")
                .WithMessage("Código de Corretora inválido");

            RuleFor(c => c.Quantidade)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantidade não pode ser negativo");

            RuleFor(c => c.PrecoUnitario)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Preço unitário não pode ser negativo");
        }
    }
}
