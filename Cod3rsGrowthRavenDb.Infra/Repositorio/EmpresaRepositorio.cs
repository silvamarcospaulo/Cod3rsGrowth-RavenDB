using Cod3rsGrowthRavenDb.Dominio.Filtros;
using Cod3rsGrowthRavenDb.Dominio.Interfaces;
using Cod3rsGrowthRavenDb.Dominio.Modelos;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;

namespace Cod3rsGrowthRavenDb.Infra.Repositorio
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        public async Task Criar(Empresa empresa)
        {
            var _documentStore = new DocumentStore()
            {
                Database = "Cod3rsGrowthRavenDb",
                Urls = new[] { "http://localhost:8080/" }
            }.Initialize();

            using (var session = _documentStore.OpenAsyncSession())
            {
                await session.StoreAsync(empresa);
                await session.SaveChangesAsync();
            }
        }

        public async Task<Empresa> ObterPorId(string idEmpresa)
        {
            var _documentStore = new DocumentStore()
            {
                Database = "Cod3rsGrowthRavenDb",
                Urls = new[] { "http://localhost:8080/" }
            }.Initialize();

            using (var session = _documentStore.OpenAsyncSession())
            {
                var empresa = await session.LoadAsync<Empresa>("docs?id=empresas/" + idEmpresa);
                return empresa;
            }
        }

        public async Task<List<Empresa>> ObterTodos(EmpresaFiltro? filtro)
        {
            var _documentStore = new DocumentStore()
            {
                Database = "Cod3rsGrowthRavenDb",
                Urls = new[] { "http://localhost:8080/" }
            }.Initialize();

            using (var session = _documentStore.OpenAsyncSession())
            {
                var query = session.Query<Empresa>();

                if (filtro != null)
                {
                    if (!string.IsNullOrEmpty(filtro?.CnpjEmpresa))
                    {
                        query = (IRavenQueryable<Empresa>)query.Where(e => e.CnpjEmpresa == filtro.CnpjEmpresa);
                    }
                    if (!string.IsNullOrEmpty(filtro?.NomeEmpresa))
                    {
                        query = (IRavenQueryable<Empresa>)query.Where(e => e.NomeEmpresa == filtro.NomeEmpresa);
                    }
                }

                var empresas = await query.ToListAsync();
                return empresas;
            }
        }


        public async Task Atualizar(Empresa empresa)
        {
            var _documentStore = new DocumentStore()
            {
                Database = "Cod3rsGrowthRavenDb",
                Urls = new[] { "http://localhost:8080/" }
            }.Initialize();

            var empresaBanco = await ObterPorId(empresa.Id);

            using (var session = _documentStore.OpenAsyncSession())
            {
                var empresaAtualizada = new Empresa()
                {
                    Id = empresaBanco.Id,
                    DataDeCadastroEmpresa = empresaBanco.DataDeCadastroEmpresa,
                    NomeEmpresa = empresa.NomeEmpresa,
                    CnpjEmpresa = empresa.CnpjEmpresa,
                    FuncionariosEmpresa = empresa.FuncionariosEmpresa
                };

                await session.SaveChangesAsync();
            }
        }

        public async Task Remover(string idEmpresa)
        {
            var _documentStore = new DocumentStore()
            {
                Database = "Cod3rsGrowthRavenDb",
                Urls = new[] { "http://localhost:8080/" }
            }.Initialize();

            var empresa = await ObterPorId(idEmpresa);

            using (var session = _documentStore.OpenAsyncSession())
            {
                session.Delete(empresa);
                await session.SaveChangesAsync();
            }
        }
    }
}