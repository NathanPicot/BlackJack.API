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
  public JsonResult GetAll()
  {
    var cartes = _carteService.GetAllCartes();
    return Json(cartes);
  }

  [HttpGet("get {id}")]
  public JsonResult Get(int id)
  {
    var carte = _carteService.GetCarteById(id);
    return Json(carte);
  }
}