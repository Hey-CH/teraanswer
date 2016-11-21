using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tera54478 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.Shown += (s, e) => {
                var bmp = new Bitmap(500, 500, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmp);
                g.FillRectangle(Brushes.White, g.VisibleClipBounds);
                g.Dispose();
                this.DrawToBitmap(bmp, new Rectangle(20, 20, this.Width, this.Height));
                bmp.Save(@"aaa.png");
            };
        }
    }
}
