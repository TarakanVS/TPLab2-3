using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public static class ServiceExtentions
    {
        public static void RegisterRepos(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IRepository), typeof(Repository));
        }
    }
}
