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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible) 
            {
                panel1.Visible = false;
                panel2.Visible = true;
                pictureBox1.BackgroundImage = Properties.Resources.arapi;
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
                pictureBox1.BackgroundImage = Properties.Resources.koloseum;
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = textBox1.Text + "I";
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = textBox2.Text + "I";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = textBox1.Text + "V";
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = textBox2.Text + "V";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = textBox1.Text + "X";
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = textBox2.Text + "X";
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = textBox1.Text + "L";
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = textBox2.Text + "L";
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = textBox1.Text + "C";
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = textBox2.Text + "C";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = textBox1.Text + "D";
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = textBox2.Text + "D";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = textBox1.Text + "M";
            }
            if (radioButton2.Checked)
            {
                textBox2.Text = textBox2.Text + "M";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }
}
