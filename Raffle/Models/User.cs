﻿namespace Raffle.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
