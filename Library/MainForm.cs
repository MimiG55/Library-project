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
                            StreamWriter txt = new StreamWriter(@"C:\Test\users.txt");
                            if (addForm.IsAdmin)//if the new user is with admin rights
                            {
                                usersList.AddUser(addForm.Username, addForm.Password, UserRights.Admin);
                                txt.Write($"{addForm.Username} {addForm.Password} {UserRights.Admin}");
                            }
                            else//if the new user is with regular rights
                            {
                                usersList.AddUser(addForm.Username, addForm.Password, UserRights.Regular);
                                txt.Write($"{addForm.Username} {addForm.Password} {UserRights.Regular}");
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
            List<Book> books = bookManager.GetAllBooks();//da dobawq da gi chete ot txt faila
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

        private void booksAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUsername==string.Empty || curentUser.Rights==UserRights.Regular)
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
                if (booksAddForm.ButtonAddClicked && curentUser.Rights==UserRights.Admin)
                {
                    bookManager.AddBook(booksAddForm.Author, booksAddForm.BookName, booksAddForm.Genre, booksAddForm.Description,
                        booksAddForm.YearOfPublication, booksAddForm.KeyWords, booksAddForm.Rating, booksAddForm.IsbnNumber);
                    StreamWriter txt = new StreamWriter(@"C:\Test\books.txt");
                    txt.Write("{0} {1} {2} {3} {4} {5} {6} {7}", booksAddForm.Author, booksAddForm.BookName, booksAddForm.Genre, booksAddForm.Description,
                        booksAddForm.YearOfPublication, booksAddForm.KeyWords, booksAddForm.Rating, booksAddForm.IsbnNumber);
                    txt.Flush();
                    txt.Close();
                }



            }
           
        }
    }
}
