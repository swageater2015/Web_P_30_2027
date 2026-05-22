using Hotel.Model;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Tests
{
    public class ModelValidationTests
    {
        [Fact]
        public void Hotel_Room_Valid_ShouldPass()
        {
            var room = new Hotel_Room
            {
                RoomNumber = "101",
                Floor = "5",
                Building = 2,
                Category = "Люкс"
            };
            var results = ValidateModel(room);
            Assert.Empty(results);
        }

        [Fact]
        public void Hotel_Room_MissingRoomNumber_ShouldFail()
        {
            var room = new Hotel_Room
            {
                Floor = "5",
                Building = 2,
                Category = "Люкс"
            };
            var results = ValidateModel(room);
            Assert.Contains(results, r => r.MemberNames.Contains("RoomNumber"));
        }

        [Fact]
        public void Client_InvalidEmail_ShouldFail()
        {
            var client = new Client
            {
                LastName = "Иванов Иван",
                Email = "not-an-email",
                Phone = "+79991234567",
                BirthDate = new DateTime(1990, 1, 1)
            };
            var results = ValidateModel(client);
            Assert.Contains(results, r => r.MemberNames.Contains("Email"));
        }

        [Fact]
        public void Client_BirthDateInFuture_ShouldFail()
        {
            var client = new Client
            {
                LastName = "Петров Петр",
                Email = "petrov@example.com",
                Phone = "89123456789",
                BirthDate = DateTime.Now.AddDays(1)
            };
            var results = ValidateModel(client);

            Assert.Contains(results, r => r.ErrorMessage == "Дата рождения не может быть в будущем");
        }


        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}