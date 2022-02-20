using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GesBudgetaire.Models
{
    public partial class gestionbudgetaireContext : DbContext
    {
        public gestionbudgetaireContext()
        {
        }

        public gestionbudgetaireContext(DbContextOptions<gestionbudgetaireContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategorieOperation> CategorieOperation { get; set; }
        public virtual DbSet<Depense> Depense { get; set; }
        public virtual DbSet<Revenu> Revenu { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost; port=3306; database=gestionbudgetaire; user=root; password=david");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorieOperation>(entity =>
            {
                entity.HasKey(e => e.Idcategorie)
                    .HasName("PRIMARY");

                entity.ToTable("categorie_operation");

                entity.Property(e => e.Idcategorie)
                    .HasColumnName("idcategorie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Depense>(entity =>
            {
                entity.HasKey(e => e.Iddepense)
                    .HasName("PRIMARY");

                entity.ToTable("depense");

                entity.HasIndex(e => e.Idcategorie)
                    .HasName("idcategorie");

                entity.HasIndex(e => e.Idrevenu)
                    .HasName("idrevenu");

                entity.HasIndex(e => e.Idutilisateur)
                    .HasName("idutilisateur");

                entity.Property(e => e.Iddepense)
                    .HasColumnName("iddepense")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Idcategorie)
                    .HasColumnName("idcategorie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idrevenu)
                    .HasColumnName("idrevenu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idutilisateur)
                    .HasColumnName("idutilisateur")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Montant).HasColumnName("montant");

                entity.HasOne(d => d.IdcategorieNavigation)
                    .WithMany(p => p.Depense)
                    .HasForeignKey(d => d.Idcategorie)
                    .HasConstraintName("depense_ibfk_2");

                entity.HasOne(d => d.IdrevenuNavigation)
                    .WithMany(p => p.Depense)
                    .HasForeignKey(d => d.Idrevenu)
                    .HasConstraintName("depense_ibfk_3");

                entity.HasOne(d => d.IdutilisateurNavigation)
                    .WithMany(p => p.Depense)
                    .HasForeignKey(d => d.Idutilisateur)
                    .HasConstraintName("depense_ibfk_1");
            });

            modelBuilder.Entity<Revenu>(entity =>
            {
                entity.HasKey(e => e.Idrevenu)
                    .HasName("PRIMARY");

                entity.ToTable("revenu");

                entity.HasIndex(e => e.Idcategorie)
                    .HasName("idcategorie");

                entity.HasIndex(e => e.Idutilisateur)
                    .HasName("idutilisateur");

                entity.Property(e => e.Idrevenu)
                    .HasColumnName("idrevenu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Idcategorie)
                    .HasColumnName("idcategorie")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idutilisateur)
                    .HasColumnName("idutilisateur")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Montant).HasColumnName("montant");

                entity.HasOne(d => d.IdcategorieNavigation)
                    .WithMany(p => p.Revenu)
                    .HasForeignKey(d => d.Idcategorie)
                    .HasConstraintName("revenu_ibfk_2");

                entity.HasOne(d => d.IdutilisateurNavigation)
                    .WithMany(p => p.Revenu)
                    .HasForeignKey(d => d.Idutilisateur)
                    .HasConstraintName("revenu_ibfk_1");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.Idutilisateur)
                    .HasName("PRIMARY");

                entity.ToTable("utilisateur");

                entity.Property(e => e.Idutilisateur)
                    .HasColumnName("idutilisateur")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Statut)
                    .HasColumnName("statut")
                    .HasColumnType("char(1)");
            });
        }
    }
}
