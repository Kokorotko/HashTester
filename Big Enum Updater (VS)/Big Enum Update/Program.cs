using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;

class Program
{
    const string LANGUAGE_FOLDER = "Languages";
    const string LANGUAGE_CS = "Languages.cs";

    const string START_MARKER = "//**GENERATED L DO NOT EDIT START**//";
    const string END_MARKER = "//**GENERATED L DO NOT EDIT END**//";

    const string START_MARKER_SETTINGS_EN = "//**LANGUAGE-CHECKER GENERATED ENGLISH START";
    const string END_MARKER_SETTINGS_EN = "//**LANGUAGE-CHECKER GENERATED ENGLISH END";

    const string START_MARKER_SETTINGS_CZ = "//**LANGUAGE-CHECKER GENERATED CZECH START";
    const string END_MARKER_SETTINGS_CZ = "//**LANGUAGE-CHECKER GENERATED CZECH END";

    static void Main()
    {
        try
        {
            Console.WriteLine("=== ENUM GENERATOR START ===");

            string baseDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, ".."));

            string languagesFolder = FindDirectories(baseDir, LANGUAGE_FOLDER).FirstOrDefault();
            if (languagesFolder == null)
            {
                Console.WriteLine("ERROR: Languages folder not found.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            string langCsPath = Directory
                .EnumerateFiles(baseDir, LANGUAGE_CS, SearchOption.AllDirectories)
                .FirstOrDefault();

            if (langCsPath == null)
            {
                Console.WriteLine("ERROR: Languages.cs not found.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            string settingsPath = Directory
                .EnumerateFiles(baseDir, "settings.cs", SearchOption.AllDirectories)
                .FirstOrDefault();

            if (settingsPath == null)
            {
                Console.WriteLine("ERROR: settings.cs not found.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Languages folder: {languagesFolder}");
            Console.WriteLine($"Languages.cs: {langCsPath}");
            Console.WriteLine($"settings.cs: {settingsPath}");

            string englishPath = Path.Combine(languagesFolder, "English.json");
            string czechPath = Path.Combine(languagesFolder, "Čeština.json");

            if (!File.Exists(englishPath))
            {
                Console.WriteLine("ERROR: English.json not found.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            var englishDict = LoadJson(englishPath);
            if (englishDict == null)
            {
                Console.WriteLine("ERROR: Failed to parse English.json");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            var masterKeys = new HashSet<string>(englishDict.Keys);

            ValidateOtherLanguages(languagesFolder, masterKeys);

            Console.WriteLine("Enum generated.");

            // Update settings.cs
            if (File.Exists(englishPath))
            {
                ReplaceBlock(
                    settingsPath,
                    englishPath,
                    START_MARKER_SETTINGS_EN,
                    END_MARKER_SETTINGS_EN
                );
            }

            if (File.Exists(czechPath))
            {
                ReplaceBlock(
                    settingsPath,
                    czechPath,
                    START_MARKER_SETTINGS_CZ,
                    END_MARKER_SETTINGS_CZ
                );
            }

            Console.WriteLine("settings.cs updated.");
            Console.WriteLine("=== DONE ===");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    static void ValidateOtherLanguages(string folder, HashSet<string> masterKeys)
    {
        var jsonFiles = Directory.GetFiles(folder, "*.json");

        foreach (var file in jsonFiles)
        {
            if (file.EndsWith("English.json", StringComparison.OrdinalIgnoreCase))
                continue;

            var dict = LoadJson(file);
            if (dict == null)
            {
                Console.WriteLine($"ERROR: Failed to parse {Path.GetFileName(file)}");
                continue;
            }

            var keys = new HashSet<string>(dict.Keys);

            var missing = masterKeys.Except(keys).ToList();
            var extra = keys.Except(masterKeys).ToList();

            if (missing.Count == 0 && extra.Count == 0)
            {
                Console.WriteLine($"{Path.GetFileName(file)} OK");
                continue;
            }

            Console.WriteLine($"--- Issues in {Path.GetFileName(file)} ---");

            foreach (var m in missing)
                Console.WriteLine($"  MISSING: {m}");

            foreach (var e in extra)
                Console.WriteLine($"  EXTRA:   {e}");
        }
    }

    static void ReplaceBlock(string filePathSettings, string filePathEnum, string startMarker, string endMarker)
    {
        string tempPath = filePathSettings + ".tmp";
        bool foundTheBible = false;
        using (StreamReader reader = new StreamReader(filePathSettings))
        using (StreamWriter writer = new StreamWriter(tempPath))
        using (StreamReader enumReader = new StreamReader(filePathEnum))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.Trim() == startMarker)
                {
                    foundTheBible = true;
                    writer.WriteLine(line);
                    string lineTemp;
                    while (!enumReader.EndOfStream)
                    {
                        lineTemp = enumReader.ReadLine().Trim(); //"something": "something else",
                        lineTemp = lineTemp.Replace("\"", "\\\""); // Escape quotes for C# string literal)
                        writer.WriteLine($"writer.WriteLine(\"{lineTemp}\");");
                    }
                }
                else
                {
                    if (!foundTheBible)
                    {
                        writer.WriteLine(line);
                    }
                    else
                    {
                        if (line.Trim() == endMarker)
                        {
                            foundTheBible = false;
                            writer.WriteLine(endMarker);
                        }
                    }
                }
            }
        }
        try
        {
            File.Delete(filePathSettings);
            File.Move(tempPath, filePathSettings);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: Failed to replace block in {filePathSettings}: {ex.Message}");
        }
    }

    static IEnumerable<string> GenerateEnum(IEnumerable<string> keys)
    {
        var names = keys
            .Select(StringTransform)
            .Distinct()
            .OrderBy(x => x);

        yield return "    public enum L";
        yield return "    {";

        foreach (var name in names)
            yield return $"        {name},";

        yield return "    }";
    }

    static Dictionary<string, string> LoadJson(string path)
    {
        try
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
        catch
        {
            return null;
        }
    }

    static string StringTransform(string input)
    {
        var clean = new string(input.Where(char.IsLetterOrDigit).ToArray());

        if (string.IsNullOrWhiteSpace(clean))
            clean = "InvalidKey";

        if (char.IsDigit(clean[0]))
            clean = "_" + clean;

        return clean;
    }

    static IEnumerable<string> FindDirectories(string root, string target)
    {
        var stack = new Stack<string>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            string current = stack.Pop();

            string[] subDirs;
            try
            {
                subDirs = Directory.GetDirectories(current);
            }
            catch
            {
                continue;
            }

            foreach (var dir in subDirs)
            {
                if (Path.GetFileName(dir)
                    .Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    yield return dir;
                }

                stack.Push(dir);
            }
        }
    }
}