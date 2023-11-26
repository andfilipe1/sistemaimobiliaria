using AdmBoaFe.Business.Models;

namespace AdmBoaFe.Business.Intefaces
{
    public interface ICondominioervice : IDisposable
    {
        Task Adicionar(Condominio fornecedor);
        Task Atualizar(Condominio fornecedor);
        Task Remover(Guid id);

        Task AtualizarEndereco(Proprietario endereco);
    }
}