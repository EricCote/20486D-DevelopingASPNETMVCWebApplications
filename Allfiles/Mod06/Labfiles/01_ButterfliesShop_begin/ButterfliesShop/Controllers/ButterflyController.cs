using ButterfliesShop.Models;
using ButterfliesShop.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ButterfliesShop.Controllers;

public class ButterflyController : Controller
{
    private IDataService _data;
    private IWebHostEnvironment _environment;
    private IButterfliesQuantityService _butterfliesQuantityService;

    public ButterflyController(IDataService data, IWebHostEnvironment environment, IButterfliesQuantityService butterfliesQuantityService)
    {
        _data = data;
        _environment = environment;
        _butterfliesQuantityService = butterfliesQuantityService;
        InitializeButterfliesData();
    }

    private void InitializeButterfliesData()
    {
        if (!_data.ButterfliesList.Any())
        {
            List<Butterfly> butterflies = _data.ButterfliesInitializeData();
            foreach (var butterfly in butterflies)
            {
                _butterfliesQuantityService.AddButterfliesQuantityData(butterfly);
            }
        }
    }

    public IActionResult GetImage(int id)
    {
        Butterfly? requestedButterfly = _data.GetButterflyById(id);
        if (requestedButterfly != null)
        {
            return Content("Should return an image");
        }
        else
        {
            return NotFound();
        }
    }
}
