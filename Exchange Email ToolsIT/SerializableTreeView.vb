Imports System.IO
Imports System.Runtime.Serialization
Imports System.Windows.Forms
Namespace AssetBrowserControl
    ''' <summary>
    ''' Summary description for SerializableTreeView.
    ''' </summary> 
    ''' 
    <Serializable> _
    Public Class SerializableTreeView
        Inherits TreeView
        Implements ISerializable
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(info As SerializationInfo, context As StreamingContext)
            Me.New()
            Dim infoEnumerator As SerializationInfoEnumerator = info.GetEnumerator()
            While infoEnumerator.MoveNext()
                Dim node As TreeNode = TryCast(info.GetValue(infoEnumerator.Name, infoEnumerator.ObjectType), TreeNode)
                If node IsNot Nothing Then
                    Me.Nodes.Add(node)
                End If
            End While
        End Sub
        Public Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
            For Each node As TreeNode In Me.Nodes
                info.AddValue(node.FullPath, node)
            Next
        End Sub
        ''' <summary> 
        ''' Serialize all the nodes of this tree to the stream provided, using the formatter provided. 
        ''' </summary> 
        ''' <param name="stream">The stream to serialize to.</param> 
        ''' <param name="formatter">The formatter used to serialize.</param> 
        Public Sub Serialize(stream As Stream, formatter As IFormatter)
            formatter.Serialize(stream, Me)
        End Sub
        ''' <summary> 
        ''' Recreate this tree from a serialized version. 
        ''' </summary> 
        ''' <param name="stream">the stream that contains the serialized tree.</param> 
        ''' <param name="formatter">the formatter used to desrialize the stream.</param> 
        Public Sub Deserialize(stream As Stream, formatter As IFormatter)
            ' Clear our tree: 
            Me.Nodes.Clear()
            Dim temp As SerializableTreeView = TryCast(formatter.Deserialize(stream), SerializableTreeView)
            If temp IsNot Nothing Then
                ' copy the nodes from the temp to our tree: 
                For Each node As TreeNode In temp.Nodes
                    Me.Nodes.Add(TryCast(node.Clone(), TreeNode))
                Next
            End If
        End Sub
    End Class
End Namespace
