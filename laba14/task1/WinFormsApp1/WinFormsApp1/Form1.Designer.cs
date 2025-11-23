namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private Label lblTime;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            lblTime = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(30, 30);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 30);
            btnStart.TabIndex = 0;
            btnStart.Text = "Старт";
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(140, 30);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 30);
            btnStop.TabIndex = 1;
            btnStop.Text = "Стоп";
            btnStop.Click += btnStop_Click;
            // 
            // btnReset
            // 
            btnReset.Enabled = false;
            btnReset.Location = new Point(250, 30);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 30);
            btnReset.TabIndex = 2;
            btnReset.Text = "Скинути";
            btnReset.Click += btnReset_Click;
            // 
            // lblTime
            // 
            lblTime.Font = new Font("Segoe UI", 24F);
            lblTime.Location = new Point(30, 80);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(320, 55);
            lblTime.TabIndex = 3;
            lblTime.Text = "0 сек";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(30, 135);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(320, 30);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Готово";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            ClientSize = new Size(384, 231);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            Controls.Add(btnReset);
            Controls.Add(lblTime);
            Controls.Add(lblStatus);
            Name = "Form1";
            Text = "Секундомір (Thread)";
            ResumeLayout(false);
        }
    }
}