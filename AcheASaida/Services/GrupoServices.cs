using System.Diagnostics;
using AcheASaida.Contracts;
using AcheASaida.Data;
using AcheASaida.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcheASaida.Services;

public class GrupoService(AppDbContext dbContext)
{
    public async Task<GrupoDto> ObterGrupoComInformacoes(Guid id)
    {
        var grupo = await dbContext.Grupos
            .Include(g => g.Informacoes)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (grupo == null)
        {
            Debug.Fail("Grupo não encontrado"); // Ou lance uma exceção, dependendo do seu caso de uso
        }

        var grupoDto = new GrupoDto(
            grupo.Id,
            grupo.Nome,
            grupo.Pontuacao,
            grupo.LabirintosConcluidos,
            grupo.QtdLabirintosConcluidos,
            grupo.MediaExploracao,
            grupo.MediaPassos,
            grupo.Informacoes.Select(i => new InfoLabirintoDto(
                i.IdLabirinto,
                i.Dificuldade,
                i.Completo,
                i.Passos,
                i.PorcentagemExploracao)).ToList()
        );

        return grupoDto;
    }

    public async Task<GrupoDto> CriarGrupo(CriarGrupoDto criarGrupoDto)
    {
        var novoGrupo = new Grupo(criarGrupoDto.Nome);
        dbContext.Grupos.Add(novoGrupo);
        await dbContext.SaveChangesAsync();
        var grupoDto = new GrupoDto(novoGrupo.Id,
            novoGrupo.Nome,
            novoGrupo.Pontuacao,
            novoGrupo.LabirintosConcluidos,
            novoGrupo.QtdLabirintosConcluidos,
            novoGrupo.MediaExploracao,
            novoGrupo.MediaPassos,
            novoGrupo.Informacoes.Select(i => new InfoLabirintoDto(i.IdLabirinto,
                    i.Dificuldade,
                    i.Completo,
                    i.Passos,
                    i.PorcentagemExploracao))
                .ToList());
        return grupoDto;
    }
}