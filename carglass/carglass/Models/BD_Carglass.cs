namespace carglass.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BD_Carglass : DbContext
    {
        public BD_Carglass()
            : base("name=BD_Carglass")
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<FornecedorPF> FornecedorPF { get; set; }
        public virtual DbSet<Telefone_Fornecedor> Telefone_Fornecedor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .Property(e => e.UF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.NOME_FANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.CNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Fornecedor)
                .WithRequired(e => e.Empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.CPFCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .HasOptional(e => e.FornecedorPF)
                .WithRequired(e => e.Fornecedor);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(e => e.Telefone_Fornecedor)
                .WithRequired(e => e.Fornecedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FornecedorPF>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<Telefone_Fornecedor>()
                .Property(e => e.DDD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Telefone_Fornecedor>()
                .Property(e => e.TELEFONE)
                .IsUnicode(false);
        }
    }
}
