using System;
using GuiaBar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuiaBar.Data
{
    public class GuiaBarContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<Pub> Pubs{ get; set; }

        public DbSet<UserPubEvaluation> UserPubEvaluations {get; set;}

        public GuiaBarContext(DbContextOptions<GuiaBarContext> options) : base(options) { } 


    }
}
