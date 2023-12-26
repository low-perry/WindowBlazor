using Blazored.LocalStorage;
using WindowBlazor_Client.Service.IService;
using WindowBlazor_Client.ViewModels;
using WindowBlazor_Common;

namespace WindowBlazor_Client.Service
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        public event Action OnChange;

        public CartService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
        }
        public async Task DecrementCart(ShoppingCart cartToDecrement)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);

            //if count is 0 or 1 then we remove the item
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].WindowId == cartToDecrement.WindowId)
                {
                    if (cart[i].Count == 1 || cartToDecrement.Count == 0)
                    {
                        cart.Remove(cart[i]);
                    }
                    else
                    {
                        cart[i].Count -= cartToDecrement.Count;
                    }
                }
            }

            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
            OnChange.Invoke();
        }

        public async Task IncrementCart(ShoppingCart cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);
            bool itemInCart = false;

            if (cart == null)
            {
                cart = new List<ShoppingCart>();
            }
            foreach (var obj in cart)
            {
                if (obj.WindowId == cartToAdd.WindowId)
                {
                    itemInCart = true;
                    obj.Count += cartToAdd.Count;
                }
            }
            if (!itemInCart)
            {
                cart.Add(new ShoppingCart()
                {
                    WindowId = cartToAdd.WindowId,
                    Count = cartToAdd.Count
                });
            }
            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
            OnChange.Invoke();
        }
    }
}
