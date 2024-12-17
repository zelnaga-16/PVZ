using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameAPI.Models;

public class GameAPIContext : DbContext
{
    public GameAPIContext (DbContextOptions<GameAPIContext> options)
        : base(options)
    {
    }

    public DbSet<GameAPI.Models.User> User { get; set; }
    public DbSet<Game> Game { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
    }

}
