using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Graphical_PL_Language
{
    public class Circle : Shapes
    {

        private float rad;
        public void getvalue(float width, float height, float radius, float hypotenous)
        {

            radius = rad;


        }

       public void draw(Graphics g, int x, int y)
        {
            g.DrawEllipse(new Pen(Color.Yellow, 5), x, y, rad, rad);

        }

    }
}
