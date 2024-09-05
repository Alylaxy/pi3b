using System.ComponentModel.DataAnnotations;

namespace AcheASaida.Contracts;

public record LabirintoDto(
    int Id, 
    string Dificuldade, 
    VerticeDto Entrada, 
    List<VerticeDto> Vertices);
