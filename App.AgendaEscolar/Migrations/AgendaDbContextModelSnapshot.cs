using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using App.AgendaEscolar.Services;
using App.AgendaEscolar.Data;

namespace App.AgendaEscolar.Migrations
{
    [DbContext(typeof(AgendaDbContext))]
    partial class AgendaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("App.AgendaEscolar.Data.Compromisso", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("Data");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Compromisso");
                });
        }
    }
}
