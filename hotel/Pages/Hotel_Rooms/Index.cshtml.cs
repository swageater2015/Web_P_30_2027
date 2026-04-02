using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hotel;
using RoomModel = Hotel.Model.Hotel_Room;

namespace Hotel.Pages.Hotel_Rooms
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RoomModel> Hotel_Rooms { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Hotel_Rooms = await _context.Hotel_Room.ToListAsync();
        }
    }
}