using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdPrestamo", "IdUsuario", Name = "UQ_Prestamo_IdPrestamo_IdUsuario", IsUnique = true)]
public partial class Prestamo
{
    [Key]
    public int IdPrestamo { get; set; }

    public int IdUsuario { get; set; }

    public int IdEntidad { get; set; }

    public int? IdTransaccionDesembolso { get; set; }

    [StringLength(120)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal MontoOriginal { get; set; }

    public DateOnly FechaPrestamo { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    [Column(TypeName = "money")]
    public decimal? CuotaMensual { get; set; }

    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [InverseProperty("Prestamo")]
    public virtual ICollection<DetallesPrestamo> DetallesPrestamos { get; set; } = new List<DetallesPrestamo>();

    [ForeignKey("IdEntidad, IdUsuario")]
    [InverseProperty("Prestamos")]
    public virtual Entidade Entidade { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Prestamos")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [ForeignKey("IdTransaccionDesembolso, IdUsuario")]
    [InverseProperty("Prestamos")]
    public virtual Transaccione? Transaccione { get; set; }
}
