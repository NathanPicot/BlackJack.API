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
  public JsonResult Create(Partie partie)
  {
    _partieService.Add(partie);
    return Json(partie);
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
}