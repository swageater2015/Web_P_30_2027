using hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel.Pages.Hotel_Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Hotel_Room Hotel_Room { get; set; }

        public IActionResult OnGet(int id)
        {
            Hotel_Room = _context.Hotel_Rooms.FirstOrDefault(b => b.Id == id);

            if (Hotel_Room == null)
                return NotFound();

            return Page();
        }
    }
}
