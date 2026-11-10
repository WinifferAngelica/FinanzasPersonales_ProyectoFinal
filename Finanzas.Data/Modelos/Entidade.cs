using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("IdEntidad", "IdUsuario", Name = "UQ_Entidad_IdEntidad_IdUsuario", IsUnique = true)]
public partial class Entidade
{
    [Key]
    public int IdEntidad { get; set; }

    public int IdUsuario { get; set; }

    [StringLength(150)]
    public string Nombre { get; set; } = null!;

    [StringLength(30)]
    public string TipoEntidad { get; set; } = null!;

    [StringLength(30)]
    public string? Identificacion { get; set; }

    [StringLength(20)]
    public string? Telefono { get; set; }

    [StringLength(150)]
    public string? Email { get; set; }

    [StringLength(250)]
    public string? Direccion { get; set; }

    [InverseProperty("Entidade")]
    public virtual ICollection<Deuda> Deuda { get; set; } = new List<Deuda>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Entidades")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [InverseProperty("Entidade")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
