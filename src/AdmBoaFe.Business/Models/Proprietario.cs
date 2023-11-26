using System;
using System.Collections.Generic;
using AdmBoaFe.Business.Models.Enums;

namespace AdmBoaFe.Business.Models
{
    public class Proprietario : Entity
    {
        public string Nome { get; set; }
        public TipoPessoa TipoProprietario { get; set; }
        public string Documento { get; set; }

        public Guid LogradouroId { get; set; } 
        public Logradouro Logradouro { get; set; } 

        public IEnumerable<Imovel> Imoveis { get; set; }
    }
}
