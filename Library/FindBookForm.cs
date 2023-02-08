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
    public partial class FindBookForm : Form
    {
        public SearchingCriteria criteria;
        public string searchWords;
        public bool findClicked;
        public FindBookForm()
        {
            InitializeComponent();
            comboBox1.Items.Add(SearchingCriteria.Author);
            comboBox1.Items.Add(SearchingCriteria.Tag);
            comboBox1.Items.Add(SearchingCriteria.Title);
            comboBox1.SelectedIndex = 0;
            searchWords = string.Empty;
            criteria = (SearchingCriteria)comboBox1.Items[comboBox1.SelectedIndex];
            findClicked = false;
            keywords.Text = string.Empty;


        }

        private void findBookButton_Click(object sender, EventArgs e)
        {
            criteria = (SearchingCriteria)comboBox1.Items[comboBox1.SelectedIndex];
            findClicked = true;
            searchWords = keywords.Text;
            Close();
        }
    }
}
