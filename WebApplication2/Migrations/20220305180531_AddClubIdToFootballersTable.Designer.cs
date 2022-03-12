﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Entities;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(TiproomDbContext))]
    [Migration("20220305180531_AddClubIdToFootballersTable")]
    partial class AddClubIdToFootballersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LeagueUser", b =>
                {
                    b.Property<int>("LeaguesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("LeaguesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("LeagueUser");
                });

            modelBuilder.Entity("WebApplication2.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nameclub")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("WebApplication2.Entities.Footballer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Footballers");
                });

            modelBuilder.Entity("WebApplication2.Entities.Footballer_stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FootballerId")
                        .HasColumnType("int");

                    b.Property<int>("If_cleansheet")
                        .HasColumnType("int");

                    b.Property<int>("If_goal")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FootballerId");

                    b.HasIndex("MatchId");

                    b.ToTable("Footballer_stats");
                });

            modelBuilder.Entity("WebApplication2.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Creation_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("League_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("WebApplication2.Entities.League_founder", b =>
                {
                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("FounderId")
                        .HasColumnType("int");

                    b.HasKey("LeagueId", "FounderId");

                    b.HasIndex("FounderId");

                    b.ToTable("League_founders");
                });

            modelBuilder.Entity("WebApplication2.Entities.League_score", b =>
                {
                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("LeagueId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("League_scores");
                });

            modelBuilder.Entity("WebApplication2.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AwayId")
                        .HasColumnType("int");

                    b.Property<int>("Gameweek")
                        .HasColumnType("int");

                    b.Property<int>("Goal_away")
                        .HasColumnType("int");

                    b.Property<int>("Goal_home")
                        .HasColumnType("int");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayId");

                    b.HasIndex("HomeId");

                    b.ToTable("Matchs");
                });

            modelBuilder.Entity("WebApplication2.Entities.Odd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<double>("Odd_away")
                        .HasColumnType("float");

                    b.Property<double>("Odd_cleansheet")
                        .HasColumnType("float");

                    b.Property<double>("Odd_draw")
                        .HasColumnType("float");

                    b.Property<double>("Odd_goal_defender")
                        .HasColumnType("float");

                    b.Property<double>("Odd_goal_forward")
                        .HasColumnType("float");

                    b.Property<double>("Odd_goal_midfielder")
                        .HasColumnType("float");

                    b.Property<double>("Odd_home")
                        .HasColumnType("float");

                    b.Property<double>("Odd_over2")
                        .HasColumnType("float");

                    b.Property<double>("Odd_under2")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Odds");
                });

            modelBuilder.Entity("WebApplication2.Entities.Tip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DefenderId")
                        .HasColumnType("int");

                    b.Property<int>("ForwardId")
                        .HasColumnType("int");

                    b.Property<int>("Goal_count")
                        .HasColumnType("int");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("MidfielderId")
                        .HasColumnType("int");

                    b.Property<int>("Tip_goal_away")
                        .HasColumnType("int");

                    b.Property<int>("Tip_goal_defenderId")
                        .HasColumnType("int");

                    b.Property<int>("Tip_goal_forwardId")
                        .HasColumnType("int");

                    b.Property<int>("Tip_goal_home")
                        .HasColumnType("int");

                    b.Property<int>("Tip_goal_midfielderId")
                        .HasColumnType("int");

                    b.Property<int>("Tip_score")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("MatchId");

                    b.HasIndex("Tip_goal_defenderId");

                    b.HasIndex("Tip_goal_forwardId");

                    b.HasIndex("Tip_goal_midfielderId");

                    b.HasIndex("UserId");

                    b.ToTable("Tips");
                });

            modelBuilder.Entity("WebApplication2.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Ifadmin")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LeagueUser", b =>
                {
                    b.HasOne("WebApplication2.Entities.League", null)
                        .WithMany()
                        .HasForeignKey("LeaguesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication2.Entities.Footballer", b =>
                {
                    b.HasOne("WebApplication2.Entities.Club", "Club")
                        .WithMany("Footballers")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("WebApplication2.Entities.Footballer_stat", b =>
                {
                    b.HasOne("WebApplication2.Entities.Footballer", "Footballer")
                        .WithMany()
                        .HasForeignKey("FootballerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Footballer");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("WebApplication2.Entities.League_founder", b =>
                {
                    b.HasOne("WebApplication2.Entities.User", "Founder")
                        .WithMany("LeagueFounders")
                        .HasForeignKey("FounderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.League", "League")
                        .WithMany("LeagueFounders")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Founder");

                    b.Navigation("League");
                });

            modelBuilder.Entity("WebApplication2.Entities.League_score", b =>
                {
                    b.HasOne("WebApplication2.Entities.League", "League")
                        .WithMany("LeagueScores")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.User", "User")
                        .WithMany("LeagueScores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication2.Entities.Match", b =>
                {
                    b.HasOne("WebApplication2.Entities.Club", "Away")
                        .WithMany()
                        .HasForeignKey("AwayId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.Club", "Home")
                        .WithMany()
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Away");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("WebApplication2.Entities.Odd", b =>
                {
                    b.HasOne("WebApplication2.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("WebApplication2.Entities.Tip", b =>
                {
                    b.HasOne("WebApplication2.Entities.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.Footballer_stat", "Tip_goal_defender")
                        .WithMany()
                        .HasForeignKey("Tip_goal_defenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.Footballer_stat", "Tip_goal_forward")
                        .WithMany()
                        .HasForeignKey("Tip_goal_forwardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.Footballer_stat", "Tip_goal_midfielder")
                        .WithMany()
                        .HasForeignKey("Tip_goal_midfielderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication2.Entities.User", "User")
                        .WithMany("Tips")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Match");

                    b.Navigation("Tip_goal_defender");

                    b.Navigation("Tip_goal_forward");

                    b.Navigation("Tip_goal_midfielder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication2.Entities.Club", b =>
                {
                    b.Navigation("Footballers");
                });

            modelBuilder.Entity("WebApplication2.Entities.League", b =>
                {
                    b.Navigation("LeagueFounders");

                    b.Navigation("LeagueScores");
                });

            modelBuilder.Entity("WebApplication2.Entities.User", b =>
                {
                    b.Navigation("LeagueFounders");

                    b.Navigation("LeagueScores");

                    b.Navigation("Tips");
                });
#pragma warning restore 612, 618
        }
    }
}
