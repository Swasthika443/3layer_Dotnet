using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int EmpAge { get; set; }

    public string Mobile { get; set; } = null!;
}
