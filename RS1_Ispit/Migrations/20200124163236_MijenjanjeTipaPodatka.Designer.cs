﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RS1_Ispit_asp.net_core.EF;

namespace RS1_Ispit_asp.net_core.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20200124163236_MijenjanjeTipaPodatka")]
    partial class MijenjanjeTipaPodatka
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.DodjeljenPredmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OdjeljenjeStavkaId")
                        .HasColumnType("int");

                    b.Property<int>("PredmetId")
                        .HasColumnType("int");

                    b.Property<int>("ZakljucnoKrajGodine")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OdjeljenjeStavkaId");

                    b.HasIndex("PredmetId");

                    b.ToTable("DodjeljenPredmet");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.MaturskiIspit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIspita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NastavnikID")
                        .HasColumnType("int");

                    b.Property<int>("PredmetID")
                        .HasColumnType("int");

                    b.Property<int>("SkolaID")
                        .HasColumnType("int");

                    b.Property<int>("SkolskaGodinaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NastavnikID");

                    b.HasIndex("PredmetID");

                    b.HasIndex("SkolaID");

                    b.HasIndex("SkolskaGodinaID");

                    b.ToTable("MaturskiIspit");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.MaturskiIspitUcenik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BrojBodova")
                        .HasColumnType("float");

                    b.Property<int>("MaturskiIspitID")
                        .HasColumnType("int");

                    b.Property<bool>("PristupioMaturskomIspitu")
                        .HasColumnType("bit");

                    b.Property<int>("UcenikID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MaturskiIspitID");

                    b.HasIndex("UcenikID");

                    b.ToTable("MaturskiIspitUcenik");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nastavnik");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Odjeljenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPrebacenuViseOdjeljenje")
                        .HasColumnType("bit");

                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Razred")
                        .HasColumnType("int");

                    b.Property<int>("RazrednikID")
                        .HasColumnType("int");

                    b.Property<int>("SkolaID")
                        .HasColumnType("int");

                    b.Property<int>("SkolskaGodinaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RazrednikID");

                    b.HasIndex("SkolaID");

                    b.HasIndex("SkolskaGodinaID");

                    b.ToTable("Odjeljenje");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.OdjeljenjeStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojUDnevniku")
                        .HasColumnType("int");

                    b.Property<int>("OdjeljenjeId")
                        .HasColumnType("int");

                    b.Property<int>("UcenikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OdjeljenjeId");

                    b.HasIndex("UcenikId");

                    b.ToTable("OdjeljenjeStavka");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PredajePredmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NastavnikID")
                        .HasColumnType("int");

                    b.Property<int>("OdjeljenjeID")
                        .HasColumnType("int");

                    b.Property<int>("PredmetID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NastavnikID");

                    b.HasIndex("OdjeljenjeID");

                    b.HasIndex("PredmetID");

                    b.ToTable("PredajePredmet");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Razred")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Skola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skola");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.SkolskaGodina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktuelna")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SkolskaGodina");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Ucenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImePrezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ucenik");
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.DodjeljenPredmet", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.OdjeljenjeStavka", "OdjeljenjeStavka")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeStavkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.MaturskiIspit", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Skola", "Skola")
                        .WithMany()
                        .HasForeignKey("SkolaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.SkolskaGodina", "SkolskaGodina")
                        .WithMany()
                        .HasForeignKey("SkolskaGodinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.MaturskiIspitUcenik", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.MaturskiIspit", "MaturskiIspit")
                        .WithMany()
                        .HasForeignKey("MaturskiIspitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Ucenik", "Ucenik")
                        .WithMany()
                        .HasForeignKey("UcenikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.Odjeljenje", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "Razrednik")
                        .WithMany()
                        .HasForeignKey("RazrednikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Skola", "Skola")
                        .WithMany()
                        .HasForeignKey("SkolaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.SkolskaGodina", "SkolskaGodina")
                        .WithMany()
                        .HasForeignKey("SkolskaGodinaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.OdjeljenjeStavka", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Odjeljenje", "Odjeljenje")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Ucenik", "Ucenik")
                        .WithMany()
                        .HasForeignKey("UcenikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Ispit_asp.net_core.EntityModels.PredajePredmet", b =>
                {
                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Odjeljenje", "Odjeljenje")
                        .WithMany()
                        .HasForeignKey("OdjeljenjeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RS1_Ispit_asp.net_core.EntityModels.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
