using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Graphical_PL_Language
{
    public class Commands: GPL_INTERFACE
    {

        float angle;
        int mouseX;
        int mouseY;
        int x_axis;
        int y_axis;

        string[] commands = { "moveto", "drawto","rotate" };
        string[] shapes = { "rectangle", "circle", "triangle" };
        //string[] variables = { "width", "height", "hypotenus", "radius" };


        public void pointmove(string cmd, Graphics g, Panel pan)
        {
            try
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
                Boolean firstshape = commands.Contains(firstleter);
            if (firstletercom)
            {
                if (firstleter.ToLower().Equals("moveto"))
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
                if (firstleter.ToLower().Equals("drawto"))
                {
                    String args = cmd.Substring(6, (cmd.Length - 6));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    x_axis = int.Parse(parms[0]);
                    y_axis = int.Parse(parms[1]);
                    g.TranslateTransform(x_axis, y_axis);
                }

                if(firstleter.ToLower().Equals("rotate"))
                    {
                        string args = cmd.Substring(6, (cmd.Length - 6));
                        string[] parms = args.Split(',');
                        for (int i = 0; i < parms.Length; i++)
                        {
                            parms[i] = parms[i].Trim();
                        }

                        angle = float.Parse(parms[0]);
                        g.RotateTransform(angle);


                    }

                else if(firstleter.ToLower().Equals("clear"))

                    {

                        pan.Refresh();
                    }

                else if(firstleter.ToLower().Equals("reset"))
                    {
                       g.ResetTransform();
                    }
                }

      
                Boolean firstleterShape = shapes.Contains(firstleter);
                FactoryShapes sf = new FactoryShapes();

                if (firstleterShape)
                {
                    if (firstleter.ToLower().Equals("circle"))
                    {
                        string args = cmd.Substring(6, (cmd.Length - 6));
                        string[] parms = args.Split(',');
                        for (int i = 0; i < parms.Length; i++)
                        {
                            parms[i] = parms[i].Trim();
                        }
                            float shapethree = float.Parse(words[1]);
                            Shapes s = sf.GetShapes("circle");
                            s.getvalue(0, 0, shapethree, 0);
                            s.draw(g, x_axis, y_axis);
                    }
                   


                    else if (firstleter.ToLower().Equals("rectangle")) 
                    {
                        String args = cmd.Substring(9, (cmd.Length - 9));
                        String[] parms = args.Split(',');
                        for (int i = 0; i < parms.Length; i++)
                        {
                            parms[i] = parms[i].Trim();
                        }

                        float shapef = float.Parse(parms[0]);
                        float shapes = float.Parse(parms[1]);


                        Shapes s = sf.GetShapes("rectangle");
                        s.getvalue(shapef, shapes, 0, 0);
                        s.draw(g, x_axis, y_axis);

                       
                    }
                  

                    if (firstleter.ToLower().Equals("triangle"))
                    {
                        String args = cmd.Substring(8, (cmd.Length - 8));
                        String[] parms = args.Split(',');
                        for (int i = 0; i < parms.Length; i++)
                        {
                            parms[i] = parms[i].Trim();
                        }
                        float first = float.Parse(parms[0]);
                        float second = float.Parse(parms[1]);
                        float third = float.Parse(parms[2]);

                        Shapes s = sf.GetShapes("triangle");
                        s.getvalue(first, second, 0, third);

                        s.draw(g, x_axis, y_axis);


                    }
                  
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
   }

    


