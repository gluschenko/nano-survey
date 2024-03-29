﻿using System;
using Microsoft.EntityFrameworkCore;
using NanoSurvey.Common.Entities;

namespace NanoSurvey.Common
{
    public class SurveyDatabaseContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }

        public SurveyDatabaseContext(DbContextOptions<SurveyDatabaseContext> options) : base(options)
        {
            if (!Database.CanConnect())
                Console.WriteLine("Unable to connect!");

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Табличка Results имеет композитный ключ
            modelBuilder.Entity<Result>().HasKey(e => new { e.InterviewID, e.QuestionID });
        }
    }
}
