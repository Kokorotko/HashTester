using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static HashTester.Settings;

namespace HashTester
{
    internal static class StripMenu
    {
        public static void LoadStripMenu(Form form)
        {
            var menu = new MenuStrip();

            #region Hashing

            var hashing = new ToolStripMenuItem(Languages.Translate(Languages.L.Hashing));

            var gradual = new ToolStripMenuItem(Languages.Translate(Languages.L.GradualHashing));
            gradual.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.Gradual);
            hashing.DropDownItems.Add(gradual);

            var multiple = new ToolStripMenuItem(Languages.Translate(Languages.L.MultipleHashing));
            multiple.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.MultipleHashing);
            hashing.DropDownItems.Add(multiple);

            var collisions = new ToolStripMenuItem(Languages.Translate(Languages.L.FindingCollisions));
            collisions.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.HashingCollision);
            hashing.DropDownItems.Add(collisions);

            var fileChecksum = new ToolStripMenuItem(Languages.Translate(Languages.L.FileChecksum));
            fileChecksum.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.FileChecksum);
            hashing.DropDownItems.Add(fileChecksum);

            var saltPepper = new ToolStripMenuItem(Languages.Translate(Languages.L.SaltAndPepperTester));
            saltPepper.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.SaltAndPepperTester);
            hashing.DropDownItems.Add(saltPepper);

            var passwordJailbreak = new ToolStripMenuItem(Languages.Translate(Languages.L.PasswordTester));
            passwordJailbreak.Click += (s, e) => FormManagement.SpawnForm(FormManagement.Forms.PasswordForm);
            hashing.DropDownItems.Add(passwordJailbreak);

            #endregion

            #region Options
            var options = new ToolStripMenuItem(Languages.Translate(Languages.L.Options));

            #region Visual Mode

            //Create Items
            var visualMode = new ToolStripMenuItem(Languages.Translate(Languages.L.Visualmode));
            var systemMode = new ToolStripMenuItem(Languages.Translate(Languages.L.SystemTheme));
            var lightMode = new ToolStripMenuItem(Languages.Translate(Languages.L.LightTheme));
            var darkMode = new ToolStripMenuItem(Languages.Translate(Languages.L.DarkTheme));

            //Add to Visual Mode
            visualMode.DropDownItems.Add(systemMode);
            visualMode.DropDownItems.Add(lightMode);
            visualMode.DropDownItems.Add(darkMode);
            options.DropDownItems.Add(visualMode); //Add to Options

            //Click logic
            systemMode.Click += (s, e) =>
            {
                lightMode.Checked = false;
                darkMode.Checked = false;
                systemMode.Checked = true;
                Settings.VisualMode = VisualModeEnum.System;
                Settings.SaveSettings();
                FormManagement.ReloadAllForms(false, true, false);
            };

            lightMode.Click += (s, e) =>
            {
                systemMode.Checked = false;
                darkMode.Checked = false;
                lightMode.Checked = true;
                Settings.VisualMode = VisualModeEnum.Light;
                Settings.SaveSettings();
                FormManagement.ReloadAllForms(false, true, false);
            };

            darkMode.Click += (s, e) =>
            {
                systemMode.Checked = false;
                lightMode.Checked = false;
                darkMode.Checked = true;
                Settings.VisualMode = VisualModeEnum.Dark;
                Settings.SaveSettings();
                FormManagement.SetUpFormTheme(form);
            };

            #endregion

            #region OutputType

            //Create Items
            var outputType = new ToolStripMenuItem(Languages.Translate(Languages.L.OutputType));
            var messageBox = new ToolStripMenuItem(Languages.Translate(Languages.L.MessageBox)); //Dont forget to rename
            var listBox = new ToolStripMenuItem(Languages.Translate(Languages.L.ListBox));
            var txtFile = new ToolStripMenuItem(Languages.Translate(Languages.L.FileTxt));
            options.DropDownItems.Add(outputType); //Add to options

            //Add Items to sub-menu
            outputType.DropDownItems.Add(messageBox);
            outputType.DropDownItems.Add(listBox);
            outputType.DropDownItems.Add(txtFile);

            //Click logic
            messageBox.Click += (s, e) =>
            {
                listBox.Checked = false;
                txtFile.Checked = false;
                messageBox.Checked = true;
                Settings.OutputType = OutputTypeEnum.MessageBox;
                Settings.SaveSettings();
            };

            listBox.Click += (s, e) =>
            {
                listBox.Checked = true;
                txtFile.Checked = false;
                messageBox.Checked = false;
                Settings.OutputType = OutputTypeEnum.Listbox;
                Settings.SaveSettings();
            };

            txtFile.Click += (s, e) =>
            {
                listBox.Checked = false;
                txtFile.Checked = true;
                messageBox.Checked = false;
                Settings.OutputType = OutputTypeEnum.TXTFile;
                Settings.SaveSettings();
            };

            #endregion

            #region OutputStyle

            //Create Items
            var outputStyle = new ToolStripMenuItem(Languages.Translate(Languages.L.OutputStyle));
            var includeOriginal = new ToolStripMenuItem(Languages.Translate(Languages.L.IncludeOriginalText));
            var includeNumber = new ToolStripMenuItem(Languages.Translate(Languages.L.IncludeNumbering));
            var includeAlgorithm = new ToolStripMenuItem(Languages.Translate(Languages.L.IncludeHashingAlgorithm));
            var includeSaltPepper = new ToolStripMenuItem(Languages.Translate(Languages.L.IncludeSaltAndPepper));
            var includeAll = new ToolStripMenuItem(Languages.Translate(Languages.L.IncludeAllOptions));

            //Add Items to sub-menu            
            outputStyle.DropDownItems.Add(includeOriginal);
            outputStyle.DropDownItems.Add(includeNumber);
            outputStyle.DropDownItems.Add(includeAlgorithm);
            outputStyle.DropDownItems.Add(includeSaltPepper);
            outputStyle.DropDownItems.Add(includeAll);

            //Click Logic
            includeOriginal.Click += (s, e) =>
            {
                includeOriginal.Checked = !includeOriginal.Checked;
                Settings.OutputStyleIncludeOriginalString = !Settings.OutputStyleIncludeOriginalString;
                Settings.SaveSettings();

                //Include All check
                if (Settings.OutputStyleIncludeOriginalString &&
                 Settings.OutputStyleIncludeNumberOfHash &&
                 Settings.OutputStyleIncludeHashAlgorithm &&
                 Settings.OutputStyleIncludeSaltPepper)
                {
                    includeAll.Checked = true;
                }
                else includeAll.Checked = false;
            };

            includeNumber.Click += (s, e) =>
            {
                includeNumber.Checked = !includeNumber.Checked;
                Settings.OutputStyleIncludeNumberOfHash = !Settings.OutputStyleIncludeNumberOfHash;
                Settings.SaveSettings();

                //Include All check
                if (Settings.OutputStyleIncludeOriginalString &&
                 Settings.OutputStyleIncludeNumberOfHash &&
                 Settings.OutputStyleIncludeHashAlgorithm &&
                 Settings.OutputStyleIncludeSaltPepper)
                {
                    includeAll.Checked = true;
                }
                else includeAll.Checked = false;
            };

            includeAlgorithm.Click += (s, e) =>
            {
                includeAlgorithm.Checked = !includeAlgorithm.Checked;
                Settings.OutputStyleIncludeHashAlgorithm = !Settings.OutputStyleIncludeHashAlgorithm;
                Settings.SaveSettings();

                //Include All check
                if (Settings.OutputStyleIncludeOriginalString &&
                 Settings.OutputStyleIncludeNumberOfHash &&
                 Settings.OutputStyleIncludeHashAlgorithm &&
                 Settings.OutputStyleIncludeSaltPepper)
                {
                    includeAll.Checked = true;
                }
                else includeAll.Checked = false;
            };

            includeSaltPepper.Click += (s, e) =>
            {
                includeSaltPepper.Checked = !includeSaltPepper.Checked;
                Settings.OutputStyleIncludeSaltPepper = !Settings.OutputStyleIncludeSaltPepper;
                Settings.SaveSettings();

                //Include All check
                if (Settings.OutputStyleIncludeOriginalString &&
                 Settings.OutputStyleIncludeNumberOfHash &&
                 Settings.OutputStyleIncludeHashAlgorithm &&
                 Settings.OutputStyleIncludeSaltPepper)
                {
                    includeAll.Checked = true;
                }
                else includeAll.Checked = false;
            };

            includeAll.Click += (s, e) =>
            {
                bool isAllChecked = Settings.OutputStyleIncludeOriginalString &&
                                                Settings.OutputStyleIncludeNumberOfHash &&
                                                Settings.OutputStyleIncludeHashAlgorithm &&
                                                Settings.OutputStyleIncludeSaltPepper;
                includeAll.Checked = !isAllChecked;
                includeAlgorithm.Checked = !isAllChecked;
                includeNumber.Checked = !isAllChecked;
                includeOriginal.Checked = !isAllChecked;
                includeSaltPepper.Checked = !isAllChecked;
                Settings.OutputStyleIncludeOriginalString = !isAllChecked;
                Settings.OutputStyleIncludeNumberOfHash = !isAllChecked;
                Settings.OutputStyleIncludeHashAlgorithm = !isAllChecked;
                Settings.OutputStyleIncludeSaltPepper = !isAllChecked;
                Settings.SaveSettings();
            };

            #endregion

            //Add sub-menus to menu
            options.DropDownItems.Add(visualMode);
            options.DropDownItems.Add(outputType);
            options.DropDownItems.Add(outputStyle);

            //Needs a set up logic for first load
            UpdateOptionsMenu(
                    systemMode, lightMode, darkMode,
                    listBox, txtFile, messageBox,
                    includeOriginal, includeNumber, includeAlgorithm, includeSaltPepper, includeAll
                );

            //Refreshes the options menu automatically when the menu is clicked on
            options.Click += (s, e) => 
            {
                UpdateOptionsMenu(
                    systemMode, lightMode, darkMode,
                    listBox, txtFile, messageBox,
                    includeOriginal, includeNumber, includeAlgorithm, includeSaltPepper, includeAll
                );
            };
            #endregion

            #region Languages

            //Create Items
            var languages = new ToolStripMenuItem(Languages.Translate(Languages.L.Languages));
            List<ToolStripMenuItem> langItems = new List<ToolStripMenuItem>();
            foreach (string lang in Languages.AllLanguages())
            {
                string currentForEachLang = lang; //Apparently Lambda doesnt like foreaches or something (Always loads the last foreach lang)
                ToolStripMenuItem tempItem = new ToolStripMenuItem(currentForEachLang);

                //Start-Up Check
                langItems.Add(tempItem);
                //Console.WriteLine("Created item in language tool strip named: " + tempItem.Text);
                if (Settings.SelectedLanguage == tempItem.Text)
                {
                    tempItem.Checked = true;
                }

                //Click logic
                tempItem.Click += (s, e) =>
                {
                    if (Settings.SelectedLanguage == tempItem.Text)
                    {
                        Console.WriteLine("Skipped: " + tempItem.Text);
                        return; //no need to reload all text when its the same
                    }

                    Console.WriteLine("Loading language: " + tempItem.Text);
                    if (!Languages.LoadDictionary(tempItem.Text))
                    {
                        Console.WriteLine("!WARNING! Could not load language: " + tempItem.Text);
                        return; //Load Dictionary failed
                    }
                    Console.WriteLine("Loading completed.");

                    Settings.SelectedLanguage = tempItem.Text;
                    //Console.WriteLine("Settings.SelectedLanguage: " + Settings.SelectedLanguage);
                    FormManagement.ReloadAllForms(false, false, true);

                    foreach (ToolStripMenuItem item in languages.DropDownItems)
                    {
                        item.Checked = false;
                    }
                    tempItem.Checked = true;

                };

                //Add Lang Item into Sub-menu
                languages.DropDownItems.Add(tempItem);
            }

            #endregion

            //Add all menus into the stripmenu
            menu.Items.Add(hashing);
            menu.Items.Add(options);
            menu.Items.Add(languages);

            //Add strip menu to form
            form.MainMenuStrip = menu;
            form.Controls.Add(menu);

            //Menu background
            FormManagement.SetUpFormTheme(form); //I am no longer making this optimized, I am simply too tired to care
        }

        public static void ReloadStripMenu(Form form)
        {
            RemoveStripMenu(form);
            LoadStripMenu(form);
        }

        private static void RemoveStripMenu(Form form)
        {
            foreach (Control c in form.Controls)
            {
                if (c is MenuStrip)
                {
                    form.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }
        }

        private static void UpdateVisualModeSubMenu(ToolStripMenuItem systemMode, ToolStripMenuItem lightMode, ToolStripMenuItem darkMode)
        {
            systemMode.Checked = false;
            lightMode.Checked = false;
            darkMode.Checked = false;
            switch (Settings.VisualMode)
            {
                case VisualModeEnum.System:
                    {
                        systemMode.Checked = true;
                        break;
                    }
                case VisualModeEnum.Dark:
                    {
                        darkMode.Checked = true;
                        break;
                    }
                case VisualModeEnum.Light:
                    {
                        lightMode.Checked = true;
                        break;
                    }
            }
        }

        private static void UpdateOutputSubMenu(ToolStripMenuItem listBox, ToolStripMenuItem txtFile, ToolStripMenuItem messageBox)
        {
            listBox.Checked = false;
            txtFile.Checked = false;
            messageBox.Checked = false;
            switch (Settings.OutputType)
            {
                case OutputTypeEnum.MessageBox:
                    {
                        messageBox.Checked = true; break;
                    }
                case OutputTypeEnum.Listbox:
                    {
                        listBox.Checked = true; break;
                    }
                case OutputTypeEnum.TXTFile:
                    {
                        txtFile.Checked = true; break;
                    }
            }
        }

        private static void UpdateOutputStyleSubMenu(ToolStripMenuItem includeOriginal, ToolStripMenuItem includeNumber, ToolStripMenuItem includeAlgorithm, ToolStripMenuItem includeSaltPepper, ToolStripMenuItem includeAll)
        {
            //StartUp Logic
            if (Settings.OutputStyleIncludeOriginalString &&
                 Settings.OutputStyleIncludeNumberOfHash &&
                 Settings.OutputStyleIncludeHashAlgorithm &&
                 Settings.OutputStyleIncludeSaltPepper)
            {
                includeOriginal.Checked = true;
                includeNumber.Checked = true;
                includeAlgorithm.Checked = true;
                includeSaltPepper.Checked = true;
                includeAll.Checked = true;
            }
            else
            {
                if (Settings.OutputStyleIncludeOriginalString) includeOriginal.Checked = true;
                else includeOriginal.Checked = false;

                if (Settings.OutputStyleIncludeNumberOfHash) includeNumber.Checked = true;
                else includeNumber.Checked = false;

                if (Settings.OutputStyleIncludeHashAlgorithm) includeAlgorithm.Checked = true;
                else includeAlgorithm.Checked = false;

                if (Settings.OutputStyleIncludeSaltPepper) includeSaltPepper.Checked = true;
                else includeSaltPepper.Checked = false;
            }
        }

        public static void UpdateOptionsMenu(
                    ToolStripMenuItem systemMode, ToolStripMenuItem lightMode, ToolStripMenuItem darkMode,
                    ToolStripMenuItem listBox, ToolStripMenuItem txtFile, ToolStripMenuItem messageBox,
                    ToolStripMenuItem includeOriginal, ToolStripMenuItem includeNumber, ToolStripMenuItem includeAlgorithm,
                    ToolStripMenuItem includeSaltPepper, ToolStripMenuItem includeAll)
        {
            UpdateVisualModeSubMenu(systemMode, lightMode, darkMode);
            UpdateOutputSubMenu(listBox, txtFile, messageBox);
            UpdateOutputStyleSubMenu(includeOriginal, includeNumber, includeAlgorithm, includeSaltPepper, includeAll);
        }
    }

}
