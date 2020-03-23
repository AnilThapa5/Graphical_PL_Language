using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Graphical_PL_Language
{
    public class Rectangle : Shapes
    {

        private float wid;
        private float hig;
        public void getvalue(float width, float height, float radius, float hypotenous)

        {

            float wid = width;
            float hig = height;
          

        }
        public void draw(Graphics g, int x, int y)

        {

            Pen mpen = new Pen(Color.Yellow, 5);
            g.DrawRectangle(mpen, x, y, wid, hig);

        }
    }
}
