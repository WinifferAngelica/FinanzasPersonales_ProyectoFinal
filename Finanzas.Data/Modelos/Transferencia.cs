using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdTransaccion", Name = "UQ__Transfer__334B1F76038A34D8", IsUnique = true)]
public partial class Transferencia
{
    [Key]
    public int IdTransferencia { get; set; }

    public int IdUsuario { get; set; }

    public int IdTransaccion { get; set; }

    public int IdCuentaOrigen { get; set; }

    public int IdCuentaDestino { get; set; }

    [ForeignKey("IdCuentaDestino, IdUsuario")]
    [InverseProperty("TransferenciaCuenta")]
    public virtual Cuenta Cuenta { get; set; } = null!;

    [ForeignKey("IdCuentaOrigen, IdUsuario")]
    [InverseProperty("TransferenciaCuentaNavigations")]
    public virtual Cuenta CuentaNavigation { get; set; } = null!;

    [ForeignKey("IdTransaccion, IdUsuario")]
    [InverseProperty("Transferencia")]
    public virtual Transaccione Transaccione { get; set; } = null!;
}
