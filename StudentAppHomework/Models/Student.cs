﻿using System;
using System.Collections.Generic;

namespace StudentAppHomework.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int ClassId { get; set; }

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Class Class { get; set; } = new Class();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual User User { get; set; } = new User();
}
