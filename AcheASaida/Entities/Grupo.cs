namespace AcheASaida.Entities;

//Dados de um grupo de jogadores.
public class Grupo
{
    public required Guid Id { get; init;}
    public string Nome { get; init;}
    public int Pontuacao { get; set; } = 0;
    public List<int> LabirintosConcluidos { get; set; } = [];
    public int QtdLabirintosConcluidos { get; set; } = 0;
    public decimal MediaExploracao { get; set; } = 0.0M;
    public decimal MediaPassos { get; set; } = 0.0M;
    public List<InfoLabirinto> Informacoes { get; set; } = [];

    public Grupo(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }
}