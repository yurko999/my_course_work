using Publication.Data.models;
using System.Collections.Generic;
using System.Linq;

namespace Publication.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContext content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Book.Any())
                content.Book.AddRange(Books.Select(c => c.Value));

            content.SaveChanges();
        }

        private static Dictionary<string, Category> _categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var list = new Category[]
                    {
                        new Category{ CategoryName = "Дитяча література", CategoryLink = "Kids", Description = "Книжки призначені для дітей віком 3+"},
                        new Category{ CategoryName = "Шкільна література", CategoryLink = "School", Description = "Книжки призначені школярів"},
                        new Category{ CategoryName = "Доросла література", CategoryLink = "Adults", Description = "Книжки призначені для дорослих"},
                        new Category{ CategoryName = "Підготовка до школи, ДПА, ЗНО", CategoryLink = "Preparing", Description = "Книжки призначені для підготовки до школи, ДПА, ЗНО"}
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (var el in list)
                        _categories.Add(el.CategoryName, el);
                }

                return _categories;
            }
        }

        private static Dictionary<string, Book> _books;

        public static Dictionary<string, Book> Books
        {
            get
            {
                if (_books == null)
                {
                    var list = new Book[]
                    {
                        new Book
                        {
                            Name = "Аліса в країні чудес",
                            LongDescription = "Знаменита казкова історія англійського письменника й математика Льюїса Керолла про пригоди дівчинки Аліси в чарівній країні Задзеркалля. Для середнього шкільного віку.",
                            Image = "/img/AlisaInWonderLand.jpg",
                            Price = 299,
                            IsFavourite = true,
                            IsAvailable = true,
                            Category = _categories["Дитяча література"]
                        },
                        new Book
                        {
                            Name = "Німецька мова: підручник для 8 класу ЗНЗ",
                            LongDescription = "Підручник з Німецької мови, 8 клас.",
                            Image = "/img/GermanLanguageBook8Grade.gif",
                            Price = 150,
                            IsFavourite = false,
                            IsAvailable = true,
                            Category = _categories["Шкільна література"]
                        },
                        new Book
                        {
                            Name = "Люди міленіуму",
                            LongDescription = "Маркхему здається, що він от-от нащупає шляхи, що ведуть до винуватців загибелі його дружини, але потроху він піддається власним прихованим пристрастям і перетворюється на одного з функціонерів таємної організації.",
                            Image = "/img/MillenniumPeople.jpg",
                            Price = 150,
                            IsFavourite = true,
                            IsAvailable = true,
                            Category = _categories["Доросла література"]
                        },
                        new Book
                        {
                            Name = "Чигиринський сотник",
                            LongDescription = "Захоплююча розповідь про пригоди маленького козачка Михася та козака-характерника Обуха. У романі оживають легенди і міфи з української демонології, усі події часів козацтва відбуваються в атмосфері казковості, таємничого пророцтва.",
                            Image = "/img/ChigirinskyCenturion.jpg",
                            Price = 130,
                            IsFavourite = true,
                            IsAvailable = true,
                            Category = _categories["Доросла література"]
                        },
                        new Book
                        {
                            Name = "Казка за казкою. Баба-Яга",
                            LongDescription = "У цій чарівній ілюстрованій книзі Ен Лейсен пропонує новий переказ класичної казки про Бабу-Ягу. Для всіх, хто любить захопливі історії.",
                            Image = "/img/BabaYaga.jpg",
                            Price = 175,
                            IsFavourite = true,
                            IsAvailable = true,
                            Category = _categories["Дитяча література"]
                        },
                        new Book
                        {
                            Name = "Enjoy English. English. Level 1. Activity Book",
                            LongDescription = "Видання (автор Куварзіна М.В.) являє собою збірник вправ на засвоєння й відпрацювання літер, елементарної лексики й граматики англійської мови. Тематика посібника відповідає чинній програмі з іноземних мов.",
                            Image = "/img/EnglishLanguageBook1Level.jpg",
                            Price = 25,
                            IsFavourite = true,
                            IsAvailable = true,
                            Category = _categories["Шкільна література"]
                        }
                    };

                    _books = new Dictionary<string, Book>();

                    foreach (var el in list)
                        _books.Add(el.Name, el);
                }

                return _books;
            }
        }
    }
}
