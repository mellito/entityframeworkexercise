using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "peso" },
                values: new object[] { new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d02"), "activdad 2", "Actividades Personales", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "peso" },
                values: new object[] { new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d1a"), "activdad 1", "Actividades Pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo", "estado" },
                values: new object[] { new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d34"), new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d02"), "Huelo feo", new DateTime(2022, 10, 25, 21, 37, 2, 9, DateTimeKind.Local).AddTicks(3433), 1, "Banarme", false });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo", "estado" },
                values: new object[] { new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d35"), new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d02"), "pagar los servicios o me los cortan", new DateTime(2022, 10, 25, 21, 37, 2, 9, DateTimeKind.Local).AddTicks(3445), 2, "Pagar servicios", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d1a"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d34"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d35"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("35452ec1-73dc-4c96-aaec-bf88f27b8d02"));
        }
    }
}
