using System.ComponentModel.DataAnnotations;

namespace BlackJack.API.Entity;

public class Carte
{
  [Key] public int ID_carte { get; set; }

  public int valeur { get; set; }
  public string symbole { get; set; }
  public string textCarte { get; set; }
}