using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Keyless]
[Index("IdRol", "Nombre", Name = "IX_Roles", IsUnique = true)]
public partial class Role
{
    public int IdRol { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;
}
