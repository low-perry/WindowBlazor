using WindowBlazor_Models;

namespace WindowBlazor_Client.ViewModels
{
    public class ShoppingCart
    {
        public int WindowId { get; set; }
        public WindowDTO Window { get; set; }
        public int Count { get; set; }
    }
}
