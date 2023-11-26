using AdmBoaFe.Business.Models;

namespace AdmBoaFe.Business.Intefaces
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        Task<Proprietario> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}