
namespace GMLink.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Reservation reservation, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Reservation.ReservationID == reservation.ReservationID)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Reservation = reservation,
                    Quantity = 1
                });
            }

 else
            {
                line.Quantity = 1;
            }
        }
        public virtual void RemoveLine(Reservation reservation) =>
        lineCollection.RemoveAll(l => l.Reservation.ReservationID == reservation.ReservationID);
        public virtual decimal ComputeTotalValue() =>
        lineCollection.Sum(e => e.Reservation.Price);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Reservation Reservation { get; set; }
        public int Quantity { get; set; }
    }
}