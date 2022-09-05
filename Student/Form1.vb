Imports System.Data
Imports Npgsql
Public Class Form1
    Dim lv As ListViewItem
    Dim Selected As String

    Public Sub PoplistView()
        ListView1.Clear()

        With ListView1
            .View = View.Details
            .GridLines = True
            .Columns.Add("Student ID", 40)
            .Columns.Add("last Name", 110)
            .Columns.Add("First Name", 110)
            .Columns.Add("MI", 110)
            .Columns.Add("Course", 110)
        End With

        opencon()
        sql = "SELECT * FROM tblstudinfo"
        cmd = New NpgsqlCommand(sql, cn)
        dr = cmd.ExecuteReader

        Do While dr.Read() = True
            lv = New ListViewItem(dr("studno").ToString)
            lv.SubItems.Add(dr("studlastname"))
            lv.SubItems.Add(dr("studfirstname"))
            lv.SubItems.Add(dr("studmiddle"))
            lv.SubItems.Add(dr("studcourse"))
            ListView1.Items.Add(lv)
        Loop
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PoplistView()

    End Sub
End Class
