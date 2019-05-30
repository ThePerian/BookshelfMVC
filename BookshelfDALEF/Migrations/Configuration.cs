namespace BookshelfDALEF.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookshelfDALEF.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookshelfDALEF.EF.BookshelfEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BookshelfDALEF.EF.BookshelfEntities";
        }

        protected override void Seed(BookshelfDALEF.EF.BookshelfEntities context)
        {
            var stores = new List<Store>
            {
                new Store{ ShortName = "Ozon", URL = "ozon.ru" },
                new Store{ ShortName = "Book24", URL = "book24.ru" },
                new Store{ ShortName = "�����-�����", URL = "chitai-gorod.ru" },
                new Store{ ShortName = "����������", URL = "ffan.ru" }
            };
            stores.ForEach(x => 
                context.Stores.AddOrUpdate(s => new { s.ShortName, s.URL }, x));

            var books = new List<Inventory>
            {
                new Inventory
                {
                    Author = "��. �. �. ������",
                    BookName = "����� � �����. ����� ��������",
                    ReadStatus = true
                },
                new Inventory
                {
                    Author = "���� ����������",
                    BookName = "������. ����� 6",
                    ReadStatus = false
                },
                new Inventory
                {
                    Author = "���� ����������",
                    BookName = "����������� ���. ������-�����",
                    ReadStatus = false
                },
                new Inventory
                {
                    Author = "�������� ����",
                    BookName = "���������� �����",
                    ReadStatus = false
                }
            };
            books.ForEach(x => 
                context.Inventory.AddOrUpdate(i => new { i.Author, i.BookName, i.ReadStatus }, x));

            var wishes = new List<Wishlist>
            {
                new Wishlist
                {
                    Author = "������ ������",
                    BookName = "����� ������ � ���� ������"
                },
                new Wishlist
                {
                    Author = "������� ������",
                    BookName = "CLR via C#"
                },
                new Wishlist
                {
                    Author = "���� ������",
                    BookName = "��������. ������ �����",
                    Store = stores[0]
                }
            };
            wishes.ForEach(x => 
                context.Wishlist.AddOrUpdate(w => new { w.Author, w.BookName, w.Store }, x));

            var orders = new List<Order>
            {
                new Order{ Book = wishes[0], Store = stores[2]},
                new Order{ Book = wishes[1], Store = stores[1]},
                new Order{ Book = wishes[2], Store = wishes[2].Store},
            };
            orders.ForEach(x => 
                context.Orders.AddOrUpdate(o => new { o.BookId, o.StoreId }, x));

            context.SaveChanges();
        }
    }
}
