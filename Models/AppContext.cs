using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestOSKI.Models;

namespace TestOSKI.Models
{
    public class ApplicationContext : DbContext
    {
       

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<TestOSKI.Models.Quiz> Quizzes { get; set; }
        public DbSet<TestOSKI.Models.Question> Questions { get; set; }
        public DbSet<TestOSKI.Models.Result> Results { get; set; }
        public DbSet<TestOSKI.Models.User> Users { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz[]
                {
                new Quiz { Id=1, Name="History", Description = "Short description of the history test. This is test."},
                new Quiz { Id=2, Name="IT", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit"},
                new Quiz { Id=3, Name="Literature", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit"}
                });
            modelBuilder.Entity<Question>().HasData(
                new Question[]
                {
                    new Question{ Id=1, TextOfQuestion = "When Rome fell?",  QuizId = 1, FirstAnswer = "500", SecondAnswer = "700", ThirdAnswer = "395", WrightAnswer = "395" },
                    new Question{ Id=2, TextOfQuestion = "ASP.N...",  QuizId = 2, FirstAnswer = "ET", SecondAnswer = "ON", ThirdAnswer = "ULL", WrightAnswer = "ET" },
                    new Question{ Id=3, TextOfQuestion = "Alexander...",  QuizId = 3, FirstAnswer = "Dumas", SecondAnswer = "Famas", ThirdAnswer = "Fantomas", WrightAnswer = "Dumas" },
                    new Question{ Id=4, TextOfQuestion = "When was Jeanne d'Arc born?",  QuizId = 1, FirstAnswer = "500", SecondAnswer = "1412", ThirdAnswer = "127", WrightAnswer = "1412" },
                    new Question{ Id=5, TextOfQuestion = "First satellite in space was...",  QuizId = 1, FirstAnswer = "1961", SecondAnswer = "1957", ThirdAnswer = "1955", WrightAnswer = "1957" }


                }
                
                );
        }
    }
}
