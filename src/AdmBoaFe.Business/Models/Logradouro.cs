namespace AdmBoaFe.Business.Models
{
    public  class Logradouro : Entity
    {
        public string LogradouroNome { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
