/**
 *@author: Kamil Franek
 *@date: 23.09.2026
 *@brief: Script for scaling font based on starting size
 *@file: FontScaling.cs
 */

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

        /// <summary>
        /// Constructor for script with Form, Constructor is needed
        /// </summary>
        /// <param name="form">What form to scale</param>
        public FontScaling(Form form)
        {
            this.form = form;
            baseFormSize = form.Size;
            form.AutoScaleMode = AutoScaleMode.None; //For correct font scaling
            form.SizeChanged += (s, e) => FontScaler();
            // Save the original fonts for all controls
            SaveBaseFonts(form);
        }

        /// <summary>
        /// Scales the scale of the font (call on every change)
        /// </summary>
        public void FontScaler()
        {
            float scaleX = (float)form.Width / baseFormSize.Width;
            float scaleY = (float)form.Height / baseFormSize.Height;
            float scale = Math.Min(scaleX, scaleY);

            ScaleFontsRecursively(form, scale);
        }

        /// <summary>
        /// Saves first font size to the dictionary. Run on form creation
        /// </summary>
        /// <param name="control"></param>
        private void SaveBaseFonts(Control control)
        {
            if (control == null) return;

            baseFonts[control] = control.Font;

            foreach (Control c in control.Controls)
            {
                SaveBaseFonts(c);
            }
        }

        /// <summary>
        /// Recursively sets up font, ignores comboBox
        /// </summary>
        /// <param name="control"></param>
        /// <param name="scale"></param>
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