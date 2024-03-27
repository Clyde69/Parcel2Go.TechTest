namespace Parcel2Go.TestTest.Entities.Models
{
    public record Price(int Quantity, decimal Value)
    {
        public int Quantity { get; private set; } = Quantity;
        public decimal Value { get; private set; } = Value;
    }
}
