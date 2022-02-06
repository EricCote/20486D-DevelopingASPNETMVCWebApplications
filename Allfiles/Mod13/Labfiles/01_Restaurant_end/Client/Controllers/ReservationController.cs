using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using Client.Models;

namespace Client.Controllers;

public class ReservationController : Controller
{
    private IHttpClientFactory _httpClientFactory;

    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };


    public ReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateRestaurantBranchesDropDownListAsync();
        return View();
    }

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> CreatePostAsync(OrderTable orderTable)
    {
        HttpClient httpclient = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await httpclient.PostAsJsonAsync("http://localhost:6316/api/Reservation", orderTable);
        if (response.IsSuccessStatusCode)
        {
            OrderTable order = await JsonSerializer.DeserializeAsync<OrderTable>(
                await response.Content.ReadAsStreamAsync(), options);
            // OrderTable order = await response.Content.ReadAsAsync<OrderTable>();
            return RedirectToAction("ThankYou", new { orderId = order.Id });
        }
        else
        {
            return View("Error");
        }
    }

    private async Task PopulateRestaurantBranchesDropDownListAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri("http://localhost:6316");
        HttpResponseMessage response = await httpClient.GetAsync("api/RestaurantBranches");
        if (response.IsSuccessStatusCode)
        {
            IEnumerable<RestaurantBranch> restaurantBranches = await JsonSerializer.DeserializeAsync<IEnumerable<RestaurantBranch>>(
                await response.Content.ReadAsStreamAsync(), options);
            // IEnumerable<RestaurantBranch> restaurantBranches = await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>();
            ViewBag.RestaurantBranches = new SelectList(restaurantBranches, "Id", "City");
        }
    }

    public async Task<IActionResult> ThankYouAsync(int orderId)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri("http://localhost:6316");
        HttpResponseMessage response = await httpClient.GetAsync("api/Reservation/" + orderId);
        if (response.IsSuccessStatusCode)
        {
            OrderTable orderResult = await JsonSerializer.DeserializeAsync<OrderTable>(
                await response.Content.ReadAsStreamAsync(), options);
            // OrderTable orderResult = await response.Content.ReadAsAsync<OrderTable>();
            return View(orderResult);
        }
        else
        {
            return View("Error");
        }
    }
}
