using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdCuenta", "IdUsuario", Name = "UQ_Cuenta_IdCuenta_IdUsuario", IsUnique = true)]
public partial class Cuenta
{
    [Key]
    public int IdCuenta { get; set; }

    public int IdUsuario { get; set; }

    public int IdMoneda { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(30)]
    public string Tipo { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal SaldoInicial { get; set; }

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [ForeignKey("IdMoneda")]
    [InverseProperty("Cuenta")]
    public virtual Moneda IdMonedaNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Cuenta")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [InverseProperty("Cuenta")]
    public virtual ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();

    [InverseProperty("Cuenta")]
    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();

    [InverseProperty("Cuenta")]
    public virtual ICollection<Transferencia> TransferenciaCuenta { get; set; } = new List<Transferencia>();

    [InverseProperty("CuentaNavigation")]
    public virtual ICollection<Transferencia> TransferenciaCuentaNavigations { get; set; } = new List<Transferencia>();
}
