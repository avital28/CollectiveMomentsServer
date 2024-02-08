namespace CollectiveMomentsServer.DTO_Models
{
    public class AlbumDto
    {
        public int Id { get; set; }

        public string? AlbumCover { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        public int AdminId { get; set; }

        public string? AlbumTitle { get; set; }

        public List<string> Media { get; set; } = new List<string>();  

    }
}
