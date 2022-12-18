﻿using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
	public class BaseDbContext : DbContext
	{
		protected IConfiguration Configuration { get; set; }
		public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
		public DbSet<Technology> Technologies { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }

		public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//if (!optionsBuilder.IsConfigured)
			//    base.OnConfiguring(
			//        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProgrammingLanguage>(a =>
			{
				a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.Name).HasColumnName("Name");

				a.HasMany(p => p.Technologies);
			});

			modelBuilder.Entity<Technology>(a =>
			{
				a.ToTable("Technologies").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.Name).HasColumnName("Name");

				a.HasOne(p => p.ProgrammingLanguage);
			});

			modelBuilder.Entity<User>(a =>
			{
				a.ToTable("Users").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.FirstName).HasColumnName("FirstName");
				a.Property(p => p.LastName).HasColumnName("LastName");
				a.Property(p => p.Email).HasColumnName("Email");
				a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
				a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
				a.Property(p => p.Status).HasColumnName("Status");
				a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

				a.HasMany(p => p.UserOperationClaims);
				a.HasMany(p => p.RefreshTokens);
			});

			modelBuilder.Entity<OperationClaim>(a =>
			{
				a.ToTable("OperationClaims").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.Name).HasColumnName("Name");
			});

			modelBuilder.Entity<UserOperationClaim>(a =>
			{
				a.ToTable("UserOperationClaims").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");

				a.Property(p => p.UserId).HasColumnName("UserId");
				a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
				a.HasOne(p => p.User);
				a.HasOne(p => p.OperationClaim);
			});

			modelBuilder.Entity<RefreshToken>(a =>
			{
				a.ToTable("RefreshTokens").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.Token).HasColumnName("Token");
				a.Property(p => p.Expires).HasColumnName("Expires");
				a.Property(p => p.Created).HasColumnName("Created");
				a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
				a.Property(p => p.Revoked).HasColumnName("Revoked");
				a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
				a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");

				a.Property(p => p.UserId).HasColumnName("UserId");
				a.HasOne(p => p.User);
			});

			ProgrammingLanguage[] programmingLanguageSeeds = {
				new(1, "C#"),
				new(2, "Python"),
				new(3, "Javascript")
			};

			Technology[] technologySeeds =
			{
				new(1, 1, "ASP.NET"),
				new(2, 1, "Unity"),
				new(3, 2, "Django"),
				new(4, 3, "Vue"),
				new(5, 3, "React"),
			};

			modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeeds);
			modelBuilder.Entity<Technology>().HasData(technologySeeds);

		}
	}
}
