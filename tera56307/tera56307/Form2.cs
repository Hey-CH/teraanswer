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
    public partial class Form2 : Form {
        DateModel model;
        public Form2() {
            InitializeComponent();
        }
        public Form2(DateModel m) {
            InitializeComponent();
            model = m;
        }
    }
}
