using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;                        // na pracu zo subormi


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string line;
            string file = "winners.txt";
            StreamReader F = new StreamReader(file);

            while (F.EndOfStream == false)
            {
                line = F.ReadToEnd();
                MessageBox.Show(line);

            }

            F.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string line;
            string file = "losers.txt";
            StreamReader F = new StreamReader(file);

            while (F.EndOfStream == false)
            {
                line = F.ReadToEnd();
                MessageBox.Show(line);

            }

            F.Close();
        }




        private void button4_Click(object sender, EventArgs e)
        {
            

            string line;
            string file = "all players.txt";
            StreamReader F = new StreamReader(file);

            while (F.EndOfStream == false)
            {
                line = F.ReadToEnd();
                MessageBox.Show(line);

            }

            F.Close();
            
        }
        

        }
    }


