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
        List<char> list2 = new List<char>();

        public void Vypis(List<int> l, ListBox lb)
        {
            lb.Items.Clear();
            foreach (int s in l)
                lb.Items.Add(s);
        }
        public void Vypis(List<char> l, ListBox lb)
        {
            lb.Items.Clear();
            foreach (char s in l)
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
            if(dMax != int.MinValue)
                return dMax;
            else
                return 0;
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
            List<int> doko = new List<int>();
            foreach(int i in l)
            {
                if (Dokonale(i))
                    doko.Add(i);
            }
            foreach(int i in doko)
                l.Remove(i);
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
            list1.Clear();
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

            MessageBox.Show("Průměr: " + Math.Round((double)souc / pocet, 2));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Druhe max: " + DMax(list1));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cif Součet: " + CifSouc(Max(list1)));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            list2.Clear();
            foreach(int i in list1)
            {
                if (i >= 'A' && i <= 'Z')
                    list2.Add((char)i);
                else
                    list2.Add('*');
            }
            Vypis(list2, listBox4);
        }


        // druhý příklad


        public int PoslPrvocislo(int[] pole, ref int index)
        {
            int cislo = 0;
            index = 0;
            for(int i = 0; i < pole.Length; i++)
            {
                if (JePrvocislo(pole[i]))
                {
                    cislo = pole[i];
                    index = i;
                }
            }

            return cislo;
        }

        void Vymen(int[] pole)
        {
            int pomocna = pole[0];
            pole[0] = pole[pole.Length - 1];
            pole[pole.Length - 1] = pomocna;
        }

        public void Vypis(int[] pole , ListBox lb)
        {
            lb.Items.Clear();
            foreach(int i in pole)
                lb.Items.Add(i);
        }

        bool JePrvocislo(int cislo)
        {
            bool vysledek = (cislo % 2 != 0 || cislo == 2) && !(cislo == 1 || cislo == 0);
            for (int i = 3; i <= Math.Sqrt(cislo) && vysledek != false; i += 2)
            {
                vysledek = cislo % i != 0;
            }
            return vysledek;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = int.Parse(textBox2.Text);
                int[] pole = new int[n];
                for (int i = 0; i < n; i++)
                {
                    pole[i] = r.Next(1, 26);
                }

                Vypis(pole, listBox5);
                int index = 0;
                MessageBox.Show("Prvocislo: "+PoslPrvocislo(pole,ref index)+" Index: "+index);
                Vymen(pole);
                Vypis(pole, listBox6);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Zadej dobrý číslo "+ex);
            }
        }


        string Maximalni(string veta,string parametr)
        {
            string[] slova = veta.Split(' ');
            int index = 0,max = -1, maxLength = 0;
            foreach(string s in slova)
            {
                if (s.Contains(parametr) && s.Length > maxLength)
                {
                    max = index;
                    maxLength = s.Length;
                }
                index++;
            }
            if (max == -1)
                return "";
            else
                return slova[max];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Maximalni(textBox3.Text, textBox4.Text));
        }
    }
}
