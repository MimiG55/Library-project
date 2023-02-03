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
    public partial class MainForm : Form
    {

        private User curentUser = null;
        private string currentUsername = string.Empty;

        private UserManager usersList = new UserManager();
        public MainForm()
        {
            InitializeComponent();
            usersList.AddUser("admin", "i<3c++", UserRights.Admin);
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
                        if (usersList.GetUser(addForm.Username) == null)//user already exist
                        {
                            if (addForm.IsAdmin)
                            {
                                usersList.AddUser(addForm.Username, addForm.Password, UserRights.Admin);
                            }
                            else
                            {
                                usersList.AddUser(addForm.Username, addForm.Password, UserRights.Regular);
                            }
                        }
                        else
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
    }
}
