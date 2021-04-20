using Literator.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Literator.Data
{
    public class DBObjects
    {
        private static Dictionary<string, Client> clients;
        private static Dictionary<string, Book> books;
        private static Dictionary<string, Gender> genders;
        private static Dictionary<string, Role> roles;

        public static void Start(AppDBContent content)
        {
            if(!content.Client.Any())
                content.Client.AddRange(Clients.Select(c => c.Value));

            if (!content.Book.Any())
                content.Book.AddRange(Books.Select(c => c.Value));

            if (!content.gender.Any())
                content.gender.AddRange(Genders.Select(c => c.Value));

            if (!content.role.Any())
                content.role.AddRange(Roles.Select(c => c.Value));

            content.SaveChanges();
        }

        public static Dictionary<string, Client> Clients
        {
            get
            {
                if (clients == null)
                {
                    var lst = new Client[]
                    {
                        new Client
                        {
                            roleId = 1,
                            genderId = 1,
                            email = "User@mail.ru",
                            password = "5247Tima%",
                            name = "User"
                        },
                        new Client
                        {
                            roleId = 2,
                            genderId = 1,
                            email = "Admin@mail.ru",
                            password = "5247Tima%",
                            name = "Admin"
                        }
                    };

                    clients = new Dictionary<string, Client>();
                    foreach (Client i in lst)
                        clients.Add(i.name, i);
                }

                return clients;
            }
        }

        public static Dictionary<string, Book> Books
        {
            get
            {
                if(books == null)
                {
                    var lst = new Book[]
                    {
                        new Book
                        {
                            name = "Book1",
                            author = "Author1",
                            price = 1,
                            description = "descBook1",
                            isNew = true,
                            isBestSeller = false,
                            isForSale = false
                        }
                    };

                    books = new Dictionary<string, Book>();
                    foreach (Book i in lst)
                        books.Add(i.name, i);
                }    

                return books;
            }
        }

        public static Dictionary<string, Gender> Genders
        {
            get
            {
                if (genders == null)
                {
                    var lst = new Gender[]
                    {
                        new Gender
                        {
                            name = "Unknown"
                        },
                        new Gender
                        {
                            name = "Male"
                        },
                        new Gender
                        {
                            name = "Female"
                        }
                    };

                    genders = new Dictionary<string, Gender>();
                    foreach (Gender i in lst)
                        genders.Add(i.name, i);
                }

                return genders;
            }
        }

        public static Dictionary<string, Role> Roles
        {
            get
            {
                if (roles == null)
                {
                    var lst = new Role[]
                    {
                        new Role
                        {
                            name = "User"
                        },
                        new Role
                        {
                            name = "Admin"
                        }
                    };

                    roles = new Dictionary<string, Role>();
                    foreach (Role i in lst)
                        roles.Add(i.name, i);
                }

                return roles;
            }
        }
    }
}
