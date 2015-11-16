using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImProcExp
{
    public partial class ImProcExp : Form
    {
        public ImProcExp()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                pictureBox1.Visible = true;
            }
        }

        private void closeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox1.Image = null;
        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rotateClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotationDialog RTDia = new RotationDialog();
            RTDia.ShowClockwise();
            DialogResult result = RTDia.ShowDialog();
            RTDia.HideClockwise();

            switch(result)
            {
                case DialogResult.OK:
                    rotateImage(true, RTDia.angle);
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }

            RTDia.Dispose();
            return;
        }

        private void rotateImage(Boolean rotateClockwise, int angle)
        {
            Bitmap currImage, rotatedImage;
            currImage = (Bitmap) pictureBox1.Image;

            if((angle % 180) == 0)
            {
                rotatedImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                int multiple = angle / 180;

                for (int i = 0; i < rotatedImage.Width; i++)
                {
                    for (int j = 0; j < rotatedImage.Height; j++)
                    {
                        rotatedImage.SetPixel(i, j, currImage.GetPixel(currImage.Width - (i + 1), currImage.Height - (j + 1)));
                    }
                }
                pictureBox1.Image = rotatedImage;
            }
            else if((angle % 90) == 0)
            {
                rotatedImage = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            }
            /* else
             {

             }*/
            //Bitmap rotatedImage = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            //moar code!
            return;
        }
    }
}
