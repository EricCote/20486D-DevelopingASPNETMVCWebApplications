using Microsoft.AspNetCore.Mvc;
using Client.Models;
using System.Text.Json;
namespace Client.Controllers;

public class RestaurantBranchesController : Controller
{
    private IHttpClientFactory _httpClientFactory;

    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };


    public RestaurantBranchesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri("http://localhost:6316");
        HttpResponseMessage response = await httpClient.GetAsync("api/RestaurantBranches");
        if (response.IsSuccessStatusCode)
        {
            IEnumerable<RestaurantBranch> restaurantBranches  = await JsonSerializer.DeserializeAsync<IEnumerable<RestaurantBranch>>(
                await response.Content.ReadAsStreamAsync(), options);
          
           // IEnumerable<RestaurantBranch> restaurantBranches = await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>();
            return View(restaurantBranches);
        }
        else
        {
            return View("Error");
        }
    }
}
