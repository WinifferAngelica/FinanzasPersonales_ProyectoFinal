using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdTransaccion", Name = "UQ__DetalleP__334B1F766C652A7D", IsUnique = true)]
public partial class DetallesPrestamo
{
    [Key]
    public int IdDetallePrestamo { get; set; }

    public int IdUsuario { get; set; }

    public int IdPrestamo { get; set; }

    public int IdTransaccion { get; set; }

    [Column(TypeName = "money")]
    public decimal MontoPagado { get; set; }

    public DateTime FechaPago { get; set; }

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [ForeignKey("IdPrestamo, IdUsuario")]
    [InverseProperty("DetallesPrestamos")]
    public virtual Prestamo Prestamo { get; set; } = null!;

    [ForeignKey("IdTransaccion, IdUsuario")]
    [InverseProperty("DetallesPrestamos")]
    public virtual Transaccione Transaccione { get; set; } = null!;
}
