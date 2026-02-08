using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HashTester.Settings;

namespace HashTester
{
    public static class FormManagement
    {
        #region Private
        //private form setup
        private static FileChecksum form_fileChecksum;
        private static FormGradual form_gradual;
        private static HashingCollisionForm form_hashingCollision;
        private static PasswordForm form_passwordForm;
        private static SaltAndPepperTester form_saltAndPepperTester;
        private static SaltAndPepperSetup form_saltAndPepperSetup;
        private static ThreadsForm form_threadsForm;
        private static UIUpdateFrequency form_uiUpdateFrequency;
        private static MultipleHashing form_multipleHashing;

        #endregion

        #region GetSet

        public static FileChecksum Form_FileChecksum
        {
            get { return form_fileChecksum; }
            set { form_fileChecksum = value; }
        }

        public static FormGradual Form_Gradual
        {
            get { return form_gradual; }
            set { form_gradual = value; }
        }

        public static HashingCollisionForm Form_HashingCollision
        {
            get { return form_hashingCollision; }
            set { form_hashingCollision = value; }
        }

        public static PasswordForm Form_PasswordForm
        {
            get { return form_passwordForm; }
            set { form_passwordForm = value; }
        }

        public static SaltAndPepperTester Form_SaltAndPepperTester
        {
            get { return form_saltAndPepperTester; }
            set { form_saltAndPepperTester = value; }
        }

        public static SaltAndPepperSetup Form_SaltAndPepperSetup
        {
            get { return form_saltAndPepperSetup; }
            set { form_saltAndPepperSetup = value; }
        }

        public static ThreadsForm Form_ThreadsForm
        {
            get { return form_threadsForm; }
            set { form_threadsForm = value; }
        }

        public static UIUpdateFrequency Form_UIUpdateFrequency
        {
            get { return form_uiUpdateFrequency; }
            set { form_uiUpdateFrequency = value; }
        }

        public static MultipleHashing Form_MultipleHashing
        {
            get { return form_multipleHashing; }
            set { form_multipleHashing = value; }
        }

        public enum Forms
        {
            FileChecksum,
            Gradual,
            HashingCollision,
            PasswordForm,
            SaltAndPepper,
            SaltAndPepperTester,
            SaltAndPepperSetup,
            ThreadsForm,
            UIUpdateFrequency,
            MultipleHashing
        }

        public static DialogResult SpawnForm(Forms formType, bool modal = false)
        {
            Form form = null;


            switch (formType)
            {
                case Forms.FileChecksum:
                    if (Form_FileChecksum != null && !Form_FileChecksum.IsDisposed) return DialogResult.None;
                    Form_FileChecksum = new FileChecksum();
                    form = Form_FileChecksum;
                    break;

                case Forms.Gradual:
                    if (Form_Gradual != null && !Form_Gradual.IsDisposed) return DialogResult.None;
                    Form_Gradual = new FormGradual();
                    form = Form_Gradual;
                    break;

                case Forms.HashingCollision:
                    if (Form_HashingCollision != null && !Form_HashingCollision.IsDisposed) return DialogResult.None;
                    Form_HashingCollision = new HashingCollisionForm();
                    form = Form_HashingCollision;
                    break;

                case Forms.PasswordForm:
                    if (Form_PasswordForm != null && !Form_PasswordForm.IsDisposed) return DialogResult.None;
                    Form_PasswordForm = new PasswordForm();
                    form = Form_PasswordForm;
                    break;

                case Forms.SaltAndPepperTester:
                    if (Form_SaltAndPepperTester != null && !Form_SaltAndPepperTester.IsDisposed) return DialogResult.None;
                    Form_SaltAndPepperTester = new SaltAndPepperTester();
                    form = Form_SaltAndPepperTester;
                    break;

                case Forms.SaltAndPepperSetup:
                    if (Form_SaltAndPepperSetup != null && !Form_SaltAndPepperSetup.IsDisposed) return DialogResult.None;
                    Form_SaltAndPepperSetup = new SaltAndPepperSetup();
                    form = Form_SaltAndPepperSetup;
                    break;

                case Forms.ThreadsForm:
                    if (Form_ThreadsForm != null && !Form_ThreadsForm.IsDisposed) return DialogResult.None;
                    Form_ThreadsForm = new ThreadsForm();
                    form = Form_ThreadsForm;
                    break;

                case Forms.UIUpdateFrequency:
                    if (Form_UIUpdateFrequency != null && !Form_UIUpdateFrequency.IsDisposed) return DialogResult.None;
                    Form_UIUpdateFrequency = new UIUpdateFrequency();
                    form = Form_UIUpdateFrequency;
                    break;

                case Forms.MultipleHashing:
                    if (Form_MultipleHashing != null && !Form_MultipleHashing.IsDisposed) return DialogResult.None;
                    Form_MultipleHashing = new MultipleHashing();
                    form = Form_MultipleHashing;
                    break;
            }

            if (form == null) return DialogResult.None;
            form.StartPosition = FormStartPosition.CenterScreen;
            if (!modal)
            {
                form.Show();
                return DialogResult.None;
            }
            return form.ShowDialog();
        }



