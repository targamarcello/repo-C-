using System.Security.Cryptography.X509Certificates;

namespace CacciaAlPolesellano
{
    public partial class Form1 : Form
    {
        int contatore;
        Point xy = new Point();
        Random coordinata = new Random();
        public Form1()
        {
            InitializeComponent();
            PANIN.SizeMode = PictureBoxSizeMode.StretchImage;
            radioButton1.Checked = true;
            timer1.Enabled= false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contatore= 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
              Close();   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*timer1.Enabled = false;
            MessageBox.Show("Scatto");
            timer1.Enabled = true;*/
            Button bottone = new Button();
            xy.X = coordinata.Next(0, (pnlArena.ClientSize.Width - PANIN.Width) + 1);
            xy.Y = coordinata.Next(0, (pnlArena.ClientSize.Height - PANIN.Height) + 1);
            PANIN.Location = xy;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Immagini im = new Immagini(Environment.CurrentDirectory + "\\"+"polesella"+"\\"+"becchiati.jpg");
            timer1.Enabled = false;
            PANIN.Image = im.RitornoImmagine();
        }

        private void pnlArena_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Immagini immagine = new Immagini(Environment.CurrentDirectory + "\\polesella\\panin.jpg");
            PANIN.Image = immagine.RitornoImmagine();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Immagini immagine = new Immagini(Environment.CurrentDirectory + "\\polesella\\patong.jpg");
            PANIN.Image = immagine.RitornoImmagine();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Immagini immagine = new Immagini(Environment.CurrentDirectory + "\\polesella\\NUGGETS.jpg");
            PANIN.Image = immagine.RitornoImmagine();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Immagini immagine = new Immagini(Environment.CurrentDirectory + "\\polesella\\panin.jpg");
            PANIN.Image = immagine.RitornoImmagine();
            timer1.Enabled= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled= true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("SEI SICURO DI VOLER TORNARE A POLESELLA?", "AVVISO!!!", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel= true;
            }
        }
    }
}