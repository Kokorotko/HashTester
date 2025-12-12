using System;
using System.Windows.Forms;
using static HashTester.Settings;

namespace HashTester
{
    internal class StripMenu
    {
        public static void LoadStripMenu(Form form)
        {
            var menu = new MenuStrip();

            // --------------------
            // HASHING MENU
            // --------------------
            // --------------------
            // HASHING MENU
            // --------------------
            var hashing = new ToolStripMenuItem("Hashing");

            var gradual = new ToolStripMenuItem("Gradual Hashing");
            gradual.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.Gradual);
            hashing.DropDownItems.Add(gradual);

            var multiple = new ToolStripMenuItem("Multiple Hashing");
            multiple.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.MultipleHashing);
            hashing.DropDownItems.Add(multiple);

            var collisions = new ToolStripMenuItem("Finding Collisions");
            collisions.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.HashingCollision);
            hashing.DropDownItems.Add(collisions);

            var fileChecksum = new ToolStripMenuItem("File Checksum");
            fileChecksum.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.FileChecksum);
            hashing.DropDownItems.Add(fileChecksum);

            var saltPepper = new ToolStripMenuItem("Salt & Pepper Tester");
            saltPepper.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.SaltAndPepperTester);
            hashing.DropDownItems.Add(saltPepper);

            var passwordJailbreak = new ToolStripMenuItem("Password Jailbreak");
            passwordJailbreak.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.PasswordForm);
            hashing.DropDownItems.Add(passwordJailbreak);

            // --------------------
            // OPTIONS MENU
            // --------------------
            var options = new ToolStripMenuItem("Options");

            var visualMode = new ToolStripMenuItem("Visual Mode");

            var systemMode = new ToolStripMenuItem("System");
            systemMode.Click += (s, e) => { Settings.VisualMode = VisualModeEnum.System; Settings.SaveSettings(); FormManagement.SetUpFormTheme(form); };
            visualMode.DropDownItems.Add(systemMode);

            var lightMode = new ToolStripMenuItem("Light");
            lightMode.Click += (s, e) => { Settings.VisualMode = VisualModeEnum.Light; Settings.SaveSettings(); FormManagement.SetUpFormTheme(form); };
            visualMode.DropDownItems.Add(lightMode);

            var darkMode = new ToolStripMenuItem("Dark");
            darkMode.Click += (s, e) => { Settings.VisualMode = VisualModeEnum.Dark; Settings.SaveSettings(); FormManagement.SetUpFormTheme(form); };
            visualMode.DropDownItems.Add(darkMode);

            options.DropDownItems.Add(visualMode);

            var outputType = new ToolStripMenuItem("Output Type");

            var messageBox = new ToolStripMenuItem("MessageBox");
            messageBox.Click += (s, e) => { Settings.OutputType = OutputTypeEnum.MessageBox; Settings.SaveSettings(); };
            outputType.DropDownItems.Add(messageBox);

            var listBox = new ToolStripMenuItem("ListBox");
            listBox.Click += (s, e) => { Settings.OutputType = OutputTypeEnum.Listbox; Settings.SaveSettings(); };
            outputType.DropDownItems.Add(listBox);

            var txtFile = new ToolStripMenuItem("TXT File");
            txtFile.Click += (s, e) => { Settings.OutputType = OutputTypeEnum.TXTFile; Settings.SaveSettings(); };
            outputType.DropDownItems.Add(txtFile);

            options.DropDownItems.Add(outputType);

            var outputStyle = new ToolStripMenuItem("Output Style");

            var includeOriginal = new ToolStripMenuItem("Include Original String");
            includeOriginal.Click += (s, e) => { Settings.OutputStyleIncludeOriginalString = !Settings.OutputStyleIncludeOriginalString; Settings.SaveSettings(); };
            outputStyle.DropDownItems.Add(includeOriginal);

            var includeNumber = new ToolStripMenuItem("Include Number of Hash");
            includeNumber.Click += (s, e) => { Settings.OutputStyleIncludeNumberOfHash = !Settings.OutputStyleIncludeNumberOfHash; Settings.SaveSettings(); };
            outputStyle.DropDownItems.Add(includeNumber);

            var includeAlgorithm = new ToolStripMenuItem("Include Hash Algorithm");
            includeAlgorithm.Click += (s, e) => { Settings.OutputStyleIncludeHashAlgorithm = !Settings.OutputStyleIncludeHashAlgorithm; Settings.SaveSettings(); };
            outputStyle.DropDownItems.Add(includeAlgorithm);

            var includeSaltPepper = new ToolStripMenuItem("Include Salt and Pepper");
            includeSaltPepper.Click += (s, e) => { Settings.OutputStyleIncludeSaltPepper = !Settings.OutputStyleIncludeSaltPepper; Settings.SaveSettings(); };
            outputStyle.DropDownItems.Add(includeSaltPepper);

            var includeAll = new ToolStripMenuItem("Include All");
            includeAll.Click += (s, e) =>
            {
                bool isAllChecked = Settings.OutputStyleIncludeOriginalString && Settings.OutputStyleIncludeNumberOfHash &&
                                    Settings.OutputStyleIncludeHashAlgorithm && Settings.OutputStyleIncludeSaltPepper;
                Settings.OutputStyleIncludeOriginalString = !isAllChecked;
                Settings.OutputStyleIncludeNumberOfHash = !isAllChecked;
                Settings.OutputStyleIncludeHashAlgorithm = !isAllChecked;
                Settings.OutputStyleIncludeSaltPepper = !isAllChecked;
                Settings.SaveSettings();
            };
            outputStyle.DropDownItems.Add(includeAll);

            options.DropDownItems.Add(outputStyle);


            options.DropDownItems.Add(visualMode);
            options.DropDownItems.Add(outputType);
            options.DropDownItems.Add(outputStyle);

            // --------------------
            // LANGUAGES MENU
            // --------------------
            var languages = new ToolStripMenuItem("Languages");
            foreach (var lang in Languages.AllLanguages())
            {
                ToolStripMenuItem tempItem = new ToolStripMenuItem(lang);
                tempItem.Click += (s, e) => Languages.AllLanguages();
                languages.DropDownItems.Add(tempItem);
            }

            // --------------------
            // Add main menus
            // --------------------
            menu.Items.Add(hashing);
            menu.Items.Add(options);
            menu.Items.Add(languages);

            form.MainMenuStrip = menu;
            form.Controls.Add(menu);
        }
    }
}
