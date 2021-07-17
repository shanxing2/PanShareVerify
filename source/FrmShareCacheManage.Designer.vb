<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmShareCacheManage
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvShareCacheInfo = New System.Windows.Forms.DataGridView()
        Me.cmsShareData = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.删除选中ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbErrorNo = New System.Windows.Forms.ComboBox()
        Me.btnDeleteByErrorNo = New System.Windows.Forms.Button()
        Me.cmbErrorDescription = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDeleteByErrorNoAll = New System.Windows.Forms.Button()
        CType(Me.dgvShareCacheInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsShareData.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 501)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(281, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "合理使用缓存能提高检测速度并且减少分享次数消耗"
        '
        'dgvShareCacheInfo
        '
        Me.dgvShareCacheInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShareCacheInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShareCacheInfo.ContextMenuStrip = Me.cmsShareData
        Me.dgvShareCacheInfo.Location = New System.Drawing.Point(12, 38)
        Me.dgvShareCacheInfo.Name = "dgvShareCacheInfo"
        Me.dgvShareCacheInfo.RowTemplate.Height = 23
        Me.dgvShareCacheInfo.Size = New System.Drawing.Size(810, 460)
        Me.dgvShareCacheInfo.TabIndex = 16
        '
        'cmsShareData
        '
        Me.cmsShareData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.删除选中ToolStripMenuItem})
        Me.cmsShareData.Name = "cmsShareData"
        Me.cmsShareData.Size = New System.Drawing.Size(125, 26)
        '
        '删除选中ToolStripMenuItem
        '
        Me.删除选中ToolStripMenuItem.Name = "删除选中ToolStripMenuItem"
        Me.删除选中ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.删除选中ToolStripMenuItem.Text = "删除选中"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "错误代码："
        '
        'cmbErrorNo
        '
        Me.cmbErrorNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbErrorNo.FormattingEnabled = True
        Me.cmbErrorNo.Location = New System.Drawing.Point(70, 12)
        Me.cmbErrorNo.Name = "cmbErrorNo"
        Me.cmbErrorNo.Size = New System.Drawing.Size(121, 20)
        Me.cmbErrorNo.TabIndex = 21
        '
        'btnDeleteByErrorNo
        '
        Me.btnDeleteByErrorNo.Location = New System.Drawing.Point(394, 10)
        Me.btnDeleteByErrorNo.Name = "btnDeleteByErrorNo"
        Me.btnDeleteByErrorNo.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteByErrorNo.TabIndex = 22
        Me.btnDeleteByErrorNo.Text = "删除"
        Me.btnDeleteByErrorNo.UseVisualStyleBackColor = True
        '
        'cmbErrorDescription
        '
        Me.cmbErrorDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbErrorDescription.FormattingEnabled = True
        Me.cmbErrorDescription.Location = New System.Drawing.Point(267, 12)
        Me.cmbErrorDescription.Name = "cmbErrorDescription"
        Me.cmbErrorDescription.Size = New System.Drawing.Size(121, 20)
        Me.cmbErrorDescription.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(207, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "错误描述："
        '
        'btnDeleteByErrorNoAll
        '
        Me.btnDeleteByErrorNoAll.Location = New System.Drawing.Point(475, 9)
        Me.btnDeleteByErrorNoAll.Name = "btnDeleteByErrorNoAll"
        Me.btnDeleteByErrorNoAll.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteByErrorNoAll.TabIndex = 25
        Me.btnDeleteByErrorNoAll.Text = "全部删除"
        Me.btnDeleteByErrorNoAll.UseVisualStyleBackColor = True
        '
        'FrmShareCacheManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 522)
        Me.Controls.Add(Me.btnDeleteByErrorNoAll)
        Me.Controls.Add(Me.cmbErrorDescription)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnDeleteByErrorNo)
        Me.Controls.Add(Me.cmbErrorNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvShareCacheInfo)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FrmShareCacheManage"
        Me.Text = "分享缓存管理器"
        CType(Me.dgvShareCacheInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsShareData.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents dgvShareCacheInfo As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbErrorNo As ComboBox
    Friend WithEvents btnDeleteByErrorNo As Button
    Friend WithEvents cmbErrorDescription As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnDeleteByErrorNoAll As Button
    Friend WithEvents cmsShareData As ContextMenuStrip
    Friend WithEvents 删除选中ToolStripMenuItem As ToolStripMenuItem
End Class
