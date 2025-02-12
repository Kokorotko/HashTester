using System.Drawing;
using System.Windows.Forms;

public class CustomColorTable : ProfessionalColorTable
{
    private readonly bool isDarkTheme;

    public CustomColorTable(bool isDarkTheme)
    {
        this.isDarkTheme = isDarkTheme;
    }

    public override Color MenuStripGradientBegin
    {
        get
        {
            if (isDarkTheme) return Color.FromArgb(45, 45, 48); // Dark mode background                
            else return SystemColors.Control; // Default light mode background
        }
    }

    public override Color MenuStripGradientEnd
    {
        get
        {
            if (isDarkTheme) return Color.FromArgb(45, 45, 48);
            else return SystemColors.Control;
        }
    }

    public override Color ToolStripDropDownBackground
    {
        get
        {
            if (isDarkTheme) return Color.FromArgb(30, 30, 30); // Darker dropdown background                
            else return SystemColors.ControlLightLight;
        }
    }

    public override Color MenuItemSelected
    {
        get
        {
            if (isDarkTheme) return Color.FromArgb(30, 30, 30);
            else return SystemColors.GradientActiveCaption;
        }
    }

    public override Color MenuItemBorder
    {
        get
        {
            if (isDarkTheme) return Color.Gray;
            else return SystemColors.WindowFrame;
        }
    }

    public override Color MenuItemPressedGradientBegin
    {
        get
        {
            if (isDarkTheme) return Color.FromArgb(90, 90, 95); // Clicked item color               
            else return SystemColors.GradientActiveCaption;
        }
    }

    public override Color MenuItemPressedGradientEnd
    {
        get
        {
            if (isDarkTheme) return Color.FromArgb(70, 70, 74);
            else return SystemColors.GradientInactiveCaption;
        }
    }
}
