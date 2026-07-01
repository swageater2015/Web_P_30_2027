using hotel;
using Hotel.Model;
using Hotel.Pages.Hotel_Rooms;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Tests
{
    public class HotelRoomsIndexPageTests
    {
        private ApplicationDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task IndexModel_OnGetAsync_LoadsRooms()
        {
            var context = CreateInMemoryContext();
            context.Hotel_Room.Add(new Hotel_Room { RoomNumber = "101", Floor = "1", Building = 1, Category = "Эконом" });
            context.Hotel_Room.Add(new Hotel_Room { RoomNumber = "102", Floor = "1", Building = 1, Category = "Стандарт" });
            await context.SaveChangesAsync();

            var indexModel = new IndexModel(context);

            await indexModel.OnGetAsync();

            Assert.NotNull(indexModel.Hotel_Rooms);
            Assert.Equal(2, indexModel.Hotel_Rooms.Count);
            Assert.Contains(indexModel.Hotel_Rooms, r => r.RoomNumber == "101");
        }
    }
}