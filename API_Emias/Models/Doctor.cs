using System;
using System.Collections.Generic;

namespace API_Emias.Models;

public partial class Doctor
{
    public int? IdDoctor { get; set; }

    public string NameDoctor { get; set; } = null!;

    public string SurnameDoctor { get; set; } = null!;

    public string? PatronymicDoctor { get; set; }

    public int IdSpeciality { get; set; }

    public string EnterPassword { get; set; } = null!;

    public string WorkAddress { get; set; } = null!;

}
