using Microsoft.Extensions.DependencyInjection;
using Transmutatio.Application.Conversions.Services;
using Transmutatio.Application.Conversions.Services.Interfaces;
using Transmutatio.Domain.Conversions.Services;
using Transmutatio.Domain.Conversions.Services.Interfaces;
using Transmutatio.Infra.Conversions.Services;

namespace Transmutatio.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddAbstractions(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IConversionsAppService, ConversionsAppService>();

        services.AddScoped<IConversionsService, ConversionsService>();
        services.AddScoped<IConversionsYoutubeService, ConversionsYoutubeService>();
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }
}