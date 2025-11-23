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
        private List<ModelResult> modelResults = new();

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
                txtOutput.Clear();
                lstResults.Items.Clear();
                modelResults.Clear();
                btnRecognize.Enabled = true;
                btnSave.Enabled = false;
                lblStatus.Text = $"Loaded: {Path.GetFileName(inputPath)}";
            }
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            var input = txtInput.Text ?? string.Empty;
            var numberModel = new NumberRecognizer(Culture.English).GetNumberModel();
            modelResults = numberModel.Parse(input).ToList();

            lstResults.Items.Clear();
            foreach (var r in modelResults)
            {
                var value = r.Resolution != null && r.Resolution.TryGetValue("value", out var v) ? v?.ToString() : "?";
                lstResults.Items.Add($"Text: {r.Text}, Start: {r.Start}, End: {r.End}, Value: {value}");
            }

            txtOutput.Text = ReplaceNumbers(input, modelResults);
            btnSave.Enabled = true;
            lblStatus.Text = $"Recognized {modelResults.Count} number(s).";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Title = "Save transformed text",
                Filter = "Text files (*.txt)|*.txt",
                FileName = Path.GetFileNameWithoutExtension(inputPath) + ".numbers.txt"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtOutput.Text);
                lblStatus.Text = $"Saved: {Path.GetFileName(sfd.FileName)}";
            }
        }

        private string ReplaceNumbers(string text, List<ModelResult> results)
        {
            var ordered = results
                .Where(r => r.Start >= 0 && r.End >= 0)
                .OrderByDescending(r => r.Start)
                .ToList();

            var transformed = text;
            foreach (var r in ordered)
            {
                var start = r.Start;
                var end = r.End;
                var length = end - start + 1;
                var value = r.Resolution != null && r.Resolution.TryGetValue("value", out var v) ? v?.ToString() : null;
                if (value != null)
                {
                    transformed = transformed.Remove(start, length).Insert(start, value);
                }
            }
            return transformed;
        }
    }
}