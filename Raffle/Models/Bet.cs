namespace Raffle.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public int toBet {  get; set; }
        public DateTime BetDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Propriedades para representar a relação "um para muitos"
        public int UserId { get; set; } // Id do usuário associado à aposta
        public User User { get; set; } // Propriedade de navegação para o usuário associado
    }
}
