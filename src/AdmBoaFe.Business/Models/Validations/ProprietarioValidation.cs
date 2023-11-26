using AdmBoaFe.Business.Models.Validations.Documentos;
using FluentValidation;

namespace AdmBoaFe.Business.Models.Validations
{
    public class ProprietarioValidation : AbstractValidator<Proprietario>
    {
        public ProprietarioValidation()
        {
            When(f => f.TipoProprietario == Enums.TipoPessoa.PessoaFisica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });

            When(f => f.TipoProprietario == Enums.TipoPessoa.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });

        }
    }
}