namespace GMLink.Models
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> Purchases { get; }
        void SaveOrder(Purchase purchase);
    }
}
