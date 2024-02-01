using BlackJack.API.Entity;

namespace BlackJack.API.Services;

public class CarteService : ICarteService
{
  private readonly Context _context;

  public CarteService(Context context)
  {
    _context = context;
  }

  public IEnumerable<Carte> GetAllCartes()
  {
    return _context.Carte.ToList();
  }

  public Carte GetCarteById(int ID_carte)
  {
    return _context.Carte.FirstOrDefault(c => c.ID_carte == ID_carte);
  }
}