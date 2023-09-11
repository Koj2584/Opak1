using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opak1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> list1 = new List<int>();

        public void Vypis(List<int> l, ListBox lb)
        {
            lb.Items.Clear();
            foreach (int s in l)
                lb.Items.Add(s);
        }

        public int DMax(List<int> l)
        {
            int max = int.MinValue;
            int dMax = 0;
            foreach(int i in l)
            {
                if(i > max)
                {
                    dMax = max;
                    max = i;
                }
            }
            return dMax;
        }

        public int Max(List<int> l)
        {
            int max = int.MinValue;
            foreach (int i in l)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        public bool Dokonale(int cislo)
        {
            List<int> delitele = new List<int>();
            for(int i = 1; i <= cislo / 2; i++)
            {
                if(cislo%i==0)
                {
                    delitele.Add(i);
                }
            }

            int soucet = 0;
            foreach (int i in delitele)
                soucet += i;
            if (soucet == cislo)
                return true;
            else
                return false;
        }

        public void VymazDok(List<int> l)
        {
            foreach(int i in l)
            {
                if (Dokonale(i))
                    l.Remove(i);
            }
        }

        public int CifSouc(int cislo)
        {
            int souc = 0;
            double cisloD = cislo;
            while(cisloD > 1)
            {
                souc += (int)(cisloD % 10);
                cisloD /= 10;
            }

            return souc;
        }

        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = int.Parse(textBox1.Text);
                for (int i = 0; i < n; i++)
                {
                    list1.Add(r.Next(-4, 101));
                }

                Vypis(list1, listBox1);
            } catch
            {
                MessageBox.Show("Zadej dobrý číslo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VymazDok(list1);
            Vypis(list1, listBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list1.Sort();
            Vypis(list1, listBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int souc = 0, pocet = 0;
            foreach(int i in list1)
            {
                souc += i;
                pocet++;
            }

            MessageBox.Show("Průměr: " + (souc / pocet));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Druhe max: " + DMax(list1));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cif Součet: " + CifSouc(Max(list1)));
        }


    }
}
