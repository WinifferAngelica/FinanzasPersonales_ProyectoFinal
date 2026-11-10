using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Index("Email", Name = "UQ_Usuario_Email", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [StringLength(100)]
    public string Nombres { get; set; } = null!;

    [StringLength(100)]
    public string Apellidos { get; set; } = null!;

    [StringLength(254)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string PasswordHash { get; set; } = null!;

    [Precision(0)]
    public DateTime FechaRegistro { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Categoria> Categoria { get; set; } = new List<Categoria>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Deuda> Deuda { get; set; } = new List<Deuda>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Entidade> Entidades { get; set; } = new List<Entidade>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
