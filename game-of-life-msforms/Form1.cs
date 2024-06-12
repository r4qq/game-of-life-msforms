using System;
using System.Drawing;
using System.Windows.Forms;

namespace game_of_life_msforms
{
    public partial class Form1 : Form
    {
        private int wielkoscKomorki; // Rozmiar pojedynczej komórki
        private int szerokoscPlanszy; // Szerokoœæ planszy (w iloœci komórek)
        private int wysokoscPlanszy; // Wysokoœæ planszy (w iloœci komórek)
        private bool[,] plansza; // Aktualny stan planszy
        private bool[,] buforPlanszy; // Bufor do przechowywania stanu planszy po aktualizacji
        private Color kolor; // Kolor komórek

        //private System.Windows.Forms.Timer timer1;

        public Form1()
        {
            InitializeComponent();

            wielkoscKomorki = trackBar1.Value; // Inicjalizacja wielkoœci komórki na podstawie wartoœci z trackBar

            szerokoscPlanszy = pictureBox1.Width / wielkoscKomorki; // Obliczenie szerokoœci planszy
            wysokoscPlanszy = pictureBox1.Height / wielkoscKomorki; // Obliczenie wysokoœci planszy
            plansza = new bool[szerokoscPlanszy, wysokoscPlanszy]; // Inicjalizacja planszy
            buforPlanszy = new bool[szerokoscPlanszy, wysokoscPlanszy]; // Inicjalizacja bufora

            kolor = Color.Black; // Domyœlny kolor komórek
            startButton.BackColor = Color.Green; // Ustawienie koloru przycisku start

            InitializePlansza(); // Inicjalizacja planszy losowymi wartoœciami

            timer1.Interval = (int)numericUpDown1.Value; // Ustawienie interwa³u timera na podstawie wartoœci z numericUpDown
            timer1.Tick += timer1_Tick; // Dodanie zdarzenia Tick do timera
            pictureBox1.Paint += pictureBox1_Paint; // Dodanie zdarzenia Paint do pictureBox

            pictureBox1.MouseDown += pictureBox1_MouseDown; // Dodanie zdarzenia MouseDown do pictureBox
            pictureBox1.MouseMove += pictureBox1_MouseMove; // Dodanie zdarzenia MouseMove do pictureBox

            trackBar1.ValueChanged += TrackBar1_ValueChanged; // Dodanie zdarzenia ValueChanged do trackBar
        }

        private void InitializePlansza()
        {
            Random random = new Random();
            for (int i = 0; i < szerokoscPlanszy; i++)
            {
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    plansza[i, j] = random.Next(2) == 0; // Losowe wype³nienie planszy
                }
            }
        }

        private void ClearPlansza()
        {
            for (int i = 0; i < szerokoscPlanszy; i++)
            {
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    plansza[i, j] = false; // Wyczyszczenie planszy
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            aktualizujPlansze(); // Aktualizacja planszy
            pictureBox1.Invalidate(); // Odœwie¿enie pictureBox
        }

        private void aktualizujPlansze()
        {
            for (int i = 0; i < szerokoscPlanszy; i++)
            {
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    int zywySasiad = liczZyweKomorki(i, j); // Liczenie ¿ywych s¹siadów
                    if (plansza[i, j])
                    {
                        buforPlanszy[i, j] = zywySasiad == 2 || zywySasiad == 3; // Regu³a prze¿ycia
                    }
                    else
                    {
                        buforPlanszy[i, j] = zywySasiad == 3; // Regu³a narodzin
                    }
                }
            }

            bool[,] temp = plansza; // Prze³¹czenie planszy z buforem
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
                    int nX = (x + dX + szerokoscPlanszy) % szerokoscPlanszy; // Zapewnienie cyklicznoœci planszy
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
                    SolidBrush custom = new SolidBrush(kolor); // Ustawienie koloru komórek
                    Brush b = plansza[i, j] ? custom : Brushes.White; // Ustawienie koloru t³a dla martwych komórek
                    g.FillRectangle(b, i * wielkoscKomorki, j * wielkoscKomorki, wielkoscKomorki, wielkoscKomorki); // Rysowanie komórek
                    g.DrawRectangle(Pens.LightGray, i * wielkoscKomorki, j * wielkoscKomorki, wielkoscKomorki, wielkoscKomorki); // Rysowanie siatki
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop(); // Zatrzymanie timera
                startButton.Text = "Start"; // Zmiana tekstu przycisku
                startButton.BackColor = Color.Green; // Zmiana koloru przycisku
            }
            else
            {
                timer1.Interval = (int)numericUpDown1.Value; // Ustawienie interwa³u timera
                timer1.Start(); // Uruchomienie timera
                startButton.Text = "Stop"; // Zmiana tekstu przycisku
                startButton.BackColor = Color.Red; // Zmiana koloru przycisku
            }
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // Zatrzymanie timera
            InitializePlansza(); // Inicjalizacja planszy losowymi wartoœciami
            pictureBox1.Invalidate(); // Odœwie¿enie pictureBox
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearPlansza(); // Wyczyszczenie planszy
            pictureBox1.Invalidate(); // Odœwie¿enie pictureBox
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value; // Zmiana interwa³u timera
        }

        private void zmienStanKomorki(int mouseX, int mouseY)
        {
            int komorkaX = mouseX / wielkoscKomorki; // Obliczenie wspó³rzêdnej X komórki
            int komorkaY = mouseY / wielkoscKomorki; // Obliczenie wspó³rzêdnej Y komórki

            if (komorkaX >= 0 && komorkaX < szerokoscPlanszy && komorkaY >= 0 && komorkaY < szerokoscPlanszy)
            {
                plansza[komorkaX, komorkaY] = !plansza[komorkaX, komorkaY]; // Zmiana stanu komórki
                pictureBox1.Invalidate(); // Odœwie¿enie pictureBox
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            zmienStanKomorki(e.X, e.Y); // Zmiana stanu komórki na podstawie klikniêcia mysz¹
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                zmienStanKomorki(e.X, e.Y); // Zmiana stanu komórki na podstawie ruchu mysz¹ przy wciœniêtym lewym przycisku
            }
        }

        private void kolorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                kolor = colorDialog1.Color; // Zmiana koloru komórek na wybrany kolor

                label1.BackColor = kolor; // Ustawienie koloru t³a labela
                label1.Text = kolor.Name; // Ustawienie nazwy koloru w labelu

                pictureBox1.Invalidate(); // Odœwie¿enie pictureBox
            }
        }

        private void TrackBar1_ValueChanged(object? sender, EventArgs e)
        {
            wielkoscKomorki = trackBar1.Value; // Zmiana wielkoœci komórek na podstawie wartoœci z trackBar
            szerokoscPlanszy = pictureBox1.Width / wielkoscKomorki; // Obliczenie szerokoœci planszy
            wysokoscPlanszy = pictureBox1.Height / wielkoscKomorki; // Obliczenie wysokoœci planszy
            pictureBox1.Invalidate(); // Odœwie¿enie pictureBox
        }
    }
}
