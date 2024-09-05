using System.ComponentModel.DataAnnotations;

namespace AcheASaida.Entities;

//Dados de um vértice de um labirinto.
public class Vertice
{
    [Key]
    public required Guid Id { get; init; }
    public List<Vertice> Conexoes { get; private set; }
    public int Tipo { get; init; }
    public int Labirinto { get; init; }
    
    public Vertice(int tipo, int labirinto)
    {
        Id = Guid.NewGuid();
        Tipo = tipo;
        Labirinto = labirinto;
        Conexoes = [];
    }
    public Vertice(int tipo, int labirinto, List<Vertice> conexoes)
    {
        Id = Guid.NewGuid();
        Tipo = tipo;
        Labirinto = labirinto;
        Conexoes = conexoes;
    }
    
    public void AdicionarConexao(Vertice vertice)
    {
        Conexoes.Add(vertice);
    }
}