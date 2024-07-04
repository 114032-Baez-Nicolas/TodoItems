using System;
using System.Collections.Generic;

namespace DbFirstPrueba.ModelsDatabase;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Education { get; set; } = null!;
}
