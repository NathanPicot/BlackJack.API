using System.ComponentModel.DataAnnotations;

namespace BlackJack.API.Entity;

public class Joueur
{
  [Key] public int ID_joueur { get; set; }

  public string Nom { get; set; }
  public string Password { get; set; }
  public decimal? Argent { get; set; }
}