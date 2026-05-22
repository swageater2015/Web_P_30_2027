using hotel;
using Hotel.Model;
using Hotel.Pages.Hotel_Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;

namespace Hotel.Tests
{
    public class HotelRoomsDeletePageTests
    {
        private ApplicationDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public void DeleteModel_OnPost_RemovesRoom() 
        {
            // Arrange
            var context = CreateInMemoryContext();
            var room = new Hotel_Room { RoomNumber = "101", Floor = "1", Building = 1, Category = "Эконом" };
            context.Hotel_Room.Add(room);
            context.SaveChanges();  

            var deleteModel = new DeleteModel(context);
            deleteModel.Hotel_Room = room; 

            // Act
            var result = deleteModel.OnPostAsync() as RedirectToPageResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.PageName);
            Assert.Empty(context.Hotel_Room);
        }
    }
}