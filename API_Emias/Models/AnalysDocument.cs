using System;
using System.Collections.Generic;

namespace API_Emias.Models;

public partial class AnalysDocument
{
    public int IdAppointment { get; set; }

    public string Rtf { get; set; } = null!;

}
