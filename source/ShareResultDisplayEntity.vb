Partial Class FrmShareCacheManage
    Public Class ShareResultDisplayEntity
        Inherits ShareResultCacheInfo

        Public Property Md5 As String

        Public Sub New(md5 As String, fs_Ids As String)
            MyBase.New(fs_Ids)
            Me.Md5 = md5
        End Sub
    End Class

End Class
