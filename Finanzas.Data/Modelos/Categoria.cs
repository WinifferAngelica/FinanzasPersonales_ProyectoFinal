using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdCategoria", "IdUsuario", Name = "UQ_Categoria_IdCategoria_IdUsuario", IsUnique = true)]
[Index("IdUsuario", "Nombre", "Tipo", Name = "UQ_Categoria_Nombre_Usuario_Tipo", IsUnique = true)]
public partial class Categoria
{
    [Key]
    public int IdCategoria { get; set; }

    public int IdUsuario { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    public bool Tipo { get; set; }

    [StringLength(250)]
    public string? Descripcion { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Categoria")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [InverseProperty("Categoria")]
    public virtual ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();

    [InverseProperty("Categoria")]
    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
