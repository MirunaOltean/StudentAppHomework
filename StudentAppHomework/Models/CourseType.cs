using System;
using System.Collections.Generic;

namespace StudentAppHomework.Models;

public partial class CourseType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
