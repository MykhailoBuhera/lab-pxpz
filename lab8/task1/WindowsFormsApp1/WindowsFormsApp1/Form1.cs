using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentsScholarshipApp
{
    public partial class Form1 : Form
    {

        List<(string surname, double average, string group, int course)> students = new List<(string, double, string, int)>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string surname = txtSurname.Text;
                double average = double.Parse(txtAverage.Text);
                string group = txtGroup.Text;
                int course = int.Parse(txtCourse.Text);

                students.Add((surname, average, group, course));
                lstStudents.Items.Add($"Студент: {surname}, Середній бал: {average}, Група: {group}, Курс: {course}");

                txtSurname.Clear();
                txtAverage.Clear();
                txtGroup.Clear();
                txtCourse.Clear();
            }
            catch
            {
                MessageBox.Show("Перевірте правильність введених даних!");
            }
        }

        private void btnShowScholarship_Click(object sender, EventArgs e)
        {
            var count = students.Count(s => s.average > 4.5);
            MessageBox.Show($"Кількість студентів, які отримують стипендію: {count}");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();
            foreach (var s in students)
            {
                lstStudents.Items.Add($"Прізвище: {s.surname}, Бал: {s.average}, Група: {s.group}, Курс: {s.course}");
            }
        }
    }
}

