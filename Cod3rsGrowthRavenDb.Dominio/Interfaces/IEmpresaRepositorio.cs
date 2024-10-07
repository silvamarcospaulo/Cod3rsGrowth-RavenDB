using Cod3rsGrowthRavenDb.Dominio.Filtros;
using Cod3rsGrowthRavenDb.Dominio.Modelos;

namespace Cod3rsGrowthRavenDb.Dominio.Interfaces
{
    public interface IEmpresaRepositorio
    {
        public Task Criar(Empresa empresa);
        public Task<Empresa> ObterPorId(string idEmpresa);
        public Task <List<Empresa>> ObterTodos(EmpresaFiltro? filtro);
        public Task Atualizar(Empresa empresa);
        public Task Remover(string idEmpresa);
    }
}