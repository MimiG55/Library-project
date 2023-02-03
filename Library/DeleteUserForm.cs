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
    public partial class DeleteUserForm : Form
    {
        public string Username;
        public bool RemoveClicked;
        public DeleteUserForm()
        {
            InitializeComponent();
            Username = string.Empty;
            RemoveClicked = false;
            txtUsername.Text = string.Empty;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

            Username = txtUsername.Text;
            if (Username==string.Empty)
            {
                MessageBox.Show("You should fill in the username!");
                return;
            }

            RemoveClicked = true;
           
            Close();
        }
    }
}
