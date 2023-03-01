﻿// <auto-generated />
using System;
using BirthdayTekken.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BirthdayTekken.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BirthdayTekken.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Champion")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TournamentsWon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("BirthdayTekken.Models.Participant_MatchMaker", b =>
                {
                    b.Property<int>("MatchMakerId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.HasKey("MatchMakerId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("MatchMakers");
                });

            modelBuilder.Entity("BirthdayTekken.Models.Participant_Tournament", b =>
                {
                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Participants_Tournaments");
                });

            modelBuilder.Entity("BirthdayTekken.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayersNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("TournamentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("BirthdayTekken.Models.ViewModel.MatchMaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BirthdayTekken.Models.Participant_MatchMaker", b =>
                {
                    b.HasOne("BirthdayTekken.Models.ViewModel.MatchMaker", "MatchMaker")
                        .WithMany("Participant_MatchMakers")
                        .HasForeignKey("MatchMakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirthdayTekken.Models.Participant", "Participant")
                        .WithMany("Participant_MatchMaker")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MatchMaker");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("BirthdayTekken.Models.Participant_Tournament", b =>
                {
                    b.HasOne("BirthdayTekken.Models.Participant", "Participant")
                        .WithMany("Participant_Tournaments")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirthdayTekken.Models.Tournament", "Tournament")
                        .WithMany("Participants_Tournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("BirthdayTekken.Models.Participant", b =>
                {
                    b.Navigation("Participant_MatchMaker");

                    b.Navigation("Participant_Tournaments");
                });

            modelBuilder.Entity("BirthdayTekken.Models.Tournament", b =>
                {
                    b.Navigation("Participants_Tournaments");
                });

            modelBuilder.Entity("BirthdayTekken.Models.ViewModel.MatchMaker", b =>
                {
                    b.Navigation("Participant_MatchMakers");
                });
#pragma warning restore 612, 618
        }
    }
}
