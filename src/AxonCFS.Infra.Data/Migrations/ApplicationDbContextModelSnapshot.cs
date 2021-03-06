// <auto-generated />
using System;
using AxonCFS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AxonCFS.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AxonCFS.Domain.Models.Agency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Tstamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Agency");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eff6a082-31e3-412b-b661-bd340eab29b6"),
                            Code = "Agency1"
                        },
                        new
                        {
                            Id = new Guid("4b63867c-e27c-41da-9c06-5e10817c1266"),
                            Code = "Agency2"
                        });
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.AgencyUser", b =>
                {
                    b.Property<Guid>("AgencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AgencyId", "UserId");

                    b.ToTable("AgencyUser");

                    b.HasData(
                        new
                        {
                            AgencyId = new Guid("eff6a082-31e3-412b-b661-bd340eab29b6"),
                            UserId = "1"
                        },
                        new
                        {
                            AgencyId = new Guid("4b63867c-e27c-41da-9c06-5e10817c1266"),
                            UserId = "2"
                        });
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DispatchTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResponderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Tstamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResponderId");

                    b.HasIndex("TypeId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Tstamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.Responder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Tstamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.ToTable("Responder");
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.AgencyUser", b =>
                {
                    b.HasOne("AxonCFS.Domain.Models.Agency", "Agency")
                        .WithMany("AgencyUsers")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.Event", b =>
                {
                    b.HasOne("AxonCFS.Domain.Models.Responder", "Responder")
                        .WithMany("Events")
                        .HasForeignKey("ResponderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AxonCFS.Domain.Models.EventType", "Type")
                        .WithMany("Events")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responder");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.Responder", b =>
                {
                    b.HasOne("AxonCFS.Domain.Models.Agency", "Agency")
                        .WithMany("Responders")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.Agency", b =>
                {
                    b.Navigation("AgencyUsers");

                    b.Navigation("Responders");
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("AxonCFS.Domain.Models.Responder", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
