namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnStart;
        private Button btnStop;
        private Label lblTimer1;
        private Label lblTimer2;
        private Label lblTimer3;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnStart = new Button();
            this.btnStop = new Button();
            this.lblTimer1 = new Label();
            this.lblTimer2 = new Label();
            this.lblTimer3 = new Label();
            this.lblStatus = new Label();
            this.SuspendLayout();

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(30, 30);
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.Text = "Старт";
            this.btnStart.Click += new EventHandler(this.btnStart_Click);

            // btnStop
            this.btnStop.Location = new System.Drawing.Point(140, 30);
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.Text = "Стоп";
            this.btnStop.Enabled = false;
            this.btnStop.Click += new EventHandler(this.btnStop_Click);

            // lblTimer1
            this.lblTimer1.Location = new System.Drawing.Point(30, 80);
            this.lblTimer1.Size = new System.Drawing.Size(320, 30);
            this.lblTimer1.Text = "0 сек (затримка 1000мс)";

            // lblTimer2
            this.lblTimer2.Location = new System.Drawing.Point(30, 110);
            this.lblTimer2.Size = new System.Drawing.Size(320, 30);
            this.lblTimer2.Text = "0 сек (затримка 1500мс)";

            // lblTimer3
            this.lblTimer3.Location = new System.Drawing.Point(30, 140);
            this.lblTimer3.Size = new System.Drawing.Size(320, 30);
            this.lblTimer3.Text = "0 сек (затримка 2000мс)";

            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(30, 180);
            this.lblStatus.Size = new System.Drawing.Size(320, 30);
            this.lblStatus.Text = "Готово";

            // Form1
            this.ClientSize = new System.Drawing.Size(384, 240);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblTimer1);
            this.Controls.Add(this.lblTimer2);
            this.Controls.Add(this.lblTimer3);
            this.Controls.Add(this.lblStatus);
            this.Text = "ThreadPool секундомір";
            this.ResumeLayout(false);
        }
    }
}