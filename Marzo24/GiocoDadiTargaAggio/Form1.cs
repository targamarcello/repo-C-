using System;
using System.Drawing;
using System.Windows.Forms;

namespace GiocoDadiTargaAggio
{
    public partial class Form1 : Form
    {
        Random rand;
        public Form1()
        {
            InitializeComponent();
        }

        private void rollbutt_Click(object sender, EventArgs e)
        {
            GiroDado.Enabled = true;
        }

        private void GiroDado_Tick(object sender, EventArgs e)
        {
            rand = new Random();
            if (GiroDado.Interval == 2000)
            {
                dado.BackgroundImageLayout = ImageLayout.Stretch;
                switch (rand.Next(1, 7))
                {
                    case 1:
                        dado.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Immagini\\1.jpg");
                        break;
                    case 2:
                        dado.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Immagini\\2.jpg");
                        break;
                    case 3:
                        dado.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Immagini\\3.jpg");
                        break;
                    case 4:
                        dado.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Immagini\\4.jpg");
                        break;
                    case 5:
                        dado.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Immagini\\5.jpg");
                        break;
                    case 6:
                        dado.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Immagini\\6.jpg");
                        break;
                }
            }
        }

        private void imageDado_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textRound_TextChanged(object sender, EventArgs e)
        {
            textRound.Text = $"Round : {}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textRound.Text != null && textBox1.Text != null && textBox2.Text != null)
            {
                rollbutt.Enabled = true;
                rollbutt.Visible = true;
                button2.Enabled = false;
                button2.Visible = false;
                Gara gara = new Gara(int.Parse(textRound.Text), (string) textBox1.Text, (string) textBox2.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rollbutt.Enabled = false;
            rollbutt.Visible = false;
        }

        private void textRound_KeyPress(object sender, KeyPressEventArgs e)
        {
            char carIn = e.KeyChar;
            if ((char.IsDigit(carIn) == false && carIn != '-' && carIn != ','))
            {
                e.Handled = true;
            }
        }
    }
}
