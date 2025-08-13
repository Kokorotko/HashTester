using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Hastester_LanguageChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void Checker()
        {
            listBox1.Items.Clear();

            string file1 = GetFilePath("Select main translation (English)");
            if (string.IsNullOrEmpty(file1)) return;

            string file2 = GetFilePath("Select translation to compare");
            if (string.IsNullOrEmpty(file2)) return;

            var mainData = LoadFileData(file1);
            var compareData = LoadFileData(file2);

            uint numberOfMissing = 0;

            foreach (var kvp in mainData)
            {
                if (!compareData.ContainsKey(kvp.Key) || string.IsNullOrWhiteSpace(compareData[kvp.Key]))
                {
                    listBox1.Items.Add($"Missing: {kvp.Key} in second file → {kvp.Key}=={kvp.Value}");
                    numberOfMissing++;
                }
            }

            if (numberOfMissing == 0)
                listBox1.Items.Add("No problems found :)");
        }

        private Dictionary<int, string> LoadFileData(string path)
        {
            var dict = new Dictionary<int, string>();
            foreach (var line in File.ReadLines(path))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("//")) continue;

                var parts = trimmed.Split(new[] { "==" }, StringSplitOptions.None);
                if (parts.Length < 2) continue;

                if (int.TryParse(parts[0].Trim(), out int key))
                    dict[key] = parts[1].Trim();
            }
            return dict;
        }

        private string GetFilePath(string title)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = title;
                dlg.Filter = "Text Files|*.txt;*.csv;*.dat|All Files|*.*";
                dlg.InitialDirectory = Application.StartupPath;
                return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
            }
        }

        private string GetSavePath(string title, string defaultName)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = title;
                dlg.FileName = defaultName;
                dlg.InitialDirectory = Application.StartupPath;
                dlg.Filter = "C# Files|*.cs|All Files|*.*";
                return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
            }
        }

        private void button1_Click(object sender, EventArgs e) => Checker();

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFile = GetFilePath("Select translation file");
                if (string.IsNullOrEmpty(inputFile)) return;

                string outputFile = GetSavePath("Save CustomLanguage.cs", "CustomLanguage.cs");
                if (string.IsNullOrEmpty(outputFile)) return;

                string enumFile = GetSavePath("Save CustomLanguageEnum.cs", "CustomLanguageEnum.cs");
                if (string.IsNullOrEmpty(enumFile)) return;

                ExportLanguageFile(inputFile, outputFile, enumFile);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"Error in Button2: {ex.Message}");
            }
        }

        private void ExportLanguageFile(string inputFile, string outputFileName, string enumOutputFile)
        {
            try
            {
                var lines = File.ReadAllLines(inputFile);

                // Generate CustomLanguage.cs
                using (var writer = new StreamWriter(outputFileName, false))
                {
                    writer.WriteLine("#region Language CustomLanguage");
                    writer.WriteLine("if (!Directory.Exists(Settings.DirectoryToLanguages))");
                    writer.WriteLine("{");
                    writer.WriteLine("    Directory.CreateDirectory(Settings.DirectoryToLanguages);");
                    writer.WriteLine("}");
                    writer.WriteLine("s = Path.Combine(Settings.DirectoryToLanguages, \"CustomLanguage.txt\");");
                    writer.WriteLine("if (!File.Exists(s))");
                    writer.WriteLine("{");
                    writer.WriteLine("    using (StreamWriter writer = new StreamWriter(s))");
                    writer.WriteLine("    {");

                    foreach (var line in lines)
                        writer.WriteLine($"        writer.WriteLine(\"{line.Replace("\"", "\\\"")}\");");

                    writer.WriteLine("    }");
                    writer.WriteLine("}");
                    writer.WriteLine("#endregion");
                }

                // Generate Enum
                var seenNames = new Dictionary<string, int>();
                using (var enumWriter = new StreamWriter(enumOutputFile, false))
                {
                    enumWriter.WriteLine("public enum L");
                    enumWriter.WriteLine("{");

                    foreach (var line in lines)
                    {
                        var trimmed = line.Trim();
                        if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("//")) continue;

                        var parts = trimmed.Split(new[] { "==" }, StringSplitOptions.None);
                        if (parts.Length < 2) continue;

                        if (int.TryParse(parts[0].Trim(), out int key))
                        {
                            string cleaned = CleanText(parts[1]);
                            string camelCase = ToCamelCase(cleaned);
                            if (string.IsNullOrEmpty(camelCase)) continue;

                            if (seenNames.ContainsKey(camelCase))
                            {
                                listBox1.Items.Add($"Duplicate enum: {camelCase} (IDs {seenNames[camelCase]} and {key})");
                            }
                            else
                            {
                                seenNames[camelCase] = key;
                                enumWriter.WriteLine($"    {camelCase} = {key},");
                            }
                        }
                    }

                    enumWriter.WriteLine("}");
                }

                listBox1.Items.Add("Files generated:");
                listBox1.Items.Add(" - " + outputFileName);
                listBox1.Items.Add(" - " + enumOutputFile);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"Error generating files: {ex.Message}");
            }
        }

        private string CleanText(string text) => Regex.Replace(text, @"[^\w\s<>]", "");

        private string ToCamelCase(string text)
        {
            // Remove < and > before processing
            text = text.Replace("<", "").Replace(">", "");

            // Split into words and capitalize
            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(w => w.Trim());

            if (!words.Any()) return string.Empty;

            string camel = string.Concat(words.Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));

            // If starts with a digit, move the starting digits to the end
            if (char.IsDigit(camel[0]))
            {
                string numberPart = new string(camel.TakeWhile(char.IsDigit).ToArray());
                string restPart = new string(camel.SkipWhile(char.IsDigit).ToArray());
                camel = restPart + numberPart;
            }

            return camel;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath;
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select folder with .cs files";
                    fbd.SelectedPath = Application.StartupPath;
                    if (fbd.ShowDialog() != DialogResult.OK) return;
                    folderPath = fbd.SelectedPath;
                }

                string enumFile = GetFilePath("Select the CustomLanguageEnum.cs file to use for replacements");
                if (string.IsNullOrEmpty(enumFile)) return;

                var enumMap = LoadEnumMap(enumFile);

                foreach (var file in Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories))
                {
                    string content = File.ReadAllText(file);

                    content = Regex.Replace(content,
                        @"Languages\.Translate\(\s*(\d+)\s*\)",
                        m =>
                        {
                            if (int.TryParse(m.Groups[1].Value, out int id) && enumMap.TryGetValue(id, out string enumName))
                                return $"Languages.Translate(Languages.L.{enumName})";
                            return m.Value; // leave unchanged if not found
                        });

                    File.WriteAllText(file, content);
                }

                listBox1.Items.Add("Replacement completed.");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"Error in Button3: {ex.Message}");
            }
        }


        private Dictionary<int, string> LoadEnumMap(string enumFile)
        {
            var map = new Dictionary<int, string>();
            foreach (var line in File.ReadLines(enumFile))
            {
                var match = Regex.Match(line, @"^\s*(\w+)\s*=\s*(\d+),");
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    int id = int.Parse(match.Groups[2].Value);
                    map[id] = name;
                }
            }
            return map;
        }
    }
}
