using System.Runtime.InteropServices.JavaScript;
using BlackJack.API.Entity;
using BlackJack.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Services;

/// <summary>
///   Represents a Partie service that provides methods for interacting with Partie objects in the database.
/// </summary>
public class PartieService : IPartieService
{
    /// <summary>
    ///   The private readonly variable _context represents the context of the application.
    /// </summary>
    private readonly Context _context;

  /// Creates a new instance of the PartieService class.
  /// @param context The context to be used by the PartieService.
  /// /
  public PartieService(Context context)
  {
    _context = context;
  }

  // Add remaining service methods here...
  /// <summary>
  ///   Retrieves all the "Partie" objects from the database.
  /// </summary>
  /// <returns>An IEnumerable collection of Partie objects.</returns>
  public IEnumerable<Partie> GetAll()
  {
    return _context.Partie.ToList();
  }

  /// Gets a Partie object by its ID.
  /// </summary>
  /// <param name="id">The ID of the Partie to retrieve.</param>
  /// <returns>The Partie object if found, otherwise null.</returns>
  public Partie GetPartieById(int id)
  {
    return _context.Partie.FirstOrDefault(p => p.ID_partie == id);
  }

  /// <summary>
  ///   Adds a new "Partie" object to the context and saves the changes.
  /// </summary>
  /// <param name="partie">The "Partie" object to be added.</param>
  public ObjectResult Add(Partie partie)
  {
    _context.Partie.Add(partie);
    _context.SaveChanges();

    return new ObjectResult(new { success = true, message = "Partie successfully added.", partie })
      { StatusCode = StatusCodes.Status200OK };
  }
  /// <summary>
  ///   Updates a Partie in the database based on the provided ID and updatedPartie object.
  /// </summary>
  /// <param name="id">The ID of the Partie to update.</param>
  /// <param name="updatedPartie">The updated Partie object to replace the existing Partie in the database.</param>
  public void UpdatePartie(int id, Partie updatedPartie)
  {
    _context.Partie.Update(updatedPartie);
  }

  /// <summary>
  ///   Deletes a Partie with the specified ID from the context.
  /// </summary>
  /// <param name="id">The ID of the Partie to delete.</param>
  public void DeletePartie(int id)
  {
    var partieToDelete = _context.Partie.FirstOrDefault(p => p.ID_partie == id);
    if (partieToDelete != null)
    {
      _context.Partie.Remove(partieToDelete);
      _context.SaveChanges();
    }
  }

  public void EndPartie(Partie partie)
  {
    _context.Partie.Update(partie);
    _context.SaveChanges();
  }
  
  /// <summary>
  /// retourne le totale des Gains des joueurs
  /// </summary>
  /// <returns></returns>
  public decimal GetTotalGain()
  {
    var totalGain = _context.Partie
                                      .Where(p => p.Resultat == "win")
                                      .Sum(p => p.Mise);
    totalGain = totalGain * 2.5m;
    return totalGain;
  }

  public decimal GetTotalMise()
  {
    var totalMise = _context.Partie
      .Where(p => p.Resultat != "Draw")
                                      .Sum(p => p.Mise);
    return totalMise;
  }
 
  public List<(DateTime Date, decimal GainDuCasino)> FetchAllParties()
  {
    // Calculer la date limite pour les 5 derniers jours
    var cinqDerniersJours = DateTime.Now.AddDays(-8);

    var gainsParJour = _context.Partie
      .Where(p => p.Date >= cinqDerniersJours && p.Date <= DateTime.Now )  // Filtrer les parties des 5 derniers jours
      .GroupBy(p => p.Date.Date)  // Assure que la date est sans heure pour le regroupement
      .Select(g => new
      {
        Date = g.Key,
        GainDuCasino = g.Sum(p =>
          p.Resultat == "win" ? p.Mise * -1.5m :
          p.Resultat == "Draw" ? 0 :
          p.Mise
        )
      })
      .ToList();

    // Convertir la liste d'objets anonymes en liste de tuples
    var result = gainsParJour
      .Select(g => (g.Date, g.GainDuCasino))
      .ToList();

    return result;
  }

  
}