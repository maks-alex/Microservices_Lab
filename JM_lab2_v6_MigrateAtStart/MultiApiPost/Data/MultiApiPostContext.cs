using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiApiPost.Models;

    public class MultiApiPostContext : DbContext
    {
        public MultiApiPostContext (DbContextOptions<MultiApiPostContext> options)
            : base(options)
        {
        }

        public DbSet<MultiApiPost.Models.Joke> Joke { get; set; }
    }
