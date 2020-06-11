using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_PL_Language
{

    /// <summary>
    /// factory shape class 
    /// it contains the shapes and return the shapes
    /// </summary>
   public class FactoryShapes
    {
        /// <summary>
        /// method that return the string type parameter
        /// </summary>
        /// <param name="shapestypes"></param>
        /// <returns></returns>
        public Shapes GetShapes(string shapestypes)
        {
           

                if (shapestypes == null)
                {
                    return null;
                }
                if (shapestypes == ("Circle").ToLower())
                {
                    return new Circle();
                }
                if (shapestypes == ("Rectangle").ToLower())
                {
                    return new Rectangle();
                }
                if (shapestypes == ("Triangle").ToLower())
                {
                    return new Triangle();
                }
                return null;
           
        }
    }
}
