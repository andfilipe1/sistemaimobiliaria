using AdmBoaFe.Business.Intefaces;
using AdmBoaFe.Business.Models;
using AdmBoaFe.Business.Models.Validations;

namespace AdmBoaFe.Business.Services
{
    public class ImovelService : BaseService, IImovelService
    {
        private readonly IImovelRepository _produtoRepository;

        public ImovelService(IImovelRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Imovel produto)
        {
            if (!ExecutarValidacao(new ImovelValidation(), produto)) return;

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Imovel produto)
        {
            if (!ExecutarValidacao(new ImovelValidation(), produto)) return;

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}