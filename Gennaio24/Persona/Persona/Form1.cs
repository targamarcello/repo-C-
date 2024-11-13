namespace Persona
{
    public partial class Form1 : Form
    {
        List<Persona> persone;
        List<Studente> studenti;
        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled= false;
            textBox2.Enabled= false;
            textBox3.Enabled= false;
            textBox4.Enabled = false;
            persone= new List<Persona>();
            studenti= new List<Studente>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Enabled == false)
            {
                Persona persona = new Persona();
                persona.Nome = textBox1.Text;
                persona.Cognome = textBox2.Text;
                persona.Età = Convert.ToInt32(textBox3.Text);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                if (!(persone.Exists(a => a.Nome == persona.Nome && a.Cognome == persona.Cognome) && studenti.Exists(a => a.Nome == persona.Nome && a.Cognome == persona.Cognome)))
                {
                    persone.Add(persona);
                    listBox1.Items.Add(persona.Info());
                }
                else
                {
                    MessageBox.Show("persona già presente");
                }
            }
            else
            {
                Studente stud = new Studente();
                stud.Nome=textBox1.Text;
                stud.Cognome=textBox2.Text;
                stud.Età = Convert.ToInt32(textBox3.Text);
                stud.Media = Convert.ToInt32(textBox4.Text);
                textBox4.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                if (!(persone.Exists(a => a.Nome == stud.Nome && a.Cognome == stud.Cognome) && studenti.Exists(a => a.Nome == stud.Nome && a.Cognome == stud.Cognome)))
                {
                    persone.Add(stud);
                    listBox1.Items.Add(stud.Info());
                }
                else
                {
                    MessageBox.Show("persona già presente");
                }
            }
        }

        private void tIpoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = false;
        }

        private void studenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}