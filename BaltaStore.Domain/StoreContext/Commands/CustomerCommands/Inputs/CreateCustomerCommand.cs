using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        //FailFastValidation
        //Interessante para validar coisas mais simples como tamanho de campos
        //evitando deixar na entidade e acabar fazendo requests em banco com um cpf invalido por exemplo

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            new ValidationContract()
                .HasMinLen(FirstName, 3, nameof(FirstName), "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, nameof(FirstName), "O nome deve conter no maximo 40 caracteres")
                .HasMinLen(LastName, 3, nameof(LastName), "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, nameof(LastName), "O nome deve conter no maximo 40 caracteres")
                .IsEmail(Email, nameof(Email), "O e-mail é invalido")
                .HasLen(Document, 11, nameof(Document), "CPF inválido");

            return IsValid;
        }
    }
}
