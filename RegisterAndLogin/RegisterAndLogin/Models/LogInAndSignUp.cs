using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegisterAndLogin.Models;

public partial class LogInAndSignUp
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
