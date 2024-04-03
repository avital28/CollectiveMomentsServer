using System;
using System.Collections.Generic;

namespace CollectiveMomentsServerBL.Models;

public partial class MediaItem
{
    public int Id { get; set; }

    public int? AlbumId { get; set; }

    public int? MediaId { get; set; }

    public virtual Album? Album { get; set; }

    public virtual Medium? Media { get; set; }
}
