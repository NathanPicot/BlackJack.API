using BlackJack.API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Interface;

public interface ICarteService
{
  ObjectResult GetAllCartes();
  Carte GetCarteById(int ID_carte);
  ObjectResult Hit(List<Carte> Cartes);
}