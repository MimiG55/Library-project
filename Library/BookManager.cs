using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void AddBook(string author, string bookName, string genre, string description, string yearOfPublication, string keyWords, string rating, string isbnNumber)
        {
            double rate;
            if (double.TryParse(rating, out rate))
            {
                Book book = new Book(author, bookName, genre, description, yearOfPublication, keyWords, rate, isbnNumber);
                books.Add(book);
            }
            else
            {
                MessageBox.Show("Incorect format for rating!");
            }

        }

        public List<Book> GetAllBooks()
        {
            return books;
        }
        public ListViewItem ViewInfoForSpecificBook(string bookID)
        {
            ListViewItem specItem = null;
            for (int i = 0; i < books.Count; i++)
            {
                if (bookID == books[i].ID)
                {
                    specItem = new ListViewItem(books[i].Name);
                    specItem.SubItems.Add(books[i].Author);
                    specItem.SubItems.Add(books[i].Type);
                    specItem.SubItems.Add(books[i].ID);
                    specItem.SubItems.Add(books[i].Desctiption);
                    break;
                }
            }
            return specItem;
        }
        public ListViewItem FindBookByCriteria(SearchingCriteria criteria, string keyword)//???
        {
            List<string> comand = keyword.Split(' ').ToList();
            int numKeywords = comand.Count;
            ListViewItem searchedBook = null;

            if (SearchingCriteria.Title == criteria)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = 0; j < numKeywords; j++)
                    {
                        if (books[i].Name.Contains(comand[j]))
                        {
                            searchedBook = new ListViewItem(books[i].Name);
                            searchedBook.SubItems.Add(books[i].Author);
                            searchedBook.SubItems.Add(books[i].Type);
                            searchedBook.SubItems.Add(books[i].ID);
                            searchedBook.SubItems.Add(books[i].Desctiption);
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
                            searchedBook = new ListViewItem(books[i].Name);
                            searchedBook.SubItems.Add(books[i].Author);
                            searchedBook.SubItems.Add(books[i].Type);
                            searchedBook.SubItems.Add(books[i].ID);
                            searchedBook.SubItems.Add(books[i].Desctiption);
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
                            searchedBook = new ListViewItem(books[i].Name);
                            searchedBook.SubItems.Add(books[i].Author);
                            searchedBook.SubItems.Add(books[i].Type);
                            searchedBook.SubItems.Add(books[i].ID);
                            searchedBook.SubItems.Add(books[i].Desctiption);
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
