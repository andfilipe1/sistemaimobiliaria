using AdmBoaFe.Business.Models;

namespace AdmBoaFe.Business.Intefaces
{
    public interface IImovelRepository : IRepository<Imovel>
    {
        Task<IEnumerable<Imovel>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Imovel>> ObterImovelCondominio();
        Task<Imovel> ObterImovelCondominio(Guid id);
    }
}