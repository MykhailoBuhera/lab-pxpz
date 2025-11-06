using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
         Factory fac = new Factory();
            fac.setDate(int.Parse(textBox1.Text));
            fac.setSpecialization(textBox2.Text);
            fac.setcountOFspecialist(int.Parse(textBox3.Text));
            fac.setcountOFcustomer(int.Parse(textBox4.Text));
            fac.setcountOF_CO2(int.Parse(textBox5.Text));
            fac.setcountOFbuldings(int.Parse(textBox6.Text));
            fac.setIncomes(int.Parse(textBox7.Text));
            fac.infototxt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory fac = new Factory();
            fac.setDate(int.Parse(textBox1.Text));
            MessageBox.Show("Age of factory: " + fac.Agezavody());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Factory fac = new Factory();
            fac.setcountOFspecialist(int.Parse(textBox3.Text));
            fac.setcountOFcustomer(int.Parse(textBox4.Text));
            if (fac.BigFactory())
            {
                MessageBox.Show("The factory is big.");
            }
            else
            {
                MessageBox.Show("The factory is not big.");
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Factory fac = new Factory();
            fac.setcountOF_CO2(int.Parse(textBox5.Text));
            if (fac.EcoFriendly())
            {
                MessageBox.Show("The factory is eco-friendly.");
            }
            else
            {
                MessageBox.Show("The factory is not eco-friendly.");
            }
        }
    }

    public class Factory
    {
        private int Date;
        private string Specialization;
        private int countOFspecialist;
        private int countOFcustomer;
        private int countOF_CO2;
        private int countOFbuldings;
        private int Incomes;

        public Factory()
        {
            Date = 0;
            Specialization = "";
            countOFspecialist = 0;
            countOFcustomer = 0;
            countOF_CO2 = 0;
            countOFbuldings = 0;
            Incomes = 0;
        }
        //geters
        public int getDate() { return Date; }
        public string getSpecialization() { return Specialization; }
        public int getcountOFspecialist() { return countOFspecialist; }
        public int getcountOFcustomer() { return countOFcustomer; }
        public int getcountOF_CO2() { return countOF_CO2; }
        public int getcountOFbuldings() { return countOFbuldings; }
        public int getIncomes() { return Incomes; }
        //seters
        public void setDate(int Date) { this.Date = Date; }
        public void setSpecialization(string Specialization) { this.Specialization = Specialization; }
        public void setcountOFspecialist(int countOFspecialist) { this.countOFspecialist = countOFspecialist; }
        public void setcountOFcustomer(int countOFcustomer) { this.countOFcustomer = countOFcustomer; }
        public void setcountOF_CO2(int countOF_CO2) { this.countOF_CO2 = countOF_CO2; }
        public void setcountOFbuldings(int countOFbuldings) { this.countOFbuldings = countOFbuldings; }
        public void setIncomes(int Incomes) { this.Incomes = Incomes; }
        //methods
        public void infototxt()
        {
            using (StreamWriter sw = new StreamWriter("factory_info.txt"))
            {
                sw.WriteLine("Date of foundation: " + Date);
                sw.WriteLine("Specialization: " + Specialization);
                sw.WriteLine("Count of specialists: " + countOFspecialist);
                sw.WriteLine("Count of customers: " + countOFcustomer);
                sw.WriteLine("Count of CO2 emissions: " + countOF_CO2);
                sw.WriteLine("Count of buildings: " + countOFbuldings);
                sw.WriteLine("Incomes: " + Incomes);
            }
        }
        public int Agezavody()
        {
            int currentDate = DateTime.Now.Year;
            return currentDate - Date;
        }
        public bool EcoFriendly()
        {
            return countOF_CO2 < 100; 
        }
        public bool BigFactory()
        {
            return countOFspecialist > 50 && countOFcustomer > 100;
        }


    }
}

