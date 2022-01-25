using ActorsRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActorsRazorPages.Pages.Actors
{
    public class DetailsModel : PageModel
    {
        private IData _data;
		
        public Actor Actor { get; set; }

        public DetailsModel(IData data)
        {
            _data = data;
            Actor = data.ActorsList.First();
        }
		
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor? a = _data.GetActorById(id);

            if (a == null)
            {
                return NotFound();
            }

            Actor = a;
            return Page();
        }
    }
}