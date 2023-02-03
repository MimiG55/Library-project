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
    public partial class LoginForm : Form
    {
        public string Username;
        public string Password;
        public bool LoginClicked;
        public bool ExitClicked;

        public LoginForm()
        {
            InitializeComponent();
            Username = "";
            Password = "";
            LoginClicked = false;
            ExitClicked = false;
            TextBoxUsername.Text = "";
            textBoxPassword.Text = "";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
            //Application.Exit();
            ExitClicked = true;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Username = TextBoxUsername.Text;
            Password = textBoxPassword.Text;
            LoginClicked = true;
            Close();
        }
    }
}
