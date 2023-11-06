﻿using System;
using System.Collections.Generic;

namespace CollectiveMomentsServerBL.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Passwrd { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime Birthday { get; set; }
}
