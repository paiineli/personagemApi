using PersonagemApi.Data;
using PersonagemApi.Repositories;

namespace PersonagemApi.Extensions
{
    public static class InjecaoDependencia
    {
        public static void RegisterContainers(IServiceCollection services)
        {
            services.AddScoped<ConexaoBanco>();
            services.AddScoped<IPersonagemREP, PersonagemREP>();
        }
    }
}
