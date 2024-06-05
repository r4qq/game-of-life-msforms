using System;
using System.Drawing;
using System.Windows.Forms;

namespace game_of_life_msforms
{
    public partial class Form1 : Form
    {
        private const int wielkoscKomorki = 10;
        private const int szerokoscPlanszy = 50;
        private const int wysokoscPlanszy = 50;

        private bool[,] plansza = new bool[szerokoscPlanszy, wysokoscPlanszy];
        private bool[,] buforPlanszy = new bool[szerokoscPlanszy, wysokoscPlanszy];

        //private System.Windows.Forms.Timer timer1;

        public Form1()
        {
            InitializeComponent();
            InitializePlansza();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 100;
            timer1.Tick += timer1_Tick;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            aktualizujPlansze();
            panel1.Invalidate();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < szerokoscPlanszy; i++)
            {
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    Brush b = plansza[i, j] ? Brushes.Black : Brushes.White;
                    g.FillRectangle(b, i * wielkoscKomorki, j * wielkoscKomorki, wielkoscKomorki, wielkoscKomorki);
                    g.DrawRectangle(Pens.Gray, i * wielkoscKomorki, j * wielkoscKomorki, wielkoscKomorki, wielkoscKomorki);
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
