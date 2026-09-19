using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HashTester
{
    public class FontScaling
    {
        private Form form;
        private Size baseFormSize;
        private Dictionary<Control, Font> baseFonts = new Dictionary<Control, Font>();

        public FontScaling(Form form)
        {
            this.form = form;
            baseFormSize = form.Size;
            form.AutoScaleMode = AutoScaleMode.None; //For correct font scaling
            form.SizeChanged += (s, e) => FontScaler();
            // Save the original fonts for all controls
            SaveBaseFonts(form);
        }

        // Call this on resize
        public void FontScaler()
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
    }
}