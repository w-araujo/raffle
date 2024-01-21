namespace Raffle.Models
{
    public class Raffle
    {
        public int Id { get; set; }
        public decimal prizeValue {  get; set; } 
        public  DateTime dataRaffle {  get; set; }
        public string result { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
