using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Modelos;

[Table("Notificacion")]
public partial class Notificacion
{
    [Key]
    public int IdNotificacion { get; set; }

    public int IdUsuario { get; set; }

    [StringLength(120)]
    public string Titulo { get; set; } = null!;

    [StringLength(500)]
    public string Mensaje { get; set; } = null!;

    [StringLength(30)]
    public string Tipo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public bool Leida { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Notificacions")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
