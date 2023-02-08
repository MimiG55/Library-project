using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Library
{
    public partial class MainForm : Form
    {

        private User curentUser = null;
        private string currentUsername = string.Empty;
        private BookManager bookManager = new BookManager();
        private UserManager usersList = new UserManager();

        public MainForm()
        {
            InitializeComponent();
            usersList.AddUser("admin", "i<3c++", UserRights.Admin);
            StreamReader reader = new StreamReader(@"C:\Test\users.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                List<string> user = line.Split(' ').ToList();
                if (user[2].Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    usersList.AddUser(user[0], user[1], UserRights.Admin);
                }
                else
                {
                    usersList.AddUser(user[0], user[1], UserRights.Regular);
                }
            }
            StreamReader bookReader = new StreamReader(@"C:\Test\books.txt");
            while ((line = bookReader.ReadLine()) != null)
            {
                List<string> books = line.Split('+').ToList();
                //if (currentUsername != string.Empty)
                //{
                bookManager.AddBook(books[0], books[1], books[2], books[3], books[4], books[5], books[6], books[7]);
                //}
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUsername != string.Empty)
            {
                MessageBox.Show("You are already logged in.");
                return;
            }

            var loginform = new LoginForm();
            loginform.Show();

            while (!loginform.LoginClicked && !loginform.ExitClicked)
            {
                Application.DoEvents();
            }

            if (loginform.LoginClicked)
            {
                if (usersList.VerifyUser(loginform.Username, loginform.Password))
                {
                    MessageBox.Show($"Welcome, {loginform.Username}!");
                    currentUsername = loginform.Username;
                    curentUser = usersList.GetUser(loginform.Username);
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentUsername = string.Empty;
        }

        private void usersAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUsername == string.Empty)
            {
                MessageBox.Show("You should login!");
            }
            else
            {
                if (curentUser.Rights == UserRights.Admin)
                {
                    var addForm = new AddUser();
                    addForm.Show();
                    while (!addForm.AddClicked)
                    {
                        Application.DoEvents();
                    }
                    if (addForm.AddClicked)
                    {
                        if (addForm.Username.Contains(" ") && addForm.Username.Contains(","))
                        {
                            MessageBox.Show("You can't use space or coma for username");
                            return;
                        }
                        if (usersList.GetUser(addForm.Username) == null)//user don't exist
                        {
                            StreamWriter txt = new StreamWriter(@"C:\Test\users.txt", true);
                            if (addForm.IsAdmin)//if the new user is with admin rights
                            {
                                usersList.AddUser(addForm.Username, addForm.Password, UserRights.Admin);
                                txt.WriteLine($"{addForm.Username} {addForm.Password} {UserRights.Admin}");
                            }
                            else//if the new user is with regular rights
                            {
                                usersList.AddUser(addForm.Username, addForm.Password, UserRights.Regular);
                                txt.WriteLine($"{addForm.Username} {addForm.Password} {UserRights.Regular}");
                            }
                            txt.Flush();
                            txt.Close();

                        }
                        else//the user is already exist
                        {
                            MessageBox.Show("This username already exists!\nTry with another username!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You should have admin rights!");
                }
            }


        }

        private void usersRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUsername == string.Empty)
            {
                MessageBox.Show("You should login!");
            }
            else
            {
                if (curentUser.Rights == UserRights.Admin)
                {
                    var deleteUserForm = new DeleteUserForm();
                    deleteUserForm.Show();
                    while (!deleteUserForm.RemoveClicked)
                    {
                        Application.DoEvents();
                    }
                    if (deleteUserForm.RemoveClicked)
                    {
                        if (currentUsername == deleteUserForm.Username)
                        {
                            MessageBox.Show("You can't delete currently logged user!\nAsk another admin!");
                            return;
                        }
                        else if (deleteUserForm.Username == "admin")
                        {
                            MessageBox.Show("You can't delete this user!");
                            return;
                        }
                        else
                        {
                            usersList.RemoveUser(deleteUserForm.Username);
                            MessageBox.Show($"{deleteUserForm.Username} was deleted!");
                        }
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            List<Book> books = bookManager.GetAllBooks();
            if (currentUsername != string.Empty)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    ListViewItem item = new ListViewItem(books[i].Name);
                    item.SubItems.Add(books[i].Author);
                    item.SubItems.Add(books[i].Type);
                    item.SubItems.Add(books[i].ID);
                    item.SubItems.Add(books[i].Desctiption);
                    listView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("You should login!");
            }
        }

        private void booksAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUsername == string.Empty || curentUser.Rights == UserRights.Regular)
            {
                MessageBox.Show("You are not logged in or you don't have admin rights.");
            }
            else
            {
                var booksAddForm = new AddBook();
                booksAddForm.Show();
                while (!booksAddForm.ButtonAddClicked)
                {
                    Application.DoEvents();
                }
                if (booksAddForm.ButtonAddClicked && curentUser.Rights == UserRights.Admin)
                {
                    bookManager.AddBook(booksAddForm.Author, booksAddForm.BookName, booksAddForm.Genre, booksAddForm.Description,
                        booksAddForm.YearOfPublication, booksAddForm.KeyWords, booksAddForm.Rating, booksAddForm.IsbnNumber);
                    StreamWriter txt = new StreamWriter(@"C:\Test\books.txt", true);
                    txt.WriteLine("{0}+{1}+{2}+{3}+{4}+{5}+{6}+{7}", booksAddForm.Author, booksAddForm.BookName, booksAddForm.Genre, booksAddForm.Description,
                        booksAddForm.YearOfPublication, booksAddForm.KeyWords, booksAddForm.Rating, booksAddForm.IsbnNumber);
                    txt.Flush();
                    txt.Close();
                }



            }

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindBookForm fbf = new FindBookForm();
            fbf.Show();
            while (!fbf.findClicked)
            {
                Application.DoEvents();
            }
            if (fbf.searchWords == string.Empty)
            {
                MessageBox.Show("You need to fill in keywords in the Find Book Form!");
                return;
            }
            ListViewItem findBook = bookManager.FindBookByCriteria(fbf.criteria, fbf.searchWords);
            if (currentUsername != string.Empty && findBook != null)
            {
                listView.Items.Clear();
                listView.Items.Add(findBook);
            }
            else
            {
                MessageBox.Show("You don't have a book with this criteria!");
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUsername != string.Empty)
            {
                string isbn = Interaction.InputBox("Please fill in book ISBN number:", "Find book");
                if (isbn == string.Empty) return;
                ListViewItem specItem = bookManager.ViewInfoForSpecificBook(isbn);
                if (specItem == null)
                {
                    MessageBox.Show("You don't have a book with this ISBN number!");
                }
                else
                {

                    listView.Items.Clear();
                    listView.Items.Add(specItem);

                }
            }
            else
            {
                MessageBox.Show("You should log in!");
            }

        }
    }
}
