using Microsoft.Extensions.DependencyInjection;
using Transmutatio.Application.Conversions.Services;
using Transmutatio.Application.Conversions.Services.Interfaces;
using Transmutatio.Domain.Conversions.Services;
using Transmutatio.Domain.Conversions.Services.Interfaces;
using Transmutatio.Domain.Youtube.Services;
using Transmutatio.Domain.Youtube.Services.Interfaces;
using Transmutatio.Infra.Youtube.Services;

namespace Transmutatio.Ioc;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAbstractions()
        {
            return services;
        }

        public IServiceCollection AddServices()
        {
            services.AddScoped<IConversionsAppService, ConversionsAppService>();
            
            services.AddScoped<IConversionsService, ConversionsService>();
            services.AddScoped<IYoutubeDownloadersService, YtdlpDownloadersService>();
            services.AddScoped<IYoutubeService, YoutubeService>();
        
            return services;
        }

        public IServiceCollection AddRepositories()
        {
            return services;
        }
    }
}