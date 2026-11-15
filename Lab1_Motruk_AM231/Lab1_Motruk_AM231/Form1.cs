using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_Motruk_AM231
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                Bitmap originalImage = new Bitmap(openFileDialog.FileName);

                
                pictureBox1.Image = originalImage;

                int width = originalImage.Width;
                int height = originalImage.Height;

                Bitmap imageR = new Bitmap(width, height);
                Bitmap imageG = new Bitmap(width, height);
                Bitmap imageB = new Bitmap(width, height);

                
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        
                        Color p = originalImage.GetPixel(x, y);

                        
                        imageR.SetPixel(x, y, Color.FromArgb(p.A, p.R, 0, 0));
                        imageG.SetPixel(x, y, Color.FromArgb(p.A, 0, p.G, 0));
                        imageB.SetPixel(x, y, Color.FromArgb(p.A, 0, 0, p.B));
                    }
                }

                
                pictureBox2.Image = imageR;
                pictureBox3.Image = imageG;
                pictureBox4.Image = imageB;

             
                string path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                imageR.Save(path + "\\Motruk _AM-231_R.bmp");
                imageG.Save(path + "\\Motruk _AM-231_G.bmp");
                imageB.Save(path + "\\Motruk _AM-231_B.bmp");

                MessageBox.Show(" Файли збережено у папці з оригіналом.");
            }
        }
    }
}
