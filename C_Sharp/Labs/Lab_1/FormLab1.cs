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

namespace Lab_1
{
    public partial class FormLab1 : Form {
        public FormLab1() {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            panelToolbar.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            splitContainerPictures.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;

            if (pictureBoxInput.Image == null) {
                buttonCount.Enabled = false;
                buttonSave.Enabled = false;
            }
        }
        
        private static int Normalize(int color) {
            if (color < 0)
                return 0;
            if (color > 255)
                return 255;
            return color;
        }

        private static Color UseFilter(int x, int y, Bitmap image, double[,] filter) {
            int r = 0, g = 0, b = 0;
            for (int i = 0; i < filter.GetLength(0); i++) {
                for (int j = 0; j < filter.GetLength(1); j++) {
                    Color bitmapPixelColor = image.GetPixel(x + j, y + i);
                    r += Convert.ToInt32(bitmapPixelColor.R * filter[i, j]);
                    g += Convert.ToInt32(bitmapPixelColor.G * filter[i, j]);
                    b += Convert.ToInt32(bitmapPixelColor.B * filter[i, j]);
                }
            }
            return Color.FromArgb(Normalize(r), Normalize(g), Normalize(b));
        }
        
        public static Bitmap EditImage(Bitmap image, double[,] filter) {
            Bitmap editedImage = new Bitmap(image.Width - filter.GetLength(1) + 1,
                image.Height - filter.GetLength(0) + 1);
            for (int y = 0; y < image.Height - filter.GetLength(0) + 1; y++) {
                for (int x = 0; x < image.Width - filter.GetLength(1) + 1; x++) {
                    editedImage.SetPixel(x, y, UseFilter(x, y, image, filter));
                }
            }
            return editedImage;
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
                    buttonCount.Enabled = true;
                    buttonSave.Enabled = true;
                } catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void buttonCount_Click(object sender, EventArgs e) {
            Thread thread = new Thread(() => {
                labelInfo.Text = "Start";
                labelInfo.ForeColor = Color.Red;
            });
            thread.Start();
            thread.Join();
            
            Bitmap bmp = (Bitmap)pictureBoxInput.Image;
            double[,] filterMatrix = new double[3,3];
            filterMatrix[0, 0] = double.Parse(textBox00.Text);
            filterMatrix[0, 1] = double.Parse(textBox01.Text);
            filterMatrix[0, 2] = double.Parse(textBox02.Text);
            
            filterMatrix[1, 0] = double.Parse(textBox10.Text);
            filterMatrix[1, 1] = double.Parse(textBox11.Text);
            filterMatrix[1, 2] = double.Parse(textBox12.Text);
            
            filterMatrix[2, 0] = double.Parse(textBox20.Text);
            filterMatrix[2, 1] = double.Parse(textBox21.Text);
            filterMatrix[2, 2] = double.Parse(textBox22.Text);
            
            double multiplier = double.Parse(textBoxNumerator.Text) / double.Parse(textBoxNumerator.Text);

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    filterMatrix[i, j] *= multiplier;
                }
            }
            
            labelInfo.Text = "Ready";
            labelInfo.ForeColor = Color.DarkGreen;
            pictureBoxOutput.Image = EditImage(bmp, filterMatrix);
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

        private void buttonLowPassFilter1_Click(object sender, EventArgs e) {
            textBoxNumerator.Text = "1";
            textBoxDenominator.Text = "16";

            textBox00.Text = "1";
            textBox01.Text = "2";
            textBox02.Text = "1";

            textBox10.Text = "2";
            textBox11.Text = "4";
            textBox12.Text = "2";

            textBox20.Text = "1";
            textBox21.Text = "2";
            textBox22.Text = "1";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
        }

        private void buttonLowPassFilter2_Click(object sender, EventArgs e) {
            textBoxNumerator.Text = "1";
            textBoxDenominator.Text = "1";

            textBox00.Text = "-1";
            textBox01.Text = "-1";
            textBox02.Text = "-1";

            textBox10.Text = "-1";
            textBox11.Text = "9";
            textBox12.Text = "-1";

            textBox20.Text = "-1";
            textBox21.Text = "-1";
            textBox22.Text = "-1";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
        }

        private void buttonSobel_Click(object sender, EventArgs e) {
            textBoxNumerator.Text = "1";
            textBoxDenominator.Text = "1";

            textBox00.Text = "-1";
            textBox01.Text = "-2";
            textBox02.Text = "-1";

            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";

            textBox20.Text = "1";
            textBox21.Text = "2";
            textBox22.Text = "1";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            textBoxNumerator.Text = "";
            textBoxDenominator.Text = "";

            textBox00.Text = "";
            textBox01.Text = "";
            textBox02.Text = "";

            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            labelInfo.Text = "—";
            labelInfo.ForeColor = Color.Black;
        }
    }
}