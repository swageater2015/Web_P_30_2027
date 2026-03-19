using hotel;
using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel.Pages.Hotel_Rooms
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hotel_Room Hotel_Room { get; set; }

        public IActionResult OnGet(int id)
        {
            Hotel_Room = _context.Hotel_Room.Find(id);

            if (Hotel_Room == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Hotel_Room.Update(Hotel_Room);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
