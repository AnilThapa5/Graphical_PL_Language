﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
	

namespace Graphical_PL_Language
{

    /// <summary>
    /// reflect the major class
    /// </summary>
    public interface Shapes
    {

        void draw(Graphics g, int x, int y);

        void getvalue(float width, float height, float radius, float hypotenous);
    }
    
}
