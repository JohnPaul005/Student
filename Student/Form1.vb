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
            .Columns.Add("Student ID", 60)
            .Columns.Add("last Name", 90)
            .Columns.Add("First Name", 90)
            .Columns.Add("MI", 60)
            .Columns.Add("Address", 90)
            .Columns.Add("Gender", 90)
            .Columns.Add("Contact", 90)
            .Columns.Add("Course", 90)
        End With

        opencon()
        sql = "SELECT * FROM tblstudinfo"
        cmd = New NpgsqlCommand(sql, cn)
        dr = cmd.ExecuteReader

        Do While dr.Read() = True
            lv = New ListViewItem(dr("studno").ToString)
            lv.SubItems.Add(dr("studlastname").ToString)
            lv.SubItems.Add(dr("studfirstname").ToString)
            lv.SubItems.Add(dr("studmiddle").ToString)
            lv.SubItems.Add(dr("studaddress").ToString)
            lv.SubItems.Add(dr("studgender").ToString)
            lv.SubItems.Add(dr("studcontact").ToString)
            lv.SubItems.Add(dr("studcourse").ToString)
            ListView1.Items.Add(lv)
        Loop
        cn.Close()
    End Sub
    Private Sub ClearAllTextbox()
        txtstudentno.Clear()
        txtlastname.Clear()
        txtfirstname.Clear()
        txtmiddle.Clear()
        txtcontact.Clear()
        txtaddress.Clear()
        cmbcourse.Text = ""
        cmbgender.Text = ""
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PoplistView()

    End Sub

    Private Sub btnaddnew_Click(sender As Object, e As EventArgs) Handles btnaddnew.Click
        opencon()
        If MsgBox("Are you really really want to save???", vbQuestion + vbYesNo) Then

            sql = "INSERT INTO tblstudinfo (studno, studlastname, studfirstname, studmiddle, studaddress, studgender, studcontact, studcourse)" & "VALUES ('" & (Me.txtstudentno.Text) & "', '" & (Me.txtlastname.Text) & "', '" & (Me.txtfirstname.Text) & "', '" & (Me.txtmiddle.Text) & "', '" & (Me.txtaddress.Text) & "', '" & (Me.cmbgender.Text) & "', '" & (Me.txtcontact.Text) & "', '" & (Me.cmbcourse.Text) & "')"
            cmd = New NpgsqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        End If
        ClearAllTextbox()
        PoplistView()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If MsgBox("Are you really really want to Update this name???", vbQuestion + vbYesNo) = vbYes Then
            opencon()
            sql = "Update tblstudinfo set studlastname = '" & txtlastname.Text & "', studfirstname = '" & txtfirstname.Text & "', studmiddle = '" & txtmiddle.Text & "', studaddress = '" & txtaddress.Text & "', studgender = '" & cmbgender.Text & "', studcontact = '" & txtcontact.Text & "', studcourse = '" & cmbcourse.Text & "' where studno = '" & (txtstudentno.Text).ToString & "'"
            cmd = New NpgsqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            cn.Close()
            PoplistView()
            ClearAllTextbox()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim i As Integer
        For i = 0 To ListView1.SelectedItems.Count - 1

            Selected = ListView1.SelectedItems(i).Text
            opencon()
            sql = "Select * from tblstudinfo where studno = ' " & Selected & "'"
            cmd = New NpgsqlCommand(sql, cn)
            dr = cmd.ExecuteReader

            dr.Read()
            Me.txtstudentno.Text = dr("studno").ToString
            Me.txtlastname.Text = dr("studlastname").ToString
            Me.txtfirstname.Text = dr("studfirstname").ToString
            Me.txtmiddle.Text = dr("studmiddle").ToString
            Me.txtaddress.Text = dr("studaddress").ToString
            Me.cmbgender.Text = dr("studgender").ToString
            Me.txtcontact.Text = dr("studcontact").ToString
            Me.cmbcourse.Text = dr("studcourse").ToString
            cn.Close()
        Next
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        opencon()
        If MsgBox("Are you really really want to delete this name???", vbQuestion + vbYesNo) Then
            sql = "Delete from tblstudinfo where studno = ' " & txtstudentno.Text & "'"
            cmd = New NpgsqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            cn.Close()
        End If
        ClearAllTextbox()
        PoplistView()
    End Sub
End Class
