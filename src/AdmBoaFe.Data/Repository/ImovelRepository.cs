using AdmBoaFe.Business.Intefaces;
using AdmBoaFe.Business.Models;
using AdmBoaFe.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AdmBoaFe.Data.Repository
{
    public class ImovelRepository : Repository<Imovel>, IImovelRepository
    {
        public ImovelRepository(MeuDbContext context) : base(context) { }

        public async Task<Imovel> ObterImovelCondominio(Guid id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Imovel>> ObterImovelCondominio()
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Imovel>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            throw new NotImplementedException();

        }
    }
}