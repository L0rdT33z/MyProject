Imports System.Runtime.InteropServices
Public Class Form1

    <DllImport("user32.dll")> Private Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private Const SW_HIDE As Integer = &H0
    Private Const SW_SHOW As Integer = &H5

    Private HiddenWindowHandle As IntPtr = IntPtr.Zero

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p As Process = Process.GetProcessesByName(TextBox1.Text).FirstOrDefault
        If p IsNot Nothing Then
            HiddenWindowHandle = p.MainWindowHandle 'save the window handle in a class scoped IntPtr type variable
            ShowWindow(HiddenWindowHandle, SW_HIDE) 'now hide the window
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim p As Process = Process.GetProcessesByName(TextBox1.Text).FirstOrDefault 'the process will still be found using this Process method
        If p IsNot Nothing Then 'make sure the process is still running
            ShowWindow(HiddenWindowHandle, SW_SHOW) 'use the saved handle to show the window again
            Button1.Enabled = True
        End If
    End Sub
End Class
