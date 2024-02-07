using BlackJack.API.Entity;
using BlackJack.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Services;

public class CarteService : ICarteService
{
  private readonly Context _context;
  private static readonly Random rng = new Random();
  public CarteService(Context context)
  {
    _context = context;
  }

  public ObjectResult GetAllCartes()
  {
    var cartes = _context.Carte.ToList();

    // Renvoie la liste de cartes avec un message de succès et le code status HTTP 200 (OK)
    return new ObjectResult(new { success = true, message = "Cartes retrieved successfully", cartes })
      { StatusCode = StatusCodes.Status200OK };
  }

  public Carte GetCarteById(int ID_carte)
  {
    return _context.Carte.FirstOrDefault(c => c.ID_carte == ID_carte);
  }


  public ObjectResult Hit(List<Carte> Cartes)
  {
    var allCartes = Cartes;
    if (allCartes.Count < 1)
    {
      // Renvoie un message d'erreur avec le code status HTTP 400 (Bad Request)
      return new ObjectResult(new { message = "No cards left in the deck" }) { StatusCode = 400 };
    }

    var randomIndex = rng.Next(allCartes.Count);
    var drawnCarte = allCartes[randomIndex];
    allCartes.RemoveAt(randomIndex);
    
    // Renvoie la carte dessinée avec un message de succès et le code status HTTP 200 (OK)
    return new ObjectResult(new {success = true,  message = "Success", carte = drawnCarte, cartes = allCartes }) { StatusCode = 200 };
  }
}