using BlackJack.API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Interface;

public interface IJoueurService
{
  IEnumerable<Joueur> GetAllJoueurs();
  Joueur GetJoueurById(int joueurId);
  ObjectResult AddJoueur(Joueur joueur);
  void UpdateJoueur(Joueur joueur);
  void DeleteJoueur(int joueurId);
}