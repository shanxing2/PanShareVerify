Imports ShanXingTech.Net2
Imports ShanXingTech.Net2.BaiduNetdisk

Public Class NodeSorter
    Implements IComparer

    Private _Order As OrderMode
    Private _Desc As Boolean

    Public Property Order As OrderMode
        Get
            Return _Order
        End Get
        Set(value As OrderMode)
            _Order = value
        End Set
    End Property

    Public Property Desc As Boolean
        Get
            Return _Desc
        End Get
        Set(value As Boolean)
            _Desc = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal order As OrderMode, ByVal desc As Boolean)
        Me._Order = order
        Me._Desc = desc
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) _
        As Integer Implements IComparer.Compare
        Dim tnX As TreeNode = DirectCast(x, TreeNode)
        Dim tnY As TreeNode = DirectCast(y, TreeNode)

        Dim pathX = DirectCast(tnX.Tag, BdVerifier.PathInfo)
        Dim pathY = DirectCast(tnY.Tag, BdVerifier.PathInfo)

        Dim order As Integer
        Select Case _Order
            Case OrderMode.name
                order = String.Compare(tnX.Text, tnY.Text)
            Case OrderMode.size
                order = CInt(pathX.Size - pathY.Size)
            Case OrderMode.time
                order = CInt(pathX.ModifyTime - pathY.ModifyTime)
        End Select

        Return If(_Desc, 0 - order, order)
    End Function
End Class
