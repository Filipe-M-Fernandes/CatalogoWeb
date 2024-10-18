using System.ComponentModel;

namespace CatalogoWeb.Domain.Enuns
{
    public enum AtivoInativo
    {
        [DescriptionAttribute("Inativo")]
        Inativo = 0,
        [DescriptionAttribute("Ativo")]
        Ativo = 1,
        [DescriptionAttribute("Todos")]
        Todos = 2
    }
}
