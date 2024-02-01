using Microsoft.EntityFrameworkCore;

namespace BlackJack.API.Entity;

public class Context : DbContext
{
  public DbSet<Joueur> Joueur { get; set; }
  public DbSet<Partie> Partie { get; set; }

  public DbSet<Carte> Carte { get; set; }
  // Ajoutez d'autres DbSet selon vos besoins

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    // Modify this information to match yours
    const string serverName = "127.0.0.1";
    const int port = 3306;
    const string databaseName = "blackjackDb";
    const string username = "root";
    const string password = "";

    // Build the connection string
    var connectionString =
      $"Server={serverName};Port={port};Database={databaseName};User={username};Password={password};";

    // Configure the database connection
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
  }
}