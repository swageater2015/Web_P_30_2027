using hotel;
using Hotel.Model;
using Hotel.Pages.Hotel_Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;

namespace Hotel.Tests
{
    public class HotelRoomsEditPageTests
    {
        private ApplicationDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task EditModel_OnPostAsync_UpdatesRoom()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var room = new Hotel_Room { RoomNumber = "101", Floor = "1", Building = 1, Category = "Эконом" };
            context.Hotel_Room.Add(room);
            await context.SaveChangesAsync();

            var editModel = new EditModel(context);
            editModel.Hotel_Room = new Hotel_Room
            {
                Id = room.Id,
                RoomNumber = "999",
                Floor = "2",
                Building = 2,
                Category = "Люкс"
            };

            // Act
            var result = await editModel.OnPostAsync() as RedirectToPageResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.PageName);
            var updatedRoom = await context.Hotel_Room.FindAsync(room.Id);
            Assert.Equal("999", updatedRoom.RoomNumber);
        }
    }
}