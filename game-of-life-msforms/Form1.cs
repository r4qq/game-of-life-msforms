using System;
using System.Drawing;
using System.Windows.Forms;

namespace game_of_life_msforms
{
    public partial class Form1 : Form
    {
        private const int wielkoscKomorki = 10;
        private int szerokoscPlanszy;
        private int wysokoscPlanszy;
        private bool[,] plansza;
        private bool[,] buforPlanszy;
        private Color kolor;



        //private System.Windows.Forms.Timer timer1;

        public Form1()
        {
            InitializeComponent();

            szerokoscPlanszy = pictureBox1.Width / wielkoscKomorki;
            wysokoscPlanszy = pictureBox1.Height / wielkoscKomorki;
            plansza = new bool[szerokoscPlanszy, wysokoscPlanszy];
            buforPlanszy = new bool[szerokoscPlanszy, wysokoscPlanszy];

            kolor = Color.Black;

            InitializePlansza();

            timer1.Interval = (int)numericUpDown1.Value;
            timer1.Tick += timer1_Tick;
            pictureBox1.Paint += pictureBox1_Paint;

            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
        }



        private void InitializePlansza()
        {
            Random random = new Random();
            for (int i = 0; i < szerokoscPlanszy; i++)
            {
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    plansza[i, j] = random.Next(2) == 0;
                }
            }
        }
        private void ClearPlansza()
        {
            for (int i = 0; i < szerokoscPlanszy; i++)
            {
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    plansza[i, j] = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            aktualizujPlansze();
            pictureBox1.Invalidate();
        }

        private void aktualizujPlansze()
        {
            for (int i = 0; i < szerokoscPlanszy; i++)
            {
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    int zywySasiad = liczZyweKomorki(i, j);
                    if (plansza[i, j])
                    {
                        buforPlanszy[i, j] = zywySasiad == 2 || zywySasiad == 3;
                    }
                    else
                    {
                        buforPlanszy[i, j] = zywySasiad == 3;
                    }
                }
            }

            bool[,] temp = plansza;
            plansza = buforPlanszy;
            buforPlanszy = temp;
        }

        private int liczZyweKomorki(int x, int y)
        {
            int zlicz = 0;

            for (int dX = -1; dX <= 1; dX++)
            {
                for (int dY = -1; dY <= 1; dY++)
                {
                    if (dX == 0 && dY == 0)
                    {
                        continue;
                    }
                    int nX = (x + dX + szerokoscPlanszy) % szerokoscPlanszy;
                    int nY = (y + dY + wysokoscPlanszy) % wysokoscPlanszy;
                    if (plansza[nX, nY])
                    {
                        zlicz++;
                    }
                }
            }
            return zlicz;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < szerokoscPlanszy; i++)
            {
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    SolidBrush custom = new SolidBrush(kolor);
                    Brush b = plansza[i, j] ? custom : Brushes.White;
                    g.FillRectangle(b, i * wielkoscKomorki, j * wielkoscKomorki, wielkoscKomorki, wielkoscKomorki);
                    g.DrawRectangle(Pens.LightGray, i * wielkoscKomorki, j * wielkoscKomorki, wielkoscKomorki, wielkoscKomorki);
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                startButton.Text = "Start";
            }
            else
            {
                timer1.Interval = (int)numericUpDown1.Value;
                timer1.Start();
                startButton.Text = "Stop";
            }
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            InitializePlansza();
            pictureBox1.Invalidate();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearPlansza();
            pictureBox1.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value;
        }

        private void zmienStanKomorki(int mouseX, int mouseY)
        {
            int komorkaX = mouseX / wielkoscKomorki;
            int komorkaY = mouseY / wielkoscKomorki;

            if (komorkaX >= 0 && komorkaX < szerokoscPlanszy && komorkaY >= 0 && komorkaY < szerokoscPlanszy)
            {
                plansza[komorkaX, komorkaY] = !plansza[komorkaX, komorkaY];
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            zmienStanKomorki(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                zmienStanKomorki(e.X, e.Y);
            }
        }

        private void kolorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                kolor = colorDialog1.Color;

                label1.BackColor = kolor;
                label1.Text = kolor.Name;

                pictureBox1.Invalidate();
            }
        }
    }
}
