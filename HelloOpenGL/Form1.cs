using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;

namespace HelloOpenGL
{
    public partial class Form1 : Form
    {
        private byte nRedByte;
        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            var glColor = Color.FromArgb(nRedByte, 0, 0);
            GL.ClearColor(glColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.StencilBufferBit);
            GL.ClearDepth(0);
            glControl1.SwapBuffers();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            glControl1.Invalidate();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            nRedByte = 0;
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            nRedByte++;
            Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Idle -= Application_Idle;
        }
    }
}
