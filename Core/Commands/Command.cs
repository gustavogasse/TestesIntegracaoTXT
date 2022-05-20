using FluentValidation.Results;

namespace Core.Commands
{
    public abstract class Command 
    {
        public ValidationResult ResultadosValidacao { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
