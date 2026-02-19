using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuggohidak
{
    public partial class Form1 : Form
    {
        List<Fuggohid> hidak = new List<Fuggohid>();
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void listBoxHidak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxHidak.SelectedItem is Fuggohid selected)
            {
                txtHely.Text = selected.Hely;
                txtOrszag.Text = selected.Orszag;
                txtHosszusag.Text = selected.Hossz.ToString();
                txtEv.Text = selected.Ev.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void keresésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 sf = new Form2(hidak); 
            this.Hide();
            sf.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fajlNev = "fuggohidak.csv";

            if (!File.Exists(fajlNev))
            {
                MessageBox.Show("A fájl nem található: " + fajlNev);
                return;
            }

            hidak.Clear();

            using (StreamReader sr = new StreamReader(fajlNev, Encoding.UTF8))
            {
                string fejléc = sr.ReadLine(); 

                string sor;
                while ((sor = sr.ReadLine()) != null)
                {
                    string[] mezok = sor.Split('\t'); 
                    int helyezes = int.Parse(mezok[0]);
                    string nev = mezok[1];
                    string hely = mezok[2];
                    string orszag = mezok[3];
                    int hosszusag = int.Parse(mezok[4]);
                    int ev = int.Parse(mezok[5]);

                    hidak.Add(new Fuggohid(helyezes, nev, hely, orszag, hosszusag, ev));
                }
            }

            listBoxHidak.DataSource = null;
            listBoxHidak.DataSource = hidak;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = hidak.Count(h => h.Ev < 2000).ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox1.Text = hidak.Count(h => h.Ev >= 2000).ToString();
            }
        }
    }
}
