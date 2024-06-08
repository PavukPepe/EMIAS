using System;
using System.Collections.Generic;

namespace API_Emias.Models;

public partial class Patient
{
    public long? Oms { get; set; }

    public string NamePatient { get; set; } = null!;

    public string SurnamePatient { get; set; } = null!;

    public string? PatronymicPatient { get; set; }

    public DateOnly BirthDate { get; set; }

    public string AddressPatient { get; set; } = null!;

    public string? LivingAddress { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Nickname { get; set; }

}
