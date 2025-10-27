namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSession = new System.Windows.Forms.Button();
            this.txtDataSent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataReceived = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSessionDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSessions = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnCountByMonth = new System.Windows.Forms.Button();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btnShowByDate = new System.Windows.Forms.Button();
            this.btnFindMaxDuration = new System.Windows.Forms.Button();
            this.dtpSingleDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFilterByTraffic = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSession);
            this.groupBox1.Controls.Add(this.txtDataSent);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDataReceived);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEndTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStartTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpSessionDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1147, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "+ ноаий сеанс";
            // 
            // btnAddSession
            // 
            this.btnAddSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddSession.Location = new System.Drawing.Point(907, 50);
            this.btnAddSession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddSession.Name = "btnAddSession";
            this.btnAddSession.Size = new System.Drawing.Size(213, 59);
            this.btnAddSession.TabIndex = 12;
            this.btnAddSession.Text = "+ сеанс";
            this.btnAddSession.UseVisualStyleBackColor = true;
            this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
            // 
            // txtDataSent
            // 
            this.txtDataSent.Location = new System.Drawing.Point(667, 95);
            this.txtDataSent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDataSent.Name = "txtDataSent";
            this.txtDataSent.Size = new System.Drawing.Size(185, 22);
            this.txtDataSent.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 98);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Відправлено (Кб)";
            // 
            // txtDataReceived
            // 
            this.txtDataReceived.Location = new System.Drawing.Point(667, 38);
            this.txtDataReceived.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDataReceived.Name = "txtDataReceived";
            this.txtDataReceived.Size = new System.Drawing.Size(185, 22);
            this.txtDataReceived.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Прийнято (Кб)";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(307, 95);
            this.txtEndTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(159, 22);
            this.txtEndTime.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Час завершення";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(307, 63);
            this.txtStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(159, 22);
            this.txtStartTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Час початку";
            // 
            // dtpSessionDate
            // 
            this.dtpSessionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSessionDate.Location = new System.Drawing.Point(307, 31);
            this.dtpSessionDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpSessionDate.Name = "dtpSessionDate";
            this.dtpSessionDate.Size = new System.Drawing.Size(159, 22);
            this.dtpSessionDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата сеансу";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(27, 63);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(132, 22);
            this.txtLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логін";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSessions);
            this.groupBox2.Location = new System.Drawing.Point(16, 164);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1147, 308);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Інфа про сеанси ";
            // 
            // dgvSessions
            // 
            this.dgvSessions.AllowUserToAddRows = false;
            this.dgvSessions.AllowUserToDeleteRows = false;
            this.dgvSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSessions.Location = new System.Drawing.Point(4, 19);
            this.dgvSessions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSessions.Name = "dgvSessions";
            this.dgvSessions.ReadOnly = true;
            this.dgvSessions.RowHeadersWidth = 51;
            this.dgvSessions.Size = new System.Drawing.Size(1139, 285);
            this.dgvSessions.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnShowAll);
            this.groupBox3.Controls.Add(this.btnCountByMonth);
            this.groupBox3.Controls.Add(this.numMonth);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnShowByDate);
            this.groupBox3.Controls.Add(this.btnFindMaxDuration);
            this.groupBox3.Controls.Add(this.dtpSingleDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnFilterByTraffic);
            this.groupBox3.Controls.Add(this.dtpEndDate);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dtpStartDate);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(16, 479);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1147, 197);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фільтри та звіти";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(960, 84);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(160, 28);
            this.btnShowAll.TabIndex = 12;
            this.btnShowAll.Text = "Показати всіх";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnCountByMonth
            // 
            this.btnCountByMonth.Location = new System.Drawing.Point(773, 135);
            this.btnCountByMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCountByMonth.Name = "btnCountByMonth";
            this.btnCountByMonth.Size = new System.Drawing.Size(160, 28);
            this.btnCountByMonth.TabIndex = 11;
            this.btnCountByMonth.Text = "Підрахувати";
            this.btnCountByMonth.UseVisualStyleBackColor = true;
            this.btnCountByMonth.Click += new System.EventHandler(this.btnCountByMonth_Click);
            // 
            // numMonth
            // 
            this.numMonth.Location = new System.Drawing.Point(680, 138);
            this.numMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(67, 22);
            this.numMonth.TabIndex = 10;
            this.numMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(387, 142);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(218, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Сеанси минулого року за місяць";
            // 
            // btnShowByDate
            // 
            this.btnShowByDate.Location = new System.Drawing.Point(587, 84);
            this.btnShowByDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowByDate.Name = "btnShowByDate";
            this.btnShowByDate.Size = new System.Drawing.Size(160, 28);
            this.btnShowByDate.TabIndex = 8;
            this.btnShowByDate.Text = "Показати всі сеанси";
            this.btnShowByDate.UseVisualStyleBackColor = true;
            this.btnShowByDate.Click += new System.EventHandler(this.btnShowByDate_Click);
            // 
            // btnFindMaxDuration
            // 
            this.btnFindMaxDuration.Location = new System.Drawing.Point(400, 84);
            this.btnFindMaxDuration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFindMaxDuration.Name = "btnFindMaxDuration";
            this.btnFindMaxDuration.Size = new System.Drawing.Size(160, 28);
            this.btnFindMaxDuration.TabIndex = 7;
            this.btnFindMaxDuration.Text = "Макс тривалість";
            this.btnFindMaxDuration.UseVisualStyleBackColor = true;
            this.btnFindMaxDuration.Click += new System.EventHandler(this.btnFindMaxDuration_Click);
            // 
            // dtpSingleDate
            // 
            this.dtpSingleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSingleDate.Location = new System.Drawing.Point(200, 86);
            this.dtpSingleDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpSingleDate.Name = "dtpSingleDate";
            this.dtpSingleDate.Size = new System.Drawing.Size(159, 22);
            this.dtpSingleDate.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Аналіз за конкретну дату:";
            // 
            // btnFilterByTraffic
            // 
            this.btnFilterByTraffic.Location = new System.Drawing.Point(773, 34);
            this.btnFilterByTraffic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFilterByTraffic.Name = "btnFilterByTraffic";
            this.btnFilterByTraffic.Size = new System.Drawing.Size(160, 28);
            this.btnFilterByTraffic.TabIndex = 4;
            this.btnFilterByTraffic.Text = "Знайти";
            this.btnFilterByTraffic.UseVisualStyleBackColor = true;
            this.btnFilterByTraffic.Click += new System.EventHandler(this.btnFilterByTraffic_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(587, 37);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(159, 22);
            this.dtpEndDate.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(547, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "по:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(373, 37);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(159, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(288, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Користувачі з трафіком > 20 Мб за період з";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 690);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Білінгова система Інтернет-провайдера";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Оголошення всіх елементів керування
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSessionDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataReceived;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataSent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddSession;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSessions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnFilterByTraffic;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpSingleDate;
        private System.Windows.Forms.Button btnFindMaxDuration;
        private System.Windows.Forms.Button btnShowByDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.Button btnCountByMonth;
        private System.Windows.Forms.Button btnShowAll;
    }
}