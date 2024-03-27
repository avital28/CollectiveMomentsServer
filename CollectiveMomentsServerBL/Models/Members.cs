using System;
using System.Collections.Generic;

namespace CollectiveMomentsServerBL.Models;

public partial class Members
{
    public int Id { get; set; }

    public int AlbumId { get; set; }

    public int UserId { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
