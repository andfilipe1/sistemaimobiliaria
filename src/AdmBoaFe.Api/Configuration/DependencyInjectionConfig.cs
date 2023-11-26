using AdmBoaFe.Api.Extensions;
using AdmBoaFe.Business.Intefaces;
using AdmBoaFe.Business.Notificacoes;
using AdmBoaFe.Business.Services;
using AdmBoaFe.Data.Context;
using AdmBoaFe.Data.Repository;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AdmBoaFe.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IImovelRepository, ImovelRepository>();
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ICondominioervice, CondominioService>();
            services.AddScoped<IImovelService, ImovelService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}