using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum SortBy
    {
        Author,
        Title,
        Year,
        Rating
    }
    public enum SearchingCriteria
    {
        Title,
        Author,
        Tag
    }
    public class BookManager
    {
        List<Book> books = new List<Book>();

        public void ViewInfoForAllBooks()
        {
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"- {books[i].Name}, {books[i].Author}, {books[i].Type}, {books[i].ID}");
            }
        }
        public void ViewInfoForSpecificBook(string bookID)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (bookID == books[i].ID)
                {
                    Console.WriteLine($"- {books[i].Author}, {books[i].Name}, {books[i].Type}, {books[i].Desctiption}, " +
                        $"{books[i].YearOfPublication}, {books[i].Rating}, {books[i].ID}");
                    break;
                }
            }
        }
        public List<Book> FindBookByCriteria(SearchingCriteria criteria, string keyword)//???
        {
            List<string> comand = keyword.Split(' ').ToList();
            int numKeywords = comand.Count;
            List<Book> searchedBook = new List<Book>();
            
            if (SearchingCriteria.Title == criteria)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = 0; j < numKeywords; j++)
                    {
                        if (books[i].Name.Contains(comand[j]))
                        {
                            searchedBook.Add(books[i]);
                            break;
                        }
                    }
                }
            }
            else if (SearchingCriteria.Author == criteria)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = 0; j < numKeywords; j++)
                    {
                        if (books[i].Author.Contains(comand[j]))
                        {
                            searchedBook.Add(books[i]);
                            break;
                        }
                    }
                }
            }
            else if (SearchingCriteria.Tag == criteria)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = 0; j < numKeywords; j++)
                    {
                        if (books[i].KeyWords.Contains(comand[j]))
                        {
                            searchedBook.Add(books[i]);
                            break;
                        }
                    }
                }
            }
            return searchedBook;
        }
        public void SortBooksByTile(SortBy sortKey, bool ascending)
        {
            List<Book> sortedList = new List<Book>();
            if (sortKey == SortBy.Title)
            {
                if (ascending)
                {
                    sortedList = books.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    sortedList = books.OrderByDescending(x => x.Name).ToList();
                }
            }
            else if (sortKey == SortBy.Author)
            {
                if (ascending)
                {
                    sortedList = books.OrderBy(x => x.Author).ToList();
                }
                else
                {
                    sortedList = books.OrderByDescending(x => x.Author).ToList();
                }
            }
            else if (sortKey == SortBy.Year)
            {
                if (ascending)
                {
                    sortedList = books.OrderBy(x => x.YearOfPublication).ToList();
                }
                else
                {
                    sortedList = books.OrderByDescending(x => x.YearOfPublication).ToList();
                }
            }
            else if (sortKey == SortBy.Rating)
            {
                if (ascending)
                {
                    sortedList = books.OrderBy(x => x.Rating).ToList();
                }
                else
                {
                    sortedList = books.OrderByDescending(x => x.Rating).ToList();
                }
            }

            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine($"- {sortedList[i].Author}, {sortedList[i].Name}, {sortedList[i].Type}, {sortedList[i].Desctiption}, " +
                        $"{sortedList[i].YearOfPublication}, {sortedList[i].Rating}, {sortedList[i].ID}");
            }
        }
    }
}
