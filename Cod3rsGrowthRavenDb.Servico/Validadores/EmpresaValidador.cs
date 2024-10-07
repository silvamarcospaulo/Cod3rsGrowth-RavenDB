using Cod3rsGrowthRavenDb.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowthRavenDb.Servico.Validadores
{
    public class EmpresaValidador : AbstractValidator<Empresa>
    {

        public EmpresaValidador()
        {
            RuleSet("Criar", () =>
            {
                RuleFor(empresa => empresa.NomeEmpresa)
                    .NotEmpty().WithMessage("Preencher o campo com o nome da empresa.")
                    .NotNull().WithMessage("Preencher o campo com o nome da empresa.");

                RuleFor(empresa => empresa.CnpjEmpresa)
                    .NotEmpty().WithMessage("Preencher o campo com o CNPJ da empresa.")
                    .NotNull().WithMessage("Preencher o campo com o CNPJ da empresa.");

                RuleFor(empresa => empresa.CnpjEmpresa)
                    .Must(ValidadorDeCnpj).WithMessage(
                    "CNPJ inválido!")
                    .When(empresa => !string.IsNullOrEmpty(empresa.CnpjEmpresa));
            });
        }

        private bool ValidadorDeCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            int resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            string digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}