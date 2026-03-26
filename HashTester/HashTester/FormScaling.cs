using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HashTester
{
    public class FormScaling
    {
        private Form form;
        private Size baseFormSize;
        private Dictionary<Control, Font> baseFonts = new Dictionary<Control, Font>();
        private const int startingFontSize = 10; // Base font size for scaling reference

        public FormScaling(Form form)
        {
            this.form = form;
            baseFormSize = form.Size;

            // Save the original fonts for all controls
            SaveBaseFonts(form);
        }

        // Call this on resize
        public void FontScaling()
        {
            float scaleX = (float)form.Width / baseFormSize.Width;
            float scaleY = (float)form.Height / baseFormSize.Height;
            float scale = Math.Min(scaleX, scaleY);

            ScaleFontsRecursively(form, scale);
        }

        private void SaveBaseFonts(Control control)
        {
            if (control == null) return;

            baseFonts[control] = control.Font;

            foreach (Control c in control.Controls)
            {
                SaveBaseFonts(c);
            }
        }

        private void ScaleFontsRecursively(Control control, float scale)
        {
            if (control == null) return;
            if (control is ComboBox)
            {
                return; //Fuck comboBox scaling its ass on font bullshit
            }

            if (baseFonts.TryGetValue(control, out Font baseFont))
            {
                float newSize = baseFont.Size * scale;
                control.Font = new Font(baseFont.FontFamily, newSize, baseFont.Style);
            }

            foreach (Control c in control.Controls)
            {
                ScaleFontsRecursively(c, scale);
            }
        }

        public void FontSetup()
        {
            foreach (Control c in form.Controls)
            {
                FontSetupRecursively(c);
            }
        }

        private void FontSetupRecursively(Control control)
        {
            if (control == null) return;
            if (control is ComboBox) return; // Skip ComboBox to avoid vertical sizing issues
            // Set the base font for all controls to ensure consistent scaling
            control.Font = new Font(control.Font.FontFamily, startingFontSize, control.Font.Style);
            foreach (Control c in control.Controls)
            {
                FontSetupRecursively(c);
            }
        }
    }
}