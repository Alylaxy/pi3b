using AcheASaida.Contracts;
using AcheASaida.Data;
using AcheASaida.Services;

namespace AcheASaida.Endpoints;

public static class GrupoEndpoints
{
    public static RouteGroupBuilder RegistrarGrupoEndpoints(this WebApplication app)
    {
        var grupoGrupo = app.MapGroup("grupo").WithParameterValidation();
        
        const string criarGrupoEndpoint = "CriarGrupo";
        const string obterGrupoEndpoint = "ObterGrupo";
        
        grupoGrupo.MapPost("/", async (CriarGrupoDto grupoDto, AppDbContext dbContext) =>
        {
            var novoGrupoDto = await new GrupoService(dbContext).CriarGrupo(grupoDto);
            return Results.CreatedAtRoute(obterGrupoEndpoint, new {id = novoGrupoDto.Id}, novoGrupoDto);
        }).WithName(criarGrupoEndpoint);

        grupoGrupo.MapGet("/{id}", async (Guid id, AppDbContext dbContext) =>
        {
            var grupoDto = await new GrupoService(dbContext).ObterGrupoComInformacoes(id);
            return Results.Ok(grupoDto);
        }).WithName(obterGrupoEndpoint);

        return grupoGrupo;
    }
}