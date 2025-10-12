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
            Car car = new Car();
            car.setMark(textBox1.Text);
            car.setModel(textBox2.Text);
            car.setYear(int.Parse(textBox3.Text));
            car.setColor(textBox4.Text);
            car.setFuelType(textBox5.Text);
            car.setDoorCount(int.Parse(textBox6.Text));
            car.setConsumption(int.Parse(textBox7.Text));
            car.infototxt();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.setYear(int.Parse(textBox3.Text));
            int age = car.OldCar();
            MessageBox.Show("The car is " + age + " years old.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.setDoorCount(int.Parse(textBox6.Text));
            if (car.isFamilyCar())
            {
                MessageBox.Show("The car is a family car.");
            }
            else
            {
                MessageBox.Show("The car is not a family car.");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.setConsumption(int.Parse(textBox7.Text));
            if (car.isEco())
            {
                MessageBox.Show("The car is eco-friendly.");
            }
            else
            {
                MessageBox.Show("The car is not eco-friendly.");
            }
        }
    }

    public class Car
    {
        private string Mark;
        private string Model;
        private int Year;
        private string Color;
        private string FuelType;
        private int DoorCount;
        private int Consumption;

        //default constructor
        public Car()
        {
            Mark = "Unknown";
            Model = "Unknown";
            Year = 0;
            Color = "Unknown";
            FuelType = "Unknown";
            DoorCount = 0;
            Consumption = 0;
        }

        //geters
        public string getMark() { return Mark; }
        public string getModel() { return Model; }
        public int getYear() { return Year; }
        public string getColor() { return Color; }
        public string getFuelType() { return FuelType; }
        public int getDoorCount() { return DoorCount; }
        public int getConsumption() { return Consumption; }
        //seters
        public void setMark(string mark) { Mark = mark; }
        public void setModel(string model) { Model = model; }
        public void setYear(int year) { Year = year; }
        public void setColor(string color) { Color = color; }
        public void setFuelType(string fuelType) { FuelType = fuelType; }
        public void setDoorCount(int doorCount) { DoorCount = doorCount; }
        public void setConsumption(int consumption) { Consumption = consumption; }


        public void infototxt()
        {
            StreamWriter sw = new StreamWriter("carinfo.txt");
            sw.WriteLine("Mark: " + Mark);
            sw.WriteLine("Model: " + Model);
            sw.WriteLine("Year: " + Year);
            sw.WriteLine("Color: " + Color);
            sw.WriteLine("Fuel Type: " + FuelType);
            sw.WriteLine("Door Count: " + DoorCount);
            sw.WriteLine("Consumption: " + Consumption);
            sw.WriteLine("-----------------------");
            sw.Close();
        }
        public int OldCar()
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - Year;

        }
        public bool isFamilyCar()
        {
            return DoorCount >= 4;
        }

        public bool isEco()
        {
            return Consumption <= 7;
        }
    } 
}