        #endregion

        #region Enum
        public enum FolderType
        {
            Base,
            Password,
            Collision,
            Log
        }
        #endregion

        #region

        #endregion

        public static void LoadForm(Form form)
        {
            if (form is Form1 form1) //If Loading main form (Form1)
            {
                //This sequence is VERY important
                Settings.InitialFolderChecker();
                Settings.LoadSettings();
                Languages.LoadDictionary(Settings.SelectedLanguage);                                
                form1.Name = Languages.Translate(Languages.L.Hashtester);
                Task.Run(async () =>
                {
                    await form1.CheckForUpdates();
                });
            }
            //Global form start
            StripMenu.LoadStripMenu(form);
            FormManagement.SetUpFormTheme(form);
        }

        /// <summary>
        /// Saves log from a listbox to a wanted .txt file
        /// </summary>
        /// <param name="listbox">Listbox you want to save from</param>
        /// <param name="form">In what form is the wanted listbox</param>
        public static void SaveLog(ListBox listbox, Form form)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Settings.DirectoryPathToLogs;
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "log.txt";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(Languages.Translate(Languages.L.LogSavedOn) + ": " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                    writer.WriteLine(Languages.Translate(Languages.L.LogSavedFrom) + ": " + form.Name);
                    foreach (string item in listbox.Items)
                    {
                        writer.WriteLine(item);
                    }
                }
                MessageBox.Show(Languages.Translate(Languages.L.LogSaveSuccessfully), Languages.Translate(Languages.L.Saved), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(Languages.Translate(Languages.L.LogSaveAbbandoned), Languages.Translate(Languages.L.Abandoned), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Returns number of threads to use from Settings. If multithreading is false, returns 1
        /// </summary>
        /// <returns></returns>
        public static int NumberOfThreadsToUse()
        {
            if (UseMultiThread()) return 1;
            int percentage = Settings.ThreadsUsagePercentage;
            if (percentage == 0) return 1; //Single Thread
            return (int)Math.Ceiling(percentage / 100.0 * Environment.ProcessorCount);
        }

        /// <summary>
        /// Returns if multithread should be used
        /// </summary>
        /// <returns></returns>
        public static bool UseMultiThread()
        {
            int percentage = Settings.ThreadsUsagePercentage;
            int threadsTemp = FormManagement.NumberOfThreadsToUse(); //There is no need to use multiThread if youre gonna just use 1 thread (smart I know)
            Console.WriteLine("FormManagement.NumberOfThreadsToUse(): " + FormManagement.NumberOfThreadsToUse());
            if (percentage == 0 || threadsTemp == 1)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Returns if light mode should be used (otherwise a dark mode will be used)
        /// </summary>
        /// <returns></returns>
        /// 

        #region FormTheme
        public static bool UseLightMode()
        {
            switch (Settings.VisualMode)
            {
                case Settings.VisualModeEnum.System: return RegistryUseLightMode();
                case Settings.VisualModeEnum.Light: return true;
                case Settings.VisualModeEnum.Dark: return false;
                default: return true;
            }
        }


        /// <summary>
        /// Checks registry if white mode (false means dark mode)
        /// </summary>
        /// <returns></returns>
        private static bool RegistryUseLightMode()
        {
            string registryKey = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            string valueName = "AppsUseLightTheme";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    object value = key.GetValue(valueName);
                    if (value is int intValue)
                    {
                        if (intValue == 1) return true;
                        else return false;
                    }
                }
            }
            Console.WriteLine("Couldnt find Registry for AppsUseLightTheme.");
            Console.WriteLine("Settings theme as light");
            return true;
        }

        /// <summary>
        /// Sets up dark/white mode for a form
        /// </summary>
        /// <param name="form"></param>
        public static void SetUpFormTheme(Form form)
        {
            Color controlColor;
            Color controlText;
            Color windows;
            Color windowsText;
            Color borderColor;
            bool lightMode = true;
            if (UseLightMode()) //Light Theme
            {
                controlColor = SystemColors.Control;
                controlText = SystemColors.ControlText;
                windows = SystemColors.Window;
                windowsText = SystemColors.WindowText;
                borderColor = SystemColors.ControlDarkDark;
            }
            else //Dark Theme
            {
                lightMode = false;
                controlColor = Color.FromArgb(45, 45, 48);
                controlText = Color.WhiteSmoke;
                windows = Color.FromArgb(30, 30, 30);
                windowsText = Color.WhiteSmoke;
                borderColor = SystemColors.ControlLight;
            }
            form.BackColor = controlColor;
            foreach (Control control in form.Controls)
            {
                if (control is Label || control is Button || control is CheckBox || control is RadioButton)
                {
                    control.BackColor = controlColor; //background
                    control.ForeColor = controlText; //text
                    if (control is Button button)
                    {
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 1;
                        button.FlatAppearance.BorderColor = borderColor;
                    }
                }
                else if (control is GroupBox box)
                {
                    box.BackColor = controlColor;
                    box.ForeColor = controlText;
                    foreach (Control child in box.Controls) //just apply for childs
                    {
                        child.BackColor = controlColor; //background
                        child.ForeColor = controlText; //text
                        if (child is Button button)
                        {
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderSize = 1;
                            button.FlatAppearance.BorderColor = borderColor;
                        }
                    }
                }
                else if (control is ProgressBar)
                {
                    control.BackColor = controlColor; //background
                    control.ForeColor = Color.Green; //text
                }
                else if (control is ToolStrip menuStrip)
                {
                    menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable(!lightMode));
                    ApplyThemeToMenu(menuStrip, controlColor, controlText);
                }
                else
                {
                    control.BackColor = windows; //background
                    control.ForeColor = windowsText; //text
                }
            }
        }

