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
            // Список для зберігання всіх створених організацій
            private List<Organization> organizationList = new List<Organization>();

            public Form1()
            {
                InitializeComponent();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox2.Text, out int employeeCount) || !int.TryParse(textBox3.Text, out int rating))
                {
                    MessageBox.Show("Поля 'Кількість робітників' та 'Рейтинг' повинні містити тільки числа.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newOrg = new Organization(textBox1.Text, employeeCount, rating);
                organizationList.Add(newOrg);


                UpdateListBox();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus(); 
            }


            private void button2_Click_1(object sender, EventArgs e)
            {
                if (organizationList.Count > 0)
                {
                    Organization sorter = new Organization("", 0, 0);
                    organizationList.Sort(sorter);

                    UpdateListBox();
                    MessageBox.Show("Список відсортовано за рейтингом.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Список порожній, нічого сортувати.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void UpdateListBox()
            {
                listBox1.Items.Clear(); 
                foreach (var org in organizationList)
                {
                    listBox1.Items.Add(org); 
                }
            }
            public class Organization : IComparable, IComparer<Organization>
        {
            public string Name { get; set; }
            public int EmployeeCount { get; set; }
            public int SuccessRating { get; set; } 

            public Organization(string name, int employees, int rating)
            {
                Name = name;
                EmployeeCount = employees;
                SuccessRating = rating;
            }
            public int CompareTo(object obj)
            {
                if (obj is Organization other)
                {
                    return this.EmployeeCount.CompareTo(other.EmployeeCount);
                }
                throw new ArgumentException("Об'єкт не є Organization");
            }

            public int Compare(Organization x, Organization y)
            {
                int ratingCompare = y.SuccessRating.CompareTo(x.SuccessRating);
                if (ratingCompare == 0)
                {
                    return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
                }
                return ratingCompare;
            }

            public override string ToString()
            {
                return $"[Рейтинг: {SuccessRating}] {Name} ({EmployeeCount} робітників)";
            }
        }
    }
}
