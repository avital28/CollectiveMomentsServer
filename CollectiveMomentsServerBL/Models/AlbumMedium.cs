using System;
using System.Collections.Generic;

namespace CollectiveMomentsServerBL.Models;

public partial class AlbumMedium
{
    public int Id { get; set; }

    public int Albumid { get; set; }

    public string? Mediaurl { get; set; }

    public virtual Album Album { get; set; } = null!;
}
