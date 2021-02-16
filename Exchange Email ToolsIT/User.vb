<Serializable> _
Public Class User

    Public Property user As String
    Public Property password As String
    Public Property server As String
    Public Property folders As New List(Of FolderList)
    Public Property PstFile As String
    Public Property assinatura As String = ""

End Class
