using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_PL_Language
{
    public partial class GPL_INTERFACE : Form
    {
        Graphics g;
        /// <summary>
        /// initialization of companent begin here
        /// </summary>
        public GPL_INTERFACE()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();

        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text != null && !textBox1.Text.Equals(""))
            {
                GPLValidations val = new GPLValidations(textBox1);
                if (!val.IsSomethingInvalid)
                {

                    try
                    {
                       
                        Commands c = new Commands();
                        c.loadCommand(textBox1,g,panel1);

                    }
                    catch (Exception ex)
                    {
                        textBox2.Text += "\r\n" + ex.ToString();
                    }
                }
                else if (!val.IsSyntaxValid)
                {
                    textBox2.Text += "\r\nCommand Errrs. ENTER LIKE eg: circle 50";
                }
                else if (!val.IsParameterValid)
                {
                    textBox2.Text += "\r\nParameter Error. ENTER LIKE eg: 20";
                }
            
            else
            {
                textBox2.Text += ("Somehing Went Wrong");
            }
        }
           else
        {
                textBox2.Text += ("Command Field Cannot Be Empty");
        }

    }
            
        

        private void btnreset_Click(object sender, EventArgs e)
        {
          
            textBox2.Text = "";
            panel1.Refresh();
            
            g.ResetTransform();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            panel1.Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog sdf = new SaveFileDialog();
                sdf.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
                if (sdf.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(File.Create(sdf.FileName));
                    writer.WriteLine(textBox1.Text);
                    writer.Close();
                    MessageBox.Show("File Saved Successfully");

                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Stream stream = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Browse Your File from Folder";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                
                if(openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    if((stream=openFileDialog.OpenFile()) !=null)
                    {
                        using (stream)
                        {

                            textBox1.Text = File.ReadAllText(openFileDialog.FileName);
                        }
                    }

                }

            }

            catch(FileNotFoundException)
            {

                MessageBox.Show("Something went wrong","File Missing!!!!");
            }
            catch(IOException)
            {

                MessageBox.Show("Something went wrong", "IO exception");
            }
        }

        private void GPL_INTERFACE_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpSection hs = new HelpSection();
           
            hs.Show();
        }

        private void btncanvas_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = c.Color;
                btncanvas.BackColor = c.Color;

            }
        }

        private void btnpoly_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Yellow, 3);

            // Create points that define polygon.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };

            // Draw polygon to screen.
            g.DrawPolygon(blackPen, curvePoints);
        }
    }
}

