using AdmBoaFe.Business.Intefaces;
using AdmBoaFe.Business.Models;
using AdmBoaFe.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AdmBoaFe.Data.Repository
{
    public class ProprietarioRepository : Repository<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(MeuDbContext context) : base(context) { }

        public async Task<Proprietario> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            throw new NotImplementedException();

        }
    }
}