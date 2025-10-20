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
        private Vegetable myVegetable;
        private Fruit myFruit;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // --- Створюємо Овоч (ліва колонка) ---
                int vegTermin = int.Parse(textBox1.Text);  // termin prudat
                int vegCount = int.Parse(textBox2.Text);   // count
                bool isRoot = textBox3.Text == "1";        // chu koren (1=так, 0=ні)

                myVegetable = new Vegetable(isRoot, vegTermin, vegCount);


                int fruitTermin = int.Parse(textBox4.Text); // termin prudat
                int fruitCount = int.Parse(textBox5.Text);  // count
                bool isSweet = textBox6.Text == "1";       // chu solod (1=так, 0=ні)

                myFruit = new Fruit(isSweet, fruitTermin, fruitCount);

                MessageBox.Show("Об'єкти 'Овоч' та 'Фрукт' успішно створено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при створенні: {ex.Message}\n\nБудь ласка, перевірте дані.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Функції для кнопок ОВОЧА ліво
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (myVegetable != null)
            {
                string info = $"--- Інформація про овоч ---\n";
                info += $"Кількість: {myVegetable.getcount()} кг\n";
                info += myVegetable.getTermin() + "\n";
                info += myVegetable.MakeStew();
                MessageBox.Show(info, "Інформація про овоч");
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт кнопкою 'creat'.", "Помилка");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (myVegetable != null)
            {
                if (int.TryParse(textBox2.Text, out int quantityToAdd))
                {
                    myVegetable.AddToStock(quantityToAdd);
                    MessageBox.Show($"Додано {quantityToAdd} кг. Нова кількість: {myVegetable.getcount()} кг.", "Склад оновлено");
                }
                else
                {
                    MessageBox.Show("Введіть коректну кількість для додавання.", "Помилка");
                }
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт кнопкою 'creat'.", "Помилка");
            }
        }

        // Функції для кнопок ФРУКТА право 
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (myFruit != null)
            {
                string info = $"--- Інформація про фрукт ---\n";
                info += $"Кількість: {myFruit.getcount()} кг\n";
                info += myFruit.getTermin() + "\n";
                info += myFruit.MakeJam();
                MessageBox.Show(info, "Інформація про фрукт");
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт кнопкою 'creat'.", "Помилка");
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (myFruit != null)
            {
                if (int.TryParse(textBox5.Text, out int quantityToAdd))
                {
                    myFruit.AddToStock(quantityToAdd);
                    MessageBox.Show($"Додано {quantityToAdd} кг. Нова кількість: {myFruit.getcount()} кг.", "Склад оновлено");
                }
                else
                {
                    MessageBox.Show("Введіть коректну кількість для додавання.", "Помилка");
                }
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт кнопкою 'creat'.", "Помилка");
            }
        }
    }
    public interface IPlantProduct
    {
        string getTermin();
    }

    public interface IWarehouse
    {
        int getcount();
    }

    public class Fruit : IPlantProduct, IWarehouse
    {
        public bool isSweat;
        public int termin;
        public int count;

        public Fruit(bool isSweet, int shelfLife, int initialCount)
        {
            this.isSweat = isSweet;
            this.termin = shelfLife;
            this.count = initialCount;
        }

        public string getTermin() => $"Термін придатності: {termin} днів.";
        public int getcount() => count;

        public void AddToStock(int amount) => count += amount;
        public string MakeJam() => "Готуємо смачний фруктовий джем!";
    }

    public class Vegetable : IPlantProduct, IWarehouse
    {
        public bool isrootVeg;
        public int termin;
        public int count;

        public Vegetable(bool isRoot, int shelfLife, int initialCount)
        {
            this.isrootVeg = isRoot;
            this.termin = shelfLife;
            this.count = initialCount;
        }

        public string getTermin() => $"Термін придатності: {termin} днів.";
        public int getcount() => count;

        public void AddToStock(int amount) => count += amount;
        public string MakeStew() => "Готуємо поживне овочеве рагу.";
    }
}
