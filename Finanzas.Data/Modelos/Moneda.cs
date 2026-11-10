using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("Codigo", Name = "UQ__Moneda__06370DAC3FF418C6", IsUnique = true)]
public partial class Moneda
{
    [Key]
    public int IdMoneda { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(5)]
    public string Simbolo { get; set; } = null!;

    public bool Activa { get; set; }

    [InverseProperty("IdMonedaNavigation")]
    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}
