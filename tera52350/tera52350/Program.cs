using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
//using Winium.Cruciatus;
//using Winium.Cruciatus.Core;
//using Winium.Cruciatus.Extensions;

using System.Collections;

namespace testxxx {
    class Program {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        static void Main(string[] args) {
            //var path = @"C:\Windows\System32\osk.exe";
            //var proc = Process.Start(path);

            //Thread.Sleep(5000);

            //ウィンドウのタイトルに「メモ帳」を含むプロセスをすべて取得する
            var hwnd = GetWindowByTitle("スクリーン キーボード");

            //結果を表示する
            foreach(IntPtr p in hwnd) {
                var c = GetAllChildrenWindowHandles(p);
                foreach(IntPtr cp in c) {
                    var ccp = GetAllChildrenWindowHandles(cp);
                    Console.WriteLine(ccp.Count);
                }
            }


            Console.WriteLine("終了しました。");
            Console.ReadLine();
        }
        static System.Diagnostics.Process[] GetProcessesByWindowTitle(string windowTitle) {
            System.Collections.ArrayList list = new System.Collections.ArrayList();

            //すべてのプロセスを列挙する
            foreach(System.Diagnostics.Process p
                in System.Diagnostics.Process.GetProcesses()) {
                //指定された文字列がメインウィンドウのタイトルに含まれているか調べる
                if(0 <= p.MainWindowTitle.IndexOf(windowTitle)) {
                    //含まれていたら、コレクションに追加
                    list.Add(p);
                }
            }

            //コレクションを配列にして返す
            return (System.Diagnostics.Process[])
                list.ToArray(typeof(System.Diagnostics.Process));
        }
        static List<IntPtr> GetWindowByTitle(string windowTitle) {
            List<IntPtr> list = new List<IntPtr>();

            //すべてのプロセスを列挙する
            foreach(System.Diagnostics.Process p
                in System.Diagnostics.Process.GetProcesses()) {
                //指定された文字列がメインウィンドウのタイトルに含まれているか調べる
                if(0 <= p.MainWindowTitle.IndexOf(windowTitle)) {
                    //含まれていたら、コレクションに追加
                    list.Add(p.MainWindowHandle);
                }
            }

            //コレクションを配列にして返す
            return list;
        }
        static List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent) {
            List<IntPtr> result = new List<IntPtr>();
            int ct = 0;
            IntPtr prevChild = IntPtr.Zero;
            IntPtr currChild = IntPtr.Zero;
            while(true) {
                currChild = FindWindowEx(hParent, prevChild, null, null);
                if(currChild == IntPtr.Zero) break;
                result.Add(currChild);
                prevChild = currChild;
                ++ct;
            }
            return result;
        }
    }
    public static class Ex {

        public static List<AutomationElement> Find(this AutomationElement parent, Condition conditions) {
            var l = new List<AutomationElement>();

            var tage = parent.FindAll(TreeScope.Children, conditions);
            if(tage.Count > 0) {
                l.AddRange(tage.Cast<AutomationElement>());
            }

            var c = parent.FindAll(TreeScope.Children, Condition.TrueCondition);
            c.Cast<AutomationElement>().ToList().ForEach(ae => l.AddRange(ae.Find(conditions)));

            return l;
        }
    }
}