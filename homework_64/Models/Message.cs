using System;

namespace homework_64.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}