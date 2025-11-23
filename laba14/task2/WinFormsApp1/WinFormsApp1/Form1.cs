using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<CancellationTokenSource> _tokens = new();
        private int _counter1 = 0;
        private int _counter2 = 0;
        private int _counter3 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "Запущено";

            _counter1 = 0;
            _counter2 = 0;
            _counter3 = 0;

            StartTimer(lblTimer1, () => _counter1++, () => _counter1, 1000);
            StartTimer(lblTimer2, () => _counter2++, () => _counter2, 1500);
            StartTimer(lblTimer3, () => _counter3++, () => _counter3, 2000);
        }

        private void StartTimer(Label label, Action increment, Func<int> getCounter, int delay)
        {
            var cts = new CancellationTokenSource();
            _tokens.Add(cts);
            var token = cts.Token;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                while (!token.IsCancellationRequested)
                {
                    Thread.Sleep(delay);
                    increment();
                    Invoke(() => label.Text = $"{getCounter()} сек (затримка {delay}мс)");
                }
            });
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var cts in _tokens)
                cts.Cancel();

            _tokens.Clear();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatus.Text = "Зупинено";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var cts in _tokens)
                cts.Cancel();

            base.OnFormClosing(e);
        }
    }
}