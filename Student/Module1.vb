﻿Imports System.Data
Imports Npgsql
Module Module1

    Public cn As New NpgsqlConnection
    Public cmd As NpgsqlCommand
    Public dr As NpgsqlDataReader
    Public sql As String

    Public Sub opencon()
        cn.ConnectionString = "Server = localhost; port = 5432; User ID = postgres; Password = admin; Database = StudentDB"

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub
End Module
