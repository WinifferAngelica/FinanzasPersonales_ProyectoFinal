using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Table("Presupuesto")]
public partial class Presupuesto
{
    [Key]
    public int IdPresupuesto { get; set; }

    public int IdUsuario { get; set; }

    public int IdCategoria { get; set; }

    public int? IdCuenta { get; set; }

    [StringLength(120)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Monto { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    [StringLength(250)]
    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    [ForeignKey("IdCategoria, IdUsuario")]
    [InverseProperty("Presupuestos")]
    public virtual Categoria Categoria { get; set; } = null!;

    [ForeignKey("IdCuenta, IdUsuario")]
    [InverseProperty("Presupuestos")]
    public virtual Cuenta? Cuenta { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Presupuestos")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
