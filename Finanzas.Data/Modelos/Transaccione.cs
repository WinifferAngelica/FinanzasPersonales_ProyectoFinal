using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdTransaccion", "IdUsuario", Name = "UQ_Transaccion_IdTransaccion_IdUsuario", IsUnique = true)]
public partial class Transaccione
{
    [Key]
    public int IdTransaccion { get; set; }

    public int IdUsuario { get; set; }

    public int? IdCuenta { get; set; }

    public int? IdCategoria { get; set; }

    [StringLength(120)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Monto { get; set; }

    [StringLength(30)]
    public string Tipo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [ForeignKey("IdCategoria, IdUsuario")]
    [InverseProperty("Transacciones")]
    public virtual Categoria? Categoria { get; set; }

    [ForeignKey("IdCuenta, IdUsuario")]
    [InverseProperty("Transacciones")]
    public virtual Cuenta? Cuenta { get; set; }

    [InverseProperty("Transaccione")]
    public virtual ICollection<DetallesDeuda> DetallesDeuda { get; set; } = new List<DetallesDeuda>();

    [InverseProperty("Transaccione")]
    public virtual ICollection<DetallesPrestamo> DetallesPrestamos { get; set; } = new List<DetallesPrestamo>();

    [InverseProperty("Transaccione")]
    public virtual ICollection<Deuda> Deuda { get; set; } = new List<Deuda>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Transacciones")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [InverseProperty("Transaccione")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    [InverseProperty("Transaccione")]
    public virtual ICollection<Transferencia> Transferencia { get; set; } = new List<Transferencia>();
}
