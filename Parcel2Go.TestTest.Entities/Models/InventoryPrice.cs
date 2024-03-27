using Parcel2Go.TestTest.Entities.Enums;

namespace Parcel2Go.TestTest.Entities.Models
{
    public record InventoryPrice(InventoryType Type, IEnumerable<Price> Prices)
    {
        public InventoryType Type { get; private set; } = Type;
        public IEnumerable<Price> Prices { get; private set; } = Prices;
    }
}
