using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CamionesBackEnd.Models;

public partial class CamionesContext : DbContext
{
    public CamionesContext()
    {
    }

    public CamionesContext(DbContextOptions<CamionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carga> Cargas { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carga>(entity =>
        {
            entity.HasKey(e => e.Idcarga).HasName("PK__Carga__D9C6E178F4588640");

            entity.ToTable("Carga");

            entity.Property(e => e.Idcarga).HasColumnName("IDCarga");
            entity.Property(e => e.Iva).HasColumnName("IVA");
            entity.Property(e => e.PrecioUnit).HasColumnName("Precio_Unit");
            entity.Property(e => e.Producto).HasMaxLength(255);
            entity.Property(e => e.SubtotalString)
                .HasMaxLength(255)
                .HasColumnName("Subtotal_String");
            entity.Property(e => e.UnidadDeMedida)
                .HasMaxLength(50)
                .HasColumnName("Unidad_de_Medida");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__Categori__70E82E281CD81779");

            entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");
            entity.Property(e => e.Nombre).HasMaxLength(127);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__Cliente__9B8553FC6771B46C");

            entity.ToTable("Cliente");

            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Condicion).HasMaxLength(255);
            entity.Property(e => e.Cuit)
                .HasMaxLength(255)
                .HasColumnName("CUIT");
            entity.Property(e => e.Domicilio).HasMaxLength(255);
            entity.Property(e => e.RazonSoc)
                .HasMaxLength(255)
                .HasColumnName("Razon_soc");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Idfactura).HasName("PK__Factura__492FE939ADAEC020");

            entity.ToTable("Factura");

            entity.Property(e => e.Idfactura).HasColumnName("IDFactura");
            entity.Property(e => e.Cuit)
                .HasMaxLength(63)
                .HasColumnName("CUIT");

            entity.HasOne(d => d.CargasNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Cargas)
                .HasConstraintName("FK__Factura__Cargas__5AEE82B9");

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Cliente)
                .HasConstraintName("FK__Factura__Cliente__59FA5E80");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Usuario)
                .HasConstraintName("FK__Factura__Usuario__59063A47");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.Idgasto).HasName("PK__Gastos__D41CA026CE7CDCD3");

            entity.Property(e => e.Idgasto).HasColumnName("IDGasto");
            entity.Property(e => e.Nombre).HasMaxLength(127);

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.Categoria)
                .HasConstraintName("FK__Gastos__Categori__4D94879B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__5231116966D8EEC1");

            entity.ToTable("Usuario");

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Condicion).HasMaxLength(255);
            entity.Property(e => e.Cuit)
                .HasMaxLength(63)
                .HasColumnName("CUIT");
            entity.Property(e => e.Domicilio).HasMaxLength(255);
            entity.Property(e => e.Razon).HasMaxLength(255);

            entity.HasOne(d => d.ViajesNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Viajes)
                .HasConstraintName("FK__Usuario__Viajes__5441852A");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Idviaje).HasName("PK__Viaje__6567E70C4EBCBA48");

            entity.ToTable("Viaje");

            entity.Property(e => e.Idviaje).HasColumnName("IDViaje");
            entity.Property(e => e.Cp).HasColumnName("CP");
            entity.Property(e => e.Final).HasMaxLength(255);
            entity.Property(e => e.Inicio).HasMaxLength(255);

            entity.HasOne(d => d.CargaNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.Carga)
                .HasConstraintName("FK__Viaje__Carga__5165187F");

            entity.HasOne(d => d.GastosNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.Gastos)
                .HasConstraintName("FK__Viaje__Gastos__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
