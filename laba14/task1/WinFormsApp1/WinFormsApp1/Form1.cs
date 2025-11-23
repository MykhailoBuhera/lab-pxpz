using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Thread? _timerThread;
        private volatile bool _isRunning;
        private int _seconds;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isRunning) return;

            _isRunning = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnReset.Enabled = false;
            lblStatus.Text = "Секундомір запущено";

            _timerThread = new Thread(() =>
            {
                while (_isRunning)
                {
                    Thread.Sleep(1000);
                    _seconds++;
                    Invoke(() => lblTime.Text = $"{_seconds} сек");
                }
            });
            _timerThread.IsBackground = true;
            _timerThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnReset.Enabled = true;
            lblStatus.Text = "Зупинено";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _seconds = 0;
            lblTime.Text = "0 сек";
            lblStatus.Text = "Скинуто";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _isRunning = false;
            base.OnFormClosing(e);
        }
    }
}