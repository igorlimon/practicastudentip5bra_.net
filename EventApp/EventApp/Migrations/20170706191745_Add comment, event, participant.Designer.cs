using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EventApp.Data;
using EventApp.Models;

namespace EventApp.Migrations
{
    [DbContext(typeof(EventAppDbContext))]
    [Migration("20170706191745_Add comment, event, participant")]
    partial class Addcommenteventparticipant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventApp.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("EventId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EventApp.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description");

                    b.Property<string>("Gps");

                    b.Property<string>("Location");

                    b.Property<string>("PicturePath");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventApp.Models.Participant", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Discriminator");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("EventId");

                    b.Property<int>("Gender");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PicturePath");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Participants");

                    b.HasDiscriminator().HasValue("Participant");
                });

            modelBuilder.Entity("EventApp.Models.Comment", b =>
                {
                    b.HasOne("EventApp.Models.Event", "Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("EventApp.Models.Participant", b =>
                {
                    b.HasOne("EventApp.Models.Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId");
                });
        }
    }
}
