Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel

Public Enum MessageType
    Authenticate = 0
    SendData = 1
    GetConfig = 2
    CloseConnection = 3
End Enum

<ServiceContract(SessionMode:=SessionMode.Required, CallBackContract:=GetType(IServiceCallback))> _
Public Interface IService
    <OperationContract(IsOneWay:=False, IsInitiating:=True, IsTerminating:=False)> _
    Function Authenticate(ByVal Name As String, ByVal Password As String) As String

    <OperationContract(IsOneWay:=True, IsInitiating:=False, IsTerminating:=False)> _
    Sub SendData(ByVal Data As String)

    <OperationContract(IsOneWay:=False, IsInitiating:=False, IsTerminating:=False)> _
    Function GetConfig(ByVal Name As String) As String

    <OperationContract(IsOneWay:=True, IsInitiating:=False, IsTerminating:=True)> _
    Sub CloseConnection()

End Interface

Public Interface IServiceCallback
    <OperationContract(IsOneWay:=True)> _
    Sub ReceiveData(ByVal Data As String)

    <OperationContract(IsOneWay:=True)> _
    Sub ReceiveAuthentication(ByVal Name As String, ByVal Password As String)

    <OperationContract(IsOneWay:=True)> _
    Sub ReceiveConfigRequest(ByVal Name As String)

    <OperationContract(IsOneWay:=True)> _
    Sub CloseRequest()

End Interface

Public Class ServiceEventArguments
    Inherits EventArgs

    Public MsgType As MessageType
    Public Name As String
    Public Msg As String
End Class

<ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerSession, ConcurrencyMode:=ConcurrencyMode.Multiple)> _
Public Class LicenseService
    Implements IService

    Private Shared syncObj As New Object()

    Dim Callback As IServiceCallback = Nothing

    Public Delegate Sub ServiceEventHandler(ByVal sender As Object, ByVal e As ServiceEventArguments)
    Public Shared Event ServiceEvent As ServiceEventHandler

    Shared Clients As Dictionary(Of String, ServiceEventHandler) = New Dictionary(Of String, ServiceEventHandler)

    Private Name As String = ""

    Private myEventHandler As ServiceEventHandler

    Public Function Authenticate(ByVal Name As String, ByVal Password As String) As String Implements IService.Authenticate
        Dim AuthenticationUID As String = ""

        ' TODO:  Authenticate the user\password combination

        Return AuthenticationUID
    End Function

    Public Sub SendData(ByVal Data As String) Implements IService.SendData
        ' TODO:  SendData()
    End Sub

    Public Function GetConfig(ByVal Name As String) As String Implements IService.GetConfig
        ' TODO:  GetConfig()
        Return ""
    End Function

    Public Sub CloseConnection() Implements IService.CloseConnection
        ' TODO:  CloseConnection()
    End Sub

End Class
