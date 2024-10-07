using Cod3rsGrowthRavenDb.Dominio.Filtros;
using Cod3rsGrowthRavenDb.Dominio.Interfaces;
using Cod3rsGrowthRavenDb.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowthRavenDb.Servico.Servicos
{
    public class EmpresaServico : IEmpresaRepositorio
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly IValidator<Empresa> _validadorEmpresa;

        public EmpresaServico(IEmpresaRepositorio empresaRepositorio, IValidator<Empresa> validadorEmpresa)
        {
            _empresaRepositorio = empresaRepositorio;
            _validadorEmpresa = validadorEmpresa;
        }

        public async Task Criar(Empresa empresa)
        {
            try
            {
                //_validadorEmpresa.Validate(empresa, options =>
                //{
                //    options.ThrowOnFailures();
                //    options.IncludeRuleSets("Criar");
                //});

                empresa.DataDeCadastroEmpresa = DateTime.Now;

                await _empresaRepositorio.Criar(empresa);
            }
            catch (ValidationException e)
            {
                string mensagemDeErro = string.Join(Environment.NewLine, e.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException($"{mensagemDeErro}");
            }
        }

        public async Task<Empresa> ObterPorId(string idEmpresa)
        {
            return await _empresaRepositorio.ObterPorId(idEmpresa);
        }

        public async Task<List<Empresa>> ObterTodos(EmpresaFiltro? filtro)
        {
            return await _empresaRepositorio.ObterTodos(filtro);
        }

        public async Task Atualizar(Empresa empresa)
        {
            try
            {
                _validadorEmpresa.Validate(empresa, options =>
                {
                    options.ThrowOnFailures();
                    options.IncludeRuleSets("Atualizar");
                });

                await _empresaRepositorio.Atualizar(empresa);
            }
            catch (ValidationException e)
            {
                string mensagemDeErro = string.Join(Environment.NewLine, e.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException($"{mensagemDeErro}");
            }
        }

        public async Task Remover(string idEmpresa)
        {
            try
            {
                await _empresaRepositorio.Remover(idEmpresa);
            }
            catch (ValidationException e)
            {
                string mensagemDeErro = string.Join(Environment.NewLine, e.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException($"{mensagemDeErro}");
            }
        }
    }
}