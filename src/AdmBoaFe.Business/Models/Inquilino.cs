using System;
using AdmBoaFe.Business.Models.Enums;

namespace AdmBoaFe.Business.Models
{
    public class Inquilino : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoPessoa TipoInquilino { get; set; }
        public int MyProperty { get; set; }
        public Guid LogradouroId { get; set; } 
        public Logradouro Logradouro { get; set; } 

        /* EF Relation */
        public Imovel Imovel { get; set; }
    }
}
