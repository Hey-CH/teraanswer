using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tera55705 {
public partial class Form1 : Form {
    int year = DateTime.Now.Year;
    int month = DateTime.Now.Month;
    public Form1() {
        InitializeComponent();

        for(int i = 1; i <= 12; i++)
            comboBox1.Items.Add(i);
        for(int i = year - 100; i <= year + 100; i++)
            comboBox2.Items.Add(i);
        comboBox1.SelectedItem = month;
        comboBox2.SelectedItem = year;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        //年が選択された
        month = (int)comboBox1.SelectedItem;
        setDate();
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
        //月が選択された
        year = (int)comboBox2.SelectedItem;
        setDate();
    }

    private void setDate() {
        var dFirst = new DateTime(year, month, 1);//選択された年月の1日
        var dLast = dFirst.AddMonths(1).AddDays(-1);//選択された年月の最終日
        var bdLast = dFirst.AddDays(-1);//先月の最終日
                                        //numは1日をどのラベルからはじめるか決める変数
                                        //日付に使用するラベル名はlabel8～label44
        int num = 0;//月曜の場合1でそれ以降順に1づつ増える
        if(dFirst.DayOfWeek == DayOfWeek.Monday) {
            num = 8;//月曜はlabel8
        } else if(dFirst.DayOfWeek == DayOfWeek.Tuesday) {
            num = 9;//火曜はlabel9
        } else if(dFirst.DayOfWeek == DayOfWeek.Wednesday) {
            num = 10;//水曜はlabel10
        } else if(dFirst.DayOfWeek == DayOfWeek.Thursday) {
            num = 11;//木曜はlabel11
        } else if(dFirst.DayOfWeek == DayOfWeek.Friday) {
            num = 12;//金曜はlabel12
        } else if(dFirst.DayOfWeek == DayOfWeek.Saturday) {
            num = 13;//土曜はlabel13
        } else if(dFirst.DayOfWeek == DayOfWeek.Sunday) {
            num = 14;//日曜はlabel8
        }
        //label8～label49全部設定
        for(int i = 8; i <= 49; i++) {
            var d = i - num;//1日より何日前か(後か）
            this.Controls["label" + i].Text = (dFirst.AddDays(d).Day).ToString();
            if(i < num || d >= dLast.Day) {
                //選択月の前の月の最後の方
                this.Controls["label" + i].ForeColor = Color.Gray;
            } else {
                //選択月
                this.Controls["label" + i].ForeColor = Color.Black;
            }
        }
    }
}
}
