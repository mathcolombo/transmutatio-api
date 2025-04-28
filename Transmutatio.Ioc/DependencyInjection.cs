using Microsoft.Extensions.DependencyInjection;

namespace Transmutatio.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddAbstractions(this IServiceCollection services)
    {
        return services;
    }
    
    public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
    {
        return services;
    }
}