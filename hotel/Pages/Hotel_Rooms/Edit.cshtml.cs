using hotel;
using Hotel.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoomModel = Hotel.Model.Hotel_Room;
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
        public RoomModel? Hotel_Room { get; set; }
        public List<Client> ClientsList { get; set; } = new();


        public async Task<IActionResult> OnGetAsync(int id)
        {
            Hotel_Room = await _context.Hotel_Room
                .Include(r => r.Client)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (Hotel_Room == null)
            {
                return NotFound();
            }

            ClientsList = await _context.Clients.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ClientsList = await _context.Clients.ToListAsync();
                return Page();
            }

            _context.Attach(Hotel_Room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hotel_Room.Any(e => e.Id == Hotel_Room.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
