using System;
using System.Collections.Generic;

namespace CrudWebApi.Models;

public partial class Usuary
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Username { get; set; }

    public DateTime? FechaCreate { get; set; }
}
