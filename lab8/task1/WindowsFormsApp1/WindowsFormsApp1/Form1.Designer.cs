namespace StudentsScholarshipApp
{
    partial class Form1
    {
        /// <summary>
        /// Обов’язкова змінна конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очищення ресурсів, що використовуються.
        /// </summary>
        /// <param name="disposing">true, якщо керований ресурс слід видалити; інакше false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, створений конструктором форм Windows

        /// <summary>
        /// Необхідний метод для підтримки конструктора форм - не змінюйте
        /// вміст цього методу за допомогою редактора коду.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnShowScholarship = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lstStudents = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Прізвище:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Середній бал:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Група:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Курс:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(140, 22);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(150, 22);
            this.txtSurname.TabIndex = 4;
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(140, 62);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Size = new System.Drawing.Size(150, 22);
            this.txtAverage.TabIndex = 5;
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(140, 102);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(150, 22);
            this.txtGroup.TabIndex = 6;
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(140, 142);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(150, 22);
            this.txtCourse.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(320, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Додати студента";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnShowScholarship
            // 
            this.btnShowScholarship.Location = new System.Drawing.Point(320, 65);
            this.btnShowScholarship.Name = "btnShowScholarship";
            this.btnShowScholarship.Size = new System.Drawing.Size(150, 30);
            this.btnShowScholarship.TabIndex = 9;
            this.btnShowScholarship.Text = "Стипендія";
            this.btnShowScholarship.UseVisualStyleBackColor = true;
            this.btnShowScholarship.Click += new System.EventHandler(this.btnShowScholarship_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(320, 108);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(150, 30);
            this.btnShowAll.TabIndex = 10;
            this.btnShowAll.Text = "Показати всіх";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lstStudents
            // 
            this.lstStudents.FormattingEnabled = true;
            this.lstStudents.ItemHeight = 16;
            this.lstStudents.Location = new System.Drawing.Point(31, 190);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(439, 180);
            this.lstStudents.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.lstStudents);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnShowScholarship);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Облік стипендій студентів";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnShowScholarship;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.ListBox lstStudents;
    }
}
