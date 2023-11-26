using AutoMapper;
using AdmBoaFe.Api.Controllers;
using AdmBoaFe.Api.Extensions;
using AdmBoaFe.Api.ViewModels.V1;
using AdmBoaFe.Business.Intefaces;
using AdmBoaFe.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdmBoaFe.Api.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/condominio")]
    public class CondominiosController : MainController
    {
        private readonly ICondominioRepository _condominioRepository;
        private readonly ICondominioervice _condominioService;
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IMapper _mapper;

        public CondominiosController(ICondominioRepository condominioRepository, 
                                      IMapper mapper, 
                                      ICondominioervice condominioService,
                                      INotificador notificador, 
                                      IProprietarioRepository proprietarioRepository,
                                      IUser user) : base(notificador, user)
        {
            _condominioRepository = condominioRepository;
            _mapper = mapper;
            _condominioService = condominioService;
            _proprietarioRepository = proprietarioRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CondominioViewModel>> ObterTodosCondominios()
        {
            return _mapper.Map<IEnumerable<CondominioViewModel>>(await _condominioRepository.ObterTodosCondominios());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CondominioViewModel>> ObterTodosCondominiosPorId(Guid id)
        {
            var condominio = await ObterCondominioInquilinoImovel(id);

            if (condominio == null) return NotFound();

            return condominio;
        }

        //[ClaimsAuthorize("Condominio","Adicionar")]
        [HttpPost]
        public async Task<ActionResult<CondominioViewModel>> AdicionarCondominios(CondominioViewModel condominioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _condominioService.Adicionar(_mapper.Map<Condominio>(condominioViewModel));

            return CustomResponse(condominioViewModel);
        }

        [ClaimsAuthorize("Condominio", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CondominioViewModel>> AtualizarCondominios(Guid id, CondominioViewModel condominioViewModel)
        {
            if (id != condominioViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(condominioViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _condominioService.Atualizar(_mapper.Map<Condominio>(condominioViewModel));

            return CustomResponse(condominioViewModel);
        }

       // [ClaimsAuthorize("Condominio", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CondominioViewModel>> ExcluirCondominios(Guid id)
        {
            var condominioViewModel = await ObterCondominioImovel(id);

            if (condominioViewModel == null) return NotFound();

            await _condominioService.Remover(id);

            return CustomResponse(condominioViewModel);
        }

        [HttpGet("endereco/{id:guid}")]
        public async Task<ProprietarioViewModel> ObterProprietarioPorId(Guid id)
        {
            return _mapper.Map<ProprietarioViewModel>(await _proprietarioRepository.ObterPorId(id));
        }

        //[ClaimsAuthorize("Condominio", "Atualizar")]
        [HttpPut("endereco/{id:guid}")]
        public async Task<IActionResult> AtualizarProprietario(Guid id, ProprietarioViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _condominioService.AtualizarEndereco(_mapper.Map<Proprietario>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }



        private async Task<CondominioViewModel> ObterCondominioInquilinoImovel(Guid id)
        {
            return _mapper.Map<CondominioViewModel>(await _condominioRepository.ObterCondominioInquilinoImovel(id));
        }

        private async Task<CondominioViewModel> ObterCondominioImovel(Guid id)
        {
            return _mapper.Map<CondominioViewModel>(await _condominioRepository.ObterCondominioImovel(id));
        }
    }
}