using System.ComponentModel;

namespace Cod3rsGrowthRavenDb.Dominio.Enums
{
    public enum CargosEnum
    {
        [Description("Presidente")]
        Presidente = 0,
        [Description("Diretor")]
        Diretor = 1,
        [Description("Gerente")]
        Gerente = 2,
        [Description("Coordenador ")]
        Coordenador = 3,
        [Description("Analista")]
        Analista = 4,
        [Description("Assistente")]
        Assistente = 5,
        [Description("Auxiliar")]
        Auxiliar = 6
    }
}