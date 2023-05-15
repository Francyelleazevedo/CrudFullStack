using CadastroCliente.Classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Services
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome não pode ser nulo")
                .NotNull().WithMessage("Nome não pode ser nulo");

            RuleFor(x => x.Telefone)
                .MaximumLength(11).WithMessage("Telefone não permite mais que 11 números");
        }
    }
}
