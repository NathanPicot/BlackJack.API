using BlackJack.API.Entity;
using BlackJack.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartieController : Controller
{
  private readonly IPartieService _partieService;

  public PartieController(IPartieService partieService)
  {
    _partieService = partieService;
  }

  [HttpGet("getAll")]
  public JsonResult GetAll()
  {
    var parties = _partieService.GetAll();
    return Json(parties);
  }

  [HttpGet("get {id}")]
  public JsonResult Get(int id)
  {
    var partie = _partieService.GetPartieById(id);
    return Json(partie);
  }

  [HttpPost("add")]
  public ObjectResult Create(Partie partie)
  {
    return _partieService.Add(partie);
  }

  [HttpPut("update {id}")]
  public JsonResult Update(int id, Partie partie)
  {
    _partieService.UpdatePartie(id, partie);
    return Json(partie);
  }

  [HttpDelete("delete {id}")]
  public JsonResult Delete(int id)
  {
    _partieService.DeletePartie(id);
    return Json(new { Message = "Joueur supprimé avec succès", JoueurId = id });
  }

  [HttpPost("endPartie")]

  public JsonResult EndPartie(Partie partie)
  {
    _partieService.EndPartie(partie);
    return Json(new { Message = "Partie Terminer" });
  }

  [HttpGet("getTotalGain")]
  public JsonResult GetTotalGain()
  {
    var totalGain = _partieService.GetTotalGain();
    return Json(totalGain);
  }
  
  [HttpGet("getTotalMise")]
  public JsonResult GetTotalMise()
  {
    var totalMise = _partieService.GetTotalMise();
    return Json(totalMise);
  }

  [HttpGet("getAllPartie")]
  public IActionResult GetAllPartie()
  {
    // Appeler la méthode FetchAllParties pour obtenir les données
    var allParties = _partieService.FetchAllParties();
        
    // Convertir les tuples en objets anonymes pour la sérialisation JSON
    var result = allParties.Select(p => new
    {
      Date = p.Date.ToString("yyyy-MM-dd"), // Format date en chaîne
      GainDuCasino = p.GainDuCasino
    }).ToList();
        
    // Retourner les données en format JSON
    return Ok(result); // Utilise Ok() pour retourner des données JSON
  }
}