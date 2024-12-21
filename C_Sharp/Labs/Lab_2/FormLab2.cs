using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class FormLab2 : Form {
        public FormLab2() {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            panelToolbar.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            splitContainerPictures.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;

            if (pictureBoxInput.Image == null) {
                buttonCoords1.Enabled = false;
                buttonCoords2.Enabled = false;
                buttonСoords3.Enabled = false;
                buttonCoords4.Enabled = false;
                buttonCoords5.Enabled = false;
                buttonCorrelation.Enabled = false;
                buttonSave.Enabled = false;
            }
        }
        
        private static int Normalize(double color) {
            if (color < 0)
                return 0;
            if (color > 255)
                return 255;
            return Convert.ToInt32(color);
        }
        
        private static int[,] EditImage(int[,] image, int[,] filter, bool normalize = true) {
            int filterHeight = filter.GetLength(1);
            int filterWidth = filter.GetLength(0);
            int imageHeight = image.GetLength(1);
            int imageWidth = image.GetLength(0);
            int[,] output = new int[imageWidth - filterWidth + 1, imageHeight - filterHeight + 1];

            for (int y = 0; y < imageHeight - filterHeight + 1; y++) {
                for (int x = 0; x < imageWidth - filterWidth + 1; x++) {
                    double color = 0;

                    for (int i = 0; i < filterWidth; i++) {
                        for (int j = 0; j < filterHeight; j++) {
                            double imageColor = image[x + i, y + j];
                            color += imageColor * filter[i, j];
                        }
                    }
                    int resultColor = Convert.ToInt32(color);
                    if (normalize)
                        resultColor = Normalize(color);
                    output[x, y] = resultColor;
                }
            }
            return output;
        }
        
        private static int[,] BitmapToArray(Bitmap image) {
            int[,] outputArray = new int[image.Width, image.Height];
            for (int x = 0; x < image.Width; x++) {
                for (int y = 0; y < image.Height; y++) {
                    Color color = image.GetPixel(x, y);
                    int outputBright = ((color.R + color.G + color.B) / 3);

                    outputArray[x, y] = outputBright;
                }
            }
            return outputArray;
        }
        
        private static int[,] NormalizeImage(Bitmap image) {
            int imageWidth = image.Width;
            int imageHeight = image.Height;

            int[,] outputFilter = new int[imageWidth, imageHeight];
            int[] buffer = new int[imageWidth];
            for(int x = 0; x < imageWidth; x++) {
                int bright = 0;
                for(int y = 0; y < imageHeight; y++) {
                    Color color = image.GetPixel(x, y);

                    bright += (color.R + color.G + color.B) / 3;
                }
                buffer[x] = bright / imageHeight;
            }

            int mean = 0;
            for(int i = 0; i < buffer.Length; i++) {
                mean += buffer[i];
            }

            mean /= buffer.Length;

            for (int x = 0; x < imageWidth; x++) {
                for (int y = 0; y < imageHeight; y++) {
                    Color color = image.GetPixel(x, y);
                    int outputBright = ((color.R + color.G + color.B) / 3) - mean;

                    outputFilter[x, y] = outputBright;
                }
            }
            return outputFilter;
        }
        
        private static Bitmap ImageToGray(int[,] image) {
            Bitmap outputImage = new Bitmap(image.GetLength(0), image.GetLength(1));
            int minBright = image[0, 0];
            int maxBright = image[0, 0];
            int imageWidth = image.GetLength(0);
            int imageHeight = image.GetLength(1);

            for (int x = 0; x < imageWidth; x++) {
                for (int y = 0; y < imageHeight; y++) {
                    int currentBright = image[x, y];

                    if (currentBright < minBright)
                        minBright = currentBright;

                    if (currentBright > maxBright)
                        maxBright = currentBright;
                }
            }
            decimal newMinBrightD = 0;
            decimal newMaxBrightD = 255;
            for (int x = 0; x < image.GetLength(0); x++) {
                for (int y = 0; y < image.GetLength(1); y++) {
                    decimal newCurrentBright = Convert.ToDecimal(image[x, y]);
                    decimal minimalBright = Convert.ToDecimal(minBright);
                    decimal maximalBright = Convert.ToDecimal(maxBright);

                    decimal bright1 = newMaxBrightD - newMinBrightD;
                    decimal bright2 = maximalBright - minimalBright;
                    decimal bright3 = newCurrentBright - minimalBright;

                    Console.WriteLine(bright2);

                    decimal result = (bright3 * (bright1 / bright2)) + newMinBrightD;
                    int newBright = Convert.ToInt32(result);

                    if (newBright > 255)
                        newBright = 255;

                    if (newBright < 0)
                        newBright = 0;

                    Color outputColor = Color.FromArgb(newBright, newBright, newBright);
                    outputImage.SetPixel(x, y, outputColor);
                }
            }
            return outputImage;
        }

        private void buttonLoad_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\volch\\RiderProjects\\Maga\\MiKM\\MathCompMethods\\Lab_1\\resources\\owl.jpg";
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2; 
                
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    // Получаем полный путь к выбранному файлу
                    string filePath = openFileDialog.FileName;
                    Bitmap bmp = new Bitmap(filePath);
                    pictureBoxInput.Image = bmp;
                    buttonCoords1.Enabled = true;
                    buttonCoords2.Enabled = true;
                    buttonСoords3.Enabled = true;
                    buttonCoords4.Enabled = true;
                    buttonCoords5.Enabled = true;
                    buttonCorrelation.Enabled = true;
                    buttonSave.Enabled = true;
                } catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Filter = "JPEG файл(*.jpg)|*.jpg|PNG файл(*.png)|*.png|Bitmap файл(*.bmp)|*.bmp";
        
                if (sfd.ShowDialog() == DialogResult.OK) {
                    string ext = Path.GetExtension(sfd.FileName).ToLower();
                    ImageFormat format;
            
                    switch (ext) {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        default:
                            format = ImageFormat.Jpeg;
                            break;
                    }
                    pictureBoxOutput.Image.Save(sfd.FileName, format);
                }
            }
        }

        private void buttonCorrelation_Click(object sender, EventArgs e) {
            Thread thread = new Thread(() => {
                labelInfo.Text = "Start";
                labelInfo.ForeColor = Color.Red;
            });
            thread.Start();
            thread.Join();
            
            Bitmap bmp = (Bitmap)pictureBoxInput.Image;
            
            int[,] defaultImage = BitmapToArray(bmp);
            Bitmap defaultGreyImage = ImageToGray(defaultImage);
            int[,] normalizedDefaultGreyImage = NormalizeImage(defaultGreyImage);

            if (pictureBoxCroppedImage.Image == null) {
                int xT = int.Parse(textBoxXT.Text);
                int yT = int.Parse(textBoxYT.Text);
                int xB = int.Parse(textBoxXB.Text);
                int yB = int.Parse(textBoxYB.Text);
            
                Rectangle cropRect = new Rectangle(xT, yT, xB - xT, yB - yT);
                Bitmap croppedImage = bmp.Clone(cropRect, bmp.PixelFormat);
                pictureBoxCroppedImage.Image = croppedImage;
                int[,] filter = NormalizeImage(ImageToGray(BitmapToArray(croppedImage)));
                int[,] result = EditImage(normalizedDefaultGreyImage, filter, false);
                labelInfo.Text = "Ready";
                labelInfo.ForeColor = Color.DarkGreen;
                pictureBoxOutput.Image = ImageToGray(result);
            } else {
                int[,] filter = NormalizeImage(ImageToGray(BitmapToArray((Bitmap)pictureBoxCroppedImage.Image)));
                int[,] result = EditImage(normalizedDefaultGreyImage, filter, false);
                labelInfo.Text = "Ready";
                labelInfo.ForeColor = Color.DarkGreen;
                pictureBoxOutput.Image = ImageToGray(result);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            textBoxXT.Text = "";
            textBoxYT.Text = "";
            textBoxXB.Text = "";
            textBoxYB.Text = "";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
            pictureBoxCroppedImage.Image = null;
        }

        private void buttonCoords1_Click(object sender, EventArgs e) {
            textBoxXT.Text = "390";
            textBoxYT.Text = "460";
            textBoxXB.Text = "480";
            textBoxYB.Text = "525";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
            
            int xT = int.Parse(textBoxXT.Text);
            int yT = int.Parse(textBoxYT.Text);
            int xB = int.Parse(textBoxXB.Text);
            int yB = int.Parse(textBoxYB.Text);
            
            Bitmap bmp = (Bitmap)pictureBoxInput.Image;
            Rectangle cropRect = new Rectangle(xT, yT, xB - xT, yB - yT);
            Bitmap croppedImage = bmp.Clone(cropRect, bmp.PixelFormat);
            pictureBoxCroppedImage.Image = croppedImage;
        }

        private void buttonCoords2_Click(object sender, EventArgs e) {
            textBoxXT.Text = "415";
            textBoxYT.Text = "250";
            textBoxXB.Text = "535";
            textBoxYB.Text = "350";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
            
            int xT = int.Parse(textBoxXT.Text);
            int yT = int.Parse(textBoxYT.Text);
            int xB = int.Parse(textBoxXB.Text);
            int yB = int.Parse(textBoxYB.Text);
            
            Bitmap bmp = (Bitmap)pictureBoxInput.Image;
            Rectangle cropRect = new Rectangle(xT, yT, xB - xT, yB - yT);
            Bitmap croppedImage = bmp.Clone(cropRect, bmp.PixelFormat);
            pictureBoxCroppedImage.Image = croppedImage;
        }

        private void buttonСoords3_Click(object sender, EventArgs e) {
            textBoxXT.Text = "320";
            textBoxYT.Text = "30";
            textBoxXB.Text = "370";
            textBoxYB.Text = "95";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
            
            int xT = int.Parse(textBoxXT.Text);
            int yT = int.Parse(textBoxYT.Text);
            int xB = int.Parse(textBoxXB.Text);
            int yB = int.Parse(textBoxYB.Text);
            
            Bitmap bmp = (Bitmap)pictureBoxInput.Image;
            Rectangle cropRect = new Rectangle(xT, yT, xB - xT, yB - yT);
            Bitmap croppedImage = bmp.Clone(cropRect, bmp.PixelFormat);
            pictureBoxCroppedImage.Image = croppedImage;
        }

        private void buttonCoords4_Click(object sender, EventArgs e) {
            textBoxXT.Text = "140";
            textBoxYT.Text = "215";
            textBoxXB.Text = "180";
            textBoxYB.Text = "240";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
            
            int xT = int.Parse(textBoxXT.Text);
            int yT = int.Parse(textBoxYT.Text);
            int xB = int.Parse(textBoxXB.Text);
            int yB = int.Parse(textBoxYB.Text);
            
            Bitmap bmp = (Bitmap)pictureBoxInput.Image;
            Rectangle cropRect = new Rectangle(xT, yT, xB - xT, yB - yT);
            Bitmap croppedImage = bmp.Clone(cropRect, bmp.PixelFormat);
            pictureBoxCroppedImage.Image = croppedImage;
        }

        private void buttonCoords5_Click(object sender, EventArgs e) {
            textBoxXT.Text = "265";
            textBoxYT.Text = "190";
            textBoxXB.Text = "300";
            textBoxYB.Text = "245";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
            
            int xT = int.Parse(textBoxXT.Text);
            int yT = int.Parse(textBoxYT.Text);
            int xB = int.Parse(textBoxXB.Text);
            int yB = int.Parse(textBoxYB.Text);
            
            Bitmap bmp = (Bitmap)pictureBoxInput.Image;
            Rectangle cropRect = new Rectangle(xT, yT, xB - xT, yB - yT);
            Bitmap croppedImage = bmp.Clone(cropRect, bmp.PixelFormat);
            pictureBoxCroppedImage.Image = croppedImage;
        }
    }
}