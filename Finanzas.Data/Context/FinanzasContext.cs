using System;
using System.Collections.Generic;
using Finanzas.Data.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.Context;

public partial class FinanzasContext : DbContext
{
    public FinanzasContext(DbContextOptions<FinanzasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<DetallesDeuda> DetallesDeudas { get; set; }

    public virtual DbSet<DetallesPrestamo> DetallesPrestamos { get; set; }

    public virtual DbSet<Deuda> Deudas { get; set; }

    public virtual DbSet<Entidade> Entidades { get; set; }

    public virtual DbSet<Moneda> Monedas { get; set; }

    public virtual DbSet<Notificacion> Notificacions { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Presupuesto> Presupuestos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Transferencia> Transferencias { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10DEE77944");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categoria_Usuario");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__Cuenta__D41FD7068A123FD4");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Cuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_Moneda");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_Usuario");
        });

        modelBuilder.Entity<DetallesDeuda>(entity =>
        {
            entity.HasKey(e => e.IdDetalleDeuda).HasName("PK__Detalles__BBE9846B937613C5");

            entity.Property(e => e.FechaPago).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Deuda).WithMany(p => p.DetallesDeuda)
                .HasPrincipalKey(p => new { p.IdDeuda, p.IdUsuario })
                .HasForeignKey(d => new { d.IdDeuda, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleDeuda_Deuda");

            entity.HasOne(d => d.Transaccione).WithMany(p => p.DetallesDeuda)
                .HasPrincipalKey(p => new { p.IdTransaccion, p.IdUsuario })
                .HasForeignKey(d => new { d.IdTransaccion, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleDeuda_Transaccion");
        });

        modelBuilder.Entity<DetallesPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdDetallePrestamo).HasName("PK__DetalleP__D07748AA0AF84946");

            entity.Property(e => e.FechaPago).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Prestamo).WithMany(p => p.DetallesPrestamos)
                .HasPrincipalKey(p => new { p.IdPrestamo, p.IdUsuario })
                .HasForeignKey(d => new { d.IdPrestamo, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePrestamo_Prestamo");

            entity.HasOne(d => d.Transaccione).WithMany(p => p.DetallesPrestamos)
                .HasPrincipalKey(p => new { p.IdTransaccion, p.IdUsuario })
                .HasForeignKey(d => new { d.IdTransaccion, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePrestamo_Transaccion");
        });

        modelBuilder.Entity<Deuda>(entity =>
        {
            entity.HasKey(e => e.IdDeuda).HasName("PK__Deudas__7F8C86B1C8F478AF");

            entity.Property(e => e.Estado).HasDefaultValue("Activa");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Deuda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deuda_Usuario");

            entity.HasOne(d => d.Entidade).WithMany(p => p.Deuda)
                .HasPrincipalKey(p => new { p.IdEntidad, p.IdUsuario })
                .HasForeignKey(d => new { d.IdEntidad, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deuda_Entidad");

            entity.HasOne(d => d.Transaccione).WithMany(p => p.Deuda)
                .HasPrincipalKey(p => new { p.IdTransaccion, p.IdUsuario })
                .HasForeignKey(d => new { d.IdTransaccionDesembolso, d.IdUsuario })
                .HasConstraintName("FK_Deuda_Transaccion");
        });

        modelBuilder.Entity<Entidade>(entity =>
        {
            entity.HasKey(e => e.IdEntidad).HasName("PK__Entidad__7D662868996D7795");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Entidades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entidad_Usuario");
        });

        modelBuilder.Entity<Moneda>(entity =>
        {
            entity.HasKey(e => e.IdMoneda).HasName("PK__Moneda__AA690671AE391316");

            entity.Property(e => e.Activa).HasDefaultValue(true);
            entity.Property(e => e.Codigo).IsFixedLength();
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__F6CA0A851D465352");

            entity.Property(e => e.Fecha).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notificacion_Usuario");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__6FF194C0CEEE060D");

            entity.Property(e => e.Estado).HasDefaultValue("Activo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamo_Usuario");

            entity.HasOne(d => d.Entidade).WithMany(p => p.Prestamos)
                .HasPrincipalKey(p => new { p.IdEntidad, p.IdUsuario })
                .HasForeignKey(d => new { d.IdEntidad, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamo_Entidad");

            entity.HasOne(d => d.Transaccione).WithMany(p => p.Prestamos)
                .HasPrincipalKey(p => new { p.IdTransaccion, p.IdUsuario })
                .HasForeignKey(d => new { d.IdTransaccionDesembolso, d.IdUsuario })
                .HasConstraintName("FK_Prestamo_Transaccion");
        });

        modelBuilder.Entity<Presupuesto>(entity =>
        {
            entity.HasKey(e => e.IdPresupuesto).HasName("PK__Presupue__D70FD19016A84619");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Presupuestos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Presupuesto_Usuario");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Presupuestos)
                .HasPrincipalKey(p => new { p.IdCategoria, p.IdUsuario })
                .HasForeignKey(d => new { d.IdCategoria, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Presupuesto_Categoria");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Presupuestos)
                .HasPrincipalKey(p => new { p.IdCuenta, p.IdUsuario })
                .HasForeignKey(d => new { d.IdCuenta, d.IdUsuario })
                .HasConstraintName("FK_Presupuesto_Cuenta");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.IdRol).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion).HasName("PK__Transacc__334B1F771074072E");

            entity.Property(e => e.Estado).HasDefaultValue("Completada");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Transacciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaccion_Usuario");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Transacciones)
                .HasPrincipalKey(p => new { p.IdCategoria, p.IdUsuario })
                .HasForeignKey(d => new { d.IdCategoria, d.IdUsuario })
                .HasConstraintName("FK_Transaccion_Categoria");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Transacciones)
                .HasPrincipalKey(p => new { p.IdCuenta, p.IdUsuario })
                .HasForeignKey(d => new { d.IdCuenta, d.IdUsuario })
                .HasConstraintName("FK_Transaccion_Cuenta");
        });

        modelBuilder.Entity<Transferencia>(entity =>
        {
            entity.HasKey(e => e.IdTransferencia).HasName("PK__Transfer__6E5969ECD07167FB");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.TransferenciaCuenta)
                .HasPrincipalKey(p => new { p.IdCuenta, p.IdUsuario })
                .HasForeignKey(d => new { d.IdCuentaDestino, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transferencia_CuentaDestino");

            entity.HasOne(d => d.CuentaNavigation).WithMany(p => p.TransferenciaCuentaNavigations)
                .HasPrincipalKey(p => new { p.IdCuenta, p.IdUsuario })
                .HasForeignKey(d => new { d.IdCuentaOrigen, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transferencia_CuentaOrigen");

            entity.HasOne(d => d.Transaccione).WithMany(p => p.Transferencia)
                .HasPrincipalKey(p => new { p.IdTransaccion, p.IdUsuario })
                .HasForeignKey(d => new { d.IdTransaccion, d.IdUsuario })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transferencia_Transaccion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_Usuario");

            entity.Property(e => e.Estado).HasDefaultValue(true, "DF_Usuario_Estado");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())", "DF_Usuario_FechaRegistro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
