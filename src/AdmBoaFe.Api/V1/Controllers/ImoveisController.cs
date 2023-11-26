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
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/imovel")]
    public class ImoveisController : MainController
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IImovelService _imovelService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImoveisController(INotificador notificador,
                                  IImovelRepository imovelRepository,
                                  IImovelService imovelService,
                                  IMapper mapper,
                                  IUser user,
                                  IHttpContextAccessor httpContextAccessor) : base(notificador, user)
        {
            _imovelRepository = imovelRepository;
            _imovelService = imovelService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IEnumerable<ImovelViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ImovelViewModel>>(await _imovelRepository.ObterImovelCondominio());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ImovelViewModel>> ObterPorId(Guid id)
        {
            var imovelViewModel = await Obterimovel(id);

            if (imovelViewModel == null) return NotFound();

            return imovelViewModel;
        }

        [ClaimsAuthorize("Imovel", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ImovelViewModel>> Adicionar(ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + imovelViewModel.Imagem;
            if (!UploadArquivo(imovelViewModel.ImagemUpload, imagemNome))
            {
                return CustomResponse(imovelViewModel);
            }

            imovelViewModel.Imagem = imagemNome;
            await _imovelService.Adicionar(_mapper.Map<Imovel>(imovelViewModel));

            return CustomResponse(imovelViewModel);
        }

        [ClaimsAuthorize("Imovel", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ImovelViewModel imovelViewModel)
        {
            if (id != imovelViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var imovelAtualizacao = await Obterimovel(id);

            if (string.IsNullOrEmpty(imovelViewModel.Imagem))
                imovelViewModel.Imagem = imovelAtualizacao.Imagem;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (imovelViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + imovelViewModel.Imagem;
                if (!UploadArquivo(imovelViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                imovelAtualizacao.Imagem = imagemNome;
            }

            imovelAtualizacao.Nome = imovelViewModel.Nome;
            imovelAtualizacao.Descricao = imovelViewModel.Descricao;
            imovelAtualizacao.Valor = imovelViewModel.Valor;
            imovelAtualizacao.Ativo = imovelViewModel.Ativo;

            await _imovelService.Atualizar(_mapper.Map<Imovel>(imovelAtualizacao));

            return CustomResponse(imovelViewModel);
        }

        [ClaimsAuthorize("Imovel", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ImovelViewModel>> Excluir(Guid id)
        {
            var imovel = await Obterimovel(id);

            if (imovel == null) return NotFound();

            await _imovelService.Remover(id);

            return CustomResponse(imovel);
        }

        private async Task<ImovelViewModel> Obterimovel(Guid id)
        {
            return _mapper.Map<ImovelViewModel>(await _imovelRepository.ObterImovelCondominio(id));
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este imovel!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}