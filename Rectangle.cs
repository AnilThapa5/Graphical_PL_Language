using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Graphical_PL_Language
{

    /// <summary>
    /// rectangle class 
    /// </summary>
    public class Rectangle:Shapes
    {

        private float wid;
        private float heig;

        /// <summary>
        /// parameter passed 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <param name="hypotenous"></param>
        public void getvalue(float width, float height, float radius, float hypotenous)

        {

             wid = width;
             heig = height;
          

        }

        /// <summary>
        /// implement the draw function
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void draw(Graphics g, int x, int y)

        {

            Pen mpen = new Pen(Color.Yellow, 5);
            g.DrawRectangle(mpen, x, y, wid, heig);

        }
    }
}
