using System;
using System.Collections.Generic;

namespace CollectiveMomentsServerBL.Models;

public partial class Member
{
    public int Id { get; set; }

    public int? AlbumId { get; set; }

    public int? UserId { get; set; }

    public virtual Album? Album { get; set; }

    public virtual User? User { get; set; }
}
