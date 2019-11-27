using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroDeCompetencia2019.Models;

namespace RegistroDeCompetencia2019.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Recinto> Recintos { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } 
    
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}