using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace AcheASaida.Entities;

public class Labirinto(string dificuldade)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; init; }
    
    [Required][StringLength(50, ErrorMessage = "A dificuldade não pode ter mais que 50 caracteres.")]
    public string Dificuldade { get; private set; } = dificuldade;

    public Vertice? Entrada { get; private set; }
    
    public List<Vertice> Vertices { get; private set; } = [];

    public void AdicionarVertices(List<Vertice> vertices)
    {
        Vertices.AddRange(vertices);
    }

    public void ConfigurarEntrada()
    {
        //Adicionar a entrada do labirinto.
        var entrada = Vertices.FirstOrDefault(v => v.Tipo == 1);
        if (entrada != null)
        {
            Entrada = entrada;
        }
        else
        {
            Debug.Fail("Entrada não encontrada.");
        }
    }
}