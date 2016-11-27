using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tera56307 {
    public partial class MainForm : Form {
        internal DateModel Date;
        public MainForm() {
            InitializeComponent();
            Date = new DateModel() { year = "1900", month = "11", day = "24", week = "木" };
        }

        private void button1_Click(object sender, EventArgs e) {
            var f1 = new Form1(Date);
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e) {
            var f2 = new Form2(Date);
            f2.Show();
        }
    }
    public class DateModel {
        public string year;
        public string month;
        public string day;
        public string week;
    }
}
