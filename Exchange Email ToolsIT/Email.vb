<Serializable> _
Public Class Email
    Public Property De As String
    Public Property Para As String
    Public Property Assunto As String
    Public Property data As String
    Public Property Html As String
    Public Property CC As String
    Public Property anexos As New List(Of String)
    Public Property anexosid As New List(Of String)
    Public Property folder As String
    Public Property read As Boolean
    Public Property idmessage As String
    Public Property hasatt As Boolean
End Class
