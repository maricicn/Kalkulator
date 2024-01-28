using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public static Form2 form2instance;
        public Form2()
        {
            InitializeComponent();
            form2instance = this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
