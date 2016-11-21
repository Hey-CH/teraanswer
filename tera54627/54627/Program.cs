using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace _54627 {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\Users\BlackTomato\Desktop\SampleCode\Jellyfish.jpg";
            Image bmp = Bitmap.FromFile(path);

            var f = new Form();
            var tb = new TextBox();
            tb.Text = "test";
            tb.Location = new Point(100, 100);
            f.Controls.Add(tb);

            f.Paint += (s, e) => {
                e.Graphics.DrawImage(bmp, new Point(0, 0));
            };

            f.ShowDialog();
        }
    }
}
