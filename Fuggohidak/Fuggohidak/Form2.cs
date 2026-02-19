using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuggohidak
{
    public partial class Form2 : Form
    {
        List<Fuggohid> hidak;
        public Form2(List<Fuggohid> hidakList)
        {
            InitializeComponent();
            hidak = hidakList;

            var orszagok = hidak.Select(h => h.Orszag).Distinct().ToList(); 
            comboBox1.DataSource = orszagok;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var orszagok = hidak.Select(h => h.Orszag).Distinct().ToList();
            comboBox1.DataSource = orszagok;

            listBox1.DataSource = null;
            listBox1.DataSource = hidak.Select(h => h.Nev).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var talalatok = hidak.AsEnumerable();

            if (checkBox1.Checked)
            {
                talalatok = talalatok.Where(h => h.Hossz > 1000);
            }

            if (comboBox1.SelectedItem != null)
            {
                string orszag = comboBox1.SelectedItem.ToString();
                talalatok = talalatok.Where(h => h.Orszag == orszag);
            }

            listBox1.DataSource = null;
            listBox1.DataSource = talalatok.Select(h => h.Nev).ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
