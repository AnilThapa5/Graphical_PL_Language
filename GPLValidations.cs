using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graphical_PL_Language
{
    
    public class GPLValidations
    {

            private Boolean isCmdValid = true;
            public bool IsCmdValid { get => isCmdValid; set => isCmdValid = value; }

            private Boolean isSyntaxValid = true;
            public bool IsSyntaxValid { get => isSyntaxValid; set => isSyntaxValid = value; }
            private Boolean isParameterValid = true;

            public bool IsParameterValid { get => isParameterValid; set => isParameterValid = value; }

            private Boolean isSomethingInvalid = false;
            public bool IsSomethingInvalid { get => isSomethingInvalid; set => isSomethingInvalid = value; }

            private int LineNumber = 0;
            public GPLValidations(TextBox textCmd)
            {
                int numberOfCmdLines = textCmd.Lines.Length;
                if (numberOfCmdLines == 0) { IsCmdValid = false; }
                else
                {
                    for (int i = 0; i < numberOfCmdLines; i++)
                    {
                        String singleLineCmd = textCmd.Lines[i];
                        singleLineCmd = singleLineCmd.Trim();
                        if (!singleLineCmd.Equals(""))
                        {
                            CheckCmdLineValidation(singleLineCmd);
                            LineNumber = (i + 1);
                            if (!IsCmdValid)
                            {
                                if (!IsParameterValid) { MessageBox.Show("Paramter errors at: " + LineNumber); }
                                else if (!IsSyntaxValid) { MessageBox.Show("Syntax errors at: " + LineNumber); }
                                else { MessageBox.Show("Syntax error at: " + LineNumber); }
                                IsSomethingInvalid = true;
                            }
                            else
                            {

                            }
                        }

                    }
                }
            }
            public void CheckCmdLineValidation(string cmd)
            {
                String[] syntaxs = { "drawto", "moveto", "run","clear","reset" };
                String[] shapes = { "circle", "rectangle", "triangle" };
                String[] variables = { "radius", "width", "height", "hypotenuse" };
                cmd = Regex.Replace(cmd, @"\s+", " ");
                string[] commandsAfterSpliting = cmd.Split(' ');
                for (int i = 0; i < commandsAfterSpliting.Length; i++)
                {
                    commandsAfterSpliting[i] = commandsAfterSpliting[i].Trim();
                }
                String firstWord = commandsAfterSpliting[0].ToLower();
                Boolean firstWordIsSyntax = syntaxs.Contains(firstWord);
                Boolean firstWordIsShape = shapes.Contains(firstWord);
                Boolean firstWordIsVariable = variables.Contains(firstWord);

            if (firstWordIsSyntax)
            {
                if (firstWord.Equals("drawto") || firstWord.Equals("moveto"))
                {
                    String args = cmd.Substring(6, (cmd.Length - 6));
                    String[] parms = args.Split(',');

                    if (parms.Length == 2)
                    {
                        for (int i = 0; i < parms.Length; i++)
                        {
                            if (!parms[i].Trim().All(char.IsDigit))
                            {
                                IsCmdValid = false;
                            }
                        }
                    }
                    else
                    {
                        IsCmdValid = false;
                    }
                }
                else if (firstWord.Equals("clear") || firstWord.Equals("reset"))
                {
                    IsCmdValid = true;
                }
            


            else if (firstWord.Equals("run"))
            {
                if (commandsAfterSpliting.Length != 1)
                {
                    IsCmdValid = false;
                }
            }
                }
                else if (firstWordIsShape)
                {
                    if (firstWord.ToLower().Equals("circle"))
                    {
                        if (commandsAfterSpliting.Length == 2)
                        {
                            if (commandsAfterSpliting[1].Trim().All(char.IsDigit)) { }
                            else if (commandsAfterSpliting[1].Trim().All(char.IsLetter))
                            {
                                if (variables.Contains(commandsAfterSpliting[1].ToLower())) { }
                                else { IsCmdValid = false; IsParameterValid = false; }
                            }
                            else { IsCmdValid = false; IsParameterValid = false; }
                        }
                        else { IsCmdValid = false; IsParameterValid = false; }
                    }
    
                    else if (firstWord.ToLower().Equals("rectangle"))
                    {
                        String args = cmd.Substring(9, (cmd.Length - 9));
                        String[] parms = args.Split(',');

                        if (parms.Length == 2)
                        {
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                                if (parms[i].All(char.IsDigit)) { }
                                else if (parms[i].All(char.IsLetter))
                                {
                                    if (variables.Contains(parms[i].ToLower())) { }
                                    else { IsCmdValid = false; IsParameterValid = false; }
                                }
                                else { IsCmdValid = false; IsParameterValid = false; }

                            }
                        }
                        else { IsCmdValid = false; IsParameterValid = false; }
                    }
                    else if (firstWord.ToLower().Equals("triangle"))
                    {
                        String args = cmd.Substring(8, (cmd.Length - 8));
                        String[] parms = args.Split(',');

                        if (parms.Length == 3)
                        {
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                                if (parms[i].All(char.IsDigit)) { }
                                else if (parms[i].All(char.IsLetter))
                                {
                                    if (variables.Contains(parms[i].ToLower())) { }
                                    else { IsCmdValid = false; IsParameterValid = false; }
                                }
                                else { IsCmdValid = false; IsParameterValid = false; }
                            }
                        }
                        else { IsCmdValid = false; IsParameterValid = false; }
                    }
                }
                else if (firstWordIsVariable) // radius = 6;
                {
                    if (commandsAfterSpliting.Length == 3)
                    {
                        if (commandsAfterSpliting[1].Equals("="))
                        {
                            if (!commandsAfterSpliting[2].Trim().All(char.IsDigit)) { IsCmdValid = false; IsParameterValid = false; }
                        }
                        else { IsCmdValid = false; }
                    }
                    else { IsCmdValid = false; }
                }
                else { IsCmdValid = false; IsSyntaxValid = false; }
                if (!IsCmdValid) { IsSomethingInvalid = true; }

            }
        }
    }


