using BlackJack.API.Entity;

namespace BlackJack.API.Interface;

public interface IPartieService
{
  IEnumerable<Partie> GetAll();

  Partie GetPartieById(int id);

  void Add(Partie partie);

  void UpdatePartie(int id, Partie updatedPartie);

  void DeletePartie(int id);
}