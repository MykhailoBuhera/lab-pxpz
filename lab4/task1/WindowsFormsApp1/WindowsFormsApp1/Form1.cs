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
            const int COLS = 6; 
            const int ROWS = 100; 
            string[,] data = new string[ROWS, COLS];
            int rowCount = 0;
            string filePath = " C:\\labu\\lab-pxpz\\lab4\\task1\\WindowsFormsApp1\\WindowsFormsApp1\\File.txt "; 
            string result = "C:\\labu\\lab-pxpz\\lab4\\task1\\WindowsFormsApp1\\WindowsFormsApp1\\Data.txt";
            
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    for (int i = 0; i < COLS && i < parts.Length; i++)
                    {
                        data[rowCount, i] = parts[i];
                    }
                    rowCount++;
                }
                using (StreamWriter sw = new StreamWriter(result))
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (double.TryParse(data[i, 3], out double capacity))
                        {
                            if (capacity > 2)
                            {
                                for (int j = 0; j < COLS; j++)
                                {
                                    sw.Write(data[i, j]);
                                    if (j < COLS - 1) sw.Write(";");
                                }
                                
                            }
                        }
                    }
                }
                string resultContent = File.ReadAllText(result);
                label1.Text = resultContent;
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл не знайдено.");
            }
            catch (IOException)
            {
                MessageBox.Show("Помилка при читанні файлу.");
            }
        }
    }
}
