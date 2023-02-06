using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class AddBook : Form
    {
        public string Author;
        public string BookName;
        public string Genre;
        public string Description;
        public string YearOfPublication;
        public string KeyWords;
        public string Rating;
        public string IsbnNumber;
        public bool ButtonAddClicked;
        public AddBook()   
        {
            InitializeComponent();
            Author = string.Empty;
            BookName = string.Empty;
            Genre = string.Empty;
            Description = string.Empty;
            YearOfPublication = string.Empty;
            KeyWords = string.Empty;
            Rating = string.Empty;
            IsbnNumber = string.Empty;
            ButtonAddClicked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Author = textBoxAuthor.Text;
            BookName = textBoxBookName.Text;
            Genre = textBoxGenre.Text;
            Description = textBoxDescr.Text;
            YearOfPublication = textBoxYearOfPublication.Text;
            KeyWords = textBoxKeyWords.Text;
            Rating = textBoxRating.Text;
            IsbnNumber = textBoxISBN.Text;
            ButtonAddClicked = true;
            Close();
        }
    }
}




