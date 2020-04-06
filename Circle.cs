using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Graphical_PL_Language
{
    /// <summary>
    /// circle class inheritage shapes class
    /// </summary>
    public class Circle : Shapes
    {

        private float rad;

        /// <summary>
        /// paremeters pass
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <param name="hypotenous"></param>
        public void getvalue(float width, float height, float radius, float hypotenous)
        {

            rad = radius;


        }
        

        /// <summary>
        /// implement the draw function
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
       public void draw(Graphics g, int x, int y)
        {
            g.DrawEllipse(new Pen(Color.Yellow, 5), x, y, rad, rad);

        }

    }
}
