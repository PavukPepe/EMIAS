using System;
using System.Collections.Generic;

namespace API_Emias.Models;

public partial class AdminProf
{
    public int? IdAdmin { get; set; }

    public string NameAdmin { get; set; } = null!;

    public string SurnameAdmin { get; set; } = null!;

    public string? PatronymicAdmin { get; set; }

    public string EnterPassword { get; set; } = null!;
}
