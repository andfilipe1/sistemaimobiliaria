using AdmBoaFe.Business.Models;

namespace AdmBoaFe.Business.Intefaces
{
    public interface IImovelService : IDisposable
    {
        Task Adicionar(Imovel produto);
        Task Atualizar(Imovel produto);
        Task Remover(Guid id);
    }
}