using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Aeroflot> AIR = new List<Aeroflot>();
        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            int num = int.Parse(textBox2.Text);
            string type = textBox3.Text;
            Aeroflot flight = new Aeroflot(city , num, type);
            AIR.Add(flight);

            UpdateListBox();

           
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AIR = AIR.OrderBy(flight => flight.Num).ToList();
            UpdateListBox();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Aeroflot flight in AIR)
            {
                string searchCity = textBox4.Text;
                if (flight.City.Equals(searchCity, StringComparison.OrdinalIgnoreCase))
                {
                    flight.ShowInfo();
                }
            }
        }
        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (Aeroflot flight in AIR)
            {
                listBox1.Items.Add($"Рейс: {flight.Num}, Місто: {flight.City}, Тип: {flight.Type}");
            }
        }
    }

    public struct Aeroflot
    {
        public string City;
        public int Num;
        public string Type;
        public Aeroflot(string city, int num, string type)
        {
            City = city;
            Num = num;
            Type = type;
        }


        public void ShowInfo()
        {
            MessageBox.Show($"Місто: {City}\nНомер: {Num}\nТип літак: {Type}");
        }
    }
}
