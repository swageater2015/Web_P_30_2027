using Hotel.Model;
using hotel;
using Hotel.Pages.Hotel_Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Hotel.Tests
{
    public class HotelRoomsPageTests
    {
        private ApplicationDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task CreateModel_OnPost_ValidRoom_RedirectsToIndex()
        {
            var context = CreateInMemoryContext();
            var createModel = new CreateModel(context);
            createModel.Hotel_Room = new Hotel_Room
            {
                RoomNumber = "999",
                Floor = "1",
                Building = 1,
                Category = "Эконом"
            };
            createModel.ClientsList = new List<Client>();

            var result = await createModel.OnPostAsync() as RedirectToPageResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.PageName); 
            Assert.Single(context.Hotel_Room);
        }

        [Fact]
        public async Task CreateModel_OnPost_InvalidModel_ReturnsPage()
        {
            var context = CreateInMemoryContext();
            var createModel = new CreateModel(context);
            createModel.Hotel_Room = new Hotel_Room(); 
            createModel.ModelState.AddModelError("Hotel_Room.RoomNumber", "Required");

            var result = await createModel.OnPostAsync() as IActionResult;

            Assert.IsType<PageResult>(result);
        }
    }
}