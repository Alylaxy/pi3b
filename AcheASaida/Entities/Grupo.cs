using System.ComponentModel.DataAnnotations;

namespace AcheASaida.Entities;

//Dados de um grupo de jogadores.
public class Grupo
{
    [Key]
    public required Guid Id { get; init;}
    [StringLength(50, ErrorMessage = "O nome do grupo não pode ter mais que 50 caracteres.")]  
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
    
    public void AdicionarPotuacao(int pontuacao)
    {
        Pontuacao = pontuacao;
    }
    
    public void AdicionarLabirintoConcluido(int idLabirinto)
    {
        LabirintosConcluidos.Add(idLabirinto);
        QtdLabirintosConcluidos = LabirintosConcluidos.Count;
    }

    public void AdicionarInfoLabirinto(InfoLabirinto info)
    {
        Informacoes.Add(info);
        AtualizarMedias();
    }
    
    public void AtualizarMedias()
    {
        MediaExploracao = Informacoes.Average(i => (decimal)i.PorcentagemExploracao);
        MediaPassos = Informacoes.Average(i => (decimal)i.Passos);
    }
}