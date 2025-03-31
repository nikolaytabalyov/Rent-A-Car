namespace RentACar.Models {
    public class Car {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int PassengerSeats { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
