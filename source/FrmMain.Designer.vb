<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    ''Form 重写 Dispose，以清理组件列表。
    '<System.Diagnostics.DebuggerNonUserCode()>
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.tvDirectoryInfo = New System.Windows.Forms.TreeView()
        Me.cmsDirectoryInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.检测ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.分享ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.重新加载ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.排序ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.文件名ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.大小ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.修改日期ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtVerifyReport = New System.Windows.Forms.TextBox()
        Me.chkCheckAll = New System.Windows.Forms.CheckBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnCancelCheck = New System.Windows.Forms.Button()
        Me.btnCheckCache = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.btnShare = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.cmsDirectoryInfo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(66, 14)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 0
        Me.btnLogin.Text = "登录"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'tvDirectoryInfo
        '
        Me.tvDirectoryInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvDirectoryInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvDirectoryInfo.Location = New System.Drawing.Point(1, 1)
        Me.tvDirectoryInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.tvDirectoryInfo.Name = "tvDirectoryInfo"
        Me.tvDirectoryInfo.Size = New System.Drawing.Size(774, 292)
        Me.tvDirectoryInfo.TabIndex = 7
        '
        'cmsDirectoryInfo
        '
        Me.cmsDirectoryInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.检测ToolStripMenuItem, Me.分享ToolStripMenuItem, Me.重新加载ToolStripMenuItem, Me.排序ToolStripMenuItem})
        Me.cmsDirectoryInfo.Name = "cmsDirectoryInfo"
        Me.cmsDirectoryInfo.Size = New System.Drawing.Size(125, 92)
        '
        '检测ToolStripMenuItem
        '
        Me.检测ToolStripMenuItem.Name = "检测ToolStripMenuItem"
        Me.检测ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.检测ToolStripMenuItem.Text = "检测"
        '
        '分享ToolStripMenuItem
        '
        Me.分享ToolStripMenuItem.Name = "分享ToolStripMenuItem"
        Me.分享ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.分享ToolStripMenuItem.Text = "分享"
        '
        '重新加载ToolStripMenuItem
        '
        Me.重新加载ToolStripMenuItem.Name = "重新加载ToolStripMenuItem"
        Me.重新加载ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.重新加载ToolStripMenuItem.Text = "重新加载"
        '
        '排序ToolStripMenuItem
        '
        Me.排序ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件名ToolStripMenuItem, Me.大小ToolStripMenuItem, Me.修改日期ToolStripMenuItem})
        Me.排序ToolStripMenuItem.Name = "排序ToolStripMenuItem"
        Me.排序ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.排序ToolStripMenuItem.Text = "排序"
        '
        '文件名ToolStripMenuItem
        '
        Me.文件名ToolStripMenuItem.Name = "文件名ToolStripMenuItem"
        Me.文件名ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.文件名ToolStripMenuItem.Text = "文件名"
        '
        '大小ToolStripMenuItem
        '
        Me.大小ToolStripMenuItem.Name = "大小ToolStripMenuItem"
        Me.大小ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.大小ToolStripMenuItem.Text = " 大小"
        '
        '修改日期ToolStripMenuItem
        '
        Me.修改日期ToolStripMenuItem.Name = "修改日期ToolStripMenuItem"
        Me.修改日期ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.修改日期ToolStripMenuItem.Text = "修改日期"
        '
        'txtVerifyReport
        '
        Me.txtVerifyReport.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVerifyReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVerifyReport.Location = New System.Drawing.Point(1, 313)
        Me.txtVerifyReport.Margin = New System.Windows.Forms.Padding(0)
        Me.txtVerifyReport.Multiline = True
        Me.txtVerifyReport.Name = "txtVerifyReport"
        Me.txtVerifyReport.ReadOnly = True
        Me.txtVerifyReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVerifyReport.Size = New System.Drawing.Size(774, 194)
        Me.txtVerifyReport.TabIndex = 2
        '
        'chkCheckAll
        '
        Me.chkCheckAll.AutoSize = True
        Me.chkCheckAll.Location = New System.Drawing.Point(12, 18)
        Me.chkCheckAll.Name = "chkCheckAll"
        Me.chkCheckAll.Size = New System.Drawing.Size(48, 16)
        Me.chkCheckAll.TabIndex = 1
        Me.chkCheckAll.Text = "全选"
        Me.chkCheckAll.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoEllipsis = True
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblStatus.Location = New System.Drawing.Point(4, 297)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(3)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(29, 12)
        Me.lblStatus.TabIndex = 13
        Me.lblStatus.Text = "状态"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 576)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(629, 12)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "软件检测思路是先分享，再查看，查看不到就是有违规文件，因此，有时候会检测不出来，因为不是马上被检测到违规"
        '
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(228, 14)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(75, 23)
        Me.btnSetting.TabIndex = 15
        Me.btnSetting.Text = "设置"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnCancelCheck
        '
        Me.btnCancelCheck.Location = New System.Drawing.Point(552, 14)
        Me.btnCancelCheck.Name = "btnCancelCheck"
        Me.btnCancelCheck.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelCheck.TabIndex = 19
        Me.btnCancelCheck.Text = "取消检测"
        Me.btnCancelCheck.UseVisualStyleBackColor = True
        '
        'btnCheckCache
        '
        Me.btnCheckCache.Location = New System.Drawing.Point(147, 14)
        Me.btnCheckCache.Name = "btnCheckCache"
        Me.btnCheckCache.Size = New System.Drawing.Size(75, 23)
        Me.btnCheckCache.TabIndex = 20
        Me.btnCheckCache.Text = "缓存管理"
        Me.btnCheckCache.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tvDirectoryInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtVerifyReport, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 43)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(776, 530)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(309, 14)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(75, 23)
        Me.btnVerify.TabIndex = 22
        Me.btnVerify.Text = "检测"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'btnShare
        '
        Me.btnShare.Location = New System.Drawing.Point(390, 14)
        Me.btnShare.Name = "btnShare"
        Me.btnShare.Size = New System.Drawing.Size(75, 23)
        Me.btnShare.TabIndex = 23
        Me.btnShare.Text = "分享"
        Me.btnShare.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(471, 14)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(75, 23)
        Me.btnReload.TabIndex = 24
        Me.btnReload.Text = "重新加载"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 597)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.btnShare)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnCheckCache)
        Me.Controls.Add(Me.btnCancelCheck)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkCheckAll)
        Me.Controls.Add(Me.btnLogin)
        Me.DoubleBuffered = True
        Me.Name = "FrmMain"
        Me.Text = "网盘违规文件检测姬 By 胖头鱼煲汤好好次 Q2287190283"
        Me.cmsDirectoryInfo.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogin As Button
    Friend WithEvents tvDirectoryInfo As TreeView
    Friend WithEvents cmsDirectoryInfo As ContextMenuStrip
    Friend WithEvents 检测ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtVerifyReport As TextBox
    Friend WithEvents chkCheckAll As CheckBox
    Friend WithEvents 分享ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSetting As Button
    Friend WithEvents btnCancelCheck As Button
    Friend WithEvents btnCheckCache As Button
    Friend WithEvents 重新加载ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnVerify As Button
    Friend WithEvents btnShare As Button
    Friend WithEvents btnReload As Button
    Friend WithEvents 排序ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 文件名ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 大小ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 修改日期ToolStripMenuItem As ToolStripMenuItem
End Class
