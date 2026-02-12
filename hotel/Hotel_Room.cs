namespace hotel
{
    public class Hotel_Room : EFModel
    {
        public string RoomNumber { get; set; }
        public string Floor { get; set; }
        public int Building { get; set; }
        public int Category { get; set; }
    }
}
