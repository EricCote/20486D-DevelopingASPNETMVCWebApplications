using Microsoft.AspNetCore.Mvc;
using ClientSide.Models;
using System.Text.Json;

namespace ClientSide.Controllers;

public class HomeController : Controller
{
    private IHttpClientFactory _httpClientFactory;
    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> GetByIdAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri("http://localhost:6314");
        HttpResponseMessage response = httpClient.GetAsync("http://localhost:6314/api/store/1").Result;
        if (response.IsSuccessStatusCode)
        {
            GroceryStore grocery = await JsonSerializer.DeserializeAsync<GroceryStore>(
                await response.Content.ReadAsStreamAsync(), options);
            // GroceryStore grocery = await response.Content.ReadAsAsync<GroceryStore>();
            return Json(grocery);
        }
        else
        {
            return Content("An error has occurred");
        }
    }

    public async Task<IActionResult> PostAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri("http://localhost:6314");
        GroceryStore newGrocery = new GroceryStore { Name = "Martin General Stores", Address = "4160  Oakwood Avenue" };
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("http://localhost:6314/api/store", newGrocery);
        if (response.IsSuccessStatusCode)
        {
            GroceryStore grocery = await JsonSerializer.DeserializeAsync<GroceryStore>(
               await response.Content.ReadAsStreamAsync(), options);
            //GroceryStore grocery = await response.Content.ReadAsAsync<GroceryStore>();
            return new ObjectResult(grocery);
        }
        else
        {
            return Content("An error has occurred");
        }
    }
}