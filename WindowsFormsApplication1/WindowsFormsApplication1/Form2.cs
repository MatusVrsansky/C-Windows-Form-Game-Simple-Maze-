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
    public partial class Form2 : Form
    {
        public Random random;
        public Random random_enemy_value;
        public int enemy_value;
        public string name_player;
        public int premenna;
        public int cislo;
        public int porovnavacie_cislo;              // ulozi sa tam hodnota vyg. cisla a rozhodne sa po pohybe ci panak nenarazil na prekazku
        public int hod_kocky = 0;
        public int hod_1;
        public int hod_2;
        public int hod_3;
        public int hod_4;
        public int hodnota = 100;
        public int result;
        public string length_time;





        // move after dice roll
        public List<Rectangle> continue_move_Up = new List<Rectangle>();
        public List<Rectangle> continue_move_down = new List<Rectangle>();
        public List<Rectangle> continue_move_Left = new List<Rectangle>();
        public List<Rectangle> continue_move_Right = new List<Rectangle>();

        // enemy
        public List<Rectangle> enemy_list = new List<Rectangle>();



        public Form2(string menohraca)
        {
            InitializeComponent();
            name_player = menohraca;
            dice_roll();
            progressBar1.Value = hodnota;
            label43.Text = "Hrac: " + menohraca;
            timer1.Enabled = true;
            timer1.Start();
            length_time = time.Text;

        }

        public void dice_roll()
        {
            random = new Random();
            this.premenna = random.Next(1, 7);

            if (this.premenna == 1)
            {

                this.premenna = 1;

                Number.Text = this.premenna.ToString();
            }

            else if (this.premenna == 2)
            {

                this.premenna = 2;

                Number.Text = this.premenna.ToString();
            }

            else if (this.premenna == 3)
            {

                this.premenna = 3;

                Number.Text = this.premenna.ToString();
            }

            else if (this.premenna == 4)
            {

                this.premenna = 4;

                Number.Text = this.premenna.ToString();
            }

            else if (this.premenna == 5)
            {

                this.premenna = 5;

                Number.Text = this.premenna.ToString();
            }

            else if (this.premenna == 6)
            {

                this.premenna = 6;

                Number.Text = this.premenna.ToString();
            }

            else
            {
                this.premenna = 0;
                Number.Text = this.premenna.ToString();
            }


        }



        public void skip_game()
        {
            if (Player.Bounds.IntersectsWith(label44.Bounds))
            {
                MessageBox.Show("Narazili ste na skip button, prehodi Vas na novy poziciu v poli");
                Player.Location = new Point(507, 410);
            }
        }

        public void Win_game()
        {
            if (Player.Bounds.IntersectsWith(label25.Bounds))
            {
                this.Close();
                label25.Location = new Point(1500, 1200);
                string life = Convert.ToString(progressBar1.Value);
                DateTime now = DateTime.Now;
                timer1.Stop();
                length_time = minute.ToString() + " m" +" "+duration.ToString() + " s";

                string text = "winners.txt";
                using (StreamWriter sw = File.AppendText(text))
                {
                    sw.WriteLine();
                    sw.Write("Meno hraca: "+name_player+"  Cas ukoncenia hry: "+now+"  Zostavajuci zivot: "+life+"  Dlzka hrania hry: "+length_time);
                    
                }

                MessageBox.Show("Hrac: " + name_player + " Vyhral hru s ostavajucim zivotom: " + life + "HP");


            }

            else
            {
                // nothing
            }
        }

        public void Invisible_walls_Down()
        {
            int porovnaj_invisible_down = this.hod_2;


            if (Player.Bounds.IntersectsWith(label40.Bounds))
            {
                MessageBox.Show("Narazili ste na neviditelnu stenu!!!");
                for (int index = 1; index <= porovnaj_invisible_down; index++)
                {
                    Player.Top -= 6;
                }
            }

            else if (Player.Bounds.IntersectsWith(label45.Bounds))
            {
                MessageBox.Show("Narazili ste na neviditelnu stenu!!!");
                for (int index = 1; index <= porovnaj_invisible_down; index++)
                {
                    Player.Top -= 6;
                }
            }


            else
            {
                // Nothing
            }
        }

        public void Invisible_walls_Left()
        {
            int porovnaj_invisible_left = this.hod_3;

            if (Player.Bounds.IntersectsWith(label39.Bounds))
            {
                MessageBox.Show("Narazili ste na neviditelnu stenu!!!");
                for (int index = 1; index <= porovnaj_invisible_left; index++)
                {
                    Player.Left += 6;
                }
            }

            else
            {
                // Notihng
            }
        }

        public void Invisible_wall_right()
        {
            int porovna_invisible_right = this.hod_4;

             if (Player.Bounds.IntersectsWith(label46.Bounds))
            {
                MessageBox.Show("Narazili ste na neviditelnu stenu!!!");
                for (int index = 1; index <= porovna_invisible_right; index++)
                {
                    Player.Left -= 6;
                }
            }

            else
            {
                //
            }
        }

        public void Add_life_Player()
        {
            if (Player.Bounds.IntersectsWith(label41.Bounds))
            {
                // tu sa pripocita hracovi 16 HP

                if (progressBar1.Value + 16 < 100)
                {
                    MessageBox.Show("Narazili ste na label_life, pripocita sa vam do zivota 16 HP");
                    progressBar1.Value += 16;

                }

                else
                {
                    MessageBox.Show("Narazili ste na label_life, zivot sa Vam ale nepripocita");
                }

                label41.Location = new Point(1500, 1200);
            }

            else if (Player.Bounds.IntersectsWith(label42.Bounds))
            {
                // tu sa pripocita hracovi 20 HP

                if (progressBar1.Value + 20 < 100)
                {
                    MessageBox.Show("Narazili ste na label_life, pripocita sa vam do zivota 20 HP");
                    progressBar1.Value += 20;

                }

                else
                {
                    MessageBox.Show("Narazili ste na label_life, zivot sa Vam ale nepripocita");
                }

                label42.Location = new Point(1500, 1200);
            }

            else
            {
                // Nothing
            }


        }

        public void Enemy()
        {
            random_enemy_value = new Random();
            this.enemy_value = random_enemy_value.Next(35, 50);

            if (Player.Bounds.IntersectsWith(label34.Bounds))
            {
                MessageBox.Show("Narazili ste na nepriatela!!!!! Nepriatel Vam strhne zo zivota: " + enemy_value.ToString() + " HP");



                if (progressBar1.Value - enemy_value <= 0)
                {
                    this.Close();

                    DateTime now = DateTime.Now;


                    string text = "losers.txt";
                    using (StreamWriter sw = File.AppendText(text))
                    {
                        sw.WriteLine();
                        sw.Write(name_player);
                        sw.Write("\t\t\t\t{0}", now);

                    }

                    MessageBox.Show("Hrac " + name_player + " prehral hru");
                }

                else
                {
                    progressBar1.Value -= this.enemy_value;
                    label34.Location = new Point(1500, 1200);                // zmeni sa umiestnenie label55 mimo hracie pole.
                }



            }

            else if (Player.Bounds.IntersectsWith(label35.Bounds))
            {
                MessageBox.Show("Narazili ste na nepriatela!!!!! Nepriatel Vam strhne zo zivota: " + enemy_value.ToString() + " HP");


                if (progressBar1.Value - enemy_value <= 0)
                {
                    this.Close();

                    DateTime now = DateTime.Now;


                    string text = "losers.txt";
                    using (StreamWriter sw = File.AppendText(text))
                    {
                        sw.WriteLine();
                        sw.Write(name_player);
                        sw.Write("\t\t\t\t{0}", now);

                    }
                    MessageBox.Show("Hrac " + name_player + " prehral hru");
                }

                else
                {
                    progressBar1.Value -= this.enemy_value;
                    label35.Location = new Point(1500, 1200);                // zmeni sa umiestnenie label55 mimo hracie pole.
                }
            }

            else if (Player.Bounds.IntersectsWith(label36.Bounds))
            {
                MessageBox.Show("Narazili ste na nepriatela!!!!! Nepriatel Vam strhne zo zivota: " + enemy_value.ToString() + " HP");

                if (progressBar1.Value - enemy_value <= 0)
                {
                    this.Close();

                    DateTime now = DateTime.Now;


                    string text = "losers.txt";
                    using (StreamWriter sw = File.AppendText(text))
                    {
                        sw.WriteLine();
                        sw.Write(name_player);
                        sw.Write("\t\t\t\t{0}", now);

                    }
                    MessageBox.Show("Hrac " + name_player + " prehral hru");
                }

                else
                {
                    progressBar1.Value -= this.enemy_value;
                    label36.Location = new Point(1500, 1200);                // zmeni sa umiestnenie label55 mimo hracie pole.
                }
            }

            else if (Player.Bounds.IntersectsWith(label37.Bounds))
            {
                MessageBox.Show("Narazili ste na nepriatela!!!!! Nepriatel Vam strhne zo zivota: " + enemy_value.ToString() + " HP");

                if (progressBar1.Value - enemy_value <= 0)
                {
                    this.Close();

                    DateTime now = DateTime.Now;


                    string text = "losers.txt";
                    using (StreamWriter sw = File.AppendText(text))
                    {
                        sw.WriteLine();
                        sw.Write(name_player);
                        sw.Write("\t\t\t\t{0}", now);

                    }
                    MessageBox.Show("Hrac " + name_player + " prehral hru");
                }

                else
                {
                    progressBar1.Value -= this.enemy_value;
                    label37.Location = new Point(1500, 1200);                // zmeni sa umiestnenie label55 mimo hracie pole.
                }

            }

            else if (Player.Bounds.IntersectsWith(label38.Bounds))
            {
                MessageBox.Show("Narazili ste na nepriatela!!!!! Nepriatel Vam strhne zo zivota: " + enemy_value.ToString() + " HP");

                if (progressBar1.Value - enemy_value <= 0)
                {
                    this.Close();

                    DateTime now = DateTime.Now;


                    string text = "losers.txt";
                    using (StreamWriter sw = File.AppendText(text))
                    {
                        sw.WriteLine();
                        sw.Write(name_player);
                        sw.Write("\t\t\t\t{0}", now);

                    }
                    MessageBox.Show("Hrac " + name_player + " prehral hru");
                }

                else
                {
                    progressBar1.Value -= this.enemy_value;
                    label38.Location = new Point(1500, 1200);                // zmeni sa umiestnenie label55 mimo hracie pole.
                }

            }

            else
            {
                // nothing
            }

        }

        public void fill_list_Move_UP()
        {
            continue_move_Up.Add(label1.Bounds);
            continue_move_Up.Add(label8.Bounds);
            continue_move_Up.Add(label6.Bounds);
            continue_move_Up.Add(label7.Bounds);
            continue_move_Up.Add(label17.Bounds);
            continue_move_Up.Add(label13.Bounds);
            continue_move_Up.Add(label18.Bounds);
            continue_move_Up.Add(label27.Bounds);
            continue_move_Up.Add(label20.Bounds);
            continue_move_Up.Add(label16.Bounds);
            continue_move_Up.Add(label14.Bounds);
            continue_move_Up.Add(label31.Bounds);
            continue_move_Up.Add(label29.Bounds);
            continue_move_Up.Add(label12.Bounds);
            continue_move_Up.Add(label24.Bounds);
            continue_move_Up.Add(label11.Bounds);
            continue_move_Up.Add(label5.Bounds);

            int porovnaj_up = this.hod_1;

            foreach (Rectangle element_up in continue_move_Up)
            {


                if (Player.Bounds.IntersectsWith(element_up))
                {
                    MessageBox.Show("Prekrocili ste parametre hracieho pola!!!!!");

                    for (int index = 1; index <= porovnaj_up; index++)
                    {
                        Player.Top += 6;
                    }
                    break;
                }

                else
                {
                    continue;
                }

            }

            Win_game();
        }

        public void fill_list_Move_Down()
        {
            continue_move_down.Add(label22.Bounds);
            continue_move_down.Add(label8.Bounds);
            continue_move_down.Add(label13.Bounds);
            continue_move_down.Add(label20.Bounds);
            continue_move_down.Add(label14.Bounds);
            continue_move_down.Add(label16.Bounds);
            continue_move_down.Add(label11.Bounds);
            continue_move_down.Add(label5.Bounds);
            continue_move_down.Add(label3.Bounds);
            continue_move_down.Add(label27.Bounds);
            continue_move_down.Add(label31.Bounds);
            continue_move_down.Add(label29.Bounds);
            continue_move_down.Add(label12.Bounds);
            continue_move_down.Add(label24.Bounds);
            continue_move_down.Add(label25.Bounds);
            continue_move_down.Add(label33.Bounds);

            int porovnaj_down = this.hod_2;

            foreach (Rectangle element_up in continue_move_down)
            {
                if (Player.Bounds.IntersectsWith(element_up))
                {
                    MessageBox.Show("Prekrocili ste parametre hracieho pola!!!!!");

                    for (int index = 1; index <= porovnaj_down; index++)
                    {
                        Player.Top -= 6;
                    }
                    break;
                }

                else
                {
                    continue;
                }

            }

            Win_game();
        }

        public void fill_list_Move_Left()
        {
            continue_move_Left.Add(label4.Bounds);
            continue_move_Left.Add(label7.Bounds);
            continue_move_Left.Add(label17.Bounds);
            continue_move_Left.Add(label18.Bounds);
            continue_move_Left.Add(label28.Bounds);
            continue_move_Left.Add(label21.Bounds);
            continue_move_Left.Add(label13.Bounds);
            continue_move_Left.Add(label20.Bounds);
            continue_move_Left.Add(label31.Bounds);
            continue_move_Left.Add(label16.Bounds);
            continue_move_Left.Add(label15.Bounds);
            continue_move_Left.Add(label10.Bounds);
            continue_move_Left.Add(label19.Bounds);
            continue_move_Left.Add(label26.Bounds);
            continue_move_Left.Add(label30.Bounds);
            continue_move_Left.Add(label23.Bounds);
            continue_move_Left.Add(label6.Bounds);
            continue_move_Left.Add(label27.Bounds);
            continue_move_Left.Add(label29.Bounds);
            continue_move_Left.Add(label11.Bounds);


            int porovnaj_left = this.hod_3;

            foreach (Rectangle element_left in continue_move_Left)
            {
                if (Player.Bounds.IntersectsWith(element_left))
                {
                    MessageBox.Show("Prekrocili ste parametre hracieho pola!!!!!");
                    for (int index = 1; index <= porovnaj_left; index++)
                    {
                        Player.Left += 6;
                    }
                    break;
                }

                else
                {
                    continue;
                }

            }

            Win_game();
        }



        public void fill_list_Move_Right()
        {
            continue_move_Right.Add(label7.Bounds);
            continue_move_Right.Add(label6.Bounds);
            continue_move_Right.Add(label27.Bounds);
            continue_move_Right.Add(label31.Bounds);
            continue_move_Right.Add(label19.Bounds);
            continue_move_Right.Add(label32.Bounds);
            continue_move_Right.Add(label30.Bounds);
            continue_move_Right.Add(label33.Bounds);
            continue_move_Right.Add(label17.Bounds);
            continue_move_Right.Add(label18.Bounds);
            continue_move_Right.Add(label28.Bounds);
            continue_move_Right.Add(label21.Bounds);
            continue_move_Right.Add(label10.Bounds);
            continue_move_Right.Add(label29.Bounds);
            continue_move_Right.Add(label12.Bounds);
            continue_move_Right.Add(label24.Bounds);
            continue_move_Right.Add(label5.Bounds);
            continue_move_Right.Add(label11.Bounds);
            continue_move_Right.Add(label14.Bounds);
            continue_move_Right.Add(label8.Bounds);
            continue_move_Right.Add(label2.Bounds);

            int porovnaj_right = this.hod_4;

            foreach (Rectangle element_right in continue_move_Right)
            {
                if (Player.Bounds.IntersectsWith(element_right))
                {
                    MessageBox.Show("Prekrocili ste parametre hracieho pola!!!!!");

                    for (int index = 1; index <= porovnaj_right; index++)
                    {
                        Player.Left -= 6;
                    }
                    break;
                }

                else
                {
                    continue;
                }
            }

            Win_game();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void MOVE_UP_Click(object sender, EventArgs e)
        {
            this.hod_1 = this.premenna;
            while (hod_kocky <= 1)
            {
                for (int i = 1; i <= hod_1 + 1; i++)
                {
                    if (i > hod_1)
                    {
                        dice_roll();
                        break;
                    }

                    else
                    {
                        Player.Top -= 6;
                    }
                }

                hod_kocky++;
                fill_list_Move_UP();
                Enemy();
                Invisible_walls_Down();
                Add_life_Player();
                skip_game();
            }

            fill_list_Move_UP();
            Enemy();
            Invisible_walls_Down();
            Add_life_Player();
            skip_game();


            this.hod_kocky = 0;
            hod_1 = 0;
        }




        public void MOVE_DOWN_Click(object sender, EventArgs e)
        {
            this.hod_2 = this.premenna;
            while (hod_kocky <= 1)
            {
                for (int i = 1; i <= hod_2 + 1; i++)
                {
                    if (i > hod_2)
                    {
                        dice_roll();
                        break;
                    }

                    else
                    {
                        Player.Top += 6;
                    }
                }

                hod_kocky++;
                fill_list_Move_Down();
                Enemy();
                Invisible_walls_Down();
                Add_life_Player();
                skip_game();
            }


            fill_list_Move_Down();
            Enemy();
            Invisible_walls_Down();
            Add_life_Player();
            skip_game();

            this.hod_kocky = 0;
            hod_2 = 0;
        }





        public void MOVE_LEFT_Click(object sender, EventArgs e)
        {
            this.hod_3 = this.premenna;
            while (hod_kocky <= 1)
            {
                for (int i = 1; i <= hod_3 + 1; i++)
                {
                    if (i > hod_3)
                    {
                        dice_roll();
                        break;
                    }

                    else
                    {
                        Player.Left -= 6;
                    }
                }

                hod_kocky++;
                fill_list_Move_Left();
                Enemy();
                Invisible_walls_Left();
                Add_life_Player();
                skip_game();
            }

            fill_list_Move_Left();
            Enemy();
            Invisible_walls_Left();
            Add_life_Player();
            skip_game();

            this.hod_kocky = 0;
            hod_3 = 0;
        }



        private void MOVE_RIGHT_Click(object sender, EventArgs e)
        {
            this.hod_4 = this.premenna;

            while (hod_kocky <= 1)
            {
                for (int i = 1; i <= hod_4 + 1; i++)
                {

                    if (i > hod_4)
                    {
                        dice_roll();
                        break;
                    }

                    else
                    {

                        Player.Left += 6;
                    }
                }

                hod_kocky++;
                fill_list_Move_Right();
                Enemy();
                Invisible_wall_right();
                Add_life_Player();
                skip_game();
            }

            fill_list_Move_Right();
            Enemy();
            Invisible_wall_right();
            Add_life_Player();
            skip_game();

            this.hod_kocky = 0;
            hod_4 = 0;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Player.ImageLocation = "lopta.ico";
            Player.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        public void time_Click(object sender, EventArgs e)
        {

        }

        int duration = 0;
        int seconds = 60;
        int minute = 0;
        int sekunda = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sekunda==seconds)
            {
                timer1.Stop();
                duration = 0;
                sekunda = 0;
                minute += 1;
                time.Text = minute.ToString() + " m" + " " + duration.ToString() + " s";
                timer1.Start();
               
            }

            else
            {
                sekunda++;
                duration++;
                time.Text = minute.ToString() + " m" + " " + duration.ToString() + " s";
            }
                
            
        }
    }
}