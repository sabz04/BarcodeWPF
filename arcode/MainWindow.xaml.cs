using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace arcode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void GenerateBarcode()
        {
            try
            {
                Barcode barcode = new Barcode();
                var img_barcode =
                    barcode.Encode(TYPE.CODE128A, barcodeTextBox.Text, (int)barcodeIMG.Width, (int)barcodeIMG.Height);
                barcodeIMG.Source = GetBitmap(img_barcode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private BitmapImage GetBitmap(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                GenerateBarcode();
            }
            
        }
    }
}
