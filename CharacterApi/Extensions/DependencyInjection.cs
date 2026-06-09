using CharacterApi.Data;
using CharacterApi.Repositories;

namespace CharacterApi.Extensions
{
    public static class DependencyInjection
    {
        public static void RegisterContainers(IServiceCollection services)
        {
            services.AddScoped<DatabaseConnection>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
        }
    }
}
