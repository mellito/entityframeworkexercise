// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectoef;

#nullable disable

namespace proyectoef.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20221026023702_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d1a"),
                            Descripcion = "activdad 1",
                            Nombre = "Actividades Pendientes",
                            peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d02"),
                            Descripcion = "activdad 2",
                            Nombre = "Actividades Personales",
                            peso = 50
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d34"),
                            CategoriaId = new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d02"),
                            Descripcion = "Huelo feo",
                            FechaCreacion = new DateTime(2022, 10, 25, 21, 37, 2, 9, DateTimeKind.Local).AddTicks(3433),
                            PrioridadTarea = 1,
                            Titulo = "Banarme",
                            estado = false
                        },
                        new
                        {
                            TareaId = new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d35"),
                            CategoriaId = new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d02"),
                            Descripcion = "pagar los servicios o me los cortan",
                            FechaCreacion = new DateTime(2022, 10, 25, 21, 37, 2, 9, DateTimeKind.Local).AddTicks(3445),
                            PrioridadTarea = 2,
                            Titulo = "Pagar servicios",
                            estado = true
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.HasOne("proyectoef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
