﻿// <auto-generated />
using System;
using ClinicaVeterinaria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicaVeterinaria.Migrations
{
    [DbContext(typeof(ClinicaContainer))]
    [Migration("20240616225934_CorreccionTBCliente")]
    partial class CorreccionTBCliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicaVeterinaria.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Apellidos2")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CodigoCliente")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("N_Identificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Colores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoColor")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Colores", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoConsulta")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("DescripcionCita")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DescripcionConsulta")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaConsulta")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MascotaId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Consultas", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.DetalleConsulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aplicacion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ConsultaId")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicamentosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultaId");

                    b.HasIndex("MedicamentosId");

                    b.ToTable("DetalleConsulta", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Especialidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CodigoEspecialidad")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Especialidad", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.EspecialidadesVeterinarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<string>("TituloObtenido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("EspecialidadVeterinario", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Especie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoEspecie")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Especie", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoMascota")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("EspecieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("PesoActual")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EspecieId");

                    b.ToTable("Mascota", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.MascotaColores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColoresId")
                        .HasColumnType("int");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColoresId");

                    b.HasIndex("MascotaId");

                    b.ToTable("MascotaColores", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Medicamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoVacuna")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TipoMedicamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoMedicamentoId");

                    b.ToTable("Medicamento", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Raza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoRaza")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Raza", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.RazaMascotas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int>("RazaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.HasIndex("RazaId");

                    b.ToTable("RazaMascota", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.TipoMedicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoTipo")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoMedicamento", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Apellidos2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CodigoVeterinario")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Veterinario", "CV");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Consulta", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Cliente", "Cliente")
                        .WithMany("Consulta")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Mascota", "Mascota")
                        .WithMany("Consulta")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Veterinario", "Veterinario")
                        .WithMany("Consulta")
                        .HasForeignKey("VeterinarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Mascota");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.DetalleConsulta", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Consulta", "Consulta")
                        .WithMany("DetalleConsulta")
                        .HasForeignKey("ConsultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Medicamentos", "Medicamentos")
                        .WithMany("DetalleConsulta")
                        .HasForeignKey("MedicamentosId");

                    b.Navigation("Consulta");

                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.EspecialidadesVeterinarios", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Especialidad", "Especialidad")
                        .WithMany("EspecialidadesVeterinarios")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Veterinario", "Veterinario")
                        .WithMany("EspecialidadesVeterinarios")
                        .HasForeignKey("VeterinarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Mascota", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Especie", "Especie")
                        .WithMany("Mascota")
                        .HasForeignKey("EspecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.MascotaColores", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Colores", "Colores")
                        .WithMany("MascotaColores")
                        .HasForeignKey("ColoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Mascota", "Mascota")
                        .WithMany("MascotaColores")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colores");

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Medicamentos", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.TipoMedicamento", "TipoMedicamento")
                        .WithMany("Medicamentos")
                        .HasForeignKey("TipoMedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoMedicamento");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.RazaMascotas", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Mascota", "Mascota")
                        .WithMany("RazaMascotas")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Raza", "Raza")
                        .WithMany("RazaMascotas")
                        .HasForeignKey("RazaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");

                    b.Navigation("Raza");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Cliente", b =>
                {
                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Colores", b =>
                {
                    b.Navigation("MascotaColores");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Consulta", b =>
                {
                    b.Navigation("DetalleConsulta");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Especialidad", b =>
                {
                    b.Navigation("EspecialidadesVeterinarios");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Especie", b =>
                {
                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Mascota", b =>
                {
                    b.Navigation("Consulta");

                    b.Navigation("MascotaColores");

                    b.Navigation("RazaMascotas");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Medicamentos", b =>
                {
                    b.Navigation("DetalleConsulta");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Raza", b =>
                {
                    b.Navigation("RazaMascotas");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.TipoMedicamento", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Veterinario", b =>
                {
                    b.Navigation("Consulta");

                    b.Navigation("EspecialidadesVeterinarios");
                });
#pragma warning restore 612, 618
        }
    }
}
