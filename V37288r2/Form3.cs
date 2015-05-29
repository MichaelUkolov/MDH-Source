using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form3 : Form
    {
        public Form3(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
