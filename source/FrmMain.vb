Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Imports ShanXingTech
Imports ShanXingTech.Net2
Imports ShanXingTech.Net2.BaiduNetdisk

Public Class FrmMain
#Region "字段区"
    Private WithEvents m_BdVerifier As BdVerifier
    Private ReadOnly m_NodeSorter As NodeSorter
#End Region

#Region "构造函数"
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Icon = My.Resources.icon
        Me.StartPosition = FormStartPosition.CenterScreen

        tvDirectoryInfo.ContextMenuStrip = cmsDirectoryInfo
        tvDirectoryInfo.ItemHeight = 20
        tvDirectoryInfo.CheckBoxes = True

        ' 清除过期缓存
        FrmShareCacheManage.TryDeleteExpirationCache()

        m_NodeSorter = New NodeSorter()
        tvDirectoryInfo.TreeViewNodeSorter = m_NodeSorter
    End Sub
#End Region

#Region "IDisposable Support"
    ' 要检测冗余调用
    Dim isDisposed2 As Boolean = False

    ''' <summary>
    ''' 重写Dispose 以清理非托管资源
    ''' </summary>
    ''' <param name="disposing"></param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        ' 窗体内的控件调用Close或者Dispose方法时，isDisposed2的值为True
        If isDisposed2 Then Return

        Try
            ' TODO: 释放托管资源(托管对象)。
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                    components = Nothing
                End If

                Conf2.Instance.Save()
            End If

            ' TODO: 释放未托管资源(未托管对象)并在以下内容中替代 Finalize()。
            ' TODO: 将大型字段设置为 null。


            isDisposed2 = True
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '' NOTE: Leave out the finalizer altogether if this class doesn't   
    '' own unmanaged resources itself, but leave the other methods  
    '' exactly as they are.   
    'Protected Overrides Sub Finalize()
    '    Try
    '        ' Finalizer calls Dispose(false)  
    '        Dispose(False)
    '    Finally
    '        MyBase.Finalize()
    '    End Try
    'End Sub
#End Region


    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = If(Deployment.Application.ApplicationDeployment.IsNetworkDeployed,
                $"{Conf2.Instance.APPName}   V{Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()}",
                $"{Conf2.Instance.APPName}   V{Application.ProductVersion}")
        Catch ex As Exception
            Me.Text = $"{Conf2.Instance.APPName}   V{Application.ProductVersion}"
#If DEBUG Then
            ' debug模式 不记录此处的异常
            Exit Try
#End If
            Logger.Debug(ex)
        End Try

#Disable Warning BC42358 ' 由于此调用不会等待，因此在调用完成前将继续执行当前方法
        LoginAsync()
