using System.ComponentModel.DataAnnotations;

namespace AcheASaida.Entities
{
    public class InfoLabirinto
    {
        [Required][Key]
        public int IdLabirinto { get; init; }
        public Guid GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        [Required][StringLength(50, ErrorMessage = "A dificuldade não pode ter mais que 50 caracteres.")]
        public string Dificuldade { get; private set; }
        public bool Completo { get; private set; } = false;
        public int Passos { get; private set; } = 0;
        public decimal PorcentagemExploracao { get; private set; } = 0.0M;

        private InfoLabirinto(int idLabirinto, string dificuldade)
        {
            IdLabirinto = idLabirinto;
            Dificuldade = dificuldade;
        }

        public void MudarDificuldade(string novaDificuldade)
        {
            Dificuldade = novaDificuldade;
        }
        
        public void MarcarComoCompleto()
        {
            Completo = true;
        }
        
        public void IncrementarPassos()
        {
            Passos++;
        }
        
        public void AtualizarPorcentagemExploracao(decimal porcentagem)
        {
            PorcentagemExploracao = porcentagem;
        }
        
        public void ResetarInfo()
        {
            Completo = false;
            Passos = 0;
            PorcentagemExploracao = 0.0M;
        }
    }
}