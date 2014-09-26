Imports System.IO

Public Class CVSFileUtil

    Private Shared _message As String

    Public Shared ReadOnly Property Message() As String
        Get
            Return _message
        End Get
    End Property

    Public Shared Function Write(ByVal strData As String, ByVal strFileName As String) As Boolean
        Try
            _message = String.Empty
            If File.Exists(strFileName) Then
                File.Delete(strFileName)
            End If

            Dim sw As New StreamWriter(File.Create(strFileName))

            sw.AutoFlush = True
            sw.WriteLine(strData)
            sw.Close()
            Return True
        Catch ex As Exception
            _message = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function WriteCNC(ByVal strData As String, ByVal strFileName As String) As Boolean
        Try
            _message = String.Empty
            If File.Exists(strFileName) Then
                File.Delete(strFileName)
            End If

            Dim sw As New StreamWriter(File.Create(strFileName))

            sw.AutoFlush = True
            sw.Write(strData)
            sw.Close()
            Return True
        Catch ex As Exception
            _message = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function isFolder(ByVal strFolderPath As String) As Boolean
        Try
            _message = String.Empty
            If Directory.Exists(strFolderPath) Then
                Return True
            End If
            Return False
        Catch ex As Exception
            _message = "Failed to test the folder path"
            Return False
        End Try
    End Function

    Public Shared Function Check(ByVal strSourcePath As String, ByVal strDestinationPath As String) As Boolean
        Try
            _message = String.Empty
            If Not File.Exists(strSourcePath) Then
                Return False
            End If
            If Not File.Exists(strDestinationPath) Then
                Return False
            End If

            Dim Source As New StreamReader(File.OpenRead(strSourcePath))
            Dim Destination As New StreamReader(File.OpenRead(strDestinationPath))

            While (Not Source.EndOfStream)
                Dim strSource As String = Source.ReadLine
                Dim strDestination As String = Destination.ReadLine
                If Not strSource.Equals(strDestination) Then
                    MessageBox.Show(strSource & " - " & strDestination)
                    Return False
                End If
            End While

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
