using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChineseZodiacApp
{
    public partial class Form1 : Form
    {
        private Dictionary<int, (string name, string trait)> zodiac = new Dictionary<int, (string, string)>
        {
            {1, ("Мавпа", "хитрість")},
            {2, ("Півень", "фанфараон")},
            {3, ("Собака", "справедливість")},
            {4, ("Свиня", "добра старина")},
            {5, ("Щур", "агресивність")},
            {6, ("Бик", "робота, сім’я")},
            {7, ("Тигр", "енергія")},
            {8, ("Кролик", "спокійність")},
            {9, ("Дракон", "не все золото, що блищить")},
            {10, ("Змія", "мудрість")},
            {11, ("Кінь", "чесність")},
            {12, ("Коза", "примхливість")}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
                int number = int.Parse(txtNumber.Text);

                if (number < 1 || number > 12)
                {
                    MessageBox.Show("Введіть число від 1 до 12!", "Помилка");
                    return;
                }

                var zodiacSign = zodiac[number];
                lblResult.Text = $"Знак: {zodiacSign.name}\nХарактеристика: {zodiacSign.trait}";
        }
    }
}
