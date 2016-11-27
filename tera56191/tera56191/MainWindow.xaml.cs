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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tera56191 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }
    public class ClassA : DependencyObject {
        public static readonly DependencyProperty AProperty;
        public static string GetA(DependencyObject target) {
            return (string)target.GetValue(AProperty);
        }

        public static void SetA(DependencyObject target, string value) {
            target.SetValue(AProperty, value);
        }
        private static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if(d == null) return;
            
        }
        static ClassA() {
            AProperty = DependencyProperty.RegisterAttached(
                "A", typeof(string), typeof(ClassA), new FrameworkPropertyMetadata(""));
        }
    }
}
