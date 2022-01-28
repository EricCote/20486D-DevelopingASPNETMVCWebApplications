using GridExample.Data;
using Microsoft.AspNetCore.Mvc;

namespace GridExample.Controllers;

public class ChessController : Controller
{
    private readonly ChessLeagueContext _context;

    public ChessController(ChessLeagueContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Games.ToList());
    }
}
