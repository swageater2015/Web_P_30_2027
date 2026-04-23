namespace Hotel.Model
{
    public class Hotel_Room : EFModel
    {
        public string? RoomNumber { get; set; }
        public string? Floor { get; set; }
        public int Building { get; set; }
        public string? Category { get; set; }

        public int? ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
