using BlackJack.API.Entity;
using BlackJack.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JoueurController : Controller
{
  private readonly IJoueurService _joueurService;

  public JoueurController(IJoueurService joueurService)
  {
    _joueurService = joueurService;
  }

  [HttpGet("getAll")]
  public JsonResult GetAll()
  {
    var joueurs = _joueurService.GetAllJoueurs();
    return Json(joueurs);
  }

  [HttpGet("get {id}")]
  public JsonResult Get(int id)
  {
    var joueur = _joueurService.GetJoueurById(id);
    return Json(joueur);
  }

  [HttpPost("add" )]
  public ObjectResult Create(Joueur joueur)
  {
    var result = _joueurService.AddJoueur(joueur);
    return result;
  }

  [HttpPut("update {id}")]
  public JsonResult Update(int id, Joueur joueurMisAJour)
  {
    _joueurService.UpdateJoueur(joueurMisAJour);
    return Json(joueurMisAJour);
  }

  [HttpDelete("delete {id}")]
  public JsonResult Delete(int id)
  {
    _joueurService.DeleteJoueur(id);
    return Json(new { Message = "Joueur supprimé avec succès", JoueurId = id });
  }
}