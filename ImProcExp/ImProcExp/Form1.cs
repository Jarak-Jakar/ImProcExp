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
            currImage = new Bitmap(pictureBox1.Image);

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
                        }
                    }
                }

                if(excessTheta != 0) //if the angle wasn't just a multiple of 90 degrees, will carry out the remaining rotation needed
                {
                    currImage = new Bitmap(rotatedImage);
                    rotatedImage.Dispose();
                    rotatedImage = new Bitmap(Math.Max(currImage.Width, currImage.Height), Math.Max(currImage.Width, currImage.Height));
                    double rho, coordTheta;
                    int refX, refY;
                    double excessThetaRad = (Math.PI * excessTheta) / 180.0;

                    for (int i = 0; i < rotatedImage.Width; i++)
                    {
                        for (int j = 0; j < rotatedImage.Height; j++)
                        {
                            // Transform cartesian coordinates to polar coordinates.  Information will be lost due to having to convert between floats and ints
                            rho = System.Math.Sqrt((i*i) + (j*j));
                            coordTheta = System.Math.Atan2(j, i);

                            //convert the polar coordinates back to cartesian, adjusting for excessTheta
                            refX = Convert.ToInt32(Math.Truncate(rho * Math.Cos(coordTheta - excessThetaRad))) - (currImage.Width / 2);
                            refY = Convert.ToInt32(Math.Truncate(rho * Math.Sin(coordTheta - excessThetaRad))) + (currImage.Height / 2);

                            if( (refX < 0 || refX >= currImage.Width) || (refY < 0 || refY >= currImage.Height) )
                            {
                                rotatedImage.SetPixel(i, j, Color.Gray);
                            } else
                            {
                                rotatedImage.SetPixel(i, j, currImage.GetPixel(refX, refY));
                            }
                        }
                    }
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
            currImage.Dispose();
            pictureBox1.Image = rotatedImage;
            return;
        }
    }
}
