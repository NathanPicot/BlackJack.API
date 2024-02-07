using System.ComponentModel.DataAnnotations;

namespace BlackJack.API.Entity;

public class Partie_Carte
{
  
  [Key] public int Id { get; set; }
  public int ID_partie { get; set; }
  public int ID_carte { get; set; }
  public string ID_joueur { get; set; }
}