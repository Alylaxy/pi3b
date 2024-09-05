using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AcheASaida.Entities;

public class Labirinto
{
    [Key]
    public required int Id { get; init; }
    
    [StringLength(50, ErrorMessage = "A dificuldade não pode ter mais que 50 caracteres.")]
    public string Dificuldade { get; private set; }
    
    public Vertice Entrada { get; private set; }
    
    public List<Vertice> Vertices { get; private set; }

    public Labirinto(string dificuldade)
    {
        Dificuldade = dificuldade;
        Vertices = [];
    }

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