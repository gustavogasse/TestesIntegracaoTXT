using FluentValidation.Results;

namespace Domain.Validations
{
    public abstract class EntitiesValidation
    {
        public ValidationResult ResultadosDaValidacao { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
