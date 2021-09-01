﻿namespace MovieDatabase.Domain.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
