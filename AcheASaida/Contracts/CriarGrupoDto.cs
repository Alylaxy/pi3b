using System.ComponentModel.DataAnnotations;

namespace AcheASaida.Contracts;

public record CriarGrupoDto([Required][StringLength(50)]string Nome);