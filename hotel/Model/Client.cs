namespace Hotel.Model
{
    public class Client : EFModel
    {
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
