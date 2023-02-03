using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        //private string Author;
        //private string Name;
        //private string Type;
        //private string Description;
        //private string YearOfPublication;
        //private string KeyWords;
        //private double Rating;
        //private int ID;

        public string Author { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Desctiption { get; private set; }
        public string YearOfPublication { get; private set; }
        public string KeyWords { get; private set; }
        public double Rating { get; private set; }
        public string ID { get; private set; }


        public Book(string author, string bookName, string type, string description, string yearOfPublication, string keyWords, double rating,  string id)
        {
            Author = author;
            Name = bookName;
            Type = type;
            Desctiption = description;
            YearOfPublication = yearOfPublication;
            KeyWords = keyWords;
            Rating = rating;
            ID = id;
        }

    }

    //public class Library
    //{
    //    private List<Book> books = new List<Book>();

    //    public void AddBook()
    //    {
    //        Book newBook = new Book();

    //        string author = Console.ReadLine();
    //        newBook.SetAuthor( author);//Console.ReadLine();
    //        //string name = Console.ReadLine();
    //        newBook.Name = Console.ReadLine();
    //        //... drugi stoinosti za chetene ot konzolata

    //        //Book newBook = new Book(author, name);

    //    }

    //    public void RemoveBook();
    }
