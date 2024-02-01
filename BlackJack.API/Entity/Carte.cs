using System.ComponentModel.DataAnnotations;

namespace BlackJack.API.Entity;

public class Carte
{
  [Key] public int ID_carte { get; set; }

  public string valeur { get; set; }
  public decimal symbole { get; set; }
}