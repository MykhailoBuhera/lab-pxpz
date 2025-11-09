using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    // Це частина класу Form1
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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvDefaultStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.dgvAdjacency = new System.Windows.Forms.DataGridView();
            this.dgvIncidence = new System.Windows.Forms.DataGridView();
            this.lblAdj = new System.Windows.Forms.Label();
            this.lblInc = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();

            // Налаштування стилів (спільні для обох таблиць)
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvHeaderStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dgvDefaultStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // Панель
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mainPanel.Controls.Add(this.lblAdj);
            this.mainPanel.Controls.Add(this.dgvAdjacency);
            this.mainPanel.Controls.Add(this.lblInc);
            this.mainPanel.Controls.Add(this.dgvIncidence);

            // Напис 1
            this.lblAdj.Text = "1. Матриця суміжності (V x V)";
            this.lblAdj.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdj.AutoSize = true;

            // Таблиця 1
            this.dgvAdjacency.AllowUserToAddRows = false;
            this.dgvAdjacency.AllowUserToDeleteRows = false;
            this.dgvAdjacency.ReadOnly = true;
            this.dgvAdjacency.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAdjacency.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAdjacency.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAdjacency.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvAdjacency.DefaultCellStyle = dgvDefaultStyle;
            this.dgvAdjacency.Size = new System.Drawing.Size(950, 200);

            // Напис 2
            this.lblInc.Text = "2. Матриця інцидентності (V x E)";
            this.lblInc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblInc.AutoSize = true;
            this.lblInc.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);

            // Таблиця 2
            this.dgvIncidence.AllowUserToAddRows = false;
            this.dgvIncidence.AllowUserToDeleteRows = false;
            this.dgvIncidence.ReadOnly = true;
            this.dgvIncidence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvIncidence.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvIncidence.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvIncidence.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvIncidence.DefaultCellStyle = dgvDefaultStyle;
            this.dgvIncidence.Size = new System.Drawing.Size(950, 200);

            // Головне вікно (Форма)
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Побудова матриць для графа (Варіант 2)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // Додаємо обробник події завантаження форми
            this.Load += new System.EventHandler(this.Form1_Load);

            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjacency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidence)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Тут дизайнер оголошує змінні для елементів керування
        private System.Windows.Forms.DataGridView dgvAdjacency;
        private System.Windows.Forms.DataGridView dgvIncidence;
        private System.Windows.Forms.Label lblAdj;
        private System.Windows.Forms.Label lblInc;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
    }
}