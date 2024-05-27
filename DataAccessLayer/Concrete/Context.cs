using DataAccessLayer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, string>  
    {
        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DevConnection"));
        }


        public Context(DbContextOptions<Context> options) : base(options) { }



          
        public DbSet<GeneralNeeds> GeneralNeeds { get; set; } 

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Optimization> Optimizations { get; set; }
        public DbSet<Graph> Graphs { get; set; }
        public DbSet<EmptyProject> EmptyProjects { get; set; }




    }
}
