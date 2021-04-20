using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Literator.Data.Models;

namespace Literator.Data.Interfaces
{
    public interface ICarts
    {
        IEnumerable<Cart> carts { get; }

        Cart GetCart(int ClientId);

        int GetCartId(int ClientId);

        void AddCartItem(int bookId, int ClientId);

        void DeleteItem(int bookId, int ClientId);

        List<int> GetBooksId(int ClientId);
    }
}