        /// <summary>
        /// Aplies white/dark theme to form
        /// </summary>
        /// <param name="menuStrip"></param>
        /// <param name="backColor"></param>
        /// <param name="textColor"></param>
        private static void ApplyThemeToMenu(ToolStrip menuStrip, Color backColor, Color textColor)
        {
            menuStrip.BackColor = backColor;
            menuStrip.ForeColor = textColor;

            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                ApplyThemeToMenuItem(menuItem, backColor, textColor); //Dont worry, it stops...one day
            }
        }

        /// <summary>
        /// Aplies white/dark theme to strip menu
        /// </summary>
        /// <param name="menuItem"></param>
        /// <param name="backColor"></param>
        /// <param name="textColor"></param>
        private static void ApplyThemeToMenuItem(ToolStripMenuItem menuItem, Color backColor, Color textColor)
        {
            menuItem.BackColor = backColor;
            menuItem.ForeColor = textColor;

            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    ApplyThemeToMenuItem(subMenuItem, backColor, textColor);
                }
            }
        }


        #endregion

        #region Converters

        /// <summary>
        /// Converts string to hex
        /// </summary>
        /// <param name="text">Input string</param>
        /// <returns></returns>
        public static string ConvertStringToHex(string text)
        {
            var hexBuilder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                hexBuilder.AppendFormat("{0:X2}", (int)text[i]);
            }
            return hexBuilder.ToString().ToLower();
        }

        #endregion

        #region Reloads

        /// <summary>
        /// Reloads all loaded forms languages
        /// </summary>
        public static void ReloadAllFormsLangugages()
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    ReloadFormLanguage(form);
                }
                Console.WriteLine("All Forms Text Reloaded Successfully");
            }
            catch
            {
                Console.WriteLine("ERROR: All Forms Text Reloaded Failed (FormManagement -> ReloadAllFormsLanguages)"); 
            }
        }

        /// <summary>
        /// Reloads one Form
        /// </summary>
        /// <param name="form"></param>
        public static void ReloadFormLanguage(Form form)
        {
            if (form == null || form.IsDisposed) return;

            form.SuspendLayout();

            ReloadControls(form);

            form.ResumeLayout(true);
            form.PerformLayout();
            form.Invalidate(true);
        }

        private static void ReloadControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                ReloadControl(c);
                if (c.HasChildren) ReloadControls(c);
            }
        }

        private static void ReloadControl(Control c)
        {
            switch (c)
            {
                case Button b:
                    b.Text = Languages.Translate(b.Text);
                    break;

                case Label l:
                    l.Text = Languages.Translate(l.Text);
                    break;

                case CheckBox cb:
                    cb.Text = Languages.Translate(cb.Text);
                    break;

                case RadioButton rb:
                    rb.Text = Languages.Translate(rb.Text);
                    break;

                case GroupBox gb:
                    gb.Text = Languages.Translate(gb.Text);
                    break;

                case ToolStrip ts:
                    ReloadToolStrip(ts);
                    break;
            }
        }

        private static void ReloadToolStrip(ToolStrip ts)
        {
            foreach (ToolStripItem item in ts.Items)
                ReloadToolStripItem(item);
        }

        private static void ReloadToolStripItem(ToolStripItem item)
        {
            item.Text = Languages.Translate(item.Text);

            if (item is ToolStripDropDownItem dd)
                foreach (ToolStripItem sub in dd.DropDownItems)
                    ReloadToolStripItem(sub);
        }

        #endregion
    }
}
