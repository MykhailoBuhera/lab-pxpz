using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Number;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string inputPath = "";
        private List<ModelResult> ordinalResults = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Title = "Select input text file",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inputPath = ofd.FileName;
                txtInput.Text = File.ReadAllText(inputPath);
                lstResults.Items.Clear();
                txtOutput.Clear();
                ordinalResults.Clear();
                btnRecognize.Enabled = true;
                btnSave.Enabled = false;
                lblStatus.Text = $"Loaded: {Path.GetFileName(inputPath)}";
            }
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            var input = txtInput.Text ?? string.Empty;
            var ordinalModel = new NumberRecognizer(Culture.English).GetOrdinalModel();
            ordinalResults = ordinalModel.Parse(input).ToList();

            lstResults.Items.Clear();
            foreach (var r in ordinalResults)
            {
                var value = r.Resolution != null && r.Resolution.TryGetValue("value", out var v) ? v?.ToString() : "?";
                lstResults.Items.Add($"{r.Text} Ц {value}");
            }

            txtOutput.Text = GenerateOutputText(ordinalResults);
            btnSave.Enabled = true;
            lblStatus.Text = $"Found {ordinalResults.Count} ordinal(s).";
        }

        private string GenerateOutputText(List<ModelResult> results)
        {
            var lines = new List<string>
            {
                $" ≥льк≥сть пор€дкових числ≥вник≥в: {results.Count}"
            };

            foreach (var r in results)
            {
                var value = r.Resolution != null && r.Resolution.TryGetValue("value", out var v) ? v?.ToString() : "?";
                lines.Add($"{r.Text} Ц {value}");
            }

            return string.Join(Environment.NewLine, lines);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Title = "Save ordinal results",
                Filter = "Text files (*.txt)|*.txt",
                FileName = Path.GetFileNameWithoutExtension(inputPath) + ".ordinals.txt"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtOutput.Text);
                lblStatus.Text = $"Saved: {Path.GetFileName(sfd.FileName)}";
            }
        }
    }
}