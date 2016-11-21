using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace tera48073 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Database.SetInitializer(new DropCreateDatabaseAlways<ObjectModel>());
            var db = new ObjectModel();
            var p = new Person() { ID = 0, Name = "aiueo", Comment = "com" };
            db.Persons.Add(p);
            db.SaveChanges();

            var d = new Document() { ID = 0, Name = "doc", Value = "val", Author = p };
            db.Documents.Add(d);
            db.SaveChanges();
        }
    }
}
