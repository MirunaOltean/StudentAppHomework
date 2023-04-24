﻿using System;
using System.Collections.Generic;

namespace StudentAppHomework.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
