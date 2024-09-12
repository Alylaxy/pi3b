using AcheASaida.Contracts;
using AcheASaida.Data;
using Microsoft.EntityFrameworkCore;

namespace AcheASaida.Endpoints;

public static class LabirintoEndpoints
{
    public static RouteGroupBuilder RegistrarLabirintoEndpoints(this WebApplication app)
    {
        var grupoLabirinto = app.MapGroup("labirinto").WithParameterValidation();
        
        const string iniciarDesafioEndpoint = "IniciarDesafio";
        const string obterInformacoesGrupoSobreLabirintoEndpoint = "ObterInformacoesGrupoSobreLabirinto";

        grupoLabirinto.MapGet("/iniciar/{id}", (Guid id) =>
        {
            //abrir canal websocket e retornar conexão
        }).WithName(iniciarDesafioEndpoint);

        grupoLabirinto.MapGet("/{id}", async (Guid id, AppDbContext dbContext) =>
        {
            var infoGrupo = await dbContext.InfoLabirintos.FirstOrDefaultAsync(il => il.GrupoId == id);
            if (infoGrupo == null)
            {
                return Results.NotFound("Grupo não possui informações ou não existe");
            }
            var infoLabirinto = new InfoLabirintoDto(
                infoGrupo.IdLabirinto,
                infoGrupo.Dificuldade,
                infoGrupo.Completo,
                infoGrupo.Passos,
                infoGrupo.PorcentagemExploracao
            );
            return Results.Ok(infoLabirinto);
        }).WithName(obterInformacoesGrupoSobreLabirintoEndpoint);
        return grupoLabirinto;
    }
}