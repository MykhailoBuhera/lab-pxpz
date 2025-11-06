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
        
        private LectureNotes myLectureNotes;
        private Book myBook;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // ---  КОНСПЕКТ 
                int pageCount = int.Parse(textBox1.Text);    // кількості сторінок
                int topicCount = int.Parse(textBox2.Text);   // кількості тем
                bool hasIllustrations = textBox3.Text == "1"; // наявності ілюстрацій

                myLectureNotes = new LectureNotes(pageCount, topicCount, hasIllustrations);

                // ---  КНИГУ
                int publicationYear = int.Parse(textBox4.Text); // рік публікації
                int chapterCount = int.Parse(textBox5.Text);    //  кількість розділів
                bool hasHardcover = textBox6.Text == "1";       //  обкладинка  

                myBook = new Book(publicationYear, chapterCount, hasHardcover);

                MessageBox.Show("Об'єкти 'Книга' та 'Конспект' успішно створено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при створенні: {ex.Message}\n\nБудь ласка, перевірте дані.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Функції для кнопок КОНСПЕКТУ (ліва сторона) ---
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (myLectureNotes != null)
            {
                string info = $"--- Інформація про конспект ---\n";
                info += myLectureNotes.GetContentInfo() + "\n";
                info += myLectureNotes.GetComplexity() + "\n";
                info += myLectureNotes.HighlightText();
                MessageBox.Show(info, "Інформація про конспект");
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт кнопкою 'creat'.", "Помилка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (myLectureNotes != null)
            {
                MessageBox.Show(myLectureNotes.ReviewTopic("Вступ до програмування"), "Повторення теми");
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт кнопкою 'creat'.", "Помилка");
            }
        }

        // --- Функції для кнопок КНИГИ (права сторона) ---
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (myBook != null)
            {
                string info = $"--- Інформація про книгу ---\n";
                info += myBook.GetContentInfo() + "\n";
                info += myBook.GetComplexity() + "\n";
                info += myBook.CheckAuthor();
                MessageBox.Show(info, "Інформація про книгу");
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт кнопкою 'creat'.", "Помилка");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (myBook != null)
            {
                MessageBox.Show(myBook.ReadChapter(1), "Читання книги");
            }
            else
            {
                MessageBox.Show("Спочатку створіть об'єкт кнопкою 'creat'.", "Помилка");
            }
        }
    }

    public interface IEducationalMaterial
    {
        string GetContentInfo(); // Отримати інформацію про вміст
    }

    public interface IExam
    {
        string GetComplexity(); // Отримати складність підготовки
    }

    public class Book : IEducationalMaterial, IExam
    {
        public int PublicationYear;
        public int ChapterCount;
        public bool HasHardcover; // Чи тверда обкладинка

        public Book(int year, int chapters, bool hardcover)
        {
            PublicationYear = year;
            ChapterCount = chapters;
            HasHardcover = hardcover;
        }

        // ---  методів інтерфейсів ---
        public string GetContentInfo() => $"Книга складається з {ChapterCount} розділів.";
        public string GetComplexity() => "Складність підготовки: висока (потрібно читати уважно).";

        // ---  методи класу ---
        public string ReadChapter(int chapterNumber) => $"Ви почали читати розділ №{chapterNumber} з книги.";
        public string CheckAuthor() => "Автор книги: відомий науковець.";
    }

    // Похідний клас: Конспект
    public class LectureNotes : IEducationalMaterial, IExam
    {
        public int PageCount;
        public int TopicCount;
        public bool HasIllustrations; // Чи є ілюстрації

        public LectureNotes(int pages, int topics, bool illustrations)
        {
            PageCount = pages;
            TopicCount = topics;
            HasIllustrations = illustrations;
        }

        // --- Реалізація методів інтерфейсів ---
        public string GetContentInfo() => $"Конспект містить {TopicCount} тем на {PageCount} сторінках.";
        public string GetComplexity() => "Складність підготовки: середня (основні тези).";

        // --- Власні методи класу ---
        public string ReviewTopic(string topicName) => $"Ви повторюєте тему '{topicName}' з конспекту.";
        public string HighlightText() => "Важливі тези в конспекті виділено маркером.";
    }

}
