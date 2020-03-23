using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_PL_Language
{
    public class Commands
    {
        int x_axis;
        int y_axis;
        int mouseX;
        int mouseY;

        string[] cmd = { "moveto", "drawto" };
        string[] shapes = { "rectangle", "circle", "triangle" };
    }
}
