using AdmBoaFe.Business.Intefaces;
using AdmBoaFe.Business.Models;
using AdmBoaFe.Business.Models.Validations;

namespace AdmBoaFe.Business.Services
{
    public class CondominioService : BaseService, ICondominioervice
    {
        private readonly ICondominioRepository _condominioRepository;
        private readonly IProprietarioRepository _proprietarioRepository;

        public CondominioService(ICondominioRepository condominioRepository, 
                                 IProprietarioRepository proprietarioRepository,
                                 INotificador notificador) : base(notificador)
        {
            _condominioRepository = condominioRepository;
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task Adicionar(Condominio condominio)
        {
            if (!ExecutarValidacao(new CondominioValidation(), condominio)) return;

            if (_condominioRepository.Buscar(f => f.Id == condominio.Id).Result.Any())
            {
                Notificar("Já existe um condominio com este documento infomado.");
                return;
            }

            await _condominioRepository.Adicionar(condominio);
        }

        public async Task Atualizar(Condominio condominio)
        {
            if (!ExecutarValidacao(new CondominioValidation(), condominio)) return;

            if (_condominioRepository.Buscar(f => f.Id == condominio.Id && f.Id != condominio.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return;
            }

            await _condominioRepository.Atualizar(condominio);
        }

        public async Task AtualizarEndereco(Proprietario proprietario)
        {
            if (!ExecutarValidacao(new ProprietarioValidation(), proprietario)) return;

            await _proprietarioRepository.Atualizar(proprietario);
        }

        public async Task Remover(Guid id)
        {
            if (_condominioRepository.ObterCondominioInquilinoImovel(id).Result.Imovel.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            var endereco = await _proprietarioRepository.ObterEnderecoPorFornecedor(id);

            if (endereco != null)
            {
                await _proprietarioRepository.Remover(endereco.Id);
            }

            await _condominioRepository.Remover(id);
        }

        public void Dispose()
        {
            _condominioRepository?.Dispose();
            _proprietarioRepository?.Dispose();
        }
    }
}