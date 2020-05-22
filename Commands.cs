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

       // float angle;
        int mouseX;
        int mouseY;
        int x_axis;
        int y_axis;

        public int radius = 0;
        /// <summary>
        /// Global variable. 
        /// </summary>
        public int width = 0;
       
        public int height = 0;
       
        public int hypotenus = 0;
      
        public int counter = 0;
       
        public int loopnumber = 0;
       
        public int dsize = 0;

        TextBox textBox;
        Panel pan;
        Graphics g;


        string[] commands = { "moveto", "drawto","clear","reset", "loop", "endloop", "if", "endif" };
        string[] shapes = { "rectangle", "circle", "triangle" };
        string[] variables = { "width", "height", "hypotenus", "radius","counter","size" };


        public void loadCommand(TextBox textBoxCmd, Graphics graph, Panel panelDraw)
        {
            this.textBox = textBoxCmd;
            this.pan = panelDraw;
            this.g = graph;

            int numberOfLines = textBoxCmd.Lines.Length;
            for (loopnumber = 0; loopnumber < numberOfLines; loopnumber++)
            {
                String oneLineCommand = textBoxCmd.Lines[loopnumber];
                oneLineCommand = oneLineCommand.Trim();
                if (!oneLineCommand.Equals(""))
                {
                    RunCommand(oneLineCommand);
                }
            }
        }
        /// <summary>
        /// function for running loop statement commands.
        /// </summary>
        /// <param name="singleLineCommand"></param>
        private void RunCommand(String singleLineCommand)
        {
            FactoryShapes sf = new FactoryShapes();
            Boolean hasEquals = singleLineCommand.Contains("=");
            Boolean hasplus = singleLineCommand.Contains("+");
            singleLineCommand = Regex.Replace(singleLineCommand, @"\s+", " ");
            if (hasEquals)
            {
                string[] words = singleLineCommand.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].Trim();
                }
                String firstWord = words[0].ToLower();
                if (firstWord.Equals("if"))
                {
                    Boolean loop = false;
                    if (words[1].ToLower().Equals("radius"))
                    {
                        if (radius == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("width"))
                    {
                        if (width == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("height"))
                    {
                        if (height == int.Parse(words[3]))
                        {
                            loop = true;
                        }

                    }
                    else if (words[1].ToLower().Equals("hypotenus"))
                    {
                        if (hypotenus == int.Parse(words[3]))
                        {
                            loop = true;
                        }

                    }
                    else if (words[1].ToLower().Equals("counter"))
                    {
                        if (counter == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (GetIfStartLineNumber()); 
                    int ifEndLine = (GetEndifEndLineNumber() - 1);
                    loopnumber = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            string oneLineCommand1 = textBox.Lines[j];
                            oneLineCommand1 = oneLineCommand1.Trim();
                            if (!oneLineCommand1.Equals(""))
                            {
                                RunCommand(oneLineCommand1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("If Statement is false");
                    }
                }
                else
                {
                    string[] words2 = singleLineCommand.Split('=');
                    for (int j = 0; j < words2.Length; j++)
                    {
                        words2[j] = words2[j].Trim();
                    }
                    if (words2[0].ToLower().Equals("radius"))
                    {
                        radius = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("width"))
                    {
                        width = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("height"))
                    {
                        height = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("hypotenus"))
                    {
                        hypotenus = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("counter"))
                    {
                        counter = int.Parse(words2[1]);
                    }
                }
            }
            else if (hasplus)
            {
                singleLineCommand = System.Text.RegularExpressions.Regex.Replace(singleLineCommand, @"\s+", " ");
                string[] words = singleLineCommand.Split(' ');
                if (words[0].ToLower().Equals("repeat"))
                {
                    counter = int.Parse(words[1]);
                    if (words[2].ToLower().Equals("circle"))
                    {
                        int increaseValue = GetSize(singleLineCommand);
                        radius = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            Shapes sh = sf.GetShapes("circle");
                            sh.getvalue(0, 0, 0, radius);
                            sh.draw(g, 0, 0);
                            radius += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("rectangle"))
                    {
                        int increaseValue = GetSize(singleLineCommand);
                        dsize = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            Shapes shc = sf.GetShapes("rectangle");
                            shc.getvalue(dsize, dsize, 0, 0);
                            shc.draw(g, 0, 0);
                            dsize += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("triangle"))
                    {
                        int increaseValue = GetSize(singleLineCommand);
                        dsize = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            Shapes shp = sf.GetShapes("triangle");
                            shp.getvalue(dsize, dsize, dsize, 0);
                            shp.draw(g, 0, 0);
                            dsize += increaseValue;
                        }
                    }

                }
                else
                {
                    string[] words2 = singleLineCommand.Split('+');
                    for (int j = 0; j < words2.Length; j++)
                    {
                        words2[j] = words2[j].Trim();
                    }
                    if (words2[0].ToLower().Equals("radius"))
                    {
                        radius += int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("width"))
                    {
                        width += int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("height"))
                    {
                        height += int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("hypotenus"))
                    {
                        hypotenus += int.Parse(words2[1]);
                    }
                }
            }
            else
            {
                pointmove(singleLineCommand);
            }
        }
       
        private int GetSize(string lineCommand)
        {
            int value = 0;
            if (lineCommand.ToLower().Contains("radius"))
            {
                int pos = (lineCommand.IndexOf("radius") + 6);
                int size = lineCommand.Length;
                String tempLine = lineCommand.Substring(pos, (size - pos));
                tempLine = tempLine.Trim();
                String newTempLine = tempLine.Substring(1, (tempLine.Length - 1));
                newTempLine = newTempLine.Trim();
                value = int.Parse(newTempLine);

            }
            else if (lineCommand.ToLower().Contains("size"))
            {
                int pos = (lineCommand.IndexOf("size") + 4);
                int size = lineCommand.Length;
                String tempLine = lineCommand.Substring(pos, (size - pos));
                tempLine = tempLine.Trim();
                String newTempLine = tempLine.Substring(1, (tempLine.Length - 1));
                newTempLine = newTempLine.Trim();
                value = int.Parse(newTempLine);
            }
            return value;
        }




        public void pointmove(string cmd)
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
                Boolean firstshape = shapes.Contains(firstleter);
                FactoryShapes fs = new FactoryShapes();
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
                  
                
               
                    else if (firstleter.ToLower().Equals("clear"))

                    {

                        pan.Refresh();
                    }

                    else if (firstleter.ToLower().Equals("reset"))
                    {
                        g.ResetTransform();
                    }

                    else if (firstleter.ToLower().Equals("loop"))
                    {
                        counter = int.Parse(words[1]);
                        int loopStartLine = (GetLoopStartLineNumber());
                        int loopEndLine = (GetLoopEndLineNumber() - 1);
                        loopnumber = loopEndLine;
                        for (int i = 0; i < counter; i++)
                        {
                            for (int j = loopStartLine; j <= loopEndLine; j++)
                            {
                                String oneLineCommand = textBox.Lines[j];
                                oneLineCommand = oneLineCommand.Trim();
                                if (!oneLineCommand.Equals(""))
                                {
                                    RunCommand(oneLineCommand);
                                }
                            }
                        }
                    }
                    else if (firstleter.ToLower().Equals("if"))
                    {
                        Boolean loop = false;
                        if (words[1].ToLower().Equals("radius"))
                        {
                            if (radius == int.Parse(words[1]))
                            {
                                loop = true;
                            }
                        }
                        else if (words[1].ToLower().Equals("width"))
                        {
                            if (width == int.Parse(words[1]))
                            {
                                loop = true;
                            }
                        }
                        else if (words[1].ToLower().Equals("height"))
                        {
                            if (height == int.Parse(words[1]))
                            {
                                loop = true;
                            }

                        }
                        else if (words[1].ToLower().Equals("hypotenus"))
                        {
                            if (hypotenus == int.Parse(words[1]))
                            {
                                loop = true;
                            }

                        }
                        else if (words[1].ToLower().Equals("counter"))
                        {
                            if (counter == int.Parse(words[1]))
                            {
                                loop = true;
                            }
                        }
                        int ifStartLine = (GetIfStartLineNumber());
                        int ifEndLine = (GetEndifEndLineNumber() - 1);
                        loopnumber = ifEndLine;
                        if (loop)
                        {
                            for (int j = ifStartLine; j <= ifEndLine; j++)
                            {
                                String oneLineCommand = textBox.Lines[j];
                                oneLineCommand = oneLineCommand.Trim();
                                if (!oneLineCommand.Equals(""))
                                {
                                    RunCommand(oneLineCommand);
                                }
                            }
                        }
                    }

                }
                else if (firstshape)
                {
                    FactoryShapes sf = new FactoryShapes();
                    if (firstleter.ToLower().Equals("circle"))
                    {
                        Boolean secondWordIsVariable = variables.Contains(words[1].ToLower());
                        if (secondWordIsVariable)
                        {
                            if (words[1].ToLower().Equals("radius"))
                            {
                                string args = cmd.Substring(6, (cmd.Length - 6));

                                Shapes sh = sf.GetShapes("circle");
                                sh.getvalue(0, 0, radius, 0);
                                sh.draw(g, 0, 0);
                            }
                        }
                        else
                        {
                            Shapes sh = sf.GetShapes("circle");
                            sh.getvalue(0, 0, float.Parse(words[1]), 0);
                            sh.draw(g, 0, 0);
                        }
                    }



                    else if (firstleter.ToLower().Equals("rectangle"))
                    {
                        String args = cmd.Substring(9, (cmd.Length - 9));
                        String[] parms = args.Split(',');
                        for (int i = 0; i < parms.Length; i++)
                        {
                            parms[i] = parms[i].Trim();
                        }

                        Boolean secondWordIsVariable = variables.Contains(parms[0].ToLower());
                        Boolean thirdWordIsVariable = variables.Contains(parms[1].ToLower());
                        if (secondWordIsVariable)
                        {
                            if (thirdWordIsVariable)
                            {
                                Shapes shc = sf.GetShapes("rectangle");
                                shc.getvalue(width, height, 0, 0);
                                shc.draw(g, 0, 0);
                            }
                            else
                            {
                                Shapes shc = sf.GetShapes("rectangle");
                                shc.getvalue(float.Parse(parms[0]), float.Parse(parms[1]), 0, 0);
                                shc.draw(g, 0, 0);
                            }
                        }
                        else
                        {
                            if (thirdWordIsVariable)
                            {

                                Shapes shc = sf.GetShapes("rectangle");
                                shc.getvalue(width, height, 0, 0);
                                shc.draw(g, 0, 0);
                            }
                            else
                            {
                                Shapes shc = sf.GetShapes("rectangle");
                                shc.getvalue(float.Parse(parms[0]), float.Parse(parms[1]), 0, 0);
                                shc.draw(g, 0, 0);
                            }
                        }

                    }


                    else if (firstleter.ToLower().Equals("triangle"))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetEndifEndLineNumber()
        {
            int numberOfLines = textBox.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = textBox.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (oneLineCommand.ToLower().Equals("endif"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;
        }

        private int GetIfStartLineNumber()
        {
            int numberOfLines = textBox.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = textBox.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');

                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = words[j].Trim();
                }
                String firstWord = words[0].ToLower();
                oneLineCommand = oneLineCommand.Trim();
                if (firstWord.ToLower().Equals("if"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;
        }

        private int GetLoopEndLineNumber()
        {
            int numberOfLines = textBox.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = textBox.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (oneLineCommand.ToLower().Equals("endloop"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;
        }

        private int GetLoopStartLineNumber()
        {
            int numberOfLines = textBox.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = textBox.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = words[j].Trim();
                }
                String firstWord = words[0].ToLower();
                oneLineCommand = oneLineCommand.Trim();
                if (firstWord.ToLower().Equals("loop"))
                {
                    lineNum = i + 1;
                }
            }
            return lineNum;
        }
    }



   }

    


