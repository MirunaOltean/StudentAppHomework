﻿using System;
using System.Collections.Generic;

namespace StudentAppHomework.Models;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
