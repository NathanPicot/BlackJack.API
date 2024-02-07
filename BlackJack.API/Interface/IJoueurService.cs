using BlackJack.API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Interface;

public interface IJoueurService
{
  IEnumerable<Joueur> GetAllJoueurs();
  ObjectResult GetJoueurByToken(string token);
  ObjectResult AddJoueur(Joueur joueur);

  ObjectResult LoginJoueur(Joueur joueur);
  void UpdateJoueur(Joueur joueur);
  void DeleteJoueur(int joueurId);

  void UpdateMoney(Joueur joueur);
}