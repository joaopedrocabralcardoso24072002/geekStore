using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geekStore
{
    internal class CustomColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder => Color.WhiteSmoke;
        public override Color MenuItemBorder => Color.WhiteSmoke;
        public override Color MenuItemSelected => Color.FromArgb(11, 11, 33);
        public override Color ToolStripDropDownBackground => Color.FromArgb(11, 11, 33);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(29, 108, 255);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(180, 40, 255);
    }
}
