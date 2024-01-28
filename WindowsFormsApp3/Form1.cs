﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public string operacija;
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
            textBox3.Text = string.Empty;
            label2.Text = string.Empty;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!RimskiBroj.ProveriRimski(textBox1.Text)) {
                label2.Text = "Uneli ste nepostojeci rimski broj!";
            }
            if (!RimskiBroj.ProveriRimski(textBox2.Text))
            {
                label2.Text = "Uneli ste nepostojeci rimski broj!";
            }
            if(RimskiBroj.ProveriRimski(textBox1.Text) && RimskiBroj.ProveriRimski(textBox2.Text))
            {
                int rb1 = RimskiBroj.RimskiPaInt(textBox1.Text);
                int rb2 = RimskiBroj.RimskiPaInt(textBox2.Text);
                int ukupno = 0;
                switch (operacija)
                {
                    case "+": 
                        ukupno = rb1 + rb2;
                        if(ukupno > 3999 || ukupno < 0)
                        {
                            textBox3.Text = ukupno.ToString();
                            label2.Text = "Rezultat se ne moze predstaviti kao rimski broj!";
                        }
                        else 
                        {
                            textBox3.Text = RimskiBroj.IntPaRimski(ukupno);
                        }
                        break;
                    case "-":
                        ukupno = rb1 - rb2;
                        if (ukupno > 3999 || ukupno < 0)
                        {
                            textBox3.Text = ukupno.ToString();
                            label2.Text = "Rezultat se ne moze predstaviti kao rimski broj!";
                        }
                        else
                        {
                            textBox3.Text = RimskiBroj.IntPaRimski(ukupno);
                        }
                        break;
                    case "*":
                        ukupno = rb1 * rb2;
                        if (ukupno > 3999 || ukupno < 0)
                        {
                            textBox3.Text = ukupno.ToString();
                            label2.Text = "Rezultat se ne moze predstaviti kao rimski broj!";
                        }
                        else
                        {
                            textBox3.Text = RimskiBroj.IntPaRimski(ukupno);
                        }
                        break;
                }

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            operacija = "+";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            operacija = "-";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            operacija = "*";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            operacija = "/";
        }
    }
    class RimskiBroj
    {
        public static bool ProveriRimski(string rimski)
        {
            string strRegex = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(rimski))
                return true;
            else
                return false;
        }
        public static int RimskiPaInt(string s)
        {
            int tren = 0;
            int prvi = 0;
            int drugi = 0;
            int rezultat = 0;
            while (tren < s.Length - 1)
            {
                prvi = 0;
                drugi = 0;
                switch (s[tren])
                {
                    case 'I':
                        prvi = 1;
                        break;
                    case 'V':
                        prvi = 5;
                        break;
                    case 'X':
                        prvi = 10;
                        break;
                    case 'L':
                        prvi = 50;
                        break;
                    case 'C':
                        prvi = 100;
                        break;
                    case 'D':
                        prvi = 500;
                        break;
                    case 'M':
                        prvi = 1000;
                        break;
                }

                switch (s[tren + 1])
                {
                    case 'I':
                        drugi = 1;
                        break;
                    case 'V':
                        drugi = 5;
                        break;
                    case 'X':
                        drugi = 10;
                        break;
                    case 'L':
                        drugi = 50;
                        break;
                    case 'C':
                        drugi = 100;
                        break;
                    case 'D':
                        drugi = 500;
                        break;
                    case 'M':
                        drugi = 1000;
                        break;
                }
                if (prvi >= drugi)
                {
                    rezultat += prvi;
                }
                else
                {
                    rezultat -= prvi;
                }
                tren++;
            }
            if (tren == 0)
            {
                switch (s[tren])
                {
                    case 'I':
                        prvi = 1;
                        break;
                    case 'V':
                        prvi = 5;
                        break;
                    case 'X':
                        prvi = 10;
                        break;
                    case 'L':
                        prvi = 50;
                        break;
                    case 'C':
                        prvi = 100;
                        break;
                    case 'D':
                        prvi = 500;
                        break;
                    case 'M':
                        prvi = 1000;
                        break;
                }
                return prvi;
            }
            else
            {
                rezultat += drugi;
                return rezultat;
            }


        }
        public static string IntPaRimski(int broj)
        {
            int pom = broj;
            int jedinice = broj % 10;
            int desetice = broj % 100 - jedinice;
            int stotine = broj % 1000 - jedinice - desetice;
            string rezultat = "";
            while (pom > 0)
            {
                if (pom >= 1000)
                {
                    pom -= 1000;
                    rezultat += "M";
                    continue;
                }

                else if (stotine == 900)
                {
                    pom -= 900;
                    stotine -= 900;
                    rezultat += "CM";
                    continue;
                }
                else if (stotine >= 500)
                {
                    pom -= 500;
                    stotine -= 500;
                    rezultat += "D";
                    continue;
                }
                else if (stotine == 400)
                {
                    pom -= 400;
                    stotine -= 400;
                    rezultat += "CD";
                    continue;
                }
                else if (stotine >= 100)
                {
                    pom -= 100;
                    stotine -= 100;
                    rezultat += "C";
                    continue;
                }
                else if (desetice == 90)
                {
                    pom -= 90;
                    desetice -= 90;
                    rezultat += "XC";
                    continue;
                }
                else if (desetice >= 50)
                {
                    pom -= 50;
                    desetice -= 50;
                    rezultat += "L";
                    continue;
                }
                else if (desetice == 40)
                {
                    pom -= 40;
                    desetice -= 40;
                    rezultat += "XL";
                    continue;
                }
                else if (desetice >= 10)
                {
                    pom -= 10;
                    desetice -= 10;
                    rezultat += "X";
                    continue;
                }
                else if (jedinice == 9)
                {
                    pom -= 9;
                    jedinice -= 9;
                    rezultat += "IX";
                    continue;
                }
                else if (jedinice >= 5)
                {
                    pom -= 5;
                    jedinice -= 5;
                    rezultat += "V";
                    continue;
                }
                else if (jedinice == 4)
                {
                    pom -= 4;
                    jedinice -= 4;
                    rezultat += "IV";
                    continue;
                }
                else if (jedinice >= 1)
                {
                    pom -= 1;
                    jedinice -= 1;
                    rezultat += "I";
                    continue;
                }

            }
            return rezultat;
        }
    }
}
