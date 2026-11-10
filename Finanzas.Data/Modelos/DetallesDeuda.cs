using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdTransaccion", Name = "UQ__Detalles__334B1F765E15E43E", IsUnique = true)]
public partial class DetallesDeuda
{
    [Key]
    public int IdDetalleDeuda { get; set; }

    public int IdUsuario { get; set; }

    public int IdDeuda { get; set; }

    public int IdTransaccion { get; set; }

    [Column(TypeName = "money")]
    public decimal MontoPagado { get; set; }

    public DateTime FechaPago { get; set; }

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [ForeignKey("IdDeuda, IdUsuario")]
    [InverseProperty("DetallesDeuda")]
    public virtual Deuda Deuda { get; set; } = null!;

    [ForeignKey("IdTransaccion, IdUsuario")]
    [InverseProperty("DetallesDeuda")]
    public virtual Transaccione Transaccione { get; set; } = null!;
}
