namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnLoad;
        private Button btnRecognize;
        private Button btnSave;
        private TextBox txtInput;
        private TextBox txtOutput;
        private ListBox lstResults;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoad = new Button();
            this.btnRecognize = new Button();
            this.btnSave = new Button();
            this.txtInput = new TextBox();
            this.txtOutput = new TextBox();
            this.lstResults = new ListBox();
            this.lblStatus = new Label();
            this.SuspendLayout();

            // btnLoad
            this.btnLoad.Location = new System.Drawing.Point(20, 20);
            this.btnLoad.Size = new System.Drawing.Size(120, 30);
            this.btnLoad.Text = "Load File";
            this.btnLoad.Click += new EventHandler(this.btnLoad_Click);

            // btnRecognize
            this.btnRecognize.Location = new System.Drawing.Point(160, 20);
            this.btnRecognize.Size = new System.Drawing.Size(160, 30);
            this.btnRecognize.Text = "Recognize Ordinals";
            this.btnRecognize.Enabled = false;
            this.btnRecognize.Click += new EventHandler(this.btnRecognize_Click);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(340, 20);
            this.btnSave.Size = new System.Drawing.Size(160, 30);
            this.btnSave.Text = "Save Results";
            this.btnSave.Enabled = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // txtInput
            this.txtInput.Location = new System.Drawing.Point(20, 70);
            this.txtInput.Multiline = true;
            this.txtInput.ScrollBars = ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(760, 100);

            // lstResults
            this.lstResults.Location = new System.Drawing.Point(20, 180);
            this.lstResults.Size = new System.Drawing.Size(760, 120);

            // txtOutput
            this.txtOutput.Location = new System.Drawing.Point(20, 310);
            this.txtOutput.Multiline = true;
            this.txtOutput.ScrollBars = ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(760, 100);

            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(20, 420);
            this.lblStatus.Size = new System.Drawing.Size(760, 30);
            this.lblStatus.Text = "Ready";

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblStatus);
            this.Text = "Ordinal Recognition";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}