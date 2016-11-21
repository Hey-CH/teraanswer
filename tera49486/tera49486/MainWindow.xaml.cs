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

namespace tera49486 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        double x1 = 0;          // 旗始点(x)
        double y1 = 0;          // 旗始点(y)
        double x2 = 0;          // 旗終点(x)
        double y2 = 0;          // 旗終点(y)
        bool flag = true;       // 旗描画モード切替
        bool flag2 = true;      // 旗消去モード切替
        bool flag3 = true;
        int counter = 0;
        int counter2 = 0;

        SolidColorBrush BlackBrush = new SolidColorBrush(Colors.Black);
        SolidColorBrush RedBrush = new SolidColorBrush(Colors.Red);

        public MainWindow() {
            InitializeComponent();
            canvas.EditingMode = InkCanvasEditingMode.None;
            BlackBrush.Freeze();
            RedBrush.Freeze();
        }

        // 図形描画モード
        private void button_Click(object sender, RoutedEventArgs e) {
            flag = false;
            flag2 = true;
            canvas.EditingMode = InkCanvasEditingMode.None;
        }

        // マウスクリック位置（押したとき）取得
        private void Root_MouseDown(object sender, MouseButtonEventArgs e) {
            if(flag == false) {
                System.Windows.Point pos1 = e.GetPosition(canvas);
                x1 = pos1.X;
                y1 = pos1.Y;

                textBox1.Text = null;
            }
        }

        // マウスクリック位置（離したとき）取得
        private void Root_MouseUp(object sender, MouseButtonEventArgs e) {
            if(flag == false) {
                System.Windows.Point pos2 = e.GetPosition(canvas);
                x2 = pos2.X;
                y2 = pos2.Y;

                CreateElipse();
            }
        }

        // 描画
        public void CreateElipse() {
            EllipseGeometry ellipse1 = new EllipseGeometry();
            System.Windows.Shapes.Path P1 = new System.Windows.Shapes.Path();

            EllipseGeometry ellipse2 = new EllipseGeometry();
            System.Windows.Shapes.Path P2 = new System.Windows.Shapes.Path();

            ellipse1.Center = new System.Windows.Point(x1, y1);
            ellipse1.RadiusX = 1;
            ellipse1.RadiusY = 1;

            ellipse2.Center = new System.Windows.Point(x2, y2);
            ellipse2.RadiusX = 3;
            ellipse2.RadiusY = 3;

            if(tgBtn.IsChecked == true && tgBtn2.IsChecked == false) {
                // 消去処理
                P1.MouseDown += (sender, e) => {
                    if(flag2 == false) {
                        canvas.Children.Remove(P1);
                        canvas2.Children.Remove(P2);
                    }
                };
            }

            if(tgBtn2.IsChecked == false) {
                // 円設定
                P1.Fill = RedBrush;
                P1.Stroke = RedBrush;
                P1.StrokeThickness = 1;
                P1.Data = ellipse1;

                P2.Fill = RedBrush;
                P2.Stroke = RedBrush;
                P2.StrokeThickness = 3;
                P2.Data = ellipse2;

                counter2 = canvas.Children.Capacity;

                if(counter2 == 0) {
                    canvas.Children.Add(P1);
                    canvas2.Children.Add(P2);
                    textBox1.Text = null;
                    flag3 = false;
                } else {
                    if(tgBtn.IsChecked == false && tgBtn3.IsChecked == false && flag3 == true) {
                        MessageBox.Show("文字が記入されていません\n(文字記入後消去してください)");
                    } else {
                        canvas.Children.Add(P1);
                        canvas2.Children.Add(P2);

                        textBox1.Text = null;
                        tgBtn3.IsChecked = false;
                        flag3 = false;
                    }
                }
            }
        }

        private void textBox1_LostFocus(object sender, RoutedEventArgs e) {
            if(flag == true) {
            } else {
                TextBlock tblock2 = new TextBlock();

                SolidColorBrush Brush2 = new SolidColorBrush(Colors.Transparent);
                Brush2.Freeze();

                tblock2.Background = Brush2;


                Binding bind3 = new Binding();
                bind3.ElementName = "textBox1";
                bind3.Path = new PropertyPath(TextBox.TextProperty);
                //bind3.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
                bind3.Mode = BindingMode.OneTime;
                tblock2.SetBinding(TextBlock.TextProperty, bind3);

                if(tgBtn2.IsChecked == true && tgBtn.IsChecked == false) {
                    tblock2.MouseDown += (sender2, e2) => {
                        if(flag2 == false) {
                            canvas.Children.Remove(tblock2);
                        }
                    };
                }

                if(tgBtn.IsChecked == false) {
                    if(tgBtn2.IsChecked == false) {
                        // 消去処理
                        tblock2.MouseDown += (sender2, e2) => {
                            if(flag2 == false) {
                                counter = canvas.Children.IndexOf(tblock2);

                                if(counter == 1) {
                                    canvas.Children.Remove(tblock2);
                                    canvas.Children.RemoveAt(counter - 1);
                                    canvas2.Children.RemoveAt(counter - 1);
                                } else {
                                    MessageBox.Show(counter.ToString());
                                    MessageBox.Show((counter - 1).ToString());
                                    MessageBox.Show(((counter - 1) - ((counter - 1) / 2)).ToString());

                                    canvas.Children.Remove(tblock2);
                                    canvas.Children.RemoveAt(counter - 1);
                                    canvas2.Children.RemoveAt((counter - 1) - ((counter - 1) / 2));
                                }
                            }
                        };

                        tblock2.SetValue(InkCanvas.TopProperty, y2);
                        tblock2.SetValue(InkCanvas.LeftProperty, x2);
                    }
                    // 文字だけモード
                    else {
                        tblock2.SetValue(InkCanvas.TopProperty, y1);
                        tblock2.SetValue(InkCanvas.LeftProperty, x1);
                    }
                }

                tblock2.Foreground = BlackBrush;

                if(tblock2.Text != null && tgBtn.IsChecked == false) {
                    canvas.Children.Add(tblock2);
                    tgBtn3.IsChecked = true;
                }
            }
        }

        // 消去モード
        private void button2_Click(object sender, RoutedEventArgs e) {
            flag2 = false;
            flag = true;

            canvas.EditingMode = InkCanvasEditingMode.None;
        }
    }
}
