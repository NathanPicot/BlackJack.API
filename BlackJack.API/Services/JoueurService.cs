using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlackJack.API.Entity;
using BlackJack.API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
public ObjectResult GetJoueurByToken(string token)
{
    var key = Encoding.ASCII.GetBytes("ptaincestvachementlongcommeclela");
    var tokenHandler = new JwtSecurityTokenHandler();
    var validations = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

    var claims = tokenHandler.ValidateToken(token, validations, out var tokenSecure);

    var IdClaim = claims.FindFirst("id");
    var userId = int.Parse(IdClaim.Value);

    var joueur = _context.Joueur.FirstOrDefault(j => j.ID_joueur == userId);

    // Vérifiez si joueur est null.
    if (joueur == null)
    {
        return new ObjectResult(new { success = false, message = "User not found" }) 
        { StatusCode = StatusCodes.Status404NotFound };
    }

    return new ObjectResult(new { success = true, message = "User found", user = joueur })
    { StatusCode = StatusCodes.Status200OK };
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

  public ObjectResult LoginJoueur(Joueur joueur)
  {
    Joueur? joueurDb = _context.Joueur.FirstOrDefault(j => j.Nom == joueur.Nom && j.Password == joueur.Password);

    if (joueurDb != null)
    {
      // Generate JWT token
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes("ptaincestvachementlongcommeclela");
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim("id", joueurDb.ID_joueur.ToString()) }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var jwtToken = tokenHandler.WriteToken(token);

      return new ObjectResult(new { success = "Connexion Réussis", user = joueur, token = jwtToken })
        { StatusCode = StatusCodes.Status200OK };
    }
    
    return new ObjectResult(new { error = "Connexion échoué" })
      { StatusCode = StatusCodes.Status200OK };
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