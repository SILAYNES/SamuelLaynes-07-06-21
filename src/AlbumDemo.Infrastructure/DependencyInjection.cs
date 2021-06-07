using AlbumDemo.Infrastructure.Configurations;
using AlbumDemo.Infrastructure.Interfaces;
using AlbumDemo.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlbumDemo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = false;
            
            services.AddSingleton(new DatabaseConfig() { Name = configuration["DatabaseName"]});
            services.AddSingleton<IAlbumRepository, AlbumRepository>();
            services.AddSingleton<IPhotoRepository, PhotoRepository>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            
            return services;
        }
    }
}