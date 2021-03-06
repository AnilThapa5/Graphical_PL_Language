﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graphical_PL_Language
{
    /// <summary>
    /// validation class 
    /// this class contains all the validation checked of programs
    /// </summary>
    public class GPLValidations
    {
       
        private Boolean isCmdValid = true;
        /// <summary>
        /// gets the value of IsCmdValid
        /// returns the result value 
        /// </summary>
        public bool IsCmdValid { get => isCmdValid; set => isCmdValid = value; }

        private Boolean isSyntaxValid = true;
        /// <summary>
        /// get the value of syntax and return 
        /// </summary>
        public bool IsSyntaxValid { get => isSyntaxValid; set => isSyntaxValid = value; }
        private Boolean isParameterValid = true;
        /// <summary>
        /// get the value of parameter and return valid 
        /// </summary>
        public bool IsParameterValid { get => isParameterValid; set => isParameterValid = value; }
       
        private Boolean isSomethingInvalid = false;
        /// <summary>
        /// get the syntax and return if something missing
        /// </summary>
        public bool IsSomethingInvalid { get => isSomethingInvalid; set => isSomethingInvalid = value; }

        private int LineNumber = 0;
       
        private Boolean doesCmdHasLoop = false;

        private Boolean doesCmdHasEndLoop = false;

        private Boolean doesCmdHasIf = false;

        private Boolean doesCmdHasEndIf = false;

        private int endIfLineNo = 0;
        private int loopLineNo;
        private int endLoopLineNo;
        private int ifLineNo;
        /// <summary>
        /// get the line number and return
        /// </summary>
        public int lineNumber { get => lineNumber; set => lineNumber = value; }
        /// <summary>
        /// get if syntax contains loop
        /// </summary>
        public bool DoesCmdHasLoop { get => doesCmdHasLoop; set => doesCmdHasLoop = value; }
        /// <summary>
        /// get if syntax closed with end loop
        /// if the loop has been used
        /// </summary>
        public bool DoesCmdHasEndLoop { get => doesCmdHasEndLoop; set => doesCmdHasEndLoop = value; }
        /// <summary>
        /// check if the command has if condition
        /// </summary>
        public bool DoesCmdHasIf { get => doesCmdHasIf; set => doesCmdHasIf = value; }
        /// <summary>
        /// get the command and return the value of end if
        /// </summary>
        public bool DoesCmdHasEndif { get => doesCmdHasEndIf; set => doesCmdHasEndIf = value; }
        /// <summary>
        /// get the value and return the loop 
        /// </summary>
        public int LoopLineNo { get => loopLineNo; set => loopLineNo = value; }
        /// <summary>
        /// check the command if loop is 
        /// encloused with end loop
        /// </summary>
        public int EndLoopLineNo { get => endLoopLineNo; set => endLoopLineNo = value; }
        /// <summary>
        /// ge the line no
        /// return line number
        /// </summary>
        public int IfLineNo { get => ifLineNo; set => ifLineNo = value; }
        /// <summary>
        /// check the command consist of end if
        /// </summary>
        public int EndIfLineNo { get => endIfLineNo; set => endIfLineNo = value; }

        TextBox textCmd;
        /// <summary>
        /// checking every validation
        /// and return the result
        /// </summary>
        /// <param name="textCmd"></param>
        public GPLValidations(TextBox textCmd)
        {
            this.textCmd = textCmd;
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
                            isCmdValid = true;
                        }
                       
                    }

                }
                CheckCmdLoopAndIfValidation();
                if (!isCmdValid)
                {
                    isSomethingInvalid = true;
                }
            }
        }
        /// <summary>
        /// checking every command that entered
        /// and returning the value as per it
        /// </summary>
        /// <param name="cmd"></param>
        public void CheckCmdLineValidation(string cmd)
        {
            String[] syntaxs = { "drawto", "moveto", "run", "clear", "reset", "loop", "endloop", "if", "endif" };
            String[] shapes = { "circle", "rectangle", "triangle" };
            String[] variables = { "radius", "width", "height", "hypotenuse","counter" };
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

              

                else if (firstWord.Equals("loop"))
                {
                    if (commandsAfterSpliting.Length == 2)
                    {
                        if (!commandsAfterSpliting[1].Trim().All(char.IsDigit))
                        {
                            IsCmdValid = false;
                        }
                    }
                    else
                    {
                        IsCmdValid = false;
                    }
                }
                else if (firstWord.Equals("endloop"))
                {
                    if (commandsAfterSpliting.Length == 1)
                    {
                        if (!commandsAfterSpliting[0].Equals("endloop"))
                        {
                            IsCmdValid = false;
                        }
                    }
                    else
                    {
                        IsCmdValid = false;
                    }
                }//endif
                else if (firstWord.Equals("if"))//if radius = x then
                {
                    if (commandsAfterSpliting.Length == 5)
                    {
                        if (variables.Contains(commandsAfterSpliting[1].ToLower()))
                        {
                            if (commandsAfterSpliting[2].Equals("="))
                            {
                                if (commandsAfterSpliting[3].Trim().All(char.IsDigit))
                                {
                                    if (!commandsAfterSpliting[4].ToLower().Equals("then"))
                                    {
                                        IsCmdValid = false;
                                    }
                                }
                                else { IsCmdValid = false; }

                            }
                            else { IsCmdValid = false; }
                        }
                        else { IsCmdValid = false; }

                    }
                    else { IsCmdValid = false; }

                }
                else if (firstWord.Equals("endif"))
                {
                    if (commandsAfterSpliting.Length != 1)
                    {
                        IsCmdValid = false;
                    }
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
                        if (commandsAfterSpliting[1].Trim().All(char.IsDigit))
                        {
                        }
                        else if (commandsAfterSpliting[1].Trim().All(char.IsLetter))
                        {
                            if (variables.Contains(commandsAfterSpliting[1].ToLower())) 
                            {
                                checkIfVariableDefined(commandsAfterSpliting[1]);
                            }
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
                            if (parms[i].All(char.IsDigit))
                            {
                            }
                            else if (parms[i].All(char.IsLetter))
                            {
                                if (variables.Contains(parms[i].ToLower()))
                                {
                                    checkIfVariableDefined(parms[i]);
                                }
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
                            if (parms[i].All(char.IsDigit))
                            {
                            }
                            else if (parms[i].All(char.IsLetter))
                            {
                                if (variables.Contains(parms[i].ToLower()))
                                {
                                    checkIfVariableDefined(parms[i]);
                                }
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

        /// <summary>
        /// checking command for loop and if 
        /// returns the value as per the command entered
        /// </summary>

        public void CheckCmdLoopAndIfValidation()
        {
            int numberOfLines = textCmd.Lines.Length;
            for (int i = 0; i < numberOfLines; i++)
            {
                String singleLineCmd = textCmd.Lines[i];
                singleLineCmd = singleLineCmd.Trim();
                if (!singleLineCmd.Equals(""))
                {
                    doesCmdHasLoop = Regex.IsMatch(singleLineCmd.ToLower(), @"\bloop\b");
                    if (doesCmdHasLoop)
                    {
                        loopLineNo = (i + 1);
                    }
                   doesCmdHasEndLoop = singleLineCmd.ToLower().Contains("endloop");
                    if (doesCmdHasEndLoop)
                    {
                        endLoopLineNo = (i + 1);
                    }
                    doesCmdHasIf = Regex.IsMatch(singleLineCmd.ToLower(), @"\bif\b");
                    if (doesCmdHasIf)
                    {
                        ifLineNo = (i + 1);
                    }
                    doesCmdHasEndIf = singleLineCmd.ToLower().Contains("endif");
                    if (doesCmdHasEndIf)
                    {
                        endIfLineNo = (i + 1);
                    }
                }
            }
            if (loopLineNo > 0)
            {
                doesCmdHasLoop = true;
            }
            if (endLoopLineNo > 0)
            {
                doesCmdHasLoop= true;
            }
            if (ifLineNo > 0)
            {
                doesCmdHasIf = true;
            }
            if (endIfLineNo > 0)
            {
                doesCmdHasEndIf = true;
            }

            if (doesCmdHasLoop)
            {
                if (doesCmdHasEndLoop)
                {
                    if (loopLineNo < endLoopLineNo)
                    {

                    }

                    else
                    {
                        IsCmdValid = false;
                        MessageBox.Show("EndLoop must be after loop start");
                    }

                }
                else
                {
                    IsCmdValid = false;
                    MessageBox.Show("Loop Not Ended with 'ENDLOOP'");
                }
            }
            if (doesCmdHasIf)
            {
                if (doesCmdHasIf)
                {
                    if (ifLineNo < endIfLineNo)
                    {

                    }

                    else
                    {
                        IsCmdValid = false;
                        MessageBox.Show("'ENDIF' must be after IF");
                    }
                }
                else
                {
                    IsCmdValid = false;
                    MessageBox.Show("IF Must Ended with 'ENDIF'");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        public void checkIfVariableDefined(string variable)
        {
            Boolean isvariablefound = false;
            if (textCmd.Lines.Length > 1)
            {
                if (lineNumber > 0)
                {
                    for (int i = 0; i < lineNumber; i++)
                    {
                        String oneLineCommand = textCmd.Lines[i];
                        oneLineCommand = oneLineCommand.Trim();
                        if (!oneLineCommand.Equals(""))
                        {
                            Boolean isVariableDefined = oneLineCommand.ToLower().Contains(variable.ToLower());
                            if (isVariableDefined)
                            {
                                isvariablefound = true;
                            }
                        }

                    }
                    if (!isvariablefound)
                    {
                        MessageBox.Show("Variable is not defined");
                        IsCmdValid = false;
                    }
                }
                else
                {
                    MessageBox.Show("Variable is not defined");
                    IsCmdValid = false;
                }

            }
            else
            {
                MessageBox.Show("Variable is not defined");
                IsCmdValid = false;
            }
        }
    }
}
    


