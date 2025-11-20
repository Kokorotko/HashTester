using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Hastester_LanguageUpdater
{
    public partial class Form1 : Form
    {
        private static readonly string settingsPath = "..\\..\\..\\..\\HashTester\\HashTester\\Settings.cs";
        private static readonly string settingsTempPath = "..\\..\\..\\..\\HashTester\\HashTester\\SettingsTemp.cs";
        private static readonly string languagePath = "..\\..\\..\\..\\HashTester\\HashTester\\Languages.cs";
        private static readonly string languagePathTemp = "..\\..\\..\\..\\HashTester\\HashTester\\LanguagesTemp.cs";
        private static readonly string languagesDirectory = "..\\..\\..\\..\\HashTester\\HashTester\\bin\\Debug\\Languages\\";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();
                if (Directory.Exists(languagesDirectory))
                {
                    var files = Directory.GetFiles(languagesDirectory);
                    foreach (var file in files)
                    {
                        comboBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
                    }

                    if (comboBox1.Items.Count > 0)
                        comboBox1.SelectedIndex = 0;
                }
                Console.WriteLine($"Loaded {comboBox1.Items.Count} languages into ComboBox.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR loading languages: " + ex.Message);
            }
        }

        #region BUTTON ADD
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(settingsPath))
                {
                    Console.WriteLine("ERROR: settings.cs not found.");
                    MessageBox.Show("File settings.cs does not exist");
                    return;
                }

                Console.WriteLine("=== STARTING LANGUAGE UPDATE ===");

                string settingsStartIndicator = "//**LANGUAGE-CHECKER GENERATED " + comboBox1.SelectedItem?.ToString().ToUpper() + " START";
                string settingsEndIndicator = "//**LANGUAGE-CHECKER GENERATED " + comboBox1.SelectedItem?.ToString().ToUpper() + " END";

                List<int> settingsIds = new List<int>();
                List<string> settingsTexts = new List<string>();

                //-------------------------------------------------
                // READ + UPDATE SETTINGS.CS
                //-------------------------------------------------
                using (StreamReader reader = new StreamReader(settingsPath))
                using (StreamWriter writer = new StreamWriter(settingsTempPath))
                {
                    string line;
                    bool inBlock = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!inBlock)
                        {
                            if (line.Trim() == settingsStartIndicator)
                            {
                                inBlock = true;
                                writer.WriteLine(line);
                                Console.WriteLine("Found SETTINGS START marker.");
                                continue;
                            }

                            writer.WriteLine(line);
                            continue;
                        }

                        if (line.Trim() == settingsEndIndicator)
                        {
                            Console.WriteLine("Found SETTINGS END marker.");

                            // Add new entries from textbox
                            foreach (string l in textBox1.Lines)
                            {
                                if (string.IsNullOrWhiteSpace(l)) continue;
                                string[] parts = l.Split(new[] { "==" }, StringSplitOptions.None);
                                if (parts.Length != 2) continue;
                                if (!int.TryParse(parts[0].Trim(), out int id)) continue;

                                settingsIds.Add(id);
                                settingsTexts.Add(parts[1].Trim());
                            }

                            // Remove duplicates (last wins)
                            Dictionary<int, string> unique = new Dictionary<int, string>();
                            for (int i = 0; i < settingsIds.Count; i++)
                                if (!string.IsNullOrWhiteSpace(settingsTexts[i]))
                                    unique[settingsIds[i]] = settingsTexts[i];

                            settingsIds = unique.Keys.ToList();
                            settingsTexts = unique.Values.ToList();

                            // Sort by ID
                            SortLists(settingsTexts, settingsIds);

                            // Write cleaned + sorted block
                            for (int i = 0; i < settingsIds.Count; i++)
                                writer.WriteLine($"writer.WriteLine(\"{settingsIds[i]}=={settingsTexts[i]}\");");

                            writer.WriteLine(settingsEndIndicator);
                            inBlock = false;
                            continue;
                        }

                        // Inside block: strip writer.WriteLine shell
                        string content = StripWriterLine(line);
                        Console.WriteLine(content);
                        if (string.IsNullOrWhiteSpace(content)) continue;

                        string[] split = content.Split(new[] { "==" }, StringSplitOptions.None);
                        if (split.Length == 2 && int.TryParse(split[0].Trim(), out int existingId))
                        {
                            settingsIds.Add(existingId);
                            settingsTexts.Add(split[1].Trim());
                        }
                    }
                }

                // Replace the original settings file
                File.Replace(settingsTempPath, settingsPath, null);

                Console.WriteLine("=== SETTINGS UPDATE SUCCESS ===");
                MessageBox.Show("Settings updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Helper: strip the "writer.WriteLine(...);" wrapper
        private string StripWriterLine(string line)
        {
            line = line.Trim();
            line = line.Substring(18);
            return line.Substring(0, line.Length - 3);
        }


        #endregion

        #region BUTTON CLEAN AND SORT
        private void button3_Click(object sender, EventArgs e) //Check
        {
            try
            {
                if (!File.Exists(settingsPath))
                {
                    Console.WriteLine("ERROR: settings.cs not found.");
                    MessageBox.Show("File settings.cs does not exist");
                    return;
                }

                if (!File.Exists(languagePath))
                {
                    Console.WriteLine("ERROR: languages.cs not found.");
                    MessageBox.Show("File languages.cs does not exist");
                    return;
                }
                ////**LANGUAGE-CHECKER GENERATED ČEŠTINA START
                string settingsStartIndicator = "//**LANGUAGE-CHECKER GENERATED " + comboBox1.SelectedItem?.ToString().ToUpper() + " START";
                string settingsEndIndicator = "//**LANGUAGE-CHECKER GENERATED " + comboBox1.SelectedItem?.ToString().ToUpper() + " END";
                string languageStartIndicator = "//**LANGUAGE-CHECKER GENERATED ENUM START";
                string languageEndIndicator = "//**LANGUAGE-CHECKER GENERATED ENUM END";

                //-------------------------------------------------
                // SETTINGS.CS
                //-------------------------------------------------
                Console.WriteLine("Processing Settings.cs...");
                List<int> settingsIds = new List<int>();
                List<string> settingsTexts = new List<string>();

                using (StreamReader reader = new StreamReader(settingsPath))
                using (StreamWriter writer = new StreamWriter(settingsTempPath))
                {
                    string line;
                    bool inBlock = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!inBlock)
                        {
                            if (line.Trim() == settingsStartIndicator)
                            {
                                inBlock = true;
                                Console.WriteLine("Found SETTINGS START marker.");
                                writer.WriteLine(line);
                                continue;
                            }
                            writer.WriteLine(line);
                            continue;
                        }

                        if (line.Trim() == settingsEndIndicator)
                        {
                            Console.WriteLine("Found SETTINGS END marker.");

                            // Add new user entries from textbox
                            foreach (string l in textBox1.Lines)
                            {
                                if (string.IsNullOrWhiteSpace(l)) continue;

                                string[] parts = l.Split(new[] { "==" }, StringSplitOptions.None);
                                if (parts.Length != 2) continue;

                                if (!int.TryParse(parts[0].Trim(), out int id)) continue;

                                settingsIds.Add(id);
                                settingsTexts.Add(parts[1].Trim());
                                Console.WriteLine($"Added SETTINGS entry from textbox: {id} == {parts[1].Trim()}");
                            }

                            // Remove duplicates
                            Dictionary<int, string> unique = new Dictionary<int, string>();
                            for (int i = 0; i < settingsIds.Count; i++)
                                if (!string.IsNullOrWhiteSpace(settingsTexts[i]))
                                    unique[settingsIds[i]] = settingsTexts[i]; // last wins

                            settingsIds = unique.Keys.ToList();
                            settingsTexts = unique.Values.ToList();

                            // Sort
                            SortLists(settingsTexts, settingsIds);

                            // Write cleaned + sorted block
                            for (int i = 0; i < settingsIds.Count; i++)
                                writer.WriteLine($"writer.WriteLine(\"{settingsIds[i]}=={settingsTexts[i]}\");");

                            writer.WriteLine(settingsEndIndicator);
                            Console.WriteLine("Settings block written successfully.");
                            inBlock = false;
                            continue;
                        }

                        // Strip shell from existing line
                        string content = StripWriterLine(line);
                        if (string.IsNullOrWhiteSpace(content)) continue;
                        // Parse ID==Text
                        string[] split = content.Split(new[] { "==" }, StringSplitOptions.None);
                        if (split.Length == 2 && int.TryParse(split[0].Trim(), out int readId))
                        {
                            settingsIds.Add(readId);
                            settingsTexts.Add(split[1].Trim());
                        }
                    }
                }

                //-------------------------------------------------
                // LANGUAGES.CS ENUM
                //-------------------------------------------------
                Console.WriteLine("Processing Languages.cs...");
                List<int> enumIds = new List<int>();
                List<string> enumNames = new List<string>();

                using (StreamReader reader = new StreamReader(languagePath))
                using (StreamWriter writer = new StreamWriter(languagePathTemp))
                {
                    string line;
                    bool inEnum = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!inEnum)
                        {
                            if (line.Trim() == languageStartIndicator)
                            {
                                inEnum = true;
                                Console.WriteLine("Found ENUM START marker.");
                                writer.WriteLine(line);
                                continue;
                            }
                            writer.WriteLine(line);
                            continue;
                        }

                        if (line.Trim() == languageEndIndicator)
                        {
                            // Add new enums from textbox
                            foreach (string l in textBox1.Lines)
                            {
                                if (string.IsNullOrWhiteSpace(l)) continue;

                                string[] parts = l.Split(new[] { "==" }, StringSplitOptions.None);
                                if (parts.Length != 2) continue;
                                if (!int.TryParse(parts[0].Trim(), out int id)) continue;

                                string enumName = StringTransform(parts[1]);
                                enumIds.Add(id);
                                enumNames.Add(enumName);
                                Console.WriteLine($"Added ENUM entry from textbox: {enumName} = {id}");
                            }

                            // Remove duplicates
                            Dictionary<int, string> unique = new Dictionary<int, string>();
                            for (int i = 0; i < enumIds.Count; i++)
                                unique[enumIds[i]] = enumNames[i];

                            enumIds = unique.Keys.ToList();
                            enumNames = unique.Values.ToList();

                            // Sort
                            SortLists(enumNames, enumIds);

                            // Write cleaned + sorted enum
                            for (int i = 0; i < enumIds.Count; i++)
                                writer.WriteLine($"{enumNames[i]} = {enumIds[i]},");

                            writer.WriteLine(languageEndIndicator);
                            Console.WriteLine("Enum block written successfully.");
                            inEnum = false;
                            continue;
                        }

                        // Read existing enum line
                        string[] partsEnum = line.Split(new[] { ' ', '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (partsEnum.Length >= 2 && int.TryParse(partsEnum[1], out int enumId))
                        {
                            enumIds.Add(enumId);
                            enumNames.Add(partsEnum[0].Trim());
                        }
                    }
                }

                // Replace files safely
                File.Replace(settingsTempPath, settingsPath, null);
                File.Replace(languagePathTemp, languagePath, null);

                Console.WriteLine("=== UPDATE SUCCESS ===");
                MessageBox.Show("Duplicates removed, empty lines removed, entries sorted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion

        #region HELPER METHODS
        private string StringTransform(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;

            var parts = str
                .Split(new char[] { ' ', '_', '-', '.', ',', ';', ':', '!', '?', '/', '\\', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < parts.Count; i++)
            {
                string p = parts[i].Trim();
                if (p.Length == 0) { parts.RemoveAt(i); i--; continue; }
                parts[i] = char.ToUpper(p[0]) + (p.Length > 1 ? p.Substring(1) : "");
            }

            string temp = string.Concat(parts);
            Console.WriteLine("String Transform: " + temp);
            return temp;
        }

        private void SortLists(List<string> names, List<int> numbers)
        {
            var paired = new List<(int Number, string Name)>();
            for (int i = 0; i < names.Count; i++)
                paired.Add((numbers[i], names[i]));

            paired.Sort((a, b) => a.Number.CompareTo(b.Number));

            for (int i = 0; i < paired.Count; i++)
            {
                numbers[i] = paired[i].Number;
                names[i] = paired[i].Name;
            }
        }
        #endregion

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(settingsPath) || !File.Exists(languagePath))
                {
                    Console.WriteLine("ERROR: One of the required files does not exist.");
                    MessageBox.Show("settings.cs or languages.cs does not exist");
                    return;
                }

                Console.WriteLine("=== STARTING REMOVE ===");

                string languageName = comboBox1.SelectedItem?.ToString() ?? "ENGLISH";
                string settingsStartIndicator = "//**LANGUAGE-CHECKER GENERATED " + languageName.ToUpper() + " START";
                string settingsEndIndicator = "//**LANGUAGE-CHECKER GENERATED " + languageName.ToUpper() + " END";
                string languageStartIndicator = "//**LANGUAGE-CHECKER GENERATED ENUM START";
                string languageEndIndicator = "//**LANGUAGE-CHECKER GENERATED ENUM END";

                // Collect IDs to remove
                List<int> idsToRemove = new List<int>();
                foreach (string l in textBox1.Lines)
                {
                    if (int.TryParse(l.Trim(), out int id)) idsToRemove.Add(id);
                }

                //-------------------------------------------------
                // Remove from Settings.cs
                //-------------------------------------------------
                List<int> settingsIds = new List<int>();
                List<string> settingsTexts = new List<string>();

                using (StreamReader reader = new StreamReader(settingsPath))
                using (StreamWriter writer = new StreamWriter(settingsTempPath))
                {
                    string line;
                    bool inBlock = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!inBlock)
                        {
                            if (line.Trim() == settingsStartIndicator)
                            {
                                inBlock = true;
                                writer.WriteLine(line);
                                continue;
                            }
                            writer.WriteLine(line);
                            continue;
                        }

                        if (line.Trim() == settingsEndIndicator)
                        {
                            // Remove entries
                            for (int i = settingsIds.Count - 1; i >= 0; i--)
                                if (idsToRemove.Contains(settingsIds[i]))
                                {
                                    Console.WriteLine($"Removing SETTINGS entry: {settingsIds[i]} == {settingsTexts[i]}");
                                    settingsIds.RemoveAt(i);
                                    settingsTexts.RemoveAt(i);
                                }

                            // Sort and write
                            SortLists(settingsTexts, settingsIds);
                            for (int i = 0; i < settingsIds.Count; i++)
                                writer.WriteLine($"writer.WriteLine(\"{settingsIds[i]}=={settingsTexts[i]}\");");

                            writer.WriteLine(settingsEndIndicator);
                            inBlock = false;
                            continue;
                        }

                        string content = StripWriterLine(line);
                        if (string.IsNullOrWhiteSpace(content)) continue;

                        string[] split = content.Split(new[] { "==" }, StringSplitOptions.None);
                        if (split.Length == 2 && int.TryParse(split[0].Trim(), out int existingId))
                        {
                            settingsIds.Add(existingId);
                            settingsTexts.Add(split[1].Trim());
                        }
                    }
                }

                //-------------------------------------------------
                // Remove from Languages.cs
                //-------------------------------------------------
                List<int> enumIds = new List<int>();
                List<string> enumNames = new List<string>();

                using (StreamReader reader = new StreamReader(languagePath))
                using (StreamWriter writer = new StreamWriter(languagePathTemp))
                {
                    string line;
                    bool inEnum = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!inEnum)
                        {
                            if (line.Trim() == languageStartIndicator)
                            {
                                inEnum = true;
                                writer.WriteLine(line);
                                continue;
                            }
                            writer.WriteLine(line);
                            continue;
                        }

                        if (line.Trim() == languageEndIndicator)
                        {
                            // Remove entries
                            for (int i = enumIds.Count - 1; i >= 0; i--)
                                if (idsToRemove.Contains(enumIds[i]))
                                {
                                    Console.WriteLine($"Removing ENUM entry: {enumNames[i]} = {enumIds[i]}");
                                    enumIds.RemoveAt(i);
                                    enumNames.RemoveAt(i);
                                }

                            // Sort and write
                            SortLists(enumNames, enumIds);
                            for (int i = 0; i < enumIds.Count; i++)
                                writer.WriteLine($"{enumNames[i]} = {enumIds[i]},");

                            writer.WriteLine(languageEndIndicator);
                            inEnum = false;
                            continue;
                        }

                        string[] partsEnum = line.Split(new[] { ' ', '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (partsEnum.Length >= 2 && int.TryParse(partsEnum[1], out int enumId))
                        {
                            enumIds.Add(enumId);
                            enumNames.Add(partsEnum[0].Trim());
                        }
                    }
                }

                // Replace files
                File.Replace(settingsTempPath, settingsPath, null);
                File.Replace(languagePathTemp, languagePath, null);

                Console.WriteLine("=== REMOVE SUCCESS ===");
                MessageBox.Show("Selected IDs removed from Settings and Languages successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }



    }
}
