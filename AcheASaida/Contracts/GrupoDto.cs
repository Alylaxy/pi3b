using System.ComponentModel.DataAnnotations;
using AcheASaida.Entities;

namespace AcheASaida.Contracts;

public record GrupoDto(
    Guid Id,
    string Nome,
    int Pontuacao,
    List<int> LabirintosConcluidos,
    int QtdLabirintosConcluidos,
    decimal MediaExploracao,
    decimal MediaPassos,
    List<InfoLabirintoDto> Informacoes);