using hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoomModel = Hotel.Model.Hotel_Room;
namespace Hotel.Pages.Hotel_Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomModel? Hotel_Room { get; set; }

        public IActionResult OnGet(int id)
        {
            Hotel_Room = _context.Hotel_Room.FirstOrDefault(b => b.Id == id);

            if (Hotel_Room == null)
                return NotFound();

            return Page();
        }
    }
}
