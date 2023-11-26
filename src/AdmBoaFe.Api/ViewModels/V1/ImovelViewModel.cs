using System;
using System.ComponentModel.DataAnnotations;

namespace AdmBoaFe.Api.ViewModels.V1
{
    public class ImovelViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CondominioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public string ImagemUpload { get; set; } 
        public string Imagem { get; set; } 

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCondominio { get; set; } 

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid LogradouroId { get; set; } 

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProprietarioId { get; set; }
        public ProprietarioViewModel Proprietario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid InquilinoId { get; set; }
        public InquilinoViewModel Inquilino { get; set; }
    }
}
