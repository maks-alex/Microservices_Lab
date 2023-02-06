using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiApi.Models;

    public class MultiApiContext : DbContext
    {
        public MultiApiContext (DbContextOptions<MultiApiContext> options)
            : base(options)
        {
        }

        public DbSet<MultiApi.Models.Joke> Joke { get; set; }
    }
