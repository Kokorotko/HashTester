using System.Drawing;
using System.Windows.Forms;

public class CustomColorTable : ProfessionalColorTable
{
    private readonly bool isDarkTheme;

    public CustomColorTable(bool isDarkTheme)
    {
        this.isDarkTheme = isDarkTheme;

    }
    public override Color MenuStripGradientBegin => isDarkTheme ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
    public override Color MenuStripGradientEnd => isDarkTheme ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
    public override Color ToolStripDropDownBackground => isDarkTheme ? Color.FromArgb(30, 30, 30) : SystemColors.ControlLightLight;
    public override Color MenuItemSelected => isDarkTheme ? Color.FromArgb(62, 62, 66) : SystemColors.GradientActiveCaption;
    public override Color MenuItemBorder => isDarkTheme ? Color.Gray : SystemColors.WindowFrame;
    public override Color MenuItemPressedGradientBegin => isDarkTheme ? Color.FromArgb(90, 90, 95) : SystemColors.GradientActiveCaption;
    public override Color MenuItemPressedGradientEnd => isDarkTheme ? Color.FromArgb(70, 70, 74) : SystemColors.GradientInactiveCaption;
    public override Color ImageMarginGradientBegin => isDarkTheme ? Color.FromArgb(37, 37, 38) : SystemColors.Control;
    public override Color ImageMarginGradientMiddle => isDarkTheme ? Color.FromArgb(37, 37, 38) : SystemColors.Control;
    public override Color ImageMarginGradientEnd => isDarkTheme ? Color.FromArgb(37, 37, 38) : SystemColors.Control;
    public override Color SeparatorDark => isDarkTheme ? Color.FromArgb(70, 70, 70) : SystemColors.ControlDark;
    public override Color SeparatorLight => isDarkTheme ? Color.FromArgb(70, 70, 70) : SystemColors.ControlLightLight;
    public override Color ToolStripBorder => isDarkTheme ? Color.FromArgb(30, 30, 30) : SystemColors.ControlDark;
    public override Color ToolStripGradientBegin => isDarkTheme ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
    public override Color ToolStripGradientMiddle => isDarkTheme ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
    public override Color ToolStripGradientEnd => isDarkTheme ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
    public override Color MenuBorder => isDarkTheme ? Color.FromArgb(30, 30, 30) : SystemColors.MenuBar;
    public override Color MenuItemSelectedGradientBegin => isDarkTheme ? Color.FromArgb(62, 62, 66) : SystemColors.GradientActiveCaption;
    public override Color MenuItemSelectedGradientEnd => isDarkTheme ? Color.FromArgb(62, 62, 66) : SystemColors.GradientActiveCaption;

    public override Color StatusStripGradientBegin => isDarkTheme ? Color.FromArgb(0, 122, 204) : SystemColors.Control;
    public override Color StatusStripGradientEnd => isDarkTheme ? Color.FromArgb(0, 122, 204) : SystemColors.Control;
    public override Color OverflowButtonGradientBegin => isDarkTheme ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
    public override Color OverflowButtonGradientMiddle => isDarkTheme ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
    public override Color OverflowButtonGradientEnd => isDarkTheme ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
    public override Color GripDark => isDarkTheme ? Color.FromArgb(80, 80, 80) : SystemColors.ControlDark;
    public override Color GripLight => isDarkTheme ? Color.FromArgb(50, 50, 50) : SystemColors.ControlLightLight;
}
