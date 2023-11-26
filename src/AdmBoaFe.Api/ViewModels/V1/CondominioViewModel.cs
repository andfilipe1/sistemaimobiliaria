using AdmBoaFe.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdmBoaFe.Api.ViewModels.V1
{
    public class CondominioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "A data de fundação é obrigatória")]
        public DateTime DataFundacao { get; set; }

        [Required(ErrorMessage = "O número de blocos é obrigatório")]
        public int NumeroBlocos { get; set; }

        [Required(ErrorMessage = "O número total de unidades é obrigatório")]
        public int NumeroTotalUnidades { get; set; }

        [Required(ErrorMessage = "A área total é obrigatória")]
        public double AreaTotal { get; set; }

        [Required(ErrorMessage = "A taxa de condomínio mensal é obrigatória")]
        public decimal TaxaCondominioMensal { get; set; }

        public string ContatoSindico { get; set; }
        public string ContatoAdministracao { get; set; }

        [Required(ErrorMessage = "O tipo de condomínio é obrigatório")]
        public TipoPessoa TipoCondominio { get; set; }

        public Guid LogradouroId { get; set; }

        public List<ImovelViewModel> Imoveis { get; set; }
    }
}
