﻿namespace WebApplication2.Entities
{
    public class Footballer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}
