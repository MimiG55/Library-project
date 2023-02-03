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
    public partial class AddUser : Form
    {
        public string Username;
        public string Password;
        public bool IsAdmin;
        public bool AddClicked;
        
        public AddUser()
        {
            InitializeComponent();
            Username = "";
            Password = "";
            IsAdmin = false;
            AddClicked = false;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            checkBoxAdminRights.Checked = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Username = txtUsername.Text;
            Password = txtPassword.Text;
            IsAdmin = checkBoxAdminRights.Checked;
            
            if (Username==string.Empty)
            {
                MessageBox.Show("You should fill in username!");
                return;
            }
            if (Password==string.Empty)
            {
                MessageBox.Show("You should fill in username!");
                return;
            }     
            AddClicked = true;
            Close();
        }
    }
}
