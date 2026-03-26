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
        public Model.Hotel_Room Hotel_Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Диагностика
            Console.WriteLine($"Получен id: {id}");

            Hotel_Room = await _context.Hotel_Rooms.FindAsync(id);

            // Диагностика
            if (Hotel_Room == null)
            {
                Console.WriteLine($"Номер с id {id} не найден в базе данных");
                return NotFound();
            }

            Console.WriteLine($"Найден номер: {Hotel_Room.RoomNumber}");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Hotel_Rooms.Update(Hotel_Room);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
