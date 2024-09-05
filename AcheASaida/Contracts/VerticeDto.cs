using System.ComponentModel.DataAnnotations;

namespace AcheASaida.Contracts;

public record VerticeDto(
    Guid Id, 
    List<VerticeDto> Conexoes, 
    int Estado, 
    int LabirintoPertencente);