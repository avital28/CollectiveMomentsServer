using System;
using System.Collections.Generic;

namespace CollectiveMomentsServerBL.Models;

public partial class Medium
{
    public int Id { get; set; }

    public string? Sources { get; set; }

    public bool? IsImage { get; set; }

    public bool? IsVideo { get; set; }

    public virtual ICollection<MediaItem> MediaItems { get; set; } = new List<MediaItem>();
}
