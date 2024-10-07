namespace Cod3rsGrowthRavenDb.Dominio.Modelos
{
    public class Empresa
    {
        public string Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string CnpjEmpresa { get; set; }
        public DateTime DataDeCadastroEmpresa { get; set; }
        public List<Funcionario>? FuncionariosEmpresa { get; set; }
    }
}