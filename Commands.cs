using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;

namespace Graphical_PL_Language
{
    public class Commands
    {
       
        public int mouseX=0;
        public int mouseY=0;

        string[] commands = { "moveto", "drawto" };
        string[] shapes = { "rectangle", "circle", "triangle" };
        string[] variables = { "width", "height", "hypotenus", "radius" };


        public void pointmove(string cmd, Graphics g)
        {

            cmd = Regex.Replace(cmd, @"\s+", " ");
            string[] words = cmd.Split(' ');
            //remove the white spaces between words
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            String firstleter = words[0].ToLower();
            Boolean firstletercom = commands.Contains(firstleter);
            if (firstletercom)
            {
                if (firstleter == "moveto")
                {
                    String args = cmd.Substring(6, (cmd.Length - 6));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    mouseX = int.Parse(parms[0]);
                    mouseY = int.Parse(parms[1]);
                    g.TranslateTransform(mouseX, mouseY);
                }
            }

        }
    
        public void Execode(string cmd, Graphics g)

        {
            cmd = Regex.Replace(cmd, @"\s+", " ");
            string[] words = cmd.Split(' ');
            //removing white spaces in between words
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            String firstleter = words[0].ToLower();
            Boolean firstleterShape = shapes.Contains(firstleter);
            FactoryShapes sf = new FactoryShapes();

            if (firstleterShape)
            {
                if (firstleter == "circle")
                {
                    float secondletervariable = float.Parse(words[1]);
                    Shapes s = sf.GetShapes("circle");
                    s.getvalue(0, 0, 0, secondletervariable);
                    s.draw(g, 50, 50);
                }


                else if (firstleter == "rectangle")
                {
                    String args = cmd.Substring(9, (cmd.Length - 9));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }

                    float secondvariable = float.Parse(parms[0]);
                    float thirdvariable = float.Parse(parms[1]);

                    Shapes s = sf.GetShapes("rectangle");
                    s.getvalue(secondvariable, thirdvariable, 0, 0);
                    s.draw(g, 100, 100);
                }
                if (firstleter == "triangle")
                {
                    String args = cmd.Substring(8, (cmd.Length - 8));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    float sec = float.Parse(parms[0]);
                    float thi = float.Parse(parms[1]);
                    float four = float.Parse(parms[2]);

                    Shapes s = sf.GetShapes("triangle");
                    s.getvalue(sec, thi, four, 0);
                    s.draw(g, 100, 100);
                }
            }
        }
    }
   }

    


