using Microsoft.EntityFrameworkCore;
using RaceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceAPI.Repository
{
    public class RaceDBContext : DbContext
    {
        public DbSet<Race> Races { get; set; }
        public DbSet<Participant> Participants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KRK1-LHP-P00937\SQLEXPRESS;Initial Catalog=RaceAPIDataBase;Integrated Security=True");
        }
    }
}
