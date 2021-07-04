<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

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
        Me.txtVerifyReport = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkCheckAll = New System.Windows.Forms.CheckBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmsDirectoryInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(12, 12)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 0
        Me.btnLogin.Text = "登录"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'tvDirectoryInfo
        '
        Me.tvDirectoryInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvDirectoryInfo.Location = New System.Drawing.Point(12, 43)
        Me.tvDirectoryInfo.Name = "tvDirectoryInfo"
        Me.tvDirectoryInfo.Size = New System.Drawing.Size(776, 343)
        Me.tvDirectoryInfo.TabIndex = 7
        '
        'cmsDirectoryInfo
        '
        Me.cmsDirectoryInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.检测ToolStripMenuItem, Me.分享ToolStripMenuItem})
        Me.cmsDirectoryInfo.Name = "cmsDirectoryInfo"
        Me.cmsDirectoryInfo.Size = New System.Drawing.Size(101, 48)
        '
        '检测ToolStripMenuItem
        '
        Me.检测ToolStripMenuItem.Name = "检测ToolStripMenuItem"
        Me.检测ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.检测ToolStripMenuItem.Text = "检测"
        '
        '分享ToolStripMenuItem
        '
        Me.分享ToolStripMenuItem.Name = "分享ToolStripMenuItem"
        Me.分享ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.分享ToolStripMenuItem.Text = "分享"
        '
        'txtVerifyReport
        '
        Me.txtVerifyReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVerifyReport.Location = New System.Drawing.Point(12, 404)
        Me.txtVerifyReport.Multiline = True
        Me.txtVerifyReport.Name = "txtVerifyReport"
        Me.txtVerifyReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVerifyReport.Size = New System.Drawing.Size(776, 181)
        Me.txtVerifyReport.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 389)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "日志："
        '
        'chkCheckAll
        '
        Me.chkCheckAll.AutoSize = True
        Me.chkCheckAll.Location = New System.Drawing.Point(93, 16)
        Me.chkCheckAll.Name = "chkCheckAll"
        Me.chkCheckAll.Size = New System.Drawing.Size(48, 16)
        Me.chkCheckAll.TabIndex = 1
        Me.chkCheckAll.Text = "全选"
        Me.chkCheckAll.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblStatus.Location = New System.Drawing.Point(59, 389)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblStatus.Size = New System.Drawing.Size(729, 12)
        Me.lblStatus.TabIndex = 13
        Me.lblStatus.Text = "状态"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(147, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(617, 12)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "软件检测思路是先分享，再查看，查看不到就是有违规的，所以，有时候会检测不出来，因为不是马上被检测到违规"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 597)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.chkCheckAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVerifyReport)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.tvDirectoryInfo)
        Me.DoubleBuffered = True
        Me.Name = "FrmMain"
        Me.Text = "网盘违规文件检测姬 By 胖头鱼煲汤好好次 Q2287190283"
        Me.cmsDirectoryInfo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogin As Button
    Friend WithEvents tvDirectoryInfo As TreeView
    Friend WithEvents cmsDirectoryInfo As ContextMenuStrip
    Friend WithEvents 检测ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtVerifyReport As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkCheckAll As CheckBox
    Friend WithEvents 分享ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label2 As Label
End Class
