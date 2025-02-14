﻿using EntityFrameworkExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData(
           new Person
           {
               PersonId = 1,
               FirstName = "Tara",
               LastName = "Brewer",
               City = "Ocala",
               Address = "317 Long Street"
           },
           new Person
           {
               PersonId = 2,
               FirstName = "Andrew",
               LastName = "Tippett",
               City = "Anaheim",
               Address = "3163 Nickel Road"
           });
    }
}

