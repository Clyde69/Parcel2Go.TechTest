namespace Parcel2Go.TestTest.Entities.Models
{
    public class Transaction
    {
        public Guid Reference { get; private set; } = Guid.NewGuid();
        public DateTime Start { get; private set; } = DateTime.UtcNow;
        public List<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
    }
}
