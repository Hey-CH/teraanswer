Public Class Form1
    Private Sub btn_Import_Click(sender As Object, e As EventArgs) Handles btn_Import.Click
        Dim textFile1 As New OpenFileDialog()
        textFile1.Filter = "Cursor Files|*.csv"
        textFile1.Title = "Select a Csv File"

        If (textFile1.ShowDialog() = DialogResult.OK) Then
            Dim textFile As FileIO.TextFieldParser
            ' --- 入力ファイルを開く
            textFile = New FileIO.TextFieldParser(textFile1.FileName)
            'textFile = New FileIO.TextFieldParser("C:\temp\test.csv")   ' -- デフォルト encoding は UTF8
            ' --- デリミターをタブと定義する
            textFile.TextFieldType = FileIO.FieldType.Delimited
            textFile.SetDelimiters(vbTab)
            ' --- 行を文字型配列（currentRow）に読み込み、各列を DataGridView に格納する
            Dim currentRow As String()  ' -- 文字型配列
            Dim myRow As Integer = 0
            Dim myCol As Integer = 0
            ' ---▼▼ 行ループ
            While Not textFile.EndOfData
                Me.DataGridView1.Rows.Add() ' -- DataGridView に新規行を追加
                currentRow = textFile.ReadFields()  ' -- １行を文字型配列に格納
                Dim currentColumn As String
                ' ---▼ 列ループ：１行分の列を埋める
                For Each currentColumn In currentRow
                    If (myCol > 4) Then
                        MessageBox.Show("myCol=" & myCol.ToString)
                    End If
                    Me.DataGridView1(myCol, myRow).Value = currentColumn
                    myCol += 1
                Next    ' --▲ 列ループ
                myCol = 0
                myRow += 1
            End While   ' --▲▲ 行ループ
            ' --- 入力ファイルを閉じる
            textFile.Close()
            ' ---
            Me.DataGridView1.Rows.RemoveAt(0)   ' -- 先頭行は見出し行なので削除
        End If
    End Sub
End Class
