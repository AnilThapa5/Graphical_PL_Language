using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_PL_Language
{
    public partial class GPL_INTERFACE : Form
    {
        Graphics g;
        public GPL_INTERFACE()
        {
            InitializeComponent();
            g=panel1.CreateGraphics();

        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnrun_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter the Values IN Command Box");
            }
            else
            {
                string cmd = textBox1.Text;
                Commands c = new Commands();
                c.Execode(cmd, g);
                c.pointmove(cmd, g);
            }
           
            

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panel1.Refresh();
            g.ResetTransform();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
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
            
        }
    }
}

