﻿using Domain.Entities;
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
