Public Class processThread
    Shared messages As New List(Of String)
    Shared t As New List(Of Threading.Thread)
    Shared f As New List(Of frmProcess)

    Public Sub New()

    End Sub


    Public Shared Sub Show(ByVal message As String)
        Try
            f.Add(New frmProcess)
            AddHandler f.Last.Disposed, AddressOf formDisposed
            t.Add(New Threading.Thread(AddressOf showForm))
            t.Last.Start(message)

        Catch ex As Exception

        End Try

    End Sub

    <Runtime.InteropServices.DllImport("User32.dll")> _
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As IntPtr
    End Function
    <Runtime.InteropServices.DllImport("User32.dll")> _
    Private Shared Function ShowWindow(ByVal hWnd As IntPtr, _
            ByVal nCmdShow As Integer) As IntPtr
    End Function

    Private Shared Sub formDisposed()
        Try
            Dim procs() As Process = _
                Process.GetProcessesByName(My.Application.Info.AssemblyName)
            If procs.Length = 1 Then
                ' the previously running instance will be at either index 0 or 1
                Dim index As Integer
                If CInt(procs(0).MainWindowHandle) <> 0 Then
                    index = 0
                Else
                    index = 1
                End If

                SetForegroundWindow(procs(index).MainWindowHandle)

                ShowWindow(procs(index).MainWindowHandle, 8) '8=SW_SHOWNA
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub Close()
        Try
            If f.Count > 0 Then
                f.Last.TIMERON = False
                f.RemoveAt(f.Count - 1)
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Shared Sub showForm(ByVal message As String)
        Try
            If message IsNot Nothing AndAlso f.Count > 0 Then
                f.Last.ShowDialog(message)
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
