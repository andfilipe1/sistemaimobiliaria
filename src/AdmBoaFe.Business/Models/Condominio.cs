using AdmBoaFe.Business.Models.Enums;
using System;
using System.Collections.Generic;

namespace AdmBoaFe.Business.Models
{
    public class Condominio : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Documento { get; set; }
        public DateTime DataFundacao { get; set; }
        public int NumeroBlocos { get; set; }
        public int NumeroTotalUnidades { get; set; }
        public double AreaTotal { get; set; }
        public decimal TaxaCondominioMensal { get; set; }
        public string ContatoSindico { get; set; }
        public string ContatoAdministracao { get; set; }
        public TipoPessoa TipoCondominio { get; set; }

        public Guid LogradouroId { get; set; } 
        public Logradouro Logradouro { get; set; } 

        /* EF Relations */
        public IEnumerable<Imovel> Imovel { get; set; }
    }
}
