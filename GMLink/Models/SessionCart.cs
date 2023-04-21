using Newtonsoft.Json;
using GMLink.Infrastructure;

namespace GMLink.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
            ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Reservation reservation, int quantity)
        {
            base.AddItem(reservation, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Reservation reservation)
        {
            base.RemoveLine(reservation);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}