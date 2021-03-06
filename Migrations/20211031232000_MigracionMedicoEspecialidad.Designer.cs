// <auto-generated />
using System;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20211031232000_MigracionMedicoEspecialidad")]
    partial class MigracionMedicoEspecialidad
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hospital.Models.Especialidad", b =>
                {
                    b.Property<int>("IdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdEspecialidad");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("Hospital.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("HorarioAtencionDesde")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HorarioAtencionHasta")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdMedico");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("Hospital.Models.MedicoEspecialidad", b =>
                {
                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int>("IdEspecialidad")
                        .HasColumnType("int");

                    b.HasKey("IdMedico", "IdEspecialidad");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("MedicoEspecialidad");
                });

            modelBuilder.Entity("Hospital.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdPaciente");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Hospital.Models.MedicoEspecialidad", b =>
                {
                    b.HasOne("Hospital.Models.Especialidad", "Especialidad")
                        .WithMany("MedicoEspecialidad")
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Medico", "Medico")
                        .WithMany("MedicoEspecialidad")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("Hospital.Models.Especialidad", b =>
                {
                    b.Navigation("MedicoEspecialidad");
                });

            modelBuilder.Entity("Hospital.Models.Medico", b =>
                {
                    b.Navigation("MedicoEspecialidad");
                });
#pragma warning restore 612, 618
        }
    }
}
