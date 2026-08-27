Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.Configuration

    Public Class frmMain

    Dim uri As New Uri(My.Settings.Address)
    Dim Host As ServiceHost = New ServiceHost(GetType(LicenseService), uri)

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        ' TODO:  Ensure the Service starts cleanly

        Try
            If Host.State = CommunicationState.Closed Then
                Host.Open()
                Debug.WriteLine("Host is now listening")
            ElseIf Host.State = CommunicationState.Created Then
                Debug.WriteLine("Host instance has been created")
            Else
                'Host.Abort()
                'Host.Close()
                'Host.Open()
                Select Case Host.State
                    Case CommunicationState.Closing
                        Debug.WriteLine("Error:  Host is already closing")
                    Case CommunicationState.Faulted
                        Debug.WriteLine("Error:  Host is in an error state")
                    Case CommunicationState.Opened
                        Debug.WriteLine("Error:  Host is already open")
                    Case CommunicationState.Opening
                        Debug.WriteLine("Error:  Host is already opening")
                End Select
            End If
        Catch
            Debug.WriteLine("Error encountered whilst trying to start Host")
        End Try
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click

        Try
            Host.Abort()

            Host.Close()

            Debug.WriteLine("Host has now stopped listening")
        Catch
            Debug.WriteLine("Error encountered whilst trying to close Host")
        End Try
    End Sub
End Class