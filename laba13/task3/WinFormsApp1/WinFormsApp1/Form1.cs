using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.NumberWithUnit;
using Microsoft.Recognizers.Text.Sequence;
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
        private Dictionary<string, List<ModelResult>> allResults = new();

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
                allResults.Clear();
                btnRecognize.Enabled = true;
                btnSave.Enabled = false;
                lblStatus.Text = $"Loaded: {Path.GetFileName(inputPath)}";
            }
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            var input = txtInput.Text ?? string.Empty;
            allResults.Clear();

            var culture = Culture.English;

            // NumberWithUnit
            AddResults("Currency", NumberWithUnitRecognizer.RecognizeCurrency(input, culture));
            AddResults("Dimension", NumberWithUnitRecognizer.RecognizeDimension(input, culture));
            AddResults("Temperature", NumberWithUnitRecognizer.RecognizeTemperature(input, culture));

            // DateTime
            AddResults("DateTime", DateTimeRecognizer.RecognizeDateTime(input, culture));

            // Sequence
            AddResults("PhoneNumber", SequenceRecognizer.RecognizePhoneNumber(input, culture));
            AddResults("IpAddress", SequenceRecognizer.RecognizeIpAddress(input, culture));
            AddResults("Email", SequenceRecognizer.RecognizeEmail(input, culture));
            AddResults("URL", SequenceRecognizer.RecognizeURL(input, culture));
            AddResults("Hashtag", SequenceRecognizer.RecognizeHashtag(input, culture));

            lstResults.Items.Clear();
            foreach (var category in allResults.Keys)
            {
                foreach (var r in allResults[category])
                {
                    var value = r.Resolution != null && r.Resolution.TryGetValue("value", out var v) ? v?.ToString() : "?";
                    lstResults.Items.Add($"{category}: {r.Text} → {value}");
                }
            }

            txtOutput.Text = GenerateOutputText(allResults);
            btnSave.Enabled = true;
            lblStatus.Text = $"Recognized {allResults.Sum(kvp => kvp.Value.Count)} items.";
        }

        private void AddResults(string category, IList<ModelResult> results)
        {
            if (!allResults.ContainsKey(category))
                allResults[category] = new List<ModelResult>();
            allResults[category].AddRange(results);
        }

        private string GenerateOutputText(Dictionary<string, List<ModelResult>> results)
        {
            var lines = new List<string>();
            foreach (var category in results.Keys)
            {
                lines.Add($"Тип: {category}, Кількість: {results[category].Count}");
                foreach (var r in results[category])
                {
                    var value = r.Resolution != null && r.Resolution.TryGetValue("value", out var v) ? v?.ToString() : "?";
                    lines.Add($"{r.Text} → {value}");
                }
                lines.Add(""); // empty line between categories
            }
            return string.Join(Environment.NewLine, lines);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Title = "Save recognition results",
                Filter = "Text files (*.txt)|*.txt",
                FileName = Path.GetFileNameWithoutExtension(inputPath) + ".recognized.txt"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtOutput.Text);
                lblStatus.Text = $"Saved: {Path.GetFileName(sfd.FileName)}";
            }
        }
    }
}