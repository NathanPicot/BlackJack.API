using BlackJack.API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Interface;

public interface IPartieService
{
  IEnumerable<Partie> GetAll();

  Partie GetPartieById(int id);

  ObjectResult Add(Partie partie);

  void UpdatePartie(int id, Partie updatedPartie);

  void DeletePartie(int id);

  void EndPartie(Partie partie);

  decimal GetTotalGain();

  decimal GetTotalMise();

  List<(DateTime Date, decimal GainDuCasino)> FetchAllParties();
}