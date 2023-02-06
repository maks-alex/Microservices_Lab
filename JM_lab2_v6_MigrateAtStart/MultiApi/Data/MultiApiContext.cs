using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Joke>()
            .ToTable("Joke");
        modelBuilder.Entity<Joke>()
            .Property(s => s.Id)
            .IsRequired(true);
        modelBuilder.Entity<Joke>()
            .Property(s => s.Name)
            .IsRequired(false);
        modelBuilder.Entity<Joke>()
            .Property(s => s.Text)
            //.HasDefaultValue(true);
            .IsRequired(false);
        modelBuilder.Entity<Joke>()
            .Property(s => s.Category)
            .IsRequired(false);
        modelBuilder.Entity<Joke>()
            .HasData(
                new Joke
                {
                    Id = 1,
                    Name = "sample Name",
                    Text = "sample Text",
                    Category = "SampleCat",

                }
                /*new Joke
                    {
                        Id = 1,
                        Name = "RATTLE SNAKE",
                        Text = "Two men are hiking through the woods when one of them cries out, “Snake! Run!” His companion laughs at him. “Oh, relax. It’s only a baby,” he says. “Don’t you!",
                        Category = "Animal",

                    },
                    new Joke
                    {
                        Id = 2,
                        Name = "HORSE RIDER",
                        Text = "To be or not to be a horse rider, that is equestrian. —Mark Simmons, comedian",
                        Category = "Animal",

                    },
                    new Joke
                    {
                        Id = 3,
                        Name = "POSTURE CAT",
                        Text = "What did the grandma cat say to her grandson when she saw him slouching? A: You need to pay more attention to my pawsture.",
                        Category = "Animal",

                    },
                    new Joke
                    {
                        Id = 4,
                        Name = "HE CAN DO IT HIMSELF",
                        Text = "It was my first night caring for an elderly patient. When he grew sleepy, I wheeled his chair as close to the bed as possible and, using the techniques I’d...",
                        Category = "Dockor",

                    },
                    new Joke
                    {
                        Id = 5,
                        Name = "ON THE BADGE",
                        Text = "My 85-year-old grandfather was rushed to the hospital with a possible concussion. The doctor asked him a series of questions: “Do you know where you are?” “I’m at Rex Hospital.",
                        Category = "Dockor",

                    },
                    new Joke
                    {
                        Id = 6,
                        Name = "THE NURSE HAS MY TEETH",
                        Text = "As a brain wave technologist, I often ask postoperative patients to smile to make sure their facial nerves are intact. It always struck me as odd to be asking this...",
                        Category = "Dockor",

                    },
                    new Joke
                    {
                        Id = 7,
                        Name = "GLUTEN ATTACK",
                        Text = "Guy staring at an ambulance in front of Whole Foods: “Somebody must have accidentally eaten gluten.”",
                        Category = "Food",

                    },
                    new Joke
                    {
                        Id = 8,
                        Name = "MORNING TEA",
                        Text = "What has T in the beginning, T in the middle, and T at the end? A: A teapot.",
                        Category = "Food",

                    },
                    new Joke
                    {
                        Id = 9,
                        Name = "MAKE ME A SANDWICH",
                        Text = "My husband and I were daydreaming about what we would do if we won the lottery. I started: “I’d hire a cook so that I could just say, ‘Hey, make...",
                        Category = "Marriage",

                    },
                    new Joke
                    {
                        Id = 10,
                        Name = "SELL IT",
                        Text = "As my wife and I prepared for our garage sale, I came across a painting. Looking at the back, I discovered that I had written “To my beautiful wife on...",
                        Category = "Marriage",

                    }*/
            ) ;
    }
}
