using System;
using System.Collections.Generic;
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

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.ComponentModel;

namespace tera55647 {
    public class ViewModel : System.ComponentModel.INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name) {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        string _Path;
        public string Path {
            get {
                return _Path;
            }
            set {
                _Path = value;
                OnPropertyChanged("Path");
            }
        }
    }
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            //var vm = new ViewModel() { Path = @"C:\Users\BlackTomato\Desktop\SampleCode\Jellyfish.jpg" };
            InitializeComponent();
            //this.DataContext = vm;
            var bmp = Bitmap.FromFile(@"C:\Users\BlackTomato\Desktop\SampleCode\Jellyfish.jpg");
            var bmpsrc = CreateBitmapSourceFromGdiBitmap((Bitmap)bmp);
            inkcanvas.Background = new ImageBrush(bmpsrc);
            //var enc= new PngBitmapEncoder();
            //enc.Frames.Add(BitmapFrame.Create(ibmp));
            //using(var fs = new FileStream(@"C:\Users\BlackTomato\Desktop\SampleCode\test.png", FileMode.OpenOrCreate, FileAccess.Write)) {
            //    enc.Save(fs);
            //}
        }
        public static System.Windows.Interop.InteropBitmap CreateInteropBitmapFromGdiBitmap(System.Drawing.Bitmap bitmap) {
            if(bitmap == null)
                throw new ArgumentNullException("bitmap");

            var rect = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try {
                var size = (rect.Width * rect.Height) * 4;

                return System.Windows.Interop.InteropBitmap.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    System.Windows.Media.PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride) as System.Windows.Interop.InteropBitmap;
            } finally {
                bitmap.UnlockBits(bitmapData);
            }
        }
public static BitmapSource CreateBitmapSourceFromGdiBitmap(System.Drawing.Bitmap bitmap) {
    if(bitmap == null)
        throw new ArgumentNullException("bitmap");

    var rect = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);

    var bitmapData = bitmap.LockBits(
        rect,
        ImageLockMode.ReadWrite,
        System.Drawing.Imaging.PixelFormat.Format32bppArgb);

    try {
        var size = (rect.Width * rect.Height) * 4;

        return BitmapSource.Create(
            bitmap.Width,
            bitmap.Height,
            bitmap.HorizontalResolution,
            bitmap.VerticalResolution,
            PixelFormats.Bgra32,
            null,
            bitmapData.Scan0,
            size,
            bitmapData.Stride);
    } finally {
        bitmap.UnlockBits(bitmapData);
    }
}
        //public System.Windows.Interop.InteropBitmap
        //               SystemDrawingBitmap2InteropBitmap(System.Drawing.Bitmap original) {
        //    IntPtr hBitmap = original.GetHbitmap();
        //    System.Windows.Interop.Imaging newimage = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
        //            hBitmap,
        //            IntPtr.Zero,
        //            Int32Rect.Empty,
        //            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        //    DeleteObject(hBitmap);
        //    return newimage;
        //}
        //public System.Windows.Interop.InteropBitmap
        //                SystemDrawingBitmap2InteropBitmap(System.Drawing.Bitmap original) {
        //    IntPtr hBitmap = original.GetHbitmap();
        //    System.Windows.Controls.Image image = new System.Windows.Controls.Image();
        //    image.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
        //            hBitmap,
        //            IntPtr.Zero,
        //            Int32Rect.Empty,
        //            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        //    DeleteObject(hBitmap);
        //    return image;
        //}
    }
}
