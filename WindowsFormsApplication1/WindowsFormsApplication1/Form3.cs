using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public string name_player;
        // public FileStream File;
        public Form3()
        {
            InitializeComponent();
           //  FileStream File = new FileStream("document.txt",FileMode.Open, FileAccess.Read);
            // File = new StreamReader("document.txt");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.name_player = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string menohraca = this.name_player;
            

            DateTime now = DateTime.Now;
           

            string text = "all players.txt";
            using (StreamWriter sw = File.AppendText(text))
            {
                sw.WriteLine();
                sw.Write(menohraca); 
                sw.Write("\t\t\t\t\t{0}", now);
            }

            Form2 f2 = new Form2(menohraca);
            f2.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
