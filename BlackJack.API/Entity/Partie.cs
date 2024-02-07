using System.ComponentModel.DataAnnotations;

namespace BlackJack.API.Entity;

public class Partie
{
  [Key] public int ID_partie { get; set; }
  public decimal Mise { get; set; }
  public string Resultat { get; set; }
  public int ID_joueur { get; set; }
}