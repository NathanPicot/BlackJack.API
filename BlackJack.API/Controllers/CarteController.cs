using BlackJack.API.Entity;
using BlackJack.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarteController : Controller
{
  private readonly ICarteService _carteService;

  public CarteController(ICarteService carteService)
  {
    _carteService = carteService;
  }

  [HttpGet("getAll")]
  public ObjectResult GetAll()
  {
    var cartes = _carteService.GetAllCartes();
    return cartes;
  }

  [HttpGet("get {id}")]
  public JsonResult Get(int id)
  {
    var carte = _carteService.GetCarteById(id);
    return Json(carte);
  }

  [HttpPost("Hit")]
  public ObjectResult Hit(List<Carte> Cartes)
  {
    var result = _carteService.Hit(Cartes);

    return result;
  }
  
}