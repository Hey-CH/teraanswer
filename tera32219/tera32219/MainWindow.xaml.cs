using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tera32219 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window{
        public class Item : System.ComponentModel.INotifyPropertyChanged {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string name) {
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            public int ID { get; set; }
            public string Value { get; set; }
            bool _IDSelected = false;
            public bool IDSelected {
                get {
                    return _IDSelected;
                }
                set {
                    _IDSelected = value;
                    OnPropertyChanged("IDSelected");
                }
            }
            bool _ValueSelected = false;
            public bool ValueSelected {
                get {
                    return _ValueSelected;
                }
                set {
                    _ValueSelected = value;
                    OnPropertyChanged("ValueSelected");
                }
            }
        }
        public System.Collections.ObjectModel.ObservableCollection<Item> Data { get; set; }
        public MainWindow() {
            Data = new System.Collections.ObjectModel.ObservableCollection<Item>();
            for(int i = 0; i < 1000; i++) {
                Data.Add(new Item() { ID = i, Value = "Value" + i });
            }
            InitializeComponent();
            dataGrid.ItemsSource = Data;
        }

        private void rowHeader_Click(object sender, RoutedEventArgs e) {
        }
        private void columnHeader_Click(object sender, RoutedEventArgs e) {
            //var columnHeader = sender as System.Windows.Controls.Primitives.DataGridColumnHeader;
            //if(columnHeader == null) {
            //    return;
            //}

            //for(int j = 0; j < this.dataGrid.Columns.Count; j++) {
            //    if(j != columnHeader.DisplayIndex) {
            //        continue;
            //    }

            //    for(int i = 0; i < this.dataGrid.Items.Count; i++) {
            //        this.dataGrid.ScrollIntoView(this.dataGrid.Items[i]);
            //        DataGridCellInfo cellInfo = new DataGridCellInfo(this.dataGrid.Items[i], this.dataGrid.Columns[j]);

            //        // DataGridCellInfoから該当するDataGridCellを取得
            //        DataGridCell cell = getCellFromCellInfo(this.dataGrid, cellInfo);

            //        cell.Background = new SolidColorBrush(Colors.LemonChiffon);
            //    }
            //}
            var header = sender as DataGridColumnHeader;
            if(header == null) return;
            if(header.Content.ToString() == "ID") {
                Data.ToList().ForEach(d => { d.IDSelected = true; d.ValueSelected = false; });
            }else if(header.Content.ToString() == "Value") {
                Data.ToList().ForEach(d => { d.IDSelected = false; d.ValueSelected = true; });
            }
        }
        DataGridCell getCellFromCellInfo(DataGrid dataGrid, DataGridCellInfo gridCellInfo) {

            if(gridCellInfo == null || !gridCellInfo.IsValid || gridCellInfo.Item == null ||
                dataGrid.Items.Count == 0) {
                //パフォーマンス対策:そもそも探せる状況じゃないなら、終了
                return null;
            }

            //現在のセル(のItem)から現在の行(DataGridRow)を特定します。
            var gridRow = (DataGridRow)dataGrid.ItemContainerGenerator.
                                        ContainerFromItem(gridCellInfo.Item);

            if(gridRow == null) {
                return null;
            }

            //列インデックスを取得します。
            var colIndex = dataGrid.Columns.IndexOf(gridCellInfo.Column);

            if(colIndex < 0) {
                //列インデックスは、0以上の筈。
                return null;
            }

            //FirstOrDefaultで検索にヒットした最初のオブジェクトを取得します。
            var cellsPresenter = gridRow.
                    FindVisualChildren<DataGridCellsPresenter>().FirstOrDefault();

            if(cellsPresenter == null) {
                return null;
            }

            //DataGridCellを特定します。
            var gridCell = cellsPresenter.ItemContainerGenerator.
                                ContainerFromIndex(colIndex) as DataGridCell;
            return gridCell;
        }
    }
    public static class Ex {
        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject {
            if(depObj != null) {
                for(int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if(child != null && child is T) {
                        yield return (T)child;
                    }
                    foreach(T childOfChild in FindVisualChildren<T>(child)) {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
