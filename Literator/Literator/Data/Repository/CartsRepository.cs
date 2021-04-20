using Literator.Data.Interfaces;
using Literator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data.Repository
{
    public class CartsRepository : ICarts
    {
        private readonly AppDBContent dbcontent;

        private void _DeleteBook(string booksId, int bookId)
        {
            string elem = "";
            List<string> strlst = new List<string>();
            for(int i = 0; i < booksId.Length; i++)
            {
                if (booksId[i] == '/')
                {
                    strlst.Add(elem);
                    elem = "";
                }
                else
                    elem += booksId[i];
            }

            strlst.Remove(booksId);
            booksId = "/";
            for(int i = 0; i < strlst.Count(); i++)
            {
                booksId += strlst[i] + "/";
            }
        }

        public List<int> GetBooksId(int ClientId)
        {
            List<int> lst = new List<int>();
            string elem = "";
            string booksId = GetCart(ClientId).booksId;
            for (int i = 0; i < booksId.Length; i++)
            {
                if (booksId[i] == '/')
                {
                    if (elem != "")
                    {
                        lst.Add(Convert.ToInt32(elem));
                        elem = "";
                    }
                }
                else
                    elem += booksId[i];
            }
            return lst;
        }

        public CartsRepository(AppDBContent appDBContent)
        {
            dbcontent = appDBContent;
        }

        public IEnumerable<Cart> carts => dbcontent.Cart;

        public void AddCartItem(int bookId, int ClientId)
        {
            Cart cart = GetCart(ClientId);
            if (!cart.booksId.Contains($"/{bookId}/"))
            {
                dbcontent.Cart.Find(GetCartId(ClientId)).booksId += $"{bookId}/";
                dbcontent.SaveChanges();
            }
        }

        public void DeleteItem(int bookId, int ClientId)
        {
            Cart cart = GetCart(ClientId);
            if (cart.booksId.Contains($"/{bookId}/"))
            {
                string booksId = "";
                Cart cart2 = dbcontent.Cart.Find(GetCartId(ClientId));
                if (cart2 != null)
                    booksId = cart2.booksId;
                string elem = "";
                List<string> strlst = new List<string>();
                for (int i = 0; i < booksId.Length; i++)
                {
                    if (booksId[i] == '/')
                    {
                        strlst.Add(elem);
                        elem = "";
                    }
                    else
                        elem += booksId[i];
                }

                strlst.Remove(bookId.ToString());
                booksId = "/";
                for (int i = 0; i < strlst.Count(); i++)
                {
                    if(strlst[i] != "")
                        booksId += strlst[i] + "/";
                }
                cart2.booksId = booksId;
                dbcontent.SaveChanges();
            }
        }

        public Cart GetCart(int ClientId)
        {
            if (dbcontent.Cart.Where(c => c.clientId == ClientId).FirstOrDefault() == null)
            {
                dbcontent.Cart.Add(new Cart { clientId = ClientId, booksId = "/" });
                dbcontent.SaveChanges();
            }
            return dbcontent.Cart.Where(c => c.clientId == ClientId).FirstOrDefault();
        }

        public int GetCartId(int ClientId)
        {
            if (dbcontent.Cart.Where(c => c.clientId == ClientId).FirstOrDefault() == null)
            {
                dbcontent.Cart.Add(new Cart { clientId = ClientId, booksId = "/" });
                dbcontent.SaveChanges();
            }
            return dbcontent.Cart.Where(c => c.clientId == ClientId).FirstOrDefault().id;
        }
    }
}
