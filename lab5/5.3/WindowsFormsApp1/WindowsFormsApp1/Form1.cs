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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Film film1 = new Film("Jurassic Park", "Стівен Спілберг", 120, 10);
            Film film2 = new Film("Знахар", "Єжи Гофман", 130, 7);
            Cartoon cartoon = new Cartoon("Lion King", "Роджер Аллерс", 90, 8, 6);
            Performance perf = new Performance("Hamlet", "Вільям Шекспір", 150, 12, "драма");

            listBox1.Items.Add(film1.Info());
            listBox1.Items.Add(film2.Info());
            listBox1.Items.Add(cartoon.Info());
            listBox1.Items.Add(perf.Info());
            listBox1.Items.Add("------ Оновлено ------");

            film1.Title = "Ready Player One";
            film1.Director = "Стівен Спілберг";
            film1.Duration = 140;
            film1.ActorsCount = 15;

            film2.Title = "Пан Володийовський";
            film2.Director = "Єжи Гофман";
            film2.Duration = 110;
            film2.ActorsCount = 9;

            cartoon.Title = "Shrek";
            cartoon.Director = "Ендрю Адамсон";
            cartoon.Duration = 95;
            cartoon.ActorsCount = 6;

            perf.Title = "Мина Мазайло";
            perf.Director = "Микола Куліш";
            perf.Duration = 110;
            perf.ActorsCount = 10;

            listBox1.Items.Add(film1.Info());
            listBox1.Items.Add(film2.Info());
            listBox1.Items.Add(cartoon.Info());
            listBox1.Items.Add(perf.Info());
        }
    }

    public class Film
    {
        private string title;
        private string director;
        private int duration;
        private int actorsCount;

        public Film(string title, string director, int duration, int actorsCount)
        {
            this.title = title;
            this.director = director;
            this.duration = duration;
            this.actorsCount = actorsCount;
        }

        public virtual int Price()
        {
            int basePrice = duration * 20 + actorsCount * 30;
            if (director == "Стівен Спілберг" || director == "Джеймс Кемерон")
                return basePrice * 2;
            else
                return basePrice;
        }

        public virtual string Info()
        {
            return $"Назва: {title}, Режисер: {director}, Тривалість: {duration} хв, К-сть акторів: {actorsCount}, Вартість: {Price()} тис. $";
        }

        // Властивості
        public string Title { get => title; set => title = value; }
        public string Director { get => director; set => director = value; }
        public int Duration { get => duration; set => duration = value; }
        public int ActorsCount { get => actorsCount; set => actorsCount = value; }
    }

    public class Cartoon : Film
    {
        private int minAge;

        public Cartoon(string title, string director, int duration, int actorsCount, int minAge)
            : base(title, director, duration, actorsCount)
        {
            this.minAge = minAge;
        }

        public override int Price()
        {
            return Duration * 25 + ActorsCount * 10;
        }

        public override string Info()
        {
            return $"[Мультфільм] {base.Info()}, Мін. вік: {minAge}";
        }
    }

    public class Performance : Film
    {
        private string genre;

        public Performance(string title, string director, int duration, int actorsCount, string genre)
            : base(title, director, duration, actorsCount)
        {
            this.genre = genre;
        }

        public override int Price()
        {
            return Duration * 15 + ActorsCount * 15;
        }

        public override string Info()
        {
            return $"[Вистава] {base.Info()}, Жанр: {genre}";
        }
    }






    /*
    public class  Film
    {
        private string title;
        private string autor;
        private int time;
        private int amountofactors;

        public Film(string title, string autor, int time, int amountofactors)
        {
            this.title = title;
            this.autor = autor;
            this.time = time;
            this.amountofactors = amountofactors;
        }   

        public void ShowTitle()
        {
            MessageBox.Show($"{title},{autor},{time},{amountofactors}");
        }
        public virtual int Price()
        {
            if (autor == "James Cameron" || autor == "Steven Spilberg")
            {
                return 2 * (time * 25 + amountofactors * 30);
            }
            else {
                return time * 25 + amountofactors * 30;

            }
        }

        // geters
        public string GetTitle()
        {
            return title;
        }
        public string GetAutor()
        {
            return autor;
        }
        public int GetTime()
        {
            return time;
        }
        public int GetAmountOfActors()
        {
            return amountofactors;
        }
        // seters
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void SetAutor(string autor)
        {
            this.autor = autor;
        }
        public void SetTime(int time)
        {
            this.time = time;
        }
        public void SetAmountOfActors(int amountofactors)
        {
            this.amountofactors = amountofactors;
        }
    }
    public class Cartoon : Film
    {
        private int minyear;
        public Cartoon(string title, string autor, int time, int amountofactors, int minyear) : base(title, autor, time, amountofactors)
        {
            this.minyear = minyear;
        }
        public override int Price()
        {
            return GetTime()* 25 + GetAmountOfActors() * 10;
        }
    }

    public class Perfomace : Film
    {
        private string genre;
        public Perfomace(string title, string autor, int time, int amountofactors, string genre) : base(title, autor, time, amountofactors)
        {
            this.genre = genre;
        }
        public override int Price()
        {
            return GetTime() * 15 + GetAmountOfActors() * 15;
        }
    }*/
}
