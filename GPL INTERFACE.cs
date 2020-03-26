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

            if (textBox1.Text=="")
            {
                MessageBox.Show("Enter the Values IN Command Box");
            }
            else if(textBox1.Text==null)
            {
                MessageBox.Show("Command area cannot be NULL OR EMPTY!!");
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
            
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpSection hs = new HelpSection();
           
            hs.Show();
        }
    }
}

