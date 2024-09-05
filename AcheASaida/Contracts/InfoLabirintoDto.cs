using System.ComponentModel.DataAnnotations;

namespace AcheASaida.Contracts;

public record InfoLabirintoDto(
    int IdLabirinto,
    string Dificuldade,
    bool Completo,
    int Passos,
    float PorcentagemExploracao);