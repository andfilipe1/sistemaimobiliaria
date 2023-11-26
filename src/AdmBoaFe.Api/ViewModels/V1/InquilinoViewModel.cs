using AdmBoaFe.Business.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdmBoaFe.Api.ViewModels.V1
{
    public class InquilinoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoPessoa TipoInquilino { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid LogradouroId { get; set; }

        public LogradouroViewModel Logradouro { get; set; }

        public ImovelViewModel Imovel { get; set; }

        public string ImagemUpload { get; set; }
        public string Imagem { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}
