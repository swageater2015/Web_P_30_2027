using hotel;
using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoomModel = Hotel.Model.Hotel_Room;

namespace Hotel.Pages.Hotel_Rooms
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomModel? Hotel_Room { get; set; }
        public List<Client> ClientsList { get; set; } = new();
        public void OnGet()
        {
            Hotel_Room = new Model.Hotel_Room();
            ClientsList = _context.Clients.ToList();

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Hotel_Room.Add(Hotel_Room);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}
