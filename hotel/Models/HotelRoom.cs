namespace hotel.Models
{
    public class HotelRoom : EFModel
    {
        public string Room_Number { get; set; }
        public string building { get; set; }
        public int floor { get; set; }
        public string category { get; set; }
    }
}
