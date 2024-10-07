using Cod3rsGrowthRavenDb.Dominio.Interfaces;
using Cod3rsGrowthRavenDb.Dominio.Modelos;
using Cod3rsGrowthRavenDb.Infra.Repositorio;
using Cod3rsGrowthRavenDb.Servico.Servicos;
using Cod3rsGrowthRavenDb.Servico.Validadores;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowthRavenDb.Infra
{
    public class InjetorDeDependencia
    {
        public static void BindServices(IServiceCollection servicos)
        {
            servicos.AddScoped<EmpresaServico>()
                    .AddScoped<IEmpresaRepositorio, EmpresaRepositorio>()
                    .AddScoped<IValidator<Empresa>, EmpresaValidador>();
        }
    }
}