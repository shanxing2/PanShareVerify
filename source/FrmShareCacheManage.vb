Imports System.ComponentModel

Imports ShanXingTech

Public Class FrmShareCacheManage
    Private m_ShareCacheList As List(Of ShareResultDisplayEntity)
    ' 记录列头或行头是否被单击，用于在菜单弹出前判断，如果记录列头或行头被单击，则不需要弹出菜单
    Private m_IsClickColHeaderOrRowHeader As Boolean
    ' 记录排序信息，用于删除数据之后，重新加载数据时保持原来的排序
    Private m_SortInfo As (Asc As Boolean, ColumnIndex As Integer)

    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        m_SortInfo = (False, -1)

        BindData()
    End Sub

    Private Sub BindData()
        cmbErrorNo.Items.Clear()
        cmbErrorNo.Text = String.Empty

        m_ShareCacheList = New List(Of ShareResultDisplayEntity)(Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Count)
        For Each kvp In Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic
            m_ShareCacheList.Add(New ShareResultDisplayEntity(kvp.Key, kvp.Value.Fs_Ids) With {
                                 .ErrorNo = kvp.Value.ErrorNo,
                                 .Link = kvp.Value.Link,
                                 .ErrorDescription = kvp.Value.ErrorDescription,
                                 .Time = kvp.Value.Time,
                                 .ExpirationTime = kvp.Value.ExpirationTime,
                                 .Paths = kvp.Value.Paths
                                 })
        Next
        dgvShareCacheInfo.DataSource = m_ShareCacheList

        If m_SortInfo.ColumnIndex = -1 Then Return
        dgvShareCacheInfo.TrySortByColumnHeader(m_SortInfo.ColumnIndex, m_ShareCacheList)
    End Sub

    Private Sub dgvShareCacheInfo_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvShareCacheInfo.DataBindingComplete
        dgvShareCacheInfo.AdjustDgv(False, DataGridViewAutoSizeColumnsMode.Fill, DataGridViewColumnSortMode.Programmatic)

        dgvShareCacheInfo.Columns(0).HeaderText = "MD5"
        dgvShareCacheInfo.Columns(1).HeaderText = "错误代码"
        dgvShareCacheInfo.Columns(2).HeaderText = "链接"
        dgvShareCacheInfo.Columns(3).HeaderText = "错误描述"
        dgvShareCacheInfo.Columns(4).HeaderText = "分享时间"
        dgvShareCacheInfo.Columns(5).HeaderText = "路径"

        dgvShareCacheInfo.Columns(0).Width = 205
    End Sub

    Private Sub dgvShareCacheInfo_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvShareCacheInfo.ColumnHeaderMouseClick
        If e.Button = MouseButtons.Right Then Return

        If dgvShareCacheInfo.Columns(e.ColumnIndex).Name = NameOf(ShareResultCacheInfo.Link) Then Return
        If dgvShareCacheInfo.Columns(e.ColumnIndex).Name = NameOf(ShareResultCacheInfo.Paths) Then Return

        dgvShareCacheInfo.TrySortByColumnHeader(e.ColumnIndex, m_ShareCacheList)

        m_SortInfo = (Not m_SortInfo.Asc, e.ColumnIndex)
    End Sub

    Private Sub dgvShareCacheInfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShareCacheInfo.CellContentClick
        Debug.Print(Logger.MakeDebugString("要打印的字符串"))
    End Sub

    Private Sub cmbErrorNo_Click(sender As Object, e As EventArgs) Handles cmbErrorNo.Click
        If cmbErrorNo.Items.Count > 0 Then Return

        For Each sc In m_ShareCacheList.Select(Function(s) s.ErrorNo).Distinct.OrderBy(Function(sco) sco)
            cmbErrorNo.Items.Add(sc.ToString)
        Next
    End Sub

    Private Sub btnDeleteByErrorNo_Click(sender As Object, e As EventArgs) Handles btnDeleteByErrorNo.Click
        If cmbErrorNo.SelectedIndex > -1 Then
            Dim errNo = CInt(cmbErrorNo.SelectedItem)
            Dim srs = Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Where(Function(sr) sr.Value.ErrorNo = errNo).ToList
            For Each sr In srs
                If sr.Value.ErrorNo = errNo Then
                    Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Remove(sr.Key)
                End If
            Next
        End If

        If cmbErrorDescription.SelectedIndex > -1 Then
            Dim errDesc = CStr(cmbErrorDescription.SelectedItem)
            Dim srs = Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Where(Function(sr) sr.Value.ErrorDescription = errDesc).ToList
            For Each sr In srs
                If sr.Value.ErrorDescription = errDesc Then
                    Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Remove(sr.Key)
                End If
            Next
        End If

        BindData()
    End Sub

    Public Shared Sub DeleteExpirationCache()
        Dim srs = Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Where(Function(sr) sr.Value.ExpirationTime < Now).ToList
        For Each sr In srs
            Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Remove(sr.Key)
        Next
    End Sub

    Private Sub btnDeleteByErrorNoAll_Click(sender As Object, e As EventArgs) Handles btnDeleteByErrorNoAll.Click
        Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Clear()

        BindData()
    End Sub

    Private Sub cmbErrorDescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbErrorDescription.Click
        If cmbErrorDescription.Items.Count > 0 Then Return

        For Each sc In m_ShareCacheList.Where(Function(s) s.ErrorDescription IsNot Nothing).Select(Function(s) s.ErrorDescription).Distinct.OrderBy(Function(sco) sco)
            cmbErrorDescription.Items.Add(sc.ToString)
        Next
    End Sub

    Private Sub 删除选中ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除选中ToolStripMenuItem.Click
        If dgvShareCacheInfo.CurrentRow Is Nothing Then Return

        Dim shareResultMd5 = dgvShareCacheInfo.CurrentRow.Cells(0).Value
        Conf2.Instance.BdVerifierConf.Fs_Ids_Md5_ShareLinkDic.Remove(shareResultMd5.ToString)
        BindData()
    End Sub

    Private Sub dgvShareCacheInfo_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvShareCacheInfo.CellContextMenuStripNeeded
        m_IsClickColHeaderOrRowHeader = e.RowIndex = -1 OrElse e.ColumnIndex = -1
        If m_IsClickColHeaderOrRowHeader Then
            Return
        End If

        dgvShareCacheInfo.CurrentCell = dgvShareCacheInfo.Rows(e.RowIndex).Cells(e.ColumnIndex)
        dgvShareCacheInfo.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub cmsShareData_Opening(sender As Object, e As CancelEventArgs) Handles cmsShareData.Opening
        e.Cancel = m_IsClickColHeaderOrRowHeader
    End Sub

End Class