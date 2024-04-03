using System;
using System.Collections.Generic;

namespace CollectiveMomentsServerBL.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Passwrd { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
