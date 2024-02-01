using System.ComponentModel.DataAnnotations;

namespace BlackJack.API.Entity;

public class Partie
{
  [Key] public int ID_partie { get; set; }

  public decimal Mise { get; set; }
  public string Résultat { get; set; }
  public int ID_joueur { get; set; }
  public Joueur Joueur { get; set; }
}