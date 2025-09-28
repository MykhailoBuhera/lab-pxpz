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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "";
            int count = 0;
            TextBox textBox = this.textBox1;
            string words2repeat = "";
            string input = textBox.Text;
            string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string[] repeatwords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[i].Equals(words[j], StringComparison.OrdinalIgnoreCase))
                    {
                        repeatwords[count] = words[i];
                        words2repeat += words[i] + " ";
                        count++;
                    }
                }
            }
            MessageBox.Show("Repeated words: " + words2repeat);
            for (int k =0; k<words.Length; k++)
            {
                for (int l = 0; l < repeatwords.Length; l++)
                {
                    if (words[k].Equals(repeatwords[l], StringComparison.OrdinalIgnoreCase))
                    {
                        words[k] = "";    
                    }
                }
                message += words[k] + " ";
            }
            label2.Text = "Text without repeated words: " + string.Join(",", message);
        }
    }
}
