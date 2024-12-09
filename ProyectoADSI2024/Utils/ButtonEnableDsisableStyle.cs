using System.Drawing;
using System.Windows.Forms;

public static class ButtonEnableDisableStyle
{
    public static void ApplyCustomDisabledStyle(object sender, PaintEventArgs e)
    {
        if (sender is Button btn && !btn.Enabled)
        {
            // Mantener el color de fondo actual del botón
            e.Graphics.Clear(btn.BackColor);

            // Dibujar el texto centrado en el botón con el color especificado
            TextRenderer.DrawText(
                e.Graphics,                       // Superficie de dibujo
                btn.Text,                         // Texto del botón
                btn.Font,                         // Fuente del texto
                btn.ClientRectangle,              // Área completa del botón
                btn.ForeColor,                    // Color del texto
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter  // Centramos el texto
            );
        }
    }

    public static void AttachPaintHandler(Button button)
    {
        button.Paint += ApplyCustomDisabledStyle;
    }
}