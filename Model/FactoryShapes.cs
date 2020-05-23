using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_PL_Language
{
   public class FactoryShapes
    {
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
