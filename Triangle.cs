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
    /// triangle class inheritage the shapes
    /// </summary>
    public class Triangle : Shapes
    {
        private float heig;
        private float wid;
        private float hype;

        /// <summary>
        /// passing the parameters
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <param name="hypotenous"></param>
        public void getvalue(float width, float height, float radius, float hypotenous)

        {
            heig = height;
            wid = width;
            hype = hypotenous;

        }

        /// <summary>
        /// implement the triangle validation
        /// </summary>
        /// <returns></returns>
        public Boolean checkTriangleValidity()
        {
            // check condition 
            if (wid + heig <= hype || wid + hype <= heig || heig + hype <= wid)
               
                return false;
            else
                return true;
        }

        /// <summary>
        /// draw function for triangle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void draw(Graphics g, int x, int y)
        {
            if (checkTriangleValidity())
            {
                Pen mpen = new Pen(Color.Yellow, 5);
                Point[] p = new Point[3];

                p[0].X = x;
                p[0].Y = y;

                p[1].X = Convert.ToInt32(x - wid);
                p[1].Y = y;

                p[2].X = x;
                p[2].Y = Convert.ToInt32(y - heig);
                g.DrawPolygon(mpen, p);
            }
        }
    }
}
