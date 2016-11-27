using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tera55986 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
        }
        private void button1_Click(object sender, EventArgs e) {
            if(this.WindowState != FormWindowState.Maximized) {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            } else {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.Bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            }
        }
    }
}
