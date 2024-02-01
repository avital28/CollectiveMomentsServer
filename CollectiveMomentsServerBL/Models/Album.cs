using System;
using System.Collections.Generic;

namespace CollectiveMomentsServerBL.Models;

public partial class Album
{
    public int Id { get; set; }

    public string? AlbumCover { get; set; }

    public string? Longitude { get; set; }

    public string? Latitude { get; set; }

    public int AdminId { get; set; }

    public string? AlbumTitle { get; set; }

    public virtual ICollection<AlbumMedium> AlbumMedia { get; set; } = new List<AlbumMedium>();
}
