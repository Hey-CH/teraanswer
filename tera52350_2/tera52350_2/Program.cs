using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace tera52350_2 {
    class Program {
        // 指定したID属性に一致するAutomationElementを返します
        static AutomationElement FindElementById(AutomationElement rootElement, string automationId) {
            return rootElement.FindFirst(
                TreeScope.Element | TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
        }

        // 指定したName属性に一致するAutomationElementをすべて返します
        static IEnumerable<AutomationElement> FindElementsByName(AutomationElement rootElement, string name) {
            return rootElement.FindAll(
                TreeScope.Element | TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, name))
                .Cast<AutomationElement>();
        }

        // 指定したName属性に一致するボタン要素をすべて返します
        static IEnumerable<AutomationElement> FindButtonsByName(AutomationElement rootElement, string name) {
            const string BUTTON_CLASS_NAME = "Button";
            return from x in FindElementsByName(rootElement, name)
                   where x.Current.ClassName == BUTTON_CLASS_NAME
                   select x;
        }

        static void Main(string[] args) {
            if(Process.GetProcessesByName("osk").Count() <= 0) {
                Console.WriteLine($"Please launch osk.exe");
                return;
            }

            var mainForm = AutomationElement.FromHandle(Process.GetProcessesByName("osk").First().MainWindowHandle);
            Console.WriteLine(mainForm.Current.NativeWindowHandle);

            //var btnClear = FindElementsByName(mainForm, "").First();
            //Console.WriteLine(btnClear.Current.NativeWindowHandle);

            //// ココで要素の取得ができていない
            //var xx = btnClear.FindAll(TreeScope.Children | TreeScope.Descendants,
            //    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));

            var xx = FindElementsByName(mainForm, "");



            //WalkControlElements(mainForm);
            Console.WriteLine(xx.Count());
            //Console.WriteLine(xx.Current.NativeWindowHandle);

            Console.ReadKey();
        }
        static void WalkControlElements(AutomationElement element) {
            AutomationElement elementNode = TreeWalker.ControlViewWalker.GetFirstChild(element);
            while(elementNode != null) {
                Console.WriteLine(elementNode.Current.ControlType.LocalizedControlType);
                WalkControlElements(elementNode);
                elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
            }
        }
    }
}
