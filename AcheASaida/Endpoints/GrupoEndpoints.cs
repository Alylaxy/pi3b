using AcheASaida.Contracts;

namespace AcheASaida.Endpoints;

public static class GrupoEndpoints
{
    private static readonly List<GrupoDto> Grupos = [];

    public static RouteGroupBuilder RegistrarGrupoEndpoints(this WebApplication app)
    {
        var grupoGrupo = app.MapGroup("grupo").WithParameterValidation();

        const string criarGrupoEndpoint = "CriarGrupo";
        const string obterGrupoEndpoint = "ObterGrupo";
        
        grupoGrupo.MapPost("/", (CriarGrupoDto grupo) =>
        {
            var novoGrupo = new GrupoDto(Guid.NewGuid(), grupo.Nome, 0, [], 0, 0M, 0M, []);
            Grupos.Add(novoGrupo);
            return Results.CreatedAtRoute(obterGrupoEndpoint, new {id = novoGrupo.Id}, novoGrupo);
        }).WithName(criarGrupoEndpoint);

        grupoGrupo.MapGet("/{id}", (Guid id) =>
        {
            var grupo = Grupos.FirstOrDefault(g => g.Id == id);
            if (grupo == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(grupo);
        }).WithName(obterGrupoEndpoint);

        return grupoGrupo;
    }
}