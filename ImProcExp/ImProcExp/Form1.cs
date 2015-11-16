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
            rotatedImage = null;
            currImage = (Bitmap) pictureBox1.Image;

            int excessTheta = angle % 90; //the amount of the angle (if any) which isn't a multiple of 90 degrees
            int baseTheta = angle - excessTheta; //the amount of the angle that is a multiple of 90 degrees

            //The method will rotate the image as appropriate for the baseTheta, and then will do what is needed to do the final twist with the excessTheta

            if(rotateClockwise) //perform clockwise rotation
            {
                if (baseTheta % 360 == 0) //Nothing needs to be done for this case, just return the base image
                {
                    rotatedImage = currImage;
                }
                else if (baseTheta % 270 == 0) //base rotation is identical to rotation of 270 degrees
                {
                    rotatedImage = new Bitmap(currImage.Height, currImage.Width);
                    for (int i = 0; i < rotatedImage.Width; i++)
                    {
                        for (int j = 0; j < rotatedImage.Height; j++)
                        {
                            rotatedImage.SetPixel(i, j, currImage.GetPixel(currImage.Width - (j + 1), i));
                            //rotatedImage.SetPixel(i, j, currImage.GetPixel(currImage.Height - (i+1), j));
                        }
                    }

                } else if(baseTheta % 180 == 0) //base rotation is identical to rotation of 180 degrees
                {
                    rotatedImage = new Bitmap(currImage.Width, currImage.Height);
                    for(int i = 0; i < rotatedImage.Width; i++)
                    {
                        for (int j = 0; j < rotatedImage.Height; j++)
                        {
                            rotatedImage.SetPixel(i, j, currImage.GetPixel(currImage.Width - (i +1), currImage.Height - (j+1)));
                        }
                    }
                } else if(baseTheta % 90 == 0) //base rotation is identical to rotation of 90 degrees
                {
                    rotatedImage = new Bitmap(currImage.Height, currImage.Width);
                    for (int i = 0; i < rotatedImage.Width; i++)
                    {
                        for (int j = 0; j < rotatedImage.Height; j++)
                        {
                            rotatedImage.SetPixel(i, j, currImage.GetPixel(j, currImage.Height - (i + 1)));
                            //rotatedImage.SetPixel(i, j, currImage.GetPixel(currImage.Width - (j + 1), i));
                        }
                    }
                }

                if(excessTheta != 0) //if the angle wasn't just a multiple of 90 degrees, will carry out the remaining rotation needed
                {

                }
            }
            else //perform anti-clockwise rotation - no action needed if baseTheta is a multiple of 360 degrees, so no case for it
            {
                if(baseTheta % 360 == 0) //Nothing needs to be done for this case, just return the base image
                {
                    rotatedImage = currImage;
                }
                else if (baseTheta % 270 == 0) //base rotation is identical to rotation of 270 degrees
                {

                }
                else if (baseTheta % 180 == 0) //base rotation is identical to rotation of 180 degrees
                {

                }
                else if (baseTheta % 90 == 0) //base rotation is identical to rotation of 90 degrees
                {

                }

                if (excessTheta != 0) //if the angle wasn't just a multiple of 90 degrees, will carry out the remaining rotation needed
                {

                }
            }

            /*if((angle % 180) == 0)
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
            }*/
            /* else
             {

             }*/
            //Bitmap rotatedImage = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            //moar code!

            pictureBox1.Image = rotatedImage;
            return;
        }
    }
}
