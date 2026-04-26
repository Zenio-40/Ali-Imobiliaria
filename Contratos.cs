using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Corretora;

public static class Contratos
{
    public static IServiceCollection AddContratos(this IServiceCollection services)
    {
        var assembly = typeof(Contratos).Assembly;

        var tipos = assembly.GetTypes()
            .Where(t => t.IsInterface && t.Name.StartsWith("I") && t.Name.EndsWith("Repositorio"))
            .ToList();

        foreach (var tipo in tipos)
        {
            var implementacao = assembly.GetTypes()
                .FirstOrDefault(t => t.IsClass && !t.IsAbstract && tipo.IsAssignableFrom(t));

            if (implementacao != null)
            {
                services.AddScoped(tipo, implementacao);
            }
        }

        return services;
    }
}
