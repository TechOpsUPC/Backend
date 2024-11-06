﻿namespace zenflicks_backend.content.Interfaces.REST.Resources
{
    public class ContentResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public TimeSpan Duration { get; set; }
    }
}