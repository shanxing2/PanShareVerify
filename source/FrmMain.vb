Imports System.Text
Imports System.Text.RegularExpressions
Imports ShanXingTech
Imports ShanXingTech.Net2
Imports ShanXingTech.Net2.BdVerifier

Public Class FrmMain
#Region "字段区"
    Private WithEvents m_BdVerifier As BdVerifier
#End Region

#Region "构造函数"
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.StartPosition = FormStartPosition.CenterScreen

        tvDirectoryInfo.ContextMenuStrip = cmsDirectoryInfo
        tvDirectoryInfo.ItemHeight = 20
        tvDirectoryInfo.CheckBoxes = True

    End Sub
#End Region


    Private Async Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        FrmWeb.Url = "https://pan.baidu.com/disk/home?#list/path=%2F&vmode=list"
        FrmWeb.ShowDialog()

        Try
            btnLogin.Enabled = False

            Dim loginedInfo = BdVerifier.GetLoginInfo(Operate.Html)
            m_BdVerifier = New BdVerifier(Operate.Cookies, loginedInfo.BdsToken, loginedInfo.BdUSS)
            Await LoadHomeDirInfoAsync()
        Catch ex As Exception
            Logger.WriteLine(ex)
        Finally
            btnLogin.Enabled = True
        End Try
    End Sub

    Private Async Function LoadHomeDirInfoAsync() As Task
        Dim getRst = Await m_BdVerifier.GetHomeDirInfoAsync
        If Not getRst.Success Then
            Windows2.DrawTipsTask(Me, "获取网盘首页目录失败", 1000, False, False)
            Return
        End If

        Dim root = MSJsSerializer.Deserialize(Of DirectoryEntity.Root)(getRst.Message)

        Dim imgList As New ImageList
        imgList.Images.Add(Image.FromFile(".\res\folder.png"))
        imgList.Images.Add(Image.FromFile(".\res\file.png"))
        tvDirectoryInfo.ImageList = imgList

        tvDirectoryInfo.BeginUpdate()
        tvDirectoryInfo.Nodes.Clear()
        AppendSubNode(tvDirectoryInfo.Nodes, root.list)
        tvDirectoryInfo.EndUpdate()
    End Function

    Private Sub AppendSubNode(ByRef nodes As TreeNodeCollection, ByVal list As List(Of DirectoryEntity.List))
        If list Is Nothing Then Return

        For Each d In list
            Dim node As TreeNode
            If 1 = d.isdir Then
                'If d.dir_empty = 0 Then
                ' 非空文件夹才可以展开（显示 +-）
                Dim childNodes = New List(Of TreeNode) From {
                        New TreeNode("获取中...")
                    }
                node = New TreeNode(d.server_filename, 0, 0, childNodes.ToArray)
                'Else
                '    node = New TreeNode(d.server_filename, 0, 0)
                'End If
            Else
                node = New TreeNode(d.server_filename, 1, 1)
            End If
            node.Tag = New PathInfo(d.fs_id, d.isdir = 1)
            nodes.Add(node)
        Next
    End Sub

    Private Sub tvDirectoryInfo_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvDirectoryInfo.NodeMouseClick
        ' 右键单击时设置选中项
        If e.Button = MouseButtons.Right AndAlso e.Clicks = 1 Then
            tvDirectoryInfo.SelectedNode = e.Node
            Return
        End If
    End Sub

    Private Async Sub tvDirectoryInfo_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles tvDirectoryInfo.AfterExpand
        Await LoadSubNodeAsync(e)
    End Sub

    Private Async Function LoadSubNodeAsync(e As TreeViewEventArgs) As Task
        Try
            'tvDirectoryInfo.Enabled = False

            ' 动态添加子目录
            Dim path = "/" & e.Node.FullPath.Replace("\", "/")
            Dim getRst = Await m_BdVerifier.GetDirInfoAsync(path)
            Dim root = MSJsSerializer.Deserialize(Of DirectoryEntity.Root)(getRst.Message)
            tvDirectoryInfo.BeginUpdate()
            e.Node.Nodes.Clear()
            AppendSubNode(e.Node.Nodes, root.list)

            ' 勾选所有子目录
            Dim tag = DirectCast(e.Node.Tag, PathInfo)
            If tag.IsDir Then
                For Each node As TreeNode In e.Node.Nodes
                    node.Checked = e.Node.Checked
                Next
            End If
        Catch ex As Exception
            Logger.WriteLine(ex)
        Finally
            tvDirectoryInfo.EndUpdate()
            'tvDirectoryInfo.Enabled = True
        End Try
    End Function


    Private Async Sub 检测ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检测ToolStripMenuItem.Click
        Try
            tvDirectoryInfo.Enabled = False
            txtVerifyReport.Text = String.Empty
            AppendLog("检测开始")
            lblStatus.Text = "检测开始"
            Dim path = GetSelectedNode(tvDirectoryInfo)

            If path.Count = 0 Then Return

            Await m_BdVerifier.CheckAsync(path)
        Catch ex As Exception
            Logger.WriteLine(ex)
        Finally
            AppendLog("检测完毕")
            lblStatus.Text = "检测完毕"
            tvDirectoryInfo.Enabled = True
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tv"></param>
    ''' <returns></returns>
    Private Function GetSelectedNode(ByVal tv As TreeView) As List(Of PathInfo)
        Dim parentOfSelectNode = If(tv.SelectedNode.Parent Is Nothing, tv.Nodes, tv.SelectedNode.Parent.Nodes)
        If parentOfSelectNode Is Nothing Then
            Return New List(Of PathInfo)
        End If

        Dim path As New List(Of PathInfo)
        GetSelectedNode(parentOfSelectNode, path)

        Return path
    End Function

    Private Sub GetSelectedNode(ByVal trc As TreeNodeCollection, ByRef path As List(Of PathInfo))
        For Each node As TreeNode In trc
            If node.Checked Then
                Dim newNode = TryCast(node.Tag, PathInfo)
                newNode.FullPath = node.FullPath
                path.Add(newNode)
                Continue For
            End If

            GetSelectedNode(node.Nodes, path)
        Next
    End Sub

    Private Sub cmsDirectoryInfo_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsDirectoryInfo.Opening
        If tvDirectoryInfo.Nodes.Count = 0 Then
            e.Cancel = True
            Return
        End If
    End Sub

    Private Sub m_BdVerifier_CheckReport(sender As Object, e As BdVerifier.CheckReportEventArgs) Handles m_BdVerifier.CheckReport
        AppendLog(e.Message)
    End Sub

    Private Sub m_BdVerifier_Browsing(sender As Object, e As BdVerifier.BrowsingEventArgs) Handles m_BdVerifier.Browsing
        lblStatus.Text = e.Status
    End Sub

    Private Sub AppendLog(ByVal log As String)
        txtVerifyReport.AppendText(log)
        txtVerifyReport.AppendText(Environment.NewLine)
        txtVerifyReport.AppendText(Environment.NewLine)
    End Sub
    Private Sub chkCheckAll_Click(sender As Object, e As EventArgs) Handles chkCheckAll.Click
        SetTreeNodeCheckState(tvDirectoryInfo.Nodes)
    End Sub

    Private Sub SetTreeNodeCheckState(ByRef tnc As TreeNodeCollection)
        For Each node As TreeNode In tnc
            node.Checked = chkCheckAll.Checked
            SetTreeNodeCheckState(node.Nodes)
        Next
    End Sub

    Private Async Sub 分享ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 分享ToolStripMenuItem.Click
        Try
            tvDirectoryInfo.Enabled = False
            txtVerifyReport.Text = String.Empty
            AppendLog("分享开始")
            Dim pwd = "ptyo"
            Dim rst = Await m_BdVerifier.ShareAsync(DirectCast(tvDirectoryInfo.SelectedNode.Tag, PathInfo).Id.ToStringOfCulture, ShareExpirationDate.Forever, pwd)

            Dim root = MSJsSerializer.Deserialize(Of ShareResultEntity.Root)(rst.Message)
            If root Is Nothing Then Return

            If root.errno = 0 Then
                Dim sb As New StringBuilder
                sb.AppendLine(GetShareErrorNoDescription(root.errno))
                sb.Append("分享链接：").Append(root.link).Append(" 提取码：").AppendLine(pwd)
                sb.Append("有效期：").AppendLine(ShareExpirationDate.Forever.GetDescription)
                AppendLog(sb.ToString)
            End If
        Catch ex As Exception
            Logger.WriteLine(ex)
        Finally
            AppendLog("分享完毕")
            tvDirectoryInfo.Enabled = True
        End Try
    End Sub

    Private Sub chkCheckAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheckAll.CheckedChanged
        Debug.Print(Logger.MakeDebugString("要打印的字符串"))
    End Sub
End Class
