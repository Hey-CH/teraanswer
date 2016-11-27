using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace tera56390 {
    class Program {
        static void Main(string[] args) {
            var a = new ClassA();
            a.PropertyChanged+=(s,e)=> {
                Console.WriteLine(e.PropertyName + "が変わったよ");
            };
            a.Bs.CollectionChanged += (s, e) => {
                Console.WriteLine(string.Join(",",e.NewItems.Cast<ClassB>().Select(v=>v.StrB)) + "が変わったよ");
            };
            a.ValA = 1;
            a.Bs.Add(new ClassB() { ValB = 1, StrB = "bbb" });
            a.Bs.Add(new ClassB() { ValB = 1, StrB = "ｃｃｃ" });

            //Concatはだめ
            a.Bs.Concat(new[] {
                new ClassB() { ValB = 1, StrB = "bbb1" },
                new ClassB() { ValB = 1, StrB = "bbb2" },
                new ClassB() { ValB = 1, StrB = "bbb3" },
                new ClassB() { ValB = 1, StrB = "bbb4" }
            });

            Console.Read();
        }
    }
    public class ClassA :INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name) {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        int _ValA = 0;
        public int ValA {
            get { return _ValA; }
            set {
                _ValA = value;
                OnPropertyChanged("ValA");
            }
        }
        public ObservableCollection<ClassB> Bs { get; set; } = new ObservableCollection<ClassB>();
    }
    public class ClassB :INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name) {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        string _StrB = "";
        public string StrB {
            get { return _StrB; }
            set {
                _StrB = value;
                OnPropertyChanged("StrB ");
            }
        }
        int _ValB = 0;
        public int ValB {
            get { return _ValB; }
            set {
                _ValB = value;
                OnPropertyChanged("ValB");
            }
        }

    }
}
