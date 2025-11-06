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
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<double> list = new List<double>();
        List<double> newList = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string filecontetnt = File.ReadAllText("1.txt");
            var tokens = filecontetnt
                .Split(new string[] { "\r\n", "\n", " " }, StringSplitOptions.RemoveEmptyEntries);

            var numbers = new List<double>();
            var bad = new List<string>();

            foreach (var raw in tokens)
            {
                string s = raw.Trim();

                // Remove a possible UTF-8 BOM on the first token
                if (s.Length > 0 && s[0] == '\uFEFF')
                    s = s.Substring(1);

                double value;
                // Try invariant first (file uses '.' as decimal separator), fall back to current culture
                if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out value)
                    || double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out value))
                {
                    numbers.Add(value);
                }
                else
                {
                    bad.Add(raw);
                }
            }

            list = numbers;
            listBox1.Items.Clear();
            foreach (var item in list)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newList = list.OrderByDescending(n => n).ToList();
            listBox1.Items.Clear();
            foreach (var item in newList)
            {
                listBox1.Items.Add(item);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            newList = list.OrderBy(n => n).ToList();
            listBox1.Items.Clear(); 
            foreach (var item in newList)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText("output.txt", string.Join(Environment.NewLine,newList));
        }
    }
}