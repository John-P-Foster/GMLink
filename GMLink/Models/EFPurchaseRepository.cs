using Microsoft.EntityFrameworkCore;

namespace GMLink.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private ApplicationDbContext context;
        public EFPurchaseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Purchase> Purchases => context.Purchases
        .Include(o => o.Lines)
       .ThenInclude(l => l.Reservation);
        public void SaveOrder(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(l => l.Reservation));
            if (purchase.PurchaseID == 0)
            {
                context.Purchases.Add(purchase);
            }
            context.SaveChanges();
        }
    }
}
