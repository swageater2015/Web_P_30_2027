using hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoomModel = Hotel.Model.Hotel_Room;
namespace Hotel.Pages.Hotel_Rooms
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomModel? Hotel_Room { get; set; }

        public IActionResult OnGet(int id)
        {
            Hotel_Room = _context.Hotel_Rooms.Find(id);

            if (Hotel_Room == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var book = _context.Hotel_Rooms.Find(Hotel_Room.Id);

            if (book != null)
            {
                _context.Hotel_Rooms.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