#Enable Warning BC42358 ' 由于此调用不会等待，因此在调用完成前将继续执行当前方法
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' ###################### 注意 ######################
        ' # 如果实现了IDisposble接口，则必须在 过程Protected Overrides Sub Dispose(disposing As Boolean)的
        ' # 最后调用 MyBase.Dispose(Disposing),否则无法关闭窗体
        ' # 20180806
        ' ###################### 注意 ######################
        If MessageBox.Show("确定要退出软件???", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
            e.Cancel = True
        End If
    End Sub

    Private Async Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Conf2.Instance.BdVerifierConf.BdCookies = New Net.CookieContainer

        Await LoginAsync()
    End Sub

    Private Async Function LoginAsync() As Task
        ' 如果有存储到本地的Cookie信息则先使用Cookie来测试是否仍然有效
        If Conf2.Instance.BdVerifierConf.BdCookies Is Nothing OrElse Conf2.Instance.BdVerifierConf.BdCookies.Count = 0 Then
            FrmWeb.Url = "https://pan.baidu.com/disk/home?#list/path=%2F&vmode=list"
            FrmWeb.ShowDialog()
        End If

        btnLogin.Enabled = False

        m_BdVerifier = New BdVerifier(Conf2.Instance.BdVerifierConf)
        m_NodeSorter.Order = m_BdVerifier.Order
        m_NodeSorter.Desc = m_BdVerifier.Desc

        Await LoadHomeDirInfoAsync()

        btnLogin.Enabled = True
    End Function

    Private Async Function LoadHomeDirInfoAsync() As Task
        Dim root = Await m_BdVerifier.GetHomeDirInfoAsync()

#Disable Warning BC42104 ' 在为变量赋值之前，变量已被使用
        If root Is Nothing Then Return
#Enable Warning BC42104 ' 在为变量赋值之前，变量已被使用

        Dim imgList As New ImageList
        imgList.Images.Add(Image.FromFile(".\res\folder.png"))
        imgList.Images.Add(Image.FromFile(".\res\file.png"))
        tvDirectoryInfo.ImageList = imgList

        tvDirectoryInfo.BeginUpdate()
        tvDirectoryInfo.Nodes.Clear()
        AppendSubNode(tvDirectoryInfo.Nodes, root.list)
        tvDirectoryInfo.EndUpdate()
    End Function

    Private Sub AppendSubNode(ByRef nodes As TreeNodeCollection, ByVal list As List(Of BdVerifier.DirectoryEntity.List))
        If list Is Nothing Then Return

        For Each d In list
            Dim node As TreeNode
            If 1 = d.isdir Then
                'If d.dir_empty = 1 Then
                '    node = New TreeNode(d.server_filename, 0, 0)
                'Else
                ' 非空文件夹才可以展开（显示 +-）
                Dim childNodes = New List(Of TreeNode) From {
                        New TreeNode("获取中...")
                    }
                node = New TreeNode(d.server_filename, 0, 0, childNodes.ToArray)
                'End If
            Else
                node = New TreeNode(d.server_filename, 1, 1)
            End If
            node.Tag = New BdVerifier.PathInfo(d.fs_id, d.isdir = 1) With {
                .Size = d.size,
                .ModifyTime = d.server_mtime}
            nodes.Add(node)
        Next
    End Sub

    Private Sub tvDirectoryInfo_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvDirectoryInfo.NodeMouseClick
        ' 左键单击
        If e.Button = MouseButtons.Left AndAlso e.Clicks = 1 Then
            tvDirectoryInfo.SelectedNode = e.Node
            CheckingSubNode(e)
            Return
        End If

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
            Dim root = Await m_BdVerifier.GetDirInfoAsync(path)
            tvDirectoryInfo.BeginUpdate()
            e.Node.Nodes.Clear()
            AppendSubNode(e.Node.Nodes, root.list)

            ' 勾选所有子目录
            CheckSubNode(e)
        Catch ex As Exception
            Logger.WriteLine(ex)
        Finally
            tvDirectoryInfo.EndUpdate()
            'tvDirectoryInfo.Enabled = True
        End Try
    End Function

    ''' <summary>
    ''' 勾选
    ''' </summary>
    ''' <param name="e"></param>
    Private Sub CheckingSubNode(e As TreeNodeMouseClickEventArgs)
        Dim tag = DirectCast(e.Node.Tag, BdVerifier.PathInfo)
        If tag.IsDir Then
            For Each node As TreeNode In e.Node.Nodes
                node.Checked = e.Node.Checked
            Next
        End If
    End Sub

    Private Sub CheckSubNode(e As TreeViewEventArgs)
        Dim tag = DirectCast(e.Node.Tag, BdVerifier.PathInfo)
        If tag.IsDir Then
            For Each node As TreeNode In e.Node.Nodes
                node.Checked = e.Node.Checked
            Next
        End If
    End Sub

    Private Async Sub 检测ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检测ToolStripMenuItem.Click
        Dim path = GetSelectedNode(tvDirectoryInfo)

        If path.Count = 0 Then Return

        Try
            tvDirectoryInfo.Enabled = False
            txtVerifyReport.Text = String.Empty
            AppendLog("检测开始")
            lblStatus.Text = "检测开始"

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
    Private Function GetSelectedNode(ByVal tv As TreeView) As List(Of BdVerifier.PathInfo)
        If tv Is Nothing Or tv.SelectedNode Is Nothing Then Return New List(Of BdVerifier.PathInfo)

        Dim parentOfSelectNode = If(tv.SelectedNode.Parent Is Nothing, tv.Nodes, tv.SelectedNode.Parent.Nodes)
        If parentOfSelectNode Is Nothing Then
            Return New List(Of BdVerifier.PathInfo)
        End If

        Dim path As New List(Of BdVerifier.PathInfo)
        GetSelectedNode(parentOfSelectNode, path)

        Return path
    End Function

    Private Sub GetSelectedNode(ByVal trc As TreeNodeCollection, ByRef path As List(Of BdVerifier.PathInfo))
        For Each node As TreeNode In trc
            If node.Checked Then
                Dim newNode = TryCast(node.Tag, BdVerifier.PathInfo)
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
        If tvDirectoryInfo Is Nothing Or tvDirectoryInfo.SelectedNode Is Nothing Then Return

        Try
            tvDirectoryInfo.Enabled = False
            txtVerifyReport.Text = String.Empty
            AppendLog("分享开始")

            Dim rst = Await m_BdVerifier.ShareAsync(DirectCast(tvDirectoryInfo.SelectedNode.Tag, BdVerifier.PathInfo).Id.ToStringOfCulture, Conf2.Instance.BdVerifierConf.ShareExpirationDate, Conf2.Instance.BdVerifierConf.SharePrivatePassword)

            Dim root = MSJsSerializer.Deserialize(Of BdVerifier.ShareResultEntity.Root)(rst.Message)
            If root Is Nothing Then Return

            If root.errno = 0 Then
                Dim shareInfo = $"分享链接：{root.link} 提取码：{Conf2.Instance.BdVerifierConf.SharePrivatePassword}"
                CopyToClipboard(shareInfo)

                Dim sb As New StringBuilder
                sb.AppendLine(root.show_msg)
                sb.Append(shareInfo)
                sb.Append("有效期：").AppendLine(Conf2.Instance.BdVerifierConf.ShareExpirationDate.GetDescription)
                AppendLog(sb.ToString)
            End If
        Catch ex As Exception
            Logger.WriteLine(ex)
        Finally
            AppendLog("分享完毕，分享链接已复制到粘贴板")
            tvDirectoryInfo.Enabled = True
        End Try
    End Sub

    Private Async Sub 重新加载ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重新加载ToolStripMenuItem.Click
        Await LoadHomeDirInfoAsync()
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        检测ToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btnShare_Click(sender As Object, e As EventArgs) Handles btnShare.Click
        分享ToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        重新加载ToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btnCheckCache_Click(sender As Object, e As EventArgs) Handles btnCheckCache.Click
        Using frm As New FrmShareCacheManage
            frm.Icon = Me.Icon
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.WindowState = FormWindowState.Maximized
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        Using frm As New FrmSetting
            frm.Icon = Me.Icon
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub btnCancelCheck_Click(sender As Object, e As EventArgs) Handles btnCancelCheck.Click
        m_BdVerifier.Cancel()
    End Sub

    Private Sub 排序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 大小ToolStripMenuItem.Click, 文件名ToolStripMenuItem.Click, 修改日期ToolStripMenuItem.Click
        Dim tsm = DirectCast(sender, ToolStripMenuItem)
        If tsm Is Nothing Then Return

        Dim order As OrderMode
        Select Case tsm.Name
            Case 文件名ToolStripMenuItem.Name
                order = OrderMode.name
            Case 大小ToolStripMenuItem.Name
                order = OrderMode.size
            Case 修改日期ToolStripMenuItem.Name
                order = OrderMode.time
        End Select

        m_BdVerifier.ChangeOrder(order)
        m_NodeSorter.Order = m_BdVerifier.Order

        m_BdVerifier.ChangeDesc(Not m_BdVerifier.Desc)
        For Each t As ToolStripItem In 排序ToolStripMenuItem.DropDownItems
            t.Image = Nothing
        Next
        tsm.Image = If(m_BdVerifier.Desc, My.Resources.arrow_down, My.Resources.arrow_up)
        m_NodeSorter.Desc = m_BdVerifier.Desc

        tvDirectoryInfo.Sort()
    End Sub

    ''' <summary>
    ''' 复制数据到系统粘贴板
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="tipsDisplayControl">在哪个控件/窗体上显示提示</param>
    Private Sub CopyToClipboard(ByVal data As String)
        Try
            Clipboard.SetDataObject(data, False, 3, 100)
        Catch ex As Exception
            '
        End Try
    End Sub
End Class

