
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client.Models;


namespace Client.Controllers;

public class JobApplicationController : Controller
{
    private IHttpClientFactory _httpClientFactory;

    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public JobApplicationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateEmployeeRequirementsDropDownListAsync();
        return View();
    }

    private async Task PopulateEmployeeRequirementsDropDownListAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri("http://localhost:6316");
        HttpResponseMessage response = await httpClient.GetAsync("api/RestaurantWantedAd");
        if (response.IsSuccessStatusCode)
        {
            IEnumerable<EmployeeRequirements> employeeRequirements  = await JsonSerializer.DeserializeAsync<IEnumerable<EmployeeRequirements>>(
                await response.Content.ReadAsStreamAsync(), options);
            //IEnumerable<EmployeeRequirements> employeeRequirements = await response.Content.ReadAsAsync<IEnumerable<EmployeeRequirements>>();
            ViewBag.EmployeeRequirements = new SelectList(employeeRequirements, "Id", "JobTitle");
        }
    }

    public IActionResult ThankYou()
    {
        return View();
    }
}
