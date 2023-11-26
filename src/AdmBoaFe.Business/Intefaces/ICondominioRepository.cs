using AdmBoaFe.Business.Models;

namespace AdmBoaFe.Business.Intefaces
{
    public interface ICondominioRepository : IRepository<Condominio>
    {
        Task<Condominio> ObterCondominioImovel(Guid id);
        Task<Condominio> ObterCondominioInquilinoImovel(Guid id);
    }
}