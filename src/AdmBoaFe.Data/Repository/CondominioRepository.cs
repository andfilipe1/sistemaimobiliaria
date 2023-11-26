using AdmBoaFe.Business.Intefaces;
using AdmBoaFe.Business.Models;
using AdmBoaFe.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AdmBoaFe.Data.Repository
{
    public class CondominioRepository : Repository<Condominio>, ICondominioRepository
    {
        public CondominioRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Condominio> ObterCondominioImovel(Guid id)
        {
            throw new NotImplementedException();

        }

        public Task<Condominio> ObterCondominioInquilinoImovel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}