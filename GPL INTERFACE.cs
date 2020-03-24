using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            g = pictureBox1.CreateGraphics();

        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
            string cmd = textBox1.Text;
            Commands c = new Commands();
            c.Execode(cmd, g);
            c.pointmove(cmd, g);
            int x = c.mouseX;
            int y = c.mouseY;
            

        }
    }
}

