using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdDeuda", "IdUsuario", Name = "UQ_Deuda_IdDeuda_IdUsuario", IsUnique = true)]
public partial class Deuda
{
    [Key]
    public int IdDeuda { get; set; }

    public int IdUsuario { get; set; }

    public int IdEntidad { get; set; }

    public int? IdTransaccionDesembolso { get; set; }

    [StringLength(120)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal MontoOriginal { get; set; }

    public DateOnly FechaDeuda { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    [Column(TypeName = "money")]
    public decimal? CuotaMensual { get; set; }

    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [InverseProperty("Deuda")]
    public virtual ICollection<DetallesDeuda> DetallesDeuda { get; set; } = new List<DetallesDeuda>();

    [ForeignKey("IdEntidad, IdUsuario")]
    [InverseProperty("Deuda")]
    public virtual Entidade Entidade { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Deuda")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [ForeignKey("IdTransaccionDesembolso, IdUsuario")]
    [InverseProperty("Deuda")]
    public virtual Transaccione? Transaccione { get; set; }
}
