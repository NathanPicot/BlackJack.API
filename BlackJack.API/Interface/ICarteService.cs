using BlackJack.API.Entity;

public interface ICarteService
{
  IEnumerable<Carte> GetAllCartes();
  Carte GetCarteById(int ID_carte);
}