namespace CatalogoWeb.Core.DadosUsuarioLogado
{
    public interface IDadosUsuarioLogado
    {
        string NomeUsuario();
        string EmailUsuario();
        long IdUsuario();
        int CodigoEmpresa();
        long CodigoLocal();
        string NomeEmpresa();
        string NomeFilial();
    }
}
