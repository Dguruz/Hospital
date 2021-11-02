using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        public DbSet<Especialidad> Especialidad { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Turno> Turno { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidad");
                entidad.HasKey(e => e.IdEspecialidad);
                entidad.Property(d => d.Descripccion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entidad =>
           {
               entidad.ToTable("Paciente");
               entidad.HasKey(p => p.IdPaciente);

               entidad.Property(p => p.Nombre).
               IsRequired().
               HasMaxLength(50).
               IsUnicode(false);

               entidad.Property(p => p.Apellido).
               IsRequired().
               HasMaxLength(50).
               IsUnicode(false);

               entidad.Property(p => p.Direccion).
               IsRequired().
               HasMaxLength(150).
               IsUnicode(false);

               entidad.Property(p => p.Telefono).
               IsRequired().
               HasMaxLength(20).
               IsUnicode(false);

               entidad.Property(p => p.Email).
               IsRequired().
               HasMaxLength(100).
               IsUnicode(false);
           });

            modelBuilder.Entity<Medico>(entidad =>
                 {
                     entidad.ToTable("Medico");
                     entidad.HasKey(m => m.IdMedico);

                     entidad.Property(m => m.Nombre)
                     .IsRequired()
                     .HasMaxLength(50).
                     IsUnicode(false);

                     entidad.Property(m => m.Apellido)
                     .IsRequired()
                     .HasMaxLength(50).
                     IsUnicode(false);

                     entidad.Property(m => m.Direccion)
                     .IsRequired()
                     .HasMaxLength(250).
                     IsUnicode(false);

                     entidad.Property(m => m.Telefono)
                     .IsRequired()
                     .HasMaxLength(20).
                     IsUnicode(false);

                     entidad.Property(m => m.Email)
                     .IsRequired()
                     .HasMaxLength(50).
                      IsUnicode(false);

                     entidad.Property(m => m.HorarioAtencionDesde)
                    .IsRequired()
                    .IsUnicode(false);

                     entidad.Property(m => m.HorarioAtencionHasta)
                      .IsRequired()
                      .IsUnicode(false);
                 }
             );

            modelBuilder.Entity<Turno>(entidad =>
                {
                    entidad.ToTable("Turno");
                    entidad.HasKey(m => m.IdTurno);

                    entidad.Property(m => m.IdPaciente)
                    .IsRequired().IsUnicode(false);

                    entidad.Property(m => m.IdMedico)
                    .IsRequired().IsUnicode(false);

                    entidad.Property(m => m.FechaHoraInicio)
                   .IsRequired()
                   .IsUnicode(false);

                    entidad.Property(m => m.FechaHoraFin)
                     .IsRequired()
                     .IsUnicode(false);
                }
            );

            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspecialidad });

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdMedico);

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdEspecialidad);

            modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
            .WithMany(p => p.Turno)
            .HasForeignKey(p => p.IdPaciente);

            modelBuilder.Entity<Turno>().HasOne(x => x.Medico)
            .WithMany(p => p.Turno)
            .HasForeignKey(p => p.IdMedico);
        }


    }
}