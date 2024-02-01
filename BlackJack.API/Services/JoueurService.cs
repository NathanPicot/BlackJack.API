using BlackJack.API.Entity;
using BlackJack.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Services;

public class JoueurService : IJoueurService
{
  private readonly Context _context;

  public JoueurService(Context context)
  {
    _context = context;
  }

  /// <summary>
  ///   Retrieves all Joueur records from the database.
  /// </summary>
  /// <returns>An IEnumerable of Joueur objects.</returns>
  public IEnumerable<Joueur> GetAllJoueurs()
  {
    return _context.Joueur.ToList();
  }

  /// <summary>
  ///   Retrieves a specific Joueur by its ID.
  /// </summary>
  /// <param name="joueurId">The ID of the Joueur to retrieve.</param>
  /// <returns>The Joueur object matching the given ID.</returns>
  public Joueur GetJoueurById(int joueurId)
  {
    return _context.Joueur.FirstOrDefault(j => j.ID_joueur == joueurId);
  }

  /// <summary>
  ///   Adds a new player to the database.
  /// </summary>
  /// <param name="joueur">The player to be added.</param>
  /// <exception cref="Exception">Thrown when a player with the same name already exists.</exception>
  public ObjectResult AddJoueur(Joueur joueur)
  {
    var unique = _context.Joueur.FirstOrDefault(j => j.Nom == joueur.Nom);
    if (unique != null)
    {
      return new ObjectResult(new { error = "Un joueur avec ce nom existe déjà." })
        { StatusCode = StatusCodes.Status409Conflict };
    }
    _context.Joueur.Add(joueur);
    _context.SaveChanges();
    
    return new ObjectResult(new { success = "Joueur ajouter avec succes" })
      { StatusCode = StatusCodes.Status201Created };
  }

  /// <summary>
  ///   Updates the joueur in the database.
  /// </summary>
  /// <param name="joueur">The joueur object to be updated.</param>
  /// <exception cref="Exception">Thrown when a joueur with the same name already exists.</exception>
  public void UpdateJoueur(Joueur joueur)
  {
    var unique = _context.Joueur.FirstOrDefault(j => j.Nom == joueur.Nom);
    if (unique != null) throw new Exception("Un joueur avec ce nom existe déjà.");
    _context.Joueur.Update(joueur);
    _context.SaveChanges();
  }

  /// <summary>
  ///   Deletes a joueur with the specified joueurId from the database.
  /// </summary>
  /// <param name="joueurId">The identifier of the joueur to delete.</param>
  public void DeleteJoueur(int joueurId)
  {
    var joueurToDelete = _context.Joueur.FirstOrDefault(j => j.ID_joueur == joueurId);
    if (joueurToDelete != null)
    {
      _context.Joueur.Remove(joueurToDelete);
      _context.SaveChanges();
    }
  }
}