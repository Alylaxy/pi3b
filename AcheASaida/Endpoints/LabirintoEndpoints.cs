using AcheASaida.Contracts;

namespace AcheASaida.Endpoints;

public static class LabirintoEndpoints
{
    private static readonly List<GrupoDto> Grupos = [];

    public static RouteGroupBuilder RegistrarLabirintoEndpoints(this WebApplication app)
    {
        var grupoLabirinto = app.MapGroup("labirinto").WithParameterValidation();

        const string criarGrupoEndpoint = "CriarGrupo";
        const string obterGrupoEndpoint = "ObterGrupo";
        const string iniciarDesafioEndpoint = "IniciarDesafio";
        const string obterInformacoesGrupoSobreLabirintoEndpoint = "ObterInformacoesGrupoSobreLabirinto";

        grupoLabirinto.MapGet("/iniciar/{id}", (Guid id) =>
        {
            //abrir canal websocket e retornar conexão
        }).WithName(iniciarDesafioEndpoint);

        grupoLabirinto.MapGet("/{id}", (Guid id) =>
        {
            var grupo = Grupos.FirstOrDefault(g => g.Id == id);
            if (grupo == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(grupo.Informacoes);
        }).WithName(obterInformacoesGrupoSobreLabirintoEndpoint);
        return grupoLabirinto;
    }
}