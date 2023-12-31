﻿using AdmBoaFe.Api.ViewModels.V1;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace AdmBoaFe.Api.Extensions
{
    // Binder personalizado para envio de IFormFile e ViewModel dentro de um FormData compatível com .NET Core 3.1 ou superior (system.text.json)
    public class ImovelModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true
            };

            var produtoImagemViewModel = JsonSerializer.Deserialize<ImovelImagemViewModel>(bindingContext.ValueProvider.GetValue("produto").FirstOrDefault(), serializeOptions);
            produtoImagemViewModel.ImagemUpload = bindingContext.ActionContext.HttpContext.Request.Form.Files.FirstOrDefault();

            bindingContext.Result = ModelBindingResult.Success(produtoImagemViewModel);
            return Task.CompletedTask;
        }
    }
}
