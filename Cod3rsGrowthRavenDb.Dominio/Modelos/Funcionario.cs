using Cod3rsGrowthRavenDb.Dominio.Enums;

namespace Cod3rsGrowthRavenDb.Dominio.Modelos
{
    public class Funcionario
    {
        public string Id { get; set; }
        public string NomeFuncionario { get; set; }
        public CargosEnum CargoFuncionario { get; set; }
        public decimal SalarioFuncionario { get; set; }
        public DateTime DataAdmissaoFuncionario { get; set; }
    }
}