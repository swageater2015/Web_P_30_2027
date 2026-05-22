using hotel;
using Hotel.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Hotel.Tests
{
    public class DbContextTests
    {
        [Fact]
        public void ApplicationDbContext_CanAddAndRetrieveClient()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var client = new Client
                {
                    LastName = "Тестов Тест",
                    Email = "test@test.com",
                    Phone = "123",
                    BirthDate = new System.DateTime(2000, 1, 1)
                };
                context.Clients.Add(client);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var client = context.Clients.FirstOrDefault();
                Assert.NotNull(client);
                Assert.Equal("Тестов Тест", client.LastName);
            }
        }

        [Fact]
        public void ApplicationDbContext_CanAddAndRetrieveHotelRoom()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var room = new Hotel_Room
                {
                    RoomNumber = "100",
                    Floor = "2",
                    Building = 1,
                    Category = "Стандарт"
                };
                context.Hotel_Room.Add(room);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var room = context.Hotel_Room.FirstOrDefault();
                Assert.NotNull(room);
                Assert.Equal("100", room.RoomNumber);
            }
        }
    }
}